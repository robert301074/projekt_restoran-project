using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projekt_restoran.DTOs;
using projekt_restoran.Mappers;
using projekt_restoran.Models;

namespace projekt_restoran.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly DataContext _context;

        public InvoicesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOs.InvoiceDTO>>> GetInvoices()
        {
            var invoices = await _context.Invoices
                .Include(i => i.Menuitems)
                .ToListAsync();

            return Ok(invoices.Select(invoice => invoice.ToInvoiceDTO()).ToList());
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOs.InvoiceDetailsDTO>> GetInvoice(int id)
        {
            var invoice = await _context.Invoices
                .Include(i => i.Menuitems)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (invoice == null)
            {
                return NotFound();
            }

            var invoiceDetailsDTO = new InvoiceDetailsDTO
            {
                Id = invoice.Id,
                UserId = invoice.UserId,
                TableId = invoice.TableId,
                MenuItems = invoice.Menuitems.Select(mi => new MenuItemDTO
                {
                    Id = mi.Id,
                    Name = mi.Name,
                    Price = mi.Price
                }).ToList()
            };

            return Ok(invoiceDetailsDTO);
        }

        // PUT: api/Invoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, DTOs.InvoiceUpdateDTO invoiceDto)
        {
            if (id != invoiceDto.Id)
            {
                return BadRequest();
            }

            var invoice = await _context.Invoices
                .Include(i => i.Menuitems)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (invoice == null)
            {
                return NotFound();
            }
            invoice.UserId = invoiceDto.UserId;
            invoice.TableId = invoiceDto.TableId;

            var menuItems = await _context.MenuItems
                .Where(mi => invoiceDto.MenuItemsIds.Contains(mi.Id))
                .ToListAsync();

            invoice.Menuitems = menuItems;

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }

        // POST: api/Invoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(DTOs.InvoiceCreateDTO invoiceDTO)
        {
            var invoice = new Invoice
            {
                UserId = invoiceDTO.UserId,
                TableId = invoiceDTO.TableId
            };

            // Fetch menu items by their IDs
            var menuItems = await _context.MenuItems
                .Where(mi => invoiceDTO.MenuItemsIds.Contains(mi.Id))
                .ToListAsync();

            // Assign menu items to the invoice
            invoice.Menuitems = menuItems;

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInvoice), new { id = invoice.Id }, invoice);
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}
