using DataAccessLayer.Context;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DependencyInjection
    {
       

       public static IServiceCollection AddDataAccessLayer(this IServiceCollection service,IConfiguration configuration)
       {
          
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            service.AddTransient<IProductRepository,ProductRepository>();
            return service;
       }
    }
}
