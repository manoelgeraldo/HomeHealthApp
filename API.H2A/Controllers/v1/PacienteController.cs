using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModels;

namespace API.H2A.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        /// <summary>
        /// Exibe todos os pacientes
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pacientes = await _pacienteService.ObterPacientesAsync();
            return StatusCode(StatusCodes.Status200OK, pacientes);
        }

        /// <summary>
        /// Exibe um paciente
        /// </summary>
        [HttpGet("{cpf}")]
        public async Task<IActionResult> Get(string cpf)
        {
            var paciente = await _pacienteService.ObterPacienteAsync(cpf);
            return StatusCode(StatusCodes.Status200OK, paciente);
        }

        /// <summary>
        /// Adiciona um paciente
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post(PacienteViewModel novoPaciente)
        {
            var paciente = await _pacienteService.AdicionarPacienteAsync(novoPaciente);
            return StatusCode(StatusCodes.Status201Created, paciente);
        }

        /// <summary>
        /// Edita um paciente
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Put(PacienteViewModel pacienteEditado)
        {
            pacienteEditado = await _pacienteService.EditarPacienteAsync(pacienteEditado);
            return StatusCode(StatusCodes.Status200OK, pacienteEditado);
        }
    }
}
