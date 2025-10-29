using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ooad_grupa3_tim11.Data;
using ooad_grupa3_tim11.Models;

namespace ooad_grupa3_tim11.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public ReservationsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var reservations = _context.Reservation
                .Where(r => r.RegisteredUserId == user.Id)
                .Include(r => r.Room)
                .ToList();
            return View(reservations);

            var applicationDbContext = _context.Reservation.Include(r => r.Room);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create(int? roomId)
        {
            Room selectedRoom = null;

            if (roomId.HasValue)
            {
                selectedRoom = _context.Room
                    .Include(r => r.Hotel)
                    .FirstOrDefault(r => r.RoomId == roomId.Value);
            }

            ViewBag.SelectedRoom = selectedRoom;
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId");
            return View(new Reservation { RoomId = roomId.GetValueOrDefault() });
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationId,StartDate,EndDate,Price,RoomId,RegisteredUserId")] Reservation reservation, string fullName)
        {
            var userEmail = User.Identity.Name;
            if (userEmail == null)
            {
                return Unauthorized();
            }

            var registeredUser = await _context.RegisteredUser.FirstOrDefaultAsync(u => u.Email == userEmail);

         
            reservation.RegisteredUser = registeredUser;

            //if (ModelState.IsValid){}
            var selectedRoom1 = await _context.Room
        .FirstOrDefaultAsync(r => r.RoomId == reservation.RoomId);

            if (selectedRoom1 == null)
            {
                // Handle the case where the room is not found
                return NotFound();
            }

            // Set the reservation price to the price of the selected room
            reservation.Price = selectedRoom1.Price; // Assuming Price is a property of Room

            _context.Reservation.Add(reservation);
            await _context.SaveChangesAsync();

            //TempData["Message"] = $"Reservation created successfully: {userEmail} {fullName} {reservation.RoomId}";
            return RedirectToAction(nameof(Index));


            var selectedRoom = _context.Room
                .Include(r => r.Hotel)
                .FirstOrDefault(r => r.RoomId == reservation.RoomId);

            ViewBag.SelectedRoom = selectedRoom;
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId", reservation.RoomId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId", reservation.RoomId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationId,StartDate,EndDate,Price,RoomId")] Reservation reservation)
        {
            if (id != reservation.ReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ReservationId))
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
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId", reservation.RoomId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservation.Remove(reservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservation.Any(e => e.ReservationId == id);
        }
    }
}
