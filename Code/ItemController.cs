using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_295.Models;

namespace WarehouseAPI.Controllers
{
    /// <summary>
    /// Controller für die Item-Ressource
    /// </summary>
    [Route("api/items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly WarehouseContext _context;

        public ItemController(WarehouseContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        
        /// <summary>
        /// Gibt alle Items zurück
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllItems()
        {
            var items = await _context.Items.ToListAsync();
            return Ok(items);
        }

        
        /// <summary>
        /// Gibt ein Item anhand der ID zurück
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        
        /// <summary>
        /// Erstellt ein neues Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin,WarehouseManager")] // Nur Admins und WareHouseManager können neue Items erstellen
        public async Task<ActionResult> CreateItem([FromBody] Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        
        /// <summary>
        /// Aktualisiert ein Item anhand der ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,WarehouseManager")] // Nur Admins und WareHouseManager können Items aktualisieren
        public async Task<ActionResult> UpdateItem(int id, [FromBody] Item item)
        {
            if (id != item.Id) return BadRequest();

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Items.Any(p => p.Id == id)) return NotFound();
                throw;
            }

            return NoContent();
        }

       
        /// <summary>
        /// Löscht ein Item anhand der ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // Nur Admins können Items löschen
        public async Task<ActionResult> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return NotFound();

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
