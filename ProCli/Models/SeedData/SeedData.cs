using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProCli.Data;
using System;
using System.Linq;

namespace ProCli.Models.SeedData
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProCliContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProCliContext>>()))
            {
                // Look for any movies.
                if (context.Cliente.Any())
                {
                    return;   // DB has been seeded
                }

                context.Cliente.AddRange(
                    new Cliente
                    {
                        Nombre = "Saul",
                        Domicilio = "Comas",
                        CodigoPostal = "Li04",
                        Poblacion = "po"
                    },

                    new Cliente
                    {
                        Nombre = "jaime",
                        Domicilio = "Comas",
                        CodigoPostal = "Li04",
                        Poblacion = "po1"
                    },

                    new Cliente
                    {
                        Nombre = "jose",
                        Domicilio = "Reatablo",
                        CodigoPostal = "Li04",
                        Poblacion = "po2"
                    },

                    new Cliente
                    {
                        Nombre = "luis",
                        Domicilio = "Ate",
                        CodigoPostal = "Li05",
                        Poblacion = "po3"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
