using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstNewDatabase
{
    class TestEFOptimisticLocking
    {
        /// <summary>
        /// Examples from https://msdn.microsoft.com/en-us/library/jj592904(v=vs.113).aspx
        /// </summary>

        public void OptmisticLockingReload()
        {
            using (var context = new BloggingContext())
            {
                var blog = context.Blogs.Find(1); //Read DB entity into EF Context
                blog.Name = "The New ADO.NET Blog"; //Change the EF Context Entity

                //Change the db behind the bag of the EF Context. Sents a SQL statement directly til RDBMS 
                context.Database.ExecuteSqlCommand(
                           "UPDATE dbo.Blogs SET Name = 'Bla Bla Bla' WHERE BlogId = 1");
                bool saveFailed;
                do
                {
                    saveFailed = false;
                    
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;

                        //Update the values of the entity that failed to save from the store

                        ex.Entries.Single().Reload();
                    }
                    catch (DbUpdateException ex1)
                    {
                        saveFailed = true;
                        System.Console.WriteLine("I kill that dam'ed database: " + ex1.ToString());
                    }

                } while (saveFailed);
            }
        }

        public void optimisticLockingClientWins()
        {
            using (var context = new BloggingContext())
            {
                var blog = context.Blogs.Find(1);
                blog.Name = "The New ADO.NET Blog Client Wins "+DateTime.Now;

                bool saveFailed;
                do
                {
                    saveFailed = false;
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        saveFailed = true;

                        // Update original values from the database 
                        var entry = ex.Entries.Single();
                        entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                    }

                } while (saveFailed);
            }

        }
    }
}
