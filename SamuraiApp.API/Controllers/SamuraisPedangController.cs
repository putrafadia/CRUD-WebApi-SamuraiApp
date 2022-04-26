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
    public class SamuraisPedangController : ControllerBase
    {
        private readonly ISamuraiPedang _samuraispedang;
        private readonly IMapper _mapper;
        public SamuraisPedangController(ISamuraiPedang samuraispedang, IMapper mapper)
        {
            _samuraispedang = samuraispedang;
            _mapper = mapper;
        }

        // GET: api/<SamuraisController>
        [HttpGet]
        public async Task<IEnumerable<SamuraiPedangDTO>> Get()
        {
            var result = await _samuraispedang.GetAll();
            var output = _mapper.Map<IEnumerable<SamuraiPedangDTO>>(result);
            return output;
        }

        // GET api/<SamuraisController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SamuraiPedangDTO>> GetById(int id)
        {
            var result = await _samuraispedang.GetById(id);
            var output = _mapper.Map<SamuraiPedangDTO>(result);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(output);
            }
                
        }


        // POST api/<SamuraisController>
        [HttpPost]
        public async Task<ActionResult<SamuraiPedangDTO>> Post(SamuraiPedangCreateDTO samuraiPedangCreateDTO)
        {
            try
            {
                /*
                await _samurais.Insert(samurai);
                return CreatedAtAction("GetById", new {id=samurai.Id}, samurai);*/
                var newSamurai = _mapper.Map<Samurai>(samuraiPedangCreateDTO);
                var result = await _samuraispedang.Insert(newSamurai);
                var SamuraiPedangDTO = _mapper.Map<SamuraiPedangDTO>(result);
                return CreatedAtAction("GetById", new { id = result.Id }, SamuraiPedangDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }

        
    }
}
