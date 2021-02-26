﻿using Microsoft.EntityFrameworkCore;
using Minha1Conexao.Data.Map;
using Minha1Conexao.Domain;
using Minha1Conexao.Domain.Model;
using System;

namespace Minha1Conexao.Data
{
    public class Context : DbContext
    {
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<TurmaProfessor> TurmaProfessor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=VAIO-MARCELO\\SQLEXPRESS; Database=Minha1Conexao; Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new ProfessorMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new TurmaProfessorMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
