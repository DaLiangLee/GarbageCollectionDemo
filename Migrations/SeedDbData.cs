using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garbage.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tv.Database;

namespace Tv.Infrastructure
{
    public class MyContextSeed
    {
        public static async Task SeedAsync(TvContext context, ILoggerFactory loggerFactory, int retry = 0)
        {
            int retryForAvailability = retry;
            try
            {
                if(context.GCCategories.Any()){
                    context.GCCategories.AddRange(
                        new List<GCCategory> {
                            new GCCategory { CategoryName = "可回收垃圾" },
                            new GCCategory { CategoryName = "厨余垃圾" },
                            new GCCategory { CategoryName = "有害垃圾" },
                            new GCCategory { CategoryName = "其他垃圾" },
                    });
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if(retryForAvailability < 10){
                    retryForAvailability++;
                    var logger = loggerFactory.CreateLogger<MyContextSeed>();
                    logger.LogError(ex.Message);
                    await SeedAsync(context, loggerFactory, retryForAvailability);
                }
            }
        }
    }
}