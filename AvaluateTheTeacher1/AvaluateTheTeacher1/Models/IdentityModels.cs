using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using AvaluateTheTeacher1.Models.Students;

namespace AvaluateTheTeacher1.Models
{
    // Чтобы добавить данные профиля для пользователя, можно добавить дополнительные свойства в класс ApplicationUser. Дополнительные сведения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public int? GroupId { get; set; }

        public Group Group { get; set; }

        public ICollection<StudentVoting> StudentVotings { get; set; }
        public ApplicationUser()
        {
            StudentVotings = new List<StudentVoting>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType            
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("Password", this.PasswordTxt));
                                                           
            return userIdentity;
        }

        public string PasswordTxt { get; set; }
        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teachers.Teacher> Teachers { get; set; }
        public DbSet<Teachers.Cathedra> Cathedras { get; set; }
        public DbSet<Teachers.Subject> Subjects { get; set; }
        public DbSet<Teachers.Voting> Votings { get; set; }
        public DbSet<Teachers.Rating> Ratings { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {            
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Teachers.Subject>().HasMany(c => c.Teachers)
                .WithMany(s => s.Subjects)
                .Map(t => t.MapLeftKey("SubjectId")
                .MapRightKey("TeacherId")
                .ToTable("SubjectTeacher"));

            modelBuilder.Entity<Teachers.Teacher>().HasMany(c => c.Groups)
                .WithMany(s => s.Teachers)
                .Map(t => t.MapLeftKey("TeacherId")
                .MapRightKey("GroupId")
                .ToTable("TeacherGroup"));
        }
    }
}