using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using User.Domain.Entities;

namespace User.Infrastructure.Data.Seed
{
    public class DbInitializer : IDbInitializer
    {
        private const string AdminRoleName = "Admin";
        private const string ManagerRoleName = "Manager";
        private const string UserRoleName = "User";
        private readonly UserDbContext _dbContext;
        private readonly ILogger<DbInitializer> _logger;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public DbInitializer(UserDbContext dbContext, UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager, ILogger<DbInitializer> logger)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task Initialize()
        {
            await _dbContext.Database.EnsureCreatedAsync();

            var pendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
                await _dbContext.Database.MigrateAsync();

            try
            {
                #region Role

                if (!await _roleManager.RoleExistsAsync(AdminRoleName))
                    await _roleManager.CreateAsync(new AppRole
                    {
                        Id = Guid.NewGuid(),
                        Name = AdminRoleName,
                        NormalizedName = AdminRoleName.ToUpper(),
                        DateCreated = DateTime.Now
                    });

                if (!await _roleManager.RoleExistsAsync(ManagerRoleName))
                    await _roleManager.CreateAsync(new AppRole
                    {
                        Id = Guid.NewGuid(),
                        Name = ManagerRoleName,
                        NormalizedName = ManagerRoleName.ToUpper(),
                        DateCreated = DateTime.Now
                    });

                if (!await _roleManager.RoleExistsAsync(UserRoleName))
                    await _roleManager.CreateAsync(new AppRole
                    {
                        Id = Guid.NewGuid(),
                        Name = UserRoleName,
                        NormalizedName = UserRoleName.ToUpper(),
                        DateCreated = DateTime.Now
                    });

                #endregion

                #region User

                if (!_dbContext.Users.Any())
                {
                    var result = await _userManager.CreateAsync(new AppUser
                    {
                        Id = Guid.NewGuid(),
                        UserName = "admin",
                        FullName = "super admin",
                        Email = "admin@gmail.com",
                        LockoutEnabled = false,
                        DateCreated = DateTime.Now,
                        Address = new Address
                        {
                            District = "Test district",
                            ProvinceOrCity = "Zanarkand",
                            Ward = "Test ward",
                            DetailAddress = "To Zanarkand"
                        }
                    }, "123456");
                    if (result.Succeeded)
                    {
                        var user = await _userManager.FindByNameAsync("admin");
                        await _userManager.AddToRoleAsync(user, AdminRoleName);
                    }
                }

                #endregion

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error occur while seeding data !");
                //TODO: throw exception here
            }
        }
    }
}