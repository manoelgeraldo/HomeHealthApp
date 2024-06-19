using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("PACIENTES");
            
            builder.HasKey(x => x.CPF);
            
            builder.Property(x => x.CPF)
                   .HasColumnName("CPF")
                   .HasMaxLength(14)
                   .IsFixedLength()
                   .IsRequired();

            builder.Property(x => x.Nome)
                   .HasColumnName("NOME")
                   .IsRequired();
            
            builder.Property(x => x.DataNascimento)
                   .HasColumnName("DATA_NASCIMENTO")
                   .HasConversion<DateOnlyConverter>()
                   .HasColumnType("date");
            
            builder.Property(x => x.Sexo)
                   .HasColumnName("SEXO")
                   .HasConversion
                   (
                     x => x.ToString(),
                     x => (EnumSexo)Enum.Parse(typeof(EnumSexo), x)
                   );
        }
    }
}
