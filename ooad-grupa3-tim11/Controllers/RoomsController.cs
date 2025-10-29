using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ooad_grupa3_tim11.Data;
using ooad_grupa3_tim11.Models;
using System.Diagnostics;
using Newtonsoft.Json;


namespace ooad_grupa3_tim11.Controllers
{
    public class RoomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Room.Include(r => r.Hotel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .Include(r => r.Hotel)
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            ViewData["HotelId"] = new SelectList(_context.Hotel, "HotelId", "HotelId");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        public async Task<IActionResult> Create([Bind("RoomId,AccommodationType,HotelId,BestOffer,Description,Picture,Price")] Room room)
        {
            var hotel = await _context.Hotel
            .Include(h => h.Location) // Include the Location related to the Hotel
            .FirstOrDefaultAsync(h => h.HotelId == room.HotelId);
            if (hotel == null)
            {
                ModelState.AddModelError("HotelId", "Invalid HotelId");
                return View(room);
            }

            // Poveži hotel sa sobom
            room.Hotel = hotel;

            Debug.WriteLine($"New Room created: {JsonConvert.SerializeObject(room)}");
            if (true)
                {
                    _context.Add(room);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }            
               
            ViewData["HotelId"] = new SelectList(_context.Hotel, "HotelId", "HotelId", room.HotelId);

            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    Debug.WriteLine($"Property: {state.Key} Error: {error.ErrorMessage}");
                }
            }
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["HotelId"] = new SelectList(_context.Hotel, "HotelId", "HotelId", room.HotelId);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomId,AccommodationType,HotelId,BestOffer,Description,Picture,Price")] Room room)
        {
            if (id != room.RoomId)
            {
                return NotFound();
            }
            var hotel = await _context.Hotel
            .Include(h => h.Location) // Include the Location related to the Hotel
            .FirstOrDefaultAsync(h => h.HotelId == room.HotelId);
            if (hotel == null)
            {
                ModelState.AddModelError("HotelId", "Invalid HotelId");
                return View(room);
            }

            // Poveži hotel sa sobom
            room.Hotel = hotel;

            if (true)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.RoomId))
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
            ViewData["HotelId"] = new SelectList(_context.Hotel, "HotelId", "HotelId", room.HotelId);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Room
                .Include(r => r.Hotel)
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Room.FindAsync(id);
            if (room != null)
            {
                _context.Room.Remove(room);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.RoomId == id);
        }

        public async Task<IActionResult> HomePage(string searchString, int? cityId, decimal? minPrice, decimal? maxPrice, AccommodationEnum? accommodationType)
        {
            var rooms = _context.Room.Include(r => r.Hotel).AsQueryable();

            // Apply city filter
            if (cityId.HasValue)
            {
                rooms = rooms.Where(r => r.Hotel.LocationId == cityId);
            }

            // Apply price range filter
            if (minPrice.HasValue)
            {
                rooms = rooms.Where(r => r.Price >= minPrice);
            }

            if (maxPrice.HasValue)
            {
                rooms = rooms.Where(r => r.Price <= maxPrice);
            }

            // Apply accommodation type filter
            if (accommodationType.HasValue)
            {
                rooms = rooms.Where(r => r.AccommodationType == accommodationType);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                rooms = rooms.Where(r => r.Description.Contains(searchString) || r.Hotel.Name.Contains(searchString));
            }

            var viewModel = new HomeFiltersViewModel
        {
            Cities = await _context.Location.ToListAsync(), // Assuming Location is your model for cities
            MinPrice = await _context.Room.MinAsync(r => r.Price),
            MaxPrice = await _context.Room.MaxAsync(r => r.Price)
        };

            return View((viewModel, await rooms.ToListAsync()));
        }
    }
}
