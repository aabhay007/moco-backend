using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moco_backend.Data;
using moco_backend.Models;

namespace moco_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly NeonDbContext _context;
        public DemoController(NeonDbContext context)
        {
            _context = context;
        }
      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DummyTable>>> GetDummyTables()
        {
            return await _context.DummyTables.ToListAsync();
        }
    }
}
