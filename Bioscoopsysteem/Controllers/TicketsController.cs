using Bioscoopsysteem.Data;
using Bioscoopsysteem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bioscoopsysteem.Controllers
{
    public class TicketsController : Controller
    {

        private readonly BioscoopsysteemContext _context;

        public TicketsController(BioscoopsysteemContext context)
        {
            _context = context;
        }
        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tickets.ToListAsync());
        }

        // GET: Tickets/Create
        public async Task<IActionResult> Create(int? showId)
        {
            var tariffs = await _context.Tariffs.ToListAsync();
            ViewBag.tariffs = tariffs;

            var arrangements = await _context.Arrangements.ToListAsync();
            ViewBag.arrangements = arrangements;
            return View();
        }

        // POST: Ticket/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketId,Date_sold,CustomerId,ShowId,SeatId,TariffId,ArrangementId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = ticket.TicketId});
            }
         
            var tariffs = await _context.Tariffs.ToListAsync();
            ViewBag.tariffs = tariffs;

            var arrangements = await _context.Arrangements.ToListAsync();
            ViewBag.arrangements = arrangements;
            return View(ticket);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.Show)
                .Include(t => t.Show.Movie)
                .Include(t => t.Tariff)
                .Include(t => t.Arrangement)
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (ticket == null)
            {
                return NotFound();
            }

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            string qrText = ticket.TicketId + "@" + ticket.ShowId;
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(30);
            ViewBag.QRCode = BitmapToBytes(qrCodeImage);

            return View(ticket);
        }

        private static Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
