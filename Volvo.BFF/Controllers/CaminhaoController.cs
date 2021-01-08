using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Volvo.BFF.Models;
using Volvo.BFF.Services;

namespace Volvo.BFF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaminhaoController : ControllerBase
    {
        private readonly ILogger<CaminhaoController> _logger;
        private readonly ICaminhaoService _caminhaoService;

        public CaminhaoController(ILogger<CaminhaoController> logger, ICaminhaoService caminhaoService)
        {
            _logger = logger;
            _caminhaoService = caminhaoService;
        }

        [HttpGet("{id}")]
        public async Task<Caminhao> Get(int id)
        {
            return await _caminhaoService.Get(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Caminhao>> Get()
        {
            return await _caminhaoService.Get();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Caminhao caminhao)
        {
            try
            {
                Caminhao retorno = await _caminhaoService.Save(caminhao);
                return Ok(new { data = retorno });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { data = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { data = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Caminhao caminhao)
        {
            try
            {
                await _caminhaoService.Update(caminhao, id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { data = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { data = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _caminhaoService.Delete(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { data = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { data = ex.Message });
            }

        }
    }
}