using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.Logging.Console;

namespace GroupBy.Controllers {


    [Route("api/[controller]/[action]")]
    public class GroupController {


        ILoggerFactory fact;
        public GroupController(ILoggerFactory factory) {
            this.fact = factory;
        }

        DbContextOptions Options() {
            var loggerFactory = LoggerFactory.Create(builder => {
                builder.AddFilter("Microsoft", LogLevel.Debug)
                       .AddFilter("System", LogLevel.Debug)
                       .AddConsole();
            });

            DbContextOptions options = new DbContextOptionsBuilder()
                .UseNpgsql("Host=localhost;User Id=root; Password=1234;Database=app")
                .UseLoggerFactory(loggerFactory)
                .Options;

            return options;
        }

        [HttpGet]
        public void Insert() {
            var options = Options();
            using var context = new AppContext(options);
            context.Database.EnsureCreated();

            context.Student11.AddRange(new[] {
                new Student1 {
                    Name = "n11"
                },
                new Student1 {
                    Name = "n12"
                }
            });

            context.Student22.AddRange(new[] {
                new Student2 {
                    Name = "n21"
                },
                new Student2 {
                    Name = "n22"
                },
                new Student2 {
                    Name = "n23"
                }
            });
            context.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<dynamic> Union() {
            var options = Options();
            using var context = new AppContext(options);
            context.Database.EnsureCreated();

            Console.WriteLine("Union --");

            var query =
                context.Student11.Select(x => x.Name)
                    .Union(context.Student22.Select(x => x.Name))
                    .ToList();
            return query;
        }
    }
}