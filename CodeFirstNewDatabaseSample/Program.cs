using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstNewDatabase
{
    class Program
    {
        static void Main(string[] args)
        {

            TestEFOptimisticLocking locktest = new TestEFOptimisticLocking();
            //locktest.OptmisticLockingReload();
            //locktest.OptimisticLockingClientWins();
            //locktest.OptimisticLockingCustomRecoveryObject();
            //locktest.OptimisticLockingCustomRecoveryEntity();
            //TestEFLoadings tester = new TestEFLoadings();
            //tester.TestEagerlyLoading();
            //tester.TestEagerlyLoadingMultiple();
            //tester.TestExplicitlyLoading();
            //tester.TestLINQStatements();
            //tester.TestEFLazyLoading();
            using (var db = new BloggingContext())
            {
               
                // Create and save a new Blog 
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual List<Post> Posts { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

    }


    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        //public virtual List<string> Tags { get; set; }
        public string Tags { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public class Comment
    {
        public int CommentId { get; set; }
        public String Text { get; set; }
        public int FromPostId { get; set; }
        [ForeignKey("FromPostId")]
        public Post FromPost { get; set; }
    }

    public class User
    {
        [Key]
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public int UsersOrgId { get; set;}
        [ForeignKey("UsersOrgId")]
        public Organization UsersOrg { get; set; }
       
    }

    public class Organization
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }        
        public long OrgsCountryId { get; set; }
        [ForeignKey("OrgsCountryId")]
        public List<Country> Homelands { get; set; }
    }

    public class Country
    {
        public long CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public List<Organization> OrgsInCountry { get; set; }
    }

    public class BloggingContext : DbContext
    {
        //public BloggingContext()
        //    : base("name=HandIn2-2")
        //{
        //}
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Comment> Comments { get; set; }


        public BloggingContext()
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            this.Database.Log = s => System.Console.WriteLine(s);
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.DisplayName)
                .HasColumnName("display_name");
        }
    }
}