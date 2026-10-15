using AutoMapper;
using E_COMMERCE_MANAGEMENT.DTOs.Order;
using E_COMMERCE_MANAGEMENT.DTOs.Product;
using E_COMMERCE_MANAGEMENT.Model;
using E_COMMERCE_MANAGEMENT.UnitOfWorkkk;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_COMMERCE_MANAGEMENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesOrderController : ControllerBase
    {
        private readonly IUnitOWork _repo;
        private readonly IMapper _map;
        public ValuesOrderController(IUnitOWork unitOWork, IMapper mapper)
        {
            _repo = unitOWork;
            _map = mapper;

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Entar Data");
            }
            var x = _map.Map<Order>(dto);
            await _repo.orde.Create(x);
            await _repo.SaveChangeAsync();
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int id, string  Status)
        {
            var x = await _repo.orde.GeetById(id);
            if(x.Status!= "Pending"&&x.Status!= "Completed"&&x.Status!= "Cancelled")
            {
                return BadRequest("The Status Must Be Pending Or Completed Or Completed");
            }
            if (x == null)
            {
                return NotFound();
            }
            x.Status = Status;
            await _repo.SaveChangeAsync();
            return Ok();
        }
        [HttpGet("TotalAmount")]
        public async Task<IActionResult> TotalAmount(int id) 
        {

            var x =await _repo.orde.GetOrder(id);
            return Ok(x);





        }

        [HttpGet("Revenio")]
        public async Task<IActionResult> TotalAmouReveniont( )
        {

            var x = await _repo.orde.Revenio();
            return Ok(x);





        }


    }
}
