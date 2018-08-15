namespace arkano.data.daccess.Context
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using arkano.common.domain;
    using Microsoft.EntityFrameworkCore;

    // TODO: See why namespace, class and methods are being underlined
    public class ArkanoEfContext : DbContext
    {

        public virtual DbSet<DummyTestModel> DummyTestModels { get; set; }

        public virtual DbSet<OtroDummyTestModel> OtroDummyTestModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: See were this should be taken I gues from Tenant but I'm not sure
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS17;Persist Security Info=True;User ID=sa;Password=XxXxX;Initial Catalog=DummyTestDb");

            // This enable lazyLoad of navigation properties. Navigation properties must be set as virtual in order to get it working
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DummyTestModel>();
            modelBuilder.Entity<OtroDummyTestModel>();
            modelBuilder.Entity<Student>();
            modelBuilder.Entity<Course>();
        }
    }
}
