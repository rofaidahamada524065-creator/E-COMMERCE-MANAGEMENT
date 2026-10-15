using AutoMapper;
using E_COMMERCE_MANAGEMENT.DTOs.Catigory;
using E_COMMERCE_MANAGEMENT.Model;
using E_COMMERCE_MANAGEMENT.UnitOfWorkkk;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace E_COMMERCE_MANAGEMENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOWork _repo;
        private readonly IMapper _map;
        public CategoryController(IUnitOWork unitOWork, IMapper mapper)
        {
            _repo = unitOWork;
            _map = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var x = await _repo.catigory.GetAll();
            var list = _map.Map<List<categoryDTO>>(x);
            return Ok(list);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUpdateCatigory dto)
        {
            if (dto == null)
            {
                return BadRequest("Entar Data");
            }
            var x = _map.Map<Category>(dto);
            await _repo.catigory.Create(x);
            await _repo.SaveChangeAsync();
            return Ok();
        }


       
            
            
           
    }
}
