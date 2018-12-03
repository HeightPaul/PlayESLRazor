using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlayESLRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayESLRazor.Data
{
    public class SeedData
    {
        public static void Initialize(ApplicationDbContext context,
                              UserManager<AppUser> userManager,
                              RoleManager<AppRole> roleManager)
        {
            context.Database.Migrate();
            SeedTournaments(context);
            SeedCompTeams(context);
            SeedRoles(roleManager);
            SeedUsers(userManager);
            SeedEnrollments(context);

        }
        public static void SeedTournaments(ApplicationDbContext context)
        {
            if (!context.Tournament.Any())
            {
                Tournament[] tournaments = new Tournament[]
                {
                    new Tournament { TournamentId = 1 , Title = "StarCraft 2 Open Ladder", PlayerFormat = "1v1", Tier = Tier.Minor },
                    new Tournament { TournamentId = 2 , Title = "CS:GO EU 1v1 Open Cup", PlayerFormat = "1v1", Tier = Tier.Minor },
                    new Tournament { TournamentId = 3 , Title = "FIFA 19 EU Playoffs", PlayerFormat = "1v1", Tier = Tier.Major },
                    new Tournament { TournamentId = 4 , Title = "Rainbow 6 Siege Invitational", PlayerFormat = "5v5", Tier = Tier.Premier }
                };
                foreach (Tournament t in tournaments)
                {
                    context.Tournament.Add(t);
                }
                context.SaveChanges();
            }
        }
        public static void SeedCompTeams(ApplicationDbContext context)
        {
            if (!context.CompTeam.Any())
            {
                CompTeam[] compTeams = new CompTeam[]
                {
                    new CompTeam { CompTeamId = 1 , Name = "Team Liquid", EnrollmentDate = DateTime.Parse("2017-09-12") },
                    new CompTeam { CompTeamId = 2 , Name = "SK Gaming", EnrollmentDate = DateTime.Parse("2015-10-08") },
                    new CompTeam { CompTeamId = 3 , Name = "FNATIC", EnrollmentDate = DateTime.Parse("2012-05-19") }
                };
                foreach (CompTeam cT in compTeams)
                {
                    context.CompTeam.Add(cT);
                }
                context.SaveChanges();
            }
        }
        public static void SeedRoles(RoleManager<AppRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync ("Member").Result)
            {
                AppRole role = new AppRole
                {
                    Name = "Member",
                    Description = "Perform normal operations.",
                    CreationDate = DateTime.Now
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync ("Admin").Result)
            {
                AppRole role = new AppRole
                {
                    Name = "Admin",
                    Description = "Perform all the operations.",
                    CreationDate = DateTime.Now
                };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
        public static void SeedUsers(UserManager<AppUser> userManager)
        {
            string password = "P@$$w0rd";
            if (userManager.FindByNameAsync("aa@aa.aa").Result == null)
            {
                AppUser user = new AppUser
                {
                    UserName = "aa@aa.aa",
                    Email = "aa@aa.aa",
                    FirstName = "Adam",
                    LastName = "Aldridge",
                    Country = "Canada",
                    PhoneNumber = "6902341234"
                };

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"Admin").Wait();
                }
            }
            if (userManager.FindByNameAsync("bb@bb.bb").Result == null)
            {
                AppUser user = new AppUser
                {
                    UserName = "bb@bb.bb",
                    Email = "bb@bb.bb",
                    FirstName = "Bob",
                    LastName = "Barker",
                    Country = "Britain",
                    PhoneNumber = "5432141234"
                };

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"Admin").Wait();
                }
            }
            if (userManager.FindByNameAsync("cc@cc.cc").Result == null)
            {
                AppUser user = new AppUser
                {
                    UserName = "cc@cc.cc",
                    Email = "cc@cc.cc",
                    FirstName = "Charlie",
                    LastName = "Charlstone",
                    Country = "USA",
                    PhoneNumber = "6572136821"
                };

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Member").Wait();
                }
            }
            if (userManager.FindByNameAsync("mm@mm.mm").Result == null)
            {
                AppUser user = new AppUser
                {
                    UserName = "mm@mm.mm",
                    Email = "mm@mm.mm",
                    FirstName = "Mike",
                    LastName = "Myers",
                    Country = "USA",
                    CompTeamId = 1,
                    PhoneNumber = "6572136821"
                };

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Member").Wait();
                }
            }
            if (userManager.FindByNameAsync("dd@dd.dd").Result == null)
            {
                AppUser user = new AppUser
                {
                    UserName = "dd@dd.dd",
                    Email = "dd@dd.dd",
                    FirstName = "Donald",
                    LastName = "Duck",
                    Country = "Canada",
                    CompTeamId = 3,
                    PhoneNumber = "6041234567"
                };

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Member").Wait();
                }
            }
            if (userManager.FindByNameAsync("ee@ee.ee").Result == null)
            {
                AppUser user = new AppUser
                {
                    UserName = "ee@dd.ee",
                    Email = "ee@ee.ee",
                    FirstName = "Ethan",
                    LastName = "Knight",
                    Country = "USA",
                    CompTeamId = 2,
                    PhoneNumber = "604129065"
                };

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Member").Wait();
                }
            }
            if (userManager.FindByNameAsync("ff@ff.ff").Result == null)
            {
                AppUser user = new AppUser
                {
                    UserName = "ff@ff.ff",
                    Email = "ff@ff.ff",
                    FirstName = "Clarisa",
                    LastName = "Austin",
                    Country = "Spain",
                    CompTeamId = 2,
                    PhoneNumber = "4561234567"
                };

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Member").Wait();
                }
            }
        }
        public static void SeedEnrollments(ApplicationDbContext context)
        {
            if (!context.Enrollment.Any())
            {
                Enrollment[] enrollments = new Enrollment[]
                {
                    new Enrollment { TournamentId = 1, CompTeamId = 2},
                    new Enrollment { TournamentId = 1, CompTeamId = 1},
                    new Enrollment { TournamentId = 2, CompTeamId = 3},
                    new Enrollment { TournamentId = 2, CompTeamId = 1},
                    new Enrollment { TournamentId = 3, CompTeamId = 3}
                };
                foreach (Enrollment e in enrollments)
                {
                    context.Enrollment.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}
