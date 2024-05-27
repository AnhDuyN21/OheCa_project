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
                                              .Where(im => im.Images.Any(im => im.Thumbnail == 1)).ToListAsync();
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
                                              .Where(p => p.ProductMaterials.Any(pm => pm.Material.ChildCategory.Id == childCategoryId))
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
