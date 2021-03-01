using Microsoft.EntityFrameworkCore;
using Minha1Conexao.Domain;

namespace Minha1Conexao.Data.Map
{
    public class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professor");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(x => x.Email)
                            .HasColumnType("varchar(50)")
                            .IsRequired();

        }
    }
}
