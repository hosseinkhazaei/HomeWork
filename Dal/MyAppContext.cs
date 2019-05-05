using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entites;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Dal
{
    public class MyAppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;initial catalog=MyProject;integrated security=true; ");
        }
        public override int SaveChanges()
        {
            ChangeArbicALf();
            return base.SaveChanges();

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<JobData> JobDatas { get; set; }
        private void ChangeArbicALf()
        {
            var entities = ChangeTracker.Entries().Where(c => c.State == EntityState.Added || c.State == EntityState.Modified);
            foreach (var item in entities)
            {
                var propertyFilds = item.Entity.GetType().GetProperties
                    (System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance
                    ).Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));



                foreach (var propertyInfo in propertyFilds)
                {
                    var propName = propertyInfo.Name;
                    var OldValue = GetPropValue(item.Entity, propName);
                    if (OldValue != null)
                    {
                        var NewValue = OldValue.ToString().Replace("س", "ص").Replace("خ", "ب");
                        if (NewValue == OldValue.ToString()) continue;
                        setPropValue(item.Entity, propName, NewValue);
                    }
                }

            }
        }
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
        public static void setPropValue(object src, string propName, string value)
        {
            src.GetType().GetProperty(propName).SetValue(src, value, null);
        }

    }

}
