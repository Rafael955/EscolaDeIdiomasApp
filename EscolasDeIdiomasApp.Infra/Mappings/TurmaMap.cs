using EscolaDeIdiomasApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolasDeIdiomasApp.Infra.Mappings
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.ToTable("TURMA");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("ID");

            builder.Property(u => u.Numero)
                .HasColumnName("NUMERO")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(u => u.Ano)
                .HasColumnName("ANO")
                .IsRequired();

            builder.Property(u => u.NivelTurma)
               .HasColumnName("NIVEL_TURMA")
               .IsRequired();

            //criando um índice para definir o campo 'Numero' como único na tabela
            builder.HasIndex(p => p.Numero).IsUnique();
        }
    }
}
