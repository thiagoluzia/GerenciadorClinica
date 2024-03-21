﻿using GC.Core.Entityes;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GC.Infrastructure.Persistence
{
    public class DBClinicaContexto : DbContext 
    {
        public DBClinicaContexto(DbContextOptions<DBClinicaContexto> options) : base (options)
        {}


        public DbSet<Medico> Medico{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}