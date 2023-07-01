using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IndWalks.API.Data
{
    public class IndWalkAuthDbContext : IdentityDbContext
    {
        public IndWalkAuthDbContext(DbContextOptions<IndWalkAuthDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "4e9b1e8d-4eae-45bb-8088-9753e68a6c87";
            var writerRoleId = "92e9ec6b-b29f-4685-89b8-22467ec24d3f";
            //Now Creating 2 roles 1) Reder 2) writer
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id= readerRoleId,
                    ConcurrencyStamp=readerRoleId,
                    Name="Reader",
                    NormalizedName="Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id= writerRoleId,
                    ConcurrencyStamp=writerRoleId,
                    Name="Writer",
                    NormalizedName="Writer".ToUpper()
                }
            };


            //Seed above data into Identity Role
            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
