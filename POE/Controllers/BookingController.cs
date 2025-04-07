using CLDVapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CLDVapp.Controllers
{
    public class BookingController : Controller
    {
        private readonly DatabaseContext _context;
        public BookingController(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Booking = await _context.Booking.ToListAsync();
            return View(Booking);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Booking Booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Booking);
        }

        public async Task<IActionResult> Details(int? id)
        {
            var Booking = await _context.Booking.FirstOrDefaultAsync(m => m.BookingID == id);
            if (Booking == null)
            {
                return NotFound();
            }
            return View(Booking);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var Booking = await _context.Booking.FirstOrDefaultAsync(m => m.BookingID == id);

            {
                if (Booking == null)
                {
                    return NotFound();
                }
                return View(Booking);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var Booking = await _context.Booking.FindAsync(id);
            _context.Booking.Remove(Booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExist(int id)
        {
            return _context.Booking.Any(v => v.BookingID == id);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Booking = await _context.Booking.FindAsync(id);
            if (Booking == null)
            {
                return NotFound();
            }
            return View(Booking);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Booking Booking)
        {
            if (id != Booking.BookingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExist(Booking.BookingID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
                return RedirectToAction(nameof(Index));
            }
            return View(Booking);
        }
    }
}
