using CURDEx.Models;
using Microsoft.AspNetCore.Mvc;

namespace CURDEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        CompanyContext cc;
        public ProductAPIController(CompanyContext cc)
        {
            this.cc = cc;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var res = this.cc.Products.ToList();
            if (res == null)
                return NotFound("No Record Found!");
            return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult GetProducts(Int64 id)
        {
            var res = this.cc.Products.SingleOrDefault(p=>p.ProductID==id);
            if (res == null)
                return NotFound("No Record Found!");

            return Ok(res);
        }

        [HttpPost]
        public IActionResult Insert(Product prod)
        {
            try
            {
                this.cc.Products.Add(prod);
                this.cc.SaveChanges();
                //return Created();
                return Created("/productapi/insert",prod);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
