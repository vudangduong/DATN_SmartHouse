using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartHouse.Entity;

namespace SmartHouse.Controllers
{
    public class SupplierController : Controller
    {
        private readonly DBContext dbContext;

        public SupplierController(DBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<IActionResult> Index()
        {
            List<TbSupplier> suppliers = await dbContext.TbSuppliers.ToListAsync();
            return View(suppliers);
        }
        
    }
}
