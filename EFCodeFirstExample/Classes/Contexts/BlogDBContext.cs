using EFCodeFirstExample.Classes.Models.DC_Tables;
using EFCodeFirstExample.Classes.Models.JunctionTables;
using EFCodeFirstExample.Classes.Models.MainTables;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EFCodeFirstExample.Classes.Contexts
{
    [DbConfigurationType(typeof(BlogDBContextConfiguration))]
    public partial class BlogDbContext : DbContext
    {
        public BlogDbContext() : base("name=BlogDbContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

                #region SET Table Keys

                modelBuilder.Entity<Person>().HasKey(e => e.PersonId);
                modelBuilder.Entity<Address>().HasKey(e => e.AddressId);
                modelBuilder.Entity<Post>().HasKey(e => e.PostId);

                modelBuilder.Entity<PersonXPost>().HasKey(e => new { e.PersonId, e.PostId });

                modelBuilder.Entity<DcPostType>().HasKey(e => e.DcPostTypeId);
                
                #endregion

                #region SET Relations
                
                #region Person

                modelBuilder.Entity<Person>().HasRequired(person => person.Address)
                    .WithMany(address => address.Person)
                    .WillCascadeOnDelete(false);
                
                #endregion

                #region Post
               
                modelBuilder.Entity<Post>().HasRequired(post => post.DcPostType)
                    .WithMany(dcPostType => dcPostType.Post)
                    .WillCascadeOnDelete(false);
                
                #endregion

                #region PersonXPost
         
                modelBuilder.Entity<PersonXPost>().HasRequired(personXPost => personXPost.Person)
                    .WithMany(x => x.PersonXPost)
                    .WillCascadeOnDelete(false);

                modelBuilder.Entity<PersonXPost>().HasRequired(personXPost => personXPost.Post)
                    .WithMany(x => x.PersonXPost)
                    .WillCascadeOnDelete(false);
                
                #endregion

                #endregion
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("+++++ ERROR - Hiba! Hiba a kontextus felépítése közben! " +
                    "Hiba az Adatbázis Modell létrehozása közben! " +
                    $"\tContext Name: {nameof(BlogDbContext)}.\n\n" +
                    $"Exception Message: {ex.Message}");
            }
        }

        #region DbSets
       
        public DbSet<Person> Person { get; set; }
        
        public DbSet<Address> Address { get; set; }
        
        public DbSet<Post> Post { get; set; }
        
        public DbSet<PersonXPost> PersonXPost { get; set; }

        public DbSet<DcPostType> DcPostTypes { get; set; }
        
        #endregion
    }
}
