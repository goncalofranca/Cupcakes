using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Cupcakes.Models;

using Microsoft.EntityFrameworkCore;

namespace Cupcakes.Data
{
    public class CupcakeContext : DbContext
    {
        public DbSet<Cupcake> Cupcakes { get; set; }
        public DbSet<Bakery> Bakeries { get; set; }

        public CupcakeContext(DbContextOptions<CupcakeContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            _ = modelBuilder.Entity<Bakery>().HasData(
             new Bakery {
                 BakeryID = 1,
                 BakeryName = "Gluteus Free",
                 Address = "635 Brighton Circle Road",
                 Quantity = 8
             },
              new Bakery {
                  BakeryID = 2,
                  BakeryName = "Cupcakes Break",
                  Address = "4323 Jerome Avenue",
                  Quantity = 22
              },
              new Bakery {
                  BakeryID = 3,
                  BakeryName = "Cupcakes Ahead",
                  Address = "2553 Pin Oak Drive",
                  Quantity = 18
              },
              new Bakery {
                  BakeryID = 4,
                  BakeryName = "Sugar",
                  Address = "1608 Charles Street",
                  Quantity = 30
              }
          );

            _ = modelBuilder.Entity<Cupcake>().HasData(
                new Cupcake {
                    CupcakeID = 1,
                    CupcakeType = CupcakeType.Birthday,
                    Description = "Vanilla cupcake with coconut cream",
                    GlutenFree = true,
                    BakeryID = 1,
                    Price = 2.5,
                    ImageMimeType = "image/jpeg",
                    ImageName = "birthday-cupcake.jpg"

                },
                new Cupcake {
                    CupcakeID = 2,
                    CupcakeType = CupcakeType.Chocolate,
                    Description = "Chocolate cupcake with caramel filling and chocolate butter cream",
                    GlutenFree = false,
                    BakeryID = 2,
                    Price = 3.2,
                    ImageMimeType = "image/jpeg",
                    ImageName = "chocolate-cupcake.jpg"

                },
                new Cupcake {
                    CupcakeID = 3,
                    CupcakeType = CupcakeType.Strawberry,
                    Description = "Chocolate cupcake with straberry cream filling",
                    GlutenFree = false,
                    BakeryID = 3,
                    Price = 4,
                    ImageMimeType = "image/jpeg",
                    ImageName = "pink-cupcake.jpg"
                },
                new Cupcake {
                    CupcakeID = 4,
                    CupcakeType = CupcakeType.Turquoise,
                    Description = "Vanilla cupcake with butter cream",
                    GlutenFree = true,
                    BakeryID = 4,
                    Price = 1.5,
                    ImageMimeType = "image/jpeg",
                    ImageName = "turquoise-cupcake.jpg"
                }
            );

            
        }

    }
}
