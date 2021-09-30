using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleMgt.Models;
using VehicleMgt.ViewModels;

namespace VehicleMgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly VFactoryDBContext _context;

        public VehiclesController(VFactoryDBContext context)
        {
            _context = context;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IVehicles>>> GetVehicles()
        {

            return await (from e in _context.Vehicles
                          join p in _context.ConfigurationValue
                          on e.Year equals p.Id
                          join s in _context.ConfigurationValue
                          on e.Status equals s.Id
                          //join t in db.SalesTerritories
                          //on s.TerritoryID equals t.TerritoryID
                          //where t.CountryRegionCode == "CA"
                          select new VVehicles
                          {
                              Id = e.Id ,
                              Colour = e.Colour,
                              ModelId = e.ModelId,
                              Status = e.Status,
                              Year = e.Year,
                              ModelName = e.Model.ModelName,
                              YearCode = p.Text,
                              StatusCode = s.Text,
                              
                          }).ToListAsync();


            //return await _context.Vehicles
            //.Join(_context.ConfigurationValue,
            //      p => p.Year,
            //      e => e.Id,
            //      (p, e) => new {
            //         Id  = p.Id,
            //          ModelId = p.ModelId,
            //          Year = p.Year,
            //          Status = p.Status,
            //          ModelName = p.Model.ModelName,
            //          YearCode = e.Text,

            //      }
            //      ).Join(_context.ConfigurationValue,
            //    o => o.Status,
            //    sal => sal.Id,
            //    (o, sal) => new {
            //        StatusCode = sal.Text
            //    }).Select(x=> new VVehicles { Id =, Colour = x.Colour, ModelId = x.ModelId, Status = x.Status, Year = x.Year, ModelName = x.Model.ModelName }).ToListAsync();
            //return await _context.Vehicles.Select(x => new VVehicles { Id = x.Id,Colour = x.Colour,ModelId = x.ModelId,Status= x.Status,Year=x.Year,ModelName = x.Model.ModelName  }).ToListAsync();
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicles>> GetVehicles(int id)
        {
            var vehicles = await _context.Vehicles.FindAsync(id);

            if (vehicles == null)
            {
                return NotFound();
            }

            return vehicles;
        }

        // PUT: api/Vehicles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicles(int id, Vehicles vehicles)
        {
            if (id != vehicles.Id)
            {
                return BadRequest();
            }

            _context.Entry(vehicles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehiclesExists(id))
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

        // POST: api/Vehicles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Vehicles>> PostVehicles(Vehicles vehicles)
        {
            _context.Vehicles.Add(vehicles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicles", new { id = vehicles.Id }, vehicles);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vehicles>> DeleteVehicles(int id)
        {
            var vehicles = await _context.Vehicles.FindAsync(id);
            if (vehicles == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicles);
            await _context.SaveChangesAsync();

            return vehicles;
        }

        private bool VehiclesExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }
}
