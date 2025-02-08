using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projekt_restoran;
using projekt_restoran.DTOs.Table;
using projekt_restoran.DTOs.User;
using projekt_restoran.Mappers;
using projekt_restoran.Models;

namespace projekt_restoran.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly DataContext _context;

        public TablesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Tables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableDTO>>> GetTables(int page = 1, int pageSize = 5)
        {
            List<Table> table = await _context.Tables
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();

           // List<Table> table= await _context.Tables.ToListAsync();
            return table.Select(u => u.ToTableDTO()).ToList();
        }

        // GET: api/Tables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TableDetailsDTO>> GetTable(int id)
        {
            //var table = await _context.Tables.FindAsync(id);
              var table = await _context.Tables.Include(t => t.Invoices).FirstOrDefaultAsync(t => t.Id == id);



            if (table == null)
            {
                return NotFound();
            }

            return table.ToTableDetailDTO();
        }

        // PUT: api/Tables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTable(int id, TableUpdateDTO tableUpdate)
        {
            Table table = tableUpdate.ToTable();
            if (id != table.Id)
            {
                return BadRequest();
            }

            _context.Entry(table).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Table>> PostTable(TableCreateDTO tableDTO)
        {

            Table table= tableDTO.ToTable();
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTable", new { id = table.Id }, table);
        }

        // DELETE: api/Tables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TableExists(int id)
        {
            return _context.Tables.Any(e => e.Id == id);
        }
    }
}
