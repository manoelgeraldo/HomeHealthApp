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
        Task<PacienteViewModel> AdicionarPacienteAsync(PacienteViewModel novoPaciente);
        Task<PacienteViewModel> EditarPacienteAsync(PacienteViewModel pacienteEditado);
        Task<PacienteViewModel> ObterPacienteAsync(string cpf);
        Task<IEnumerable<PacienteViewModel>> ObterPacientesAsync();
    }
} 
