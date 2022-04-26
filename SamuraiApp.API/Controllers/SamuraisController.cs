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
    public class SamuraisController : ControllerBase
    {
        private readonly ISamurai _samurais;
        private readonly IMapper _mapper;
        public SamuraisController(ISamurai samurais, IMapper mapper)
        {
            _samurais = samurais;
            _mapper = mapper;
        }

        // GET: api/<SamuraisController>
        [HttpGet]
        public async Task<IEnumerable<SamuraiDTO>> Get()
        {
           /* List<SamuraiDTO> samuraiDTOs = new List<SamuraiDTO>();
            var Results = await _samurais.GetAll();
            foreach (var result in Results)
            {
                samuraiDTOs.Add(new SamuraiDTO {
                    Id = result.Id,
                    Name = result.Name,
                });
            }
            return samuraiDTOs;*/
            var result = await _samurais.GetAll();
            var output = _mapper.Map<IEnumerable<SamuraiDTO>>(result);
            return output;
        }

        // GET api/<SamuraisController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SamuraiDTO>> GetById(int id)
        {
            var result = await _samurais.GetById(id);
            var output = _mapper.Map<SamuraiDTO>(result);
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
        public async Task<ActionResult<SamuraiDTO>> Post(SamuraiCreateDTO samuraiCreateDTO)
        {
            try
            {
                /*
                await _samurais.Insert(samurai);
                return CreatedAtAction("GetById", new {id=samurai.Id}, samurai);*/
                var newSamurai = _mapper.Map<Samurai>(samuraiCreateDTO);
                var result = await _samurais.Insert(newSamurai);
                var samuraiDTO = _mapper.Map<SamuraiDTO>(result);
                return CreatedAtAction("GetById", new { id = result.Id }, samuraiDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }

        // PUT api/<SamuraisController>/5
      
        [HttpPut("{id}")]
        public async Task<ActionResult<SamuraiDTO>> Put(int id, SamuraiCreateDTO samuraiCreateDTO)
        {
            try
            {
                /*
                var result = await _samurais.Update(id, samurai);
                return CreatedAtAction("GetById", new { id = samurai.Id }, samurai);*/
                var updateSamurai = _mapper.Map<Samurai>(samuraiCreateDTO);
                var result = await _samurais.Update(id,updateSamurai);
                var samuraiDTO = _mapper.Map<SamuraiDTO>(result);
                return Ok(samuraiDTO);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<SamuraisController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _samurais.Delete(id);
                return Ok($"record deleted {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
