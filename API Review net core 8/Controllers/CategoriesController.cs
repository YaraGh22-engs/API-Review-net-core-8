using API_Review_net_core_8.Data;
using API_Review_net_core_8.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Review_net_core_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public CategoriesController(AppDbContext db)
        {
            _db = db;
        }

        private readonly AppDbContext _db;


        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var cats = await _db.Categories.ToListAsync();
            return Ok(cats);
        }
      [HttpPost]
        public async Task<IActionResult> AddCategory(string category)
        {
            Category c = new() { Name = category  };

            await _db.Categories.AddAsync(c);
            _db.SaveChanges();
            return Ok(c);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody]Category category)
        {
            var cat = await _db.Categories.SingleOrDefaultAsync(d=>d.Id ==category.Id);
            if (cat is null) return NotFound();
            cat.Name = category.Name;
            _db.SaveChanges();
            return Ok(cat);
        }
        [HttpDelete("id")]
        public async Task<IActionResult> RemoveCategory( int id)
        {
            var c = await _db.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (c is null) return NotFound();
            _db.Categories.Remove(c);
            _db.SaveChanges();
            return Ok(c);

        }
    }
}
