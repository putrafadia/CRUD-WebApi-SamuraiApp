using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamuraiApp.API.DTO;
using SamuraiApp.Data.Interface;
using SamuraiApp.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SamuraiApp.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraisPedangElemenController : ControllerBase
    {
        private readonly ISamuraiPedangElemen _samuraispedang;
        private readonly IMapper _mapper;
        public SamuraisPedangElemenController(ISamuraiPedangElemen samuraispedang, IMapper mapper)
        {
            _samuraispedang = samuraispedang;
            _mapper = mapper;
        }

        // GET api/<SamuraisController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SamuraiPedangElemenDTO>> GetById(int id)
        {
            var result = await _samuraispedang.GetById(id);
            var output = _mapper.Map<SamuraiPedangElemenDTO>(result);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(output);
            }
                
        }



        
    }
}
