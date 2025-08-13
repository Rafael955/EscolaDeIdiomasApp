using EscolaDeIdiomasApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolasDeIdiomasApp.Infra.Mappings
{
    public class AlunoTurmasMap : IEntityTypeConfiguration<AlunoTurmas>
    {
        public void Configure(EntityTypeBuilder<AlunoTurmas> builder)
        {
            builder.ToTable("ALUNO_TURMA"); //nome da tabela

            //chave primária composta (2 campos)
            builder.HasKey(at => new { at.IdAluno, at.IdTurma });

            builder.Property(up => up.IdAluno)
                .HasColumnName("ALUNO_ID")
                .IsRequired();

            builder.Property(up => up.IdTurma)
                .HasColumnName("TURMA_ID")
                .IsRequired();

            //mapeamento da chave estrangeira para a entidade Aluno
            builder.HasOne(at => at.Aluno)
                .WithMany(a => a.AlunoTurmas) //Muitos para muitos
                .HasForeignKey(at => at.IdAluno);

            //mapeamento da chave estrangeira para a entidade Turma
            builder.HasOne(at => at.Turma)
                .WithMany(t => t.AlunoTurmas) //Muitos para muitos
                .HasForeignKey(up => up.IdTurma);
        }
    }
}
