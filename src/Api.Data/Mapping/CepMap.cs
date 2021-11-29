using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class CepMap : IEntityTypeConfiguration<CepEntity>
    {
        public void Configure(EntityTypeBuilder<CepEntity> builder)
        {
            builder.ToTable("Cep");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Cep);

            builder.HasOne(m => m.Municipio)
                .WithMany(c => c.Ceps);
        }
    }
}
