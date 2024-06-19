using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IPacienteService
    {
        Task<PacienteDTO> AdicionarPacienteAsync(PacienteDTO novoPaciente);
        Task<PacienteDTO> EditarPacienteAsync(PacienteDTO pacienteEditado);
        Task<PacienteDTO> ObterPacienteAsync(string cpf);
        Task<IEnumerable<PacienteDTO>> ObterPacientesAsync();
    }
} 
