using IndWalks.API.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace IndWalks.API.Data
{
    public class IndWalksDBContext : DbContext
    {
        public IndWalksDBContext(DbContextOptions<IndWalksDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        //Seeding Data Using EF
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Seed Defficulties
            var diffculties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id=Guid.Parse("736f1151-403e-499d-b38b-1c021f31cc86"),
                    Name="Easy"
                },
                new Difficulty()
                {
                    Id=Guid.Parse("678f796d-a48c-47cc-a9b7-891718324003"),
                    Name="Medium"
                },
                new Difficulty()
                {
                    Id=Guid.Parse("63c4329a-110e-42ba-9620-37e2a90704b3"),
                    Name="Hard"
                }
            };
            //Seed Diffculties to the Data Base
            modelBuilder.Entity<Difficulty>().HasData(diffculties);

            //Seeding Region
            var regions = new List<Region>()
            {
                new Region()
                {
                     Id =Guid.Parse("57b4e693-11d4-4220-a8c6-bcff4fc841f1"),
                     Code="Matheran",
                     Name="MTRN",
                     RegionImageUrl="AnyImage.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    Name = "Neral",
                    Code = "NRL",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Arebian Sea",
                    Code = "ARS",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Shivaji Maharaj Terminus",
                    Code = "CST",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Kandivali",
                    Code = "KAN",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Borivali",
                    Code = "BVI",
                    RegionImageUrl = null
                },
            };
            modelBuilder.Entity<Region>().HasData(regions);

        }
    }
}
