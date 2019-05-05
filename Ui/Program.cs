using Dal;
using Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ui
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new MyAppContext();
            //Test01(ctx);
           // Person person = ctx.People.FirstOrDefault();
            //var per = ctx.People.FromSql("select * from People").ToList();
           // ctx.Database.ExecuteSqlCommand("delete from People");
            //ctx.People.Load();
            List<string> lists = new List<string>();
            lists.Add("FirstName");
            lists.Add("LastName");
            ctx.deleteAll();
            //Test01(ctx);
            //updateMethod(person, lists);

        }
        private static void Test01(MyAppContext ctx)
        {
            Person person = new Person
            {
                FirstName = "hossein",
                LastName = "khazaei"
            };
            JobData jobData = new JobData
            {
                JobTitle = "developer"
            };
            person.JobData = jobData;
            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine("JobData:" + ctx.Entry(jobData).State);
            ctx.Add(person);
            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine("JobData:" + ctx.Entry(jobData).State);
            ctx.SaveChanges();
            Console.WriteLine("Person:" + ctx.Entry(person).State);
            Console.WriteLine("JobData:" + ctx.Entry(jobData).State);
        }

        private static void updateMethod(Person person, List<string> lists)
        {
            var ctx = new MyAppContext();
            foreach (var item in lists)
            {
                ctx.Entry(person).Property(item).IsModified = true;
                Console.WriteLine("Person:" + ctx.Entry(person).State);
                Console.WriteLine(ctx.Entry(person).Property(item).IsModified.ToString());
            }
            person.FirstName = "حسین";
            person.LastName = "خزایی";
            ctx.People.Update(person);
            ctx.SaveChanges();
            Console.WriteLine("Person:" + ctx.Entry(person).State);

            Console.ReadLine();
        }
        
    }
}
