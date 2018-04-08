using System;
using System.Collections.Generic;
using System.Data.Entity;

using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstNewDatabase
{
    public class TestEFLoadings
    {
        /*
         * Eksempler fra https://msdn.microsoft.com/en-us/library/jj574232(v=vs.113).aspx
         */
        public void TestEagerlyLoading()
        {
            using (var context = new BloggingContext())
            {
                // Load all blogs and related posts 
                var blogs1 = context.Blogs
                                      .Include(b => b.Posts)
                                      .ToList();
                var emptyblogs = context.Blogs
                                      .Include(b => b.Posts);

                // Load one blogs and its related posts 
                var blog1 = context.Blogs
                                    .Where(b => b.Name == "ADO.NET Blog")
                                    .Include(b => b.Posts)
                                    .FirstOrDefault();

                // Load all blogs and related posts  
                // using a string to specify the relationship 
                var blogs2 = context.Blogs
                                      .Include("Posts")
                                      .ToList();

                // Load one blog and its related posts  
                // using a string to specify the relationship 
                var blog2 = context.Blogs
                                    .Where(b => b.Name == "ADO.NET Blog")
                                    .Include("Posts")
                                    .FirstOrDefault();
            }

        }
        public void TestEagerlyLoadingMultiple()
        {
            using (var context = new BloggingContext())
            {
                // Load all blogs, all related posts with all related comments
                var blogs1 = context.Blogs
                                   .Include(b => b.Posts.Select(p => p.Comments))
                                   .ToList();

                // Load all users their related Organization and Country
                var users1 = context.Users
                                    .Include("UsersOrg.OrgsCountry")
                                    .ToList();
                users1 = context.Users
                        .Include(u => u.UsersOrg.OrgsCountry)
                        .ToList();
                //users1 = context.Users
                //        .Include(u => u.UsersOrg.OrgsCountry.CountryName) //Fail with CountryName
                //        .ToList();

                // Load all blogs, all related posts, and all related comments  
                // using a string to specify the relationships 
                var blogs2 = context.Blogs
                                   .Include("Posts.Comments")
                                   .ToList();

                // Load all users their related profiles, and related avatar  
                // using a string to specify the relationships 
                var users2 = context.Users
                                    .Include("UsersOrg.OrgsCountry")
                                    .ToList();
            }
        }

        public void TestExplicitlyLoading()
        {
            using (var context = new BloggingContext())
            {
                var post = context.Posts.Find(2);

                // Load the blog related to a given post 
                context.Entry(post).Reference(p => p.Blog).Load();

                // Load the blog related to a given post using a string  
                context.Entry(post).Reference("Blog").Load();

                var blog = context.Blogs.Find(1);

                // Load the posts related to a given blog 
                context.Entry(blog).Collection(p => p.Posts).Load();

                // Load the posts related to a given blog  
                // using a string to specify the relationship 
                context.Entry(blog).Collection("Posts").Load();
            }

            using (var context = new BloggingContext())
            {
                var blog = context.Blogs.Find(1);

                // Load the posts with the 'entity-framework' tag related to a given blog 
                context.Entry(blog)
                    .Collection(b => b.Posts)
                    .Query()
                    .Where(p => p.Tags.Contains("entity-framework")).Load();


                // Load the posts with the 'entity-framework' tag related to a given blog  
                // using a string to specify the relationship  
                //context.Entry(blog)
                //   .Collection("Posts")
                //   .Query()
                //   .Where(p => p.Tags.Contains("entity-framework")).Load();
            }

            using (var context = new BloggingContext())
            {
                var blog = context.Blogs.Find(1);

                // Count how many posts the blog has  
                var postCount = context.Entry(blog)
                                      .Collection(b => b.Posts)
                                      .Query()
                                      .Count();
            }

        }
        public void TestLINQStatements()
        {

            using (var context = new BloggingContext())
            {
                //SELECT Users.Username,Organizations.OrganizationName,Countries.CountryName FROM Users
                //     INNER JOIN Organizations ON Users.UsersOrg_OrganizationId = Organizations.Organization
                //     INNER JOIN Countries ON Organizations.OrgsCountryId = Countries.CountryId
                context.Configuration.LazyLoadingEnabled = true;
                var query =
                    from user in context.Users
                    join org in context.Organizations on user.UsersOrgId equals org.OrganizationId
                    join country in context.Countries on org.OrgsCountryId equals country.CountryId
                    select new
                    {
                        Username = user.Username,
                        OrganizationName = org.OrganizationName,
                        CountryName = country.CountryName
                        //,CountryId = country.CountryId
                    };

                foreach (var userinfo in query)
                {
                    Console.WriteLine("Username: {0} OrganizationName: {1}  Country: {2}",
                        userinfo.CountryName,
                        userinfo.OrganizationName,
                        userinfo.CountryName);
                }

                var users = (from user in context.Users
                             .Include("UsersOrg.OrgsCountry")
                             select user).FirstOrDefault();
                //users = (from user in context.Users
                //             .Include("UsersOrg.OrgsCountry")
                //         select user);

                string lastname = "HKH";
                var usersQuery = context.Users
                    .Where(c => c.Username == lastname)
                    .Select(c => new
                    {
                        Username = c.Username,
                        Orgname = c.UsersOrg.OrganizationName
                    }).ToList();
            }
        }

        public void TestEFLazyLoading()
        {
            using (BloggingContext context = new BloggingContext())
            {
                // You do not have to set context.Configuration.LazyLoadingEnabled to true 
                // if you used the Entity Framework to generate the object layer.
                // The generated object context type sets lazy loading to true
                // in the constructor. 
                context.Configuration.LazyLoadingEnabled = true;

                // Display five blogs and select a blog
                var bloglist = context.Blogs.Take(5);
                foreach (var c in bloglist)
                    Console.WriteLine(c.BlogId + " : " + c.Name);

                Console.WriteLine("Select a Blog:");
                Int32 blogID = Convert.ToInt32(Console.ReadLine());

                // Get a specified user by contact name. 
                var specblog = context.Blogs.Where(c => c.BlogId == blogID).FirstOrDefault();

                // If lazy loading was not enabled no posts would be loaded for the blog.
                foreach (var post in specblog.Posts)
                {
                    Console.WriteLine("PostID: {0} Title: {1} ",
                        post.PostId, post.Title);
                }

                //Test same scenario but now with lazy loading disabled
                context.Configuration.LazyLoadingEnabled = false;
                Console.WriteLine("Select a Blog:");
                blogID = Convert.ToInt32(Console.ReadLine());

                // Get a specified user by contact name. 
                specblog = context.Blogs.Where(c => c.BlogId == blogID).FirstOrDefault();

                // Lazy loading is not enabled no posts will be loaded for the Blog,
                // what will happen now?
                foreach (var post in specblog.Posts)
                {
                    Console.WriteLine("PostID: {0} Title: {1} ",
                        post.PostId, post.Title);
                }

                context.Entry(specblog).Collection(p => p.Posts).Load();
            }
        }
    }
}


