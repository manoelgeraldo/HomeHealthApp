using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mappings
{
    public class PacienteMappingProfile : Profile
    {
        public PacienteMappingProfile()
        {
            CreateMap<PacienteDTO, Paciente>()
                .ForMember(x => x.DataNascimento, o => o.MapFrom(x => DateOnly.FromDateTime(x.DataNascimento)))
                .ReverseMap()
                .ForPath(x => x.DataNascimento, o => o.MapFrom(x => x.DataNascimento.ToDateTime(TimeOnly.MinValue)));
        }
    }
}
