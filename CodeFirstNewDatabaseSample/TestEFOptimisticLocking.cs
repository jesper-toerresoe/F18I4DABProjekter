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

        public void OptimisticLockingClientWins()
        {
            using (var context = new BloggingContext())
            {
                var blog = context.Blogs.Find(1);
                blog.Name = "The New ADO.NET Blog Client Wins "+DateTime.Now;

                //Change the db behind the bag of the EF Context. Sents a SQL statement directly til RDBMS 
                context.Database.ExecuteSqlCommand(
                           "UPDATE dbo.Blogs SET Name = 'Blu Blu Blu' WHERE BlogId = 1");

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

        public void OptimisticLockingCustomRecoveryObject()
        {
            using (var context = new BloggingContext())
            {
                var blog = context.Blogs.Find(1);
                blog.Name = "The New ADO.NET Blog Obj" +DateTime.Now;

                //Change the db behind the bag of the EF Context. Sents a SQL statement directly til RDBMS 
                context.Database.ExecuteSqlCommand(
                           "UPDATE dbo.Blogs SET Name = 'Blo Blo Blo' WHERE BlogId = 1");

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

                        // Get the current entity values and the values in the database 
                        // as instances of the entity type 
                        var entry = ex.Entries.Single();
                        var databaseValues = entry.GetDatabaseValues();
                        var databaseValuesAsBlog = (Blog)databaseValues.ToObject();

                        // Choose an initial set of resolved values. In this case we 
                        // make the default be the values currently in the database. 
                        var resolvedValuesAsBlog = (Blog)databaseValues.ToObject();

                        // Have the user choose what the resolved values should be 
                        HaveUserResolveConcurrencyObject((Blog)entry.Entity,
                                                   databaseValuesAsBlog,
                                                   resolvedValuesAsBlog);

                        // Update the original values with the database values and 
                        // the current values with whatever the user choose. 
                        entry.OriginalValues.SetValues(databaseValues);
                        entry.CurrentValues.SetValues(resolvedValuesAsBlog);
                    }

                } while (saveFailed);
            }

        }
        public void HaveUserResolveConcurrencyObject(Blog entity,
                                                   Blog databaseValues,
                                                   Blog resolvedValues)
        {
            // Show the current, database, and resolved values to the user and have 
            // them update the resolved values to get the correct resolution. 
        }

        public void OptimisticLockingCustomRecoveryEntity()
        {
            using (var context = new BloggingContext())
            {
                var blog = context.Blogs.Find(1);
                blog.Name = "The New ADO.NET BlogCustom Recover" + DateTime.Now;

                //Change the db behind the bag of the EF Context. Sents a SQL statement directly til RDBMS 
                context.Database.ExecuteSqlCommand(
                           "UPDATE dbo.Blogs SET Name = 'Bli Bli Bli' WHERE BlogId = 1");

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

                        // Get the current entity values and the values in the database 
                        var entry = ex.Entries.Single();
                        var currentValues = entry.CurrentValues;
                        var databaseValues = entry.GetDatabaseValues();

                        // Choose an initial set of resolved values. In this case we 
                        // make the default be the values currently in the database. 
                        var resolvedValues = databaseValues.Clone();

                        // Have the user choose what the resolved values should be 
                        HaveUserResolveConcurrency(currentValues, databaseValues, resolvedValues);

                        // Update the original values with the database values and 
                        // the current values with whatever the user choose. 
                        entry.OriginalValues.SetValues(databaseValues);
                        entry.CurrentValues.SetValues(resolvedValues);
                    }
                } while (saveFailed);
            }
        }
        public void HaveUserResolveConcurrency(DbPropertyValues currentValues,
                                                   DbPropertyValues databaseValues,
                                                   DbPropertyValues resolvedValues)
        {
            // Show the current, database, and resolved values to the user and have 
            // them edit the resolved values to get the correct resolution. 
        }


    }
}
