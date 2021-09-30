using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleMgt.Models;
using Microsoft.EntityFrameworkCore;

namespace VehicleMgt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly VFactoryDBContext _context;

        public CommonController(VFactoryDBContext context)
        {
            _context = context;
        }

        [HttpGet("[action]/{name}")]
        public async Task<ActionResult<IEnumerable<ConfigurationValue>>> GetConfigValues(string name)
        {
            return await _context.ConfigurationValue.Where(x=>x.ParentId == (_context.Configuration.Where(y=> y.Name == name).FirstOrDefault()).Id.ToString()).ToListAsync();
        }
    }
}
