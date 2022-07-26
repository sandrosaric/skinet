using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context,ILoggerFactory loggerFactory){
            try{
                if(!context.ProductBrands.Any()){
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brandsEntities = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    foreach(var brand in brandsEntities){
                        context.ProductBrands.Add(brand);
                        
                    }
                    await context.SaveChangesAsync();
                }

                 if(!context.ProductTypes.Any()){
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var typesEntities = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    foreach(var type in typesEntities){
                        context.ProductTypes.Add(type);
                        
                    }
                    await context.SaveChangesAsync();
                }

                if(!context.Products.Any()){
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var productsEntities = JsonSerializer.Deserialize<List<Product>>(productsData);
                    foreach(var product in productsEntities){
                        context.Products.Add(product);
                        
                    }
                    await context.SaveChangesAsync();
                }

                if(!context.DeliveryMethods.Any()){
                    var dmData = File.ReadAllText("../Infrastructure/Data/SeedData/delivery.json");
                    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);
                    foreach(var method in methods){
                        context.DeliveryMethods.Add(method);
                        
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex){
             var logger = loggerFactory.CreateLogger<StoreContextSeed>();
             logger.LogError(ex.Message);
            }
        }
    }
}