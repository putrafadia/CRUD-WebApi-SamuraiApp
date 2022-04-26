using AutoMapper;
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
    public class PedangElemenController : ControllerBase
    {
        private readonly IPedangElemen _pedangs;
        private readonly IMapper _mapper;

        public PedangElemenController(IPedangElemen pedangs, IMapper mapper)
        {
            _pedangs = pedangs;
            _mapper = mapper;
        }

        // GET: api/<PedangsController>
        [HttpGet]
        public async Task<IEnumerable<PedangElemenDTO>> Get()
        {
            var result = await _pedangs.GetAll();
            var output = _mapper.Map<IEnumerable<PedangElemenDTO>>(result);
            return output;
        }

        // GET api/<PedangsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedangElemenDTO>> GetById(int id)
        {
            var result = await _pedangs.GetById(id);
            var output = _mapper.Map<PedangElemenDTO>(result);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(output);
            }
        }

        // POST api/<PedangsController>
        [HttpPost]
        public async Task<ActionResult<PedangElemenDTO>> Post(PedangElemenCreateDTO pedangElemenCreateDTO)
        {
            try
            {
                /*
                await _samurais.Insert(samurai);
                return CreatedAtAction("GetById", new {id=samurai.Id}, samurai);*/
                var newPedangElemen = _mapper.Map<Pedang>(pedangElemenCreateDTO);
                var result = await _pedangs.Insert(newPedangElemen);
                var PedangElemenDTO = _mapper.Map<PedangElemenDTO>(result);
                return CreatedAtAction("GetById", new { id = result.Id , }, PedangElemenDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

        }

        // PUT api/<PedangsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PedangElemenDTO>> Put(int id, PedangElemenUpdateDTO pedangElemenUpdateDTO)
        {
            try
            {
                var updatePedangElemen = _mapper.Map<Pedang>(pedangElemenUpdateDTO);
                var result = await _pedangs.Update(id, updatePedangElemen);
                var PedangElemenDTO = _mapper.Map<PedangElemenDTO>(result);
                return Ok(PedangElemenDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PedangsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _pedangs.Delete(id);
                return Ok($"record deleted {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    
}
