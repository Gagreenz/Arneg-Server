using Microsoft.AspNetCore.Mvc;
using Arneg_Server.Models;
using Arneg_Server.Models.DB;
using Arneg_Server.Dtos.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using AutoMapper;

namespace Arneg_Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMapper _mapper;
        ApplicationContext _context;
        public ProductController(ApplicationContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }
        //[Authorize]
        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody] ProductCreateDto pDto)
        {
            Product prod = new Product()
            {
                PhotoData = pDto.PhotoData,
                Title = pDto.Title,
                Description = pDto.Description,
                Price = pDto.Price
            };

            _context.Products.Add(prod);
            _context.SaveChanges();

            return Ok("Product created");
        }
        [HttpPut("Update")]
        public IActionResult Update(Guid id, ProductUpdateDto product)
        {
            var existingProduct = _context.Products.Where(p => p.Id == id).FirstOrDefault();

            if (existingProduct == null) BadRequest();

            _mapper.Map(product, existingProduct);
            _context.SaveChanges();

            return Ok();
        }
        [HttpGet("GetAll")]
        public ActionResult<List<Product>> GetAll()
        {
            var products = _context.Products.ToList();
            return products;
        }
        [HttpGet("GetById")]
        public ActionResult<Product> GetByID(Guid id)
        {
            if (id == null) return BadRequest("Wrong id.");

            Product product = _context.Products.Where(p => p.Id == id).FirstOrDefault();
            if(product == null) return NotFound();

            return Ok(product);
        }
    }
}
