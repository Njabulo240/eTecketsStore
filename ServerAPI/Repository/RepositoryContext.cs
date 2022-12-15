using Microsoft.EntityFrameworkCore;
using ServerAPI.Entities.Models;

namespace ServerAPI.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

    modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
    modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);

    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<LoginModel>().HasData(new LoginModel
        {
            Id = 1,
            UserName = "johndoe",
            Password = "def@123"
        });


     modelBuilder.Entity<UserModel>().HasData(new UserModel
        { 
          Id = 1,
          Username="Njabu", 
          Password="qwerty24", 
          EmailAddress="njeb@gmail.com", 
          Role="Admin", 
          Surname="Mamba",
          GivenName="Njebs"
        });




        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<LoginModel> LoginModels { get; set; }
        public DbSet<UserModel> UserModels { get; set; }

    }
}