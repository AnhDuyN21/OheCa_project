using Application.Interfaces;
using Application.Repositories;
using Application.ViewModels.ProductDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;

        public ProductRepository(
            AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService
        )
            : base(context, timeService, claimsService)
        {
            _dbContext = context;
        }


        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            var products = await _dbContext.Products.Include(im => im.Images)
                                                    .Include(br => br.Brand)
                                                    .Where(im => im.Images.Any(im => im.Thumbnail == true) && im.IsDeleted == null).ToListAsync();
            if (products != null)
            {
                return products;
            }
            else
            {
                throw new Exception("Don't have any Product ");
            }
        }

        public async Task<IEnumerable<Product>> GetProductByBrand(int brandId)
        {
            var products = await _dbContext.Products.Include(br => br.Brand)
                                                    .Include(im => im.Images)
                                                    .Where(im => im.Images.Any(im => im.Thumbnail == true) && im.IsDeleted == null && im.Brand.Id == brandId).ToListAsync();

                        
            if (products != null)
            {
                return products;
            }
            else
            {
                throw new Exception("Don't have any Product ");
            }
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryAsync(int childCategoryId)
        {
            var product = await _dbContext.Products
                                              .Include(p => p.Brand)
                                              .Include(p => p.Feedbacks)
                                              .Include(p => p.Discounts)
                                              .Include(p => p.ProductMaterials)
                                                   .ThenInclude(pm => pm.Material)
                                                   .ThenInclude(m => m.ChildCategory)
                                                   .ThenInclude(cc => cc.ParentCategory)
                                              .Where(p => p.ProductMaterials.Any(pm => pm.Material.ChildCategory.Id == childCategoryId) && p.IsDeleted == null)
                                              .Select(p => new Product()
                                              {
                                                  Id = p.Id,
                                                  Name = p.Name,
                                                  UnitPrice = p.UnitPrice,
                                                  PriceSold = p.PriceSold,
                                                  Quantity = p.Quantity,
                                                  QuantitySold = p.QuantitySold,
                                                  Country = p.Country,
                                                  Status = p.Status,
                                                  BrandId = p.BrandId,
                                                  Brand = p.Brand,
                                                  Feedbacks = p.Feedbacks,
                                                  Discounts = p.Discounts,
                                                  ProductMaterials = p.ProductMaterials

                                              }).ToListAsync();




            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Don't find Product By Id");
            }
        }

        public async Task<IEnumerable<Product>> GetProductByChildCategory(int childcategoryId)
        {
            var products = await _dbContext.Products.Include(p => p.ProductMaterials)
                                                       .ThenInclude(pm => pm.Material)
                                                       .ThenInclude(m => m.ChildCategory)
                                                    .Include(im => im.Images)
                                                    .Include(br => br.Brand)
                                                    .Where(p => p.Images.Any(im => im.Thumbnail == true) && p.IsDeleted == null && 
                                                           p.ProductMaterials.Any(pm => pm.Material.ChildCategory.Id == childcategoryId)).ToListAsync();
            if (products != null)
            {
                return products;
            }
            else
            {
                throw new Exception("Don't have any Product ");
            }
        }

        public async Task<IEnumerable<Product>> GetProductByDiscount()
        {
            var products = await _dbContext.Products.Include(im => im.Images)
                                                    .Where(im => im.Images.Any(im => im.Thumbnail == true) && im.IsDeleted == null )
                                                    .OrderByDescending(im => im.DiscountPercent)
                                                    .ToListAsync();
            if (products != null)
            {
                return products;
            }
            else
            {
                throw new Exception("Don't have any Product ");
            }
        }

        public async Task<IEnumerable<Product>> GetProductByFeedback(int rate)
        {
            var rates = await _dbContext.Products.Where(p => p.Feedbacks.Any())
                                                .Include(fb => fb.Feedbacks)
                                                .GroupBy(p => p.Id)
                                                .Select(g => new
                                                {
                                                    ProductId = g.Key,
                                                    AverageRate = g.SelectMany(p => p.Feedbacks).Average(fb => fb.Rate)
                                                }).ToListAsync();
            var products = new List<Product>();
            foreach (var rateProduct in rates)
            {
                var product = await _dbContext.Products.Include(fb => fb.Feedbacks)
                                                    .Include(im => im.Images)
                                                    .Include(br => br.Brand)
                                                    .Where(p => p.Id == rateProduct.ProductId && rateProduct.AverageRate >= rate && rateProduct.AverageRate < rate + 1 &&
                                                       p.Images.Any(im => im.Thumbnail == true) && p.IsDeleted == null).FirstOrDefaultAsync();
                products.Add(product);
               
               
            }
            if (products != null)
            {
                return products;
            }
            else
            {
                throw new Exception("Don't have any Product ");
            }
            
           
        }

        public  async Task<Product> GetProductByIDAsync(int id)
        {
           
            //  var product = await  _dbContext.Products.FirstOrDefaultAsync(o => o.Id == id);
            var product = await _dbContext.Products.Where(p => p.Id == id)
                                              .Include(p => p.Brand)
                                              .Include(p => p.Feedbacks)
                                              .Include(p => p.Discounts)
                                              .Include(p => p.Images)
                                              .Include(p => p.ProductMaterials)
                                                   .ThenInclude(pm => pm.Material)
                                                   .ThenInclude(m => m.ChildCategory)
                                                   .ThenInclude(cc => cc.ParentCategory)
                                              .Select(p => new Product()
                                              {
                                                  Id = p.Id,
                                                  Name = p.Name,
                                                  UnitPrice = p.UnitPrice,
                                                  PriceSold = p.PriceSold,
                                                  Quantity = p.Quantity,
                                                  QuantitySold = p.QuantitySold,
                                                  Country = p.Country,
                                                  Status = p.Status,
                                                  BrandId = p.BrandId,
                                                  Brand = p.Brand,
                                                  Feedbacks = p.Feedbacks,
                                                  Discounts = p.Discounts,
                                                  ProductMaterials = p.ProductMaterials,
                                                  Images = p.Images,
                                                  IsDeleted = p.IsDeleted,
                                                  
                                              }).FirstOrDefaultAsync();
                                     

                                 

            if ( product != null )
            {
                return product;
            }
            else
            {
                throw new Exception("Don't find Product By Id");
            }
        }


    }
}
