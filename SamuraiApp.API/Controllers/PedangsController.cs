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
    public class PedangsController : ControllerBase
    {
        private readonly IPedang _pedangs;
        private readonly IMapper _mapper;

        public PedangsController(IPedang pedangs, IMapper mapper)
        {
            _pedangs = pedangs;
            _mapper = mapper;
        }

        // GET: api/<PedangsController>
        [HttpGet]
        public async Task<IEnumerable<PedangDTO>> Get()
        {
            var result = await _pedangs.GetAll();
            var output = _mapper.Map<IEnumerable<PedangDTO>>(result);
            return output;
        }

        // GET api/<PedangsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedangDTO>> GetById(int id)
        {
            var result = await _pedangs.GetById(id);
            var output = _mapper.Map<PedangDTO>(result);
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
        public async Task<ActionResult<PedangDTO>> Post(PedangCreateDTO pedangCreateDTO)
        {
            try
            {
                /*
                await _samurais.Insert(samurai);
                return CreatedAtAction("GetById", new {id=samurai.Id}, samurai);*/
                var newPedang = _mapper.Map<Pedang>(pedangCreateDTO);
                var result = await _pedangs.Insert(newPedang);
                var pedangDTO = _mapper.Map<PedangDTO>(result);
                return CreatedAtAction("GetById", new { id = result.Id }, pedangDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

        }

        // PUT api/<PedangsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PedangDTO>> Put(int id, PedangUpdateDTO pedangUpdateDTO)
        {
            try
            {
                /*
                var result = await _samurais.Update(id, samurai);
                return CreatedAtAction("GetById", new { id = samurai.Id }, samurai);*/
                var updatePedang = _mapper.Map<Pedang>(pedangUpdateDTO);
                var result = await _pedangs.Update(id, updatePedang);
                var PedangDTO = _mapper.Map<PedangDTO>(result);
                return Ok(PedangDTO);
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
