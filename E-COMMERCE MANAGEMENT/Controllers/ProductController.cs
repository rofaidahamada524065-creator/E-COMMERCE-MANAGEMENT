using AutoMapper;
using E_COMMERCE_MANAGEMENT.DTOs.Catigory;
using E_COMMERCE_MANAGEMENT.DTOs.Product;
using E_COMMERCE_MANAGEMENT.Model;
using E_COMMERCE_MANAGEMENT.UnitOfWorkkk;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_COMMERCE_MANAGEMENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOWork _repo;
        private readonly IMapper _map;
        public ProductController(IUnitOWork unitOWork,IMapper mapper)
        {
            _repo = unitOWork;
            _map = mapper;
            
        }


        [HttpGet("Pagination")]
        public async Task<IActionResult> Pagination(int? catigorId, int page = 1, int pageSize = 1)
        {

            var x = await _repo.product.Pagination(catigorId, page, pageSize);
            var list = _map.Map<List<ProductDTO>>(x);
            return Ok(list);


        }

        [HttpGet("most_expensive")]
        public async Task<IActionResult> most_expensive(int catigorId)
        {

            var x = await _repo.product.most_expensive(catigorId);
            var list = _map.Map<List<ProductDTO>>(x);
            return Ok(list);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var x = await _repo.product.GeetById(id);
            if(x == null)
            {
                return NotFound();
            }
            var list = _map.Map<ProductDTO>(x);
            return Ok(list);


        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdatePruduct dto)
        {
            if (dto == null)
            {
                return BadRequest("Entar Data");
            }
            var x = _map.Map<Product>(dto);
            await _repo.product.Create(x);
            await _repo.SaveChangeAsync();
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int id,int stock)
        {
            var x = await _repo.product.GeetById(id);
            if (x == null)
            {
                return NotFound();
            }
            x.StockQuantaty = stock;
           await _repo.SaveChangeAsync();
            return Ok();
        }

        [HttpGet("SearchByName")]
        public async Task<IActionResult> SearchByName(string name)
        {
            var x = await _repo.product.SearchByName(name);
            var list = _map.Map<Product>(x);
            return Ok(list);
        }

    }
}
