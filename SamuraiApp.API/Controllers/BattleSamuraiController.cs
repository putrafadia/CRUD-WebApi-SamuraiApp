using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SamuraiApp.API.DTO;
using SamuraiApp.Data.Interface;
using SamuraiApp.Domain;

namespace SamuraiApp.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BattleSamuraiController : Controller
    {
        private readonly IBattleSamurai _battleSamurai;
        private readonly IMapper _mapper;

        public BattleSamuraiController(IBattleSamurai battleSamurai, IMapper mapper)
        {
            _battleSamurai = battleSamurai;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BattleSamuraiDTO>> Get()
        {
            var result = await _battleSamurai.GetAll();
            var output = _mapper.Map<IEnumerable<BattleSamuraiDTO>>(result);
            return output;
        }
    }
}