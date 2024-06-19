using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IPacienteRepository
    {
        Task<Paciente> AdicionarPacienteAsync(Paciente paciente);
        Task<Paciente> EditarPacienteAsync(Paciente paciente, Paciente pacienteEditado);
        Task<Paciente> ObterPacienteAsync(string cpf);
        Task<IEnumerable<Paciente>> ObterPacientesAsync();
    }
}
