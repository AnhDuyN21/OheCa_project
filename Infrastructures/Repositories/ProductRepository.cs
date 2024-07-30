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
using System.Drawing.Printing;
using System.Globalization;

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


        public async Task<IEnumerable<Product>> GetProductAsync(int? pageIndex = null, int? pageSize = null)
        {
            var query = _dbContext.Products.Include(im => im.Images)
                                     .Include(p => p.Brand)
                                     .Include(p => p.Feedbacks)
                                            .ThenInclude(fb => fb.User)
                                     .Include(p => p.Discounts)
                                     .Include(p => p.Images)
                                     .Include(p => p.ProductMaterials)
                                            .ThenInclude(pm => pm.Material)
                                            .ThenInclude(m => m.ChildCategory)
                                            .ThenInclude(cc => cc.ParentCategory)
                                     .Where(im => im.Images.Any(im => im.Thumbnail == true) && im.IsDeleted == null);

            // Filtering by brandId if provided
           

            // Paging logic
            if (pageIndex.HasValue && pageSize.HasValue)
            {
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10; // Assuming a default pageSize of 10 if an invalid value is passed

                query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }

            var products = await query.ToListAsync();

            if (products != null && products.Any())
            {
                return products;
            }
            else
            {
                throw new Exception("Don't have any Product");
            }
        }


        public async Task<IEnumerable<Product>> GetProductForAdminAsync(int? brandId = null, int? categoryId = null)
        {
            var query = _dbContext.Products.Include(im => im.Images)
                                     .Include(p => p.Brand)
                                     .Include(p => p.Feedbacks)
                                            .ThenInclude(fb => fb.User)
                                     .Include(p => p.Discounts)
                                     .Include(p => p.Images)
                                     .Include(p => p.ProductMaterials)
                                            .ThenInclude(pm => pm.Material)
                                            .ThenInclude(m => m.ChildCategory)
                                            .ThenInclude(cc => cc.ParentCategory)
                                     .Where(im => im.Images.Any(im => im.Thumbnail == true) && im.IsDeleted == null);

            // Filtering by brandId if provided
            if (brandId.HasValue)
            {
                query = query.Where(p => p.BrandId == brandId.Value);
            }

            // Filtering by categoryId if provided
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.ProductMaterials.Any(pm => pm.Material.ChildCategoryId == categoryId.Value));
            }

           

            var products = await query.ToListAsync();

            if (products != null && products.Any())
            {
                return products;
            }
            else
            {
                throw new Exception("Don't have any Product");
            }
        }


        public async Task<IEnumerable<Product>> GetProductByBrand(int brandId, int? pageIndex = null, int? pageSize = null)
        {
            var query = _dbContext.Products.Include(br => br.Brand)
                                                    .Include(im => im.Images)
                                                    .Where(im => im.Images.Any(im => im.Thumbnail == true) && im.IsDeleted == null && im.Brand.Id == brandId);


            if (pageIndex.HasValue && pageSize.HasValue)
            {
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10; // Assuming a default pageSize of 10 if an invalid value is passed

                query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }

            var products = await query.ToListAsync();

            if (products != null && products.Any())
            {
                return products;
            }
            else
            {
                throw new Exception("Don't have any Product ");
            }
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryAsync(int childCategoryId, int? pageIndex = null, int? pageSize = null)
        {
            var query =  _dbContext.Products
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
                                                  Description = p.Description,
                                                  QuantitySold = p.QuantitySold,
                                                  Country = p.Country,
                                                  Status = p.Status,
                                                  BrandId = p.BrandId,
                                                  Brand = p.Brand,
                                                  Feedbacks = p.Feedbacks,
                                                  Discounts = p.Discounts,
                                                  ProductMaterials = p.ProductMaterials

                                              });




            if (pageIndex.HasValue && pageSize.HasValue)
            {
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10; // Assuming a default pageSize of 10 if an invalid value is passed

                query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }

            var products = await query.ToListAsync();

            if (products != null && products.Any())
            {
                return products;
            }
            else
            {
                throw new Exception("Don't have any Product ");
            }
        }

        public async Task<IEnumerable<Product>> GetProductByChildCategory(int childcategoryId, int? pageIndex = null, int? pageSize = null)
        {
            var query =  _dbContext.Products.Include(p => p.ProductMaterials)
                                                       .ThenInclude(pm => pm.Material)
                                                       .ThenInclude(m => m.ChildCategory)
                                                    .Include(im => im.Images)
                                                    .Include(br => br.Brand)
                                                    .Where(p => p.Images.Any(im => im.Thumbnail == true) && p.IsDeleted == null && 
                                                           p.ProductMaterials.Any(pm => pm.Material.ChildCategory.Id == childcategoryId));
            if (pageIndex.HasValue && pageSize.HasValue)
            {
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10; // Assuming a default pageSize of 10 if an invalid value is passed

                query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }

            var products = await query.ToListAsync();

            if (products != null && products.Any())
            {
                return products;
            }
            else
            {
                throw new Exception("Don't have any Product ");
            }
        }

        public async Task<IEnumerable<Product>> GetProductByDiscount(int? pageIndex = null, int? pageSize = null)
        {
            var query =  _dbContext.Products.Include(im => im.Images)
                                                    .Include(im => im.Brand)
                                                    .Where(im => im.Images.Any(im => im.Thumbnail == true) && im.IsDeleted == null)
                                                    .OrderByDescending(im => im.DiscountPercent);
            if (pageIndex.HasValue && pageSize.HasValue)
            {
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10; // Assuming a default pageSize of 10 if an invalid value is passed

                query = (IOrderedQueryable<Product>) query.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }

            var products = await query.ToListAsync();

            if (products != null && products.Any())
            {
                return products;
            }
            else
            {
                throw new Exception("Don't have any Product ");
            }
        }

        public async Task<IEnumerable<Product>> GetProductByFeedback(int rate, int? pageIndex = null, int? pageSize = null)
        {
            var rates = await _dbContext.Products.Where(p => p.Feedbacks.Any())
                                                  .Include(fb => fb.Feedbacks)
                                                  .GroupBy(p => p.Id)
                                                  .Select(g => new
                                                  {
                                                      ProductId = g.Key,
                                                      AverageRate = g.SelectMany(p => p.Feedbacks).Average(fb => fb.Rate)
                                                  }).ToListAsync();

            var productIds = rates
                .Where(rateProduct => rateProduct.AverageRate >= rate && rateProduct.AverageRate < rate + 1)
                .Select(rateProduct => rateProduct.ProductId)
                .ToList();
            var products = new List<Product>();
            foreach(var productId in productIds)
            {
                var product =  _dbContext.Products.Include(fb => fb.Feedbacks)
                                           .Include(im => im.Images)
                                           .Include(br => br.Brand)
                                           .Where(p => productId == p.Id &&
                                                       p.Images.Any(im => im.Thumbnail == true) &&
                                                       p.IsDeleted == null).FirstOrDefault();
                if (product != null)
                {
                    products.Add(product);
                }
            }


            if (pageIndex.HasValue && pageSize.HasValue)
            {
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10; // Giả sử pageSize mặc định là 10 nếu giá trị không hợp lệ

                products = products.Skip(validPageIndex * validPageSize).Take(validPageSize).ToList();
            }

            if (products != null && products.Any())
            {
                return products;
            }
            else
            {
                throw new Exception("Don't have any Product");
            }
        }


        public async Task<Product> GetProductByIDAsync(int id)
        {
           
            //  var product = await  _dbContext.Products.FirstOrDefaultAsync(o => o.Id == id);
            var product = await _dbContext.Products.Where(p => p.Id == id)
                                              .Include(p => p.Brand)
                                              .Include(p => p.Feedbacks)
                                                   .ThenInclude(fb => fb.User)
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
                                                  Description = p.Description,
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

        public async Task<IEnumerable<Product>> GetTop5BestProductSelling()
        {
            var query = _dbContext.Products.Include(p => p.Images)
                                     .Include(p => p.Brand)
                                     .Include(p => p.Feedbacks)
                                            .ThenInclude(fb => fb.User)
                                     .Include(p => p.Discounts)
                                     .Include(p => p.Images)
                                     .Include(p => p.ProductMaterials)
                                            .ThenInclude(pm => pm.Material)
                                            .ThenInclude(m => m.ChildCategory)
                                            .ThenInclude(cc => cc.ParentCategory)
                                     .Where(im => im.Images.Any(im => im.Thumbnail == true) && im.IsDeleted == null);

            // Filtering by brandId if provided


            // Paging logic
           

            var products = await query.OrderByDescending(p => p.QuantitySold).Take(5).ToListAsync();

            if (products != null && products.Any())
            {
                return products;
            }
            else
            {
                throw new Exception("Don't have any Product");
            }
        }

        public async Task<IEnumerable<decimal>> GetRevenueForMonth()
        {
            int currentYear = DateTime.Now.Year;
            var query = await _dbContext.Orders.Where(x => x.Status == 3).Select(p => new
            {

                ReceiveDate = (DateTime)p.ReceiveDate,
                OrderId = p.Id,
                TotalPrice = (decimal?)p.TotalPrice
            }).ToListAsync();



            // Khoi tao mang chua kq TotalRevenue của moi thang
            decimal[] monthlyRevenue = new decimal[12];

            for (int i = 0; i < 12; i++)
            {
                DateTime currentMonthStart = new DateTime(currentYear, i + 1, 1);
                DateTime currentMonthEnd = currentMonthStart.AddMonths(1).AddDays(-1);




                // Tính tổng doanh thu của shop trong tháng hiện tại
                decimal totalRevenue =  query.Where(p => p.ReceiveDate >= currentMonthStart && p.ReceiveDate <= currentMonthEnd).Sum(p => p.TotalPrice ?? 0m);

                // Gán đối tượng tháng vào mảng monthlyRevenue
                monthlyRevenue[i] = totalRevenue;
            }

            return monthlyRevenue;
        }

        public async Task<decimal> GetTotalRevenue()
        {
            
            var query = await _dbContext.Orders.Where(x => x.Status == 3).Select(p => new
            {               
                OrderId = p.Id,
                TotalPrice = (decimal?)p.TotalPrice
            }).ToListAsync();     
                decimal totalRevenue = query.Sum(p => p.TotalPrice ?? 0m);
            return totalRevenue;
        }

        public async Task<IEnumerable<decimal>> GetRevenueForWeek()
        {
            DateTime today = DateTime.Today;
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            int currentWeek = cal.GetWeekOfYear(today, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            int currentYear = today.Year;

            var query = await _dbContext.Orders.Where(x => x.Status == 3).Select(p => new
            {

                ReceiveDate = (DateTime)p.ReceiveDate,
                OrderId = p.Id,
                TotalPrice = (decimal?)p.TotalPrice
            }).ToListAsync();



            // Khoi tao mang chua kq TotalRevenue của moi thang
            decimal[] dailyRevenue = new decimal[7];

            for (int i = 0; i < 7; i++)
            {
                DateTime currentDate = FirstDateOfWeek(currentYear, currentWeek).AddDays(i);

                // Tính tổng doanh thu của shop trong ngày hiện tại
                decimal totalRevenue = query.Where(p => p.ReceiveDate.Date == currentDate.Date).Sum(p => p.TotalPrice ?? 0m);

                // Gán giá trị tổng doanh thu vào mảng dailyRevenue
                dailyRevenue[i] = totalRevenue;
               
            }
            return dailyRevenue;
        }

        public async Task<IEnumerable<Product>> GetProductdDiscountAsync(int? pageIndex = null, int? pageSize = null)
        {
            var query = _dbContext.Products.Include(im => im.Images)
                                    .Include(p => p.Brand)
                                    .Include(p => p.Feedbacks)
                                           .ThenInclude(fb => fb.User)
                                    .Include(p => p.Discounts)
                                    .Include(p => p.Images)
                                    .Include(p => p.ProductMaterials)
                                           .ThenInclude(pm => pm.Material)
                                           .ThenInclude(m => m.ChildCategory)
                                           .ThenInclude(cc => cc.ParentCategory)
                                    .Where(im => im.Images.Any(im => im.Thumbnail == true) && im.IsDeleted == null && im.DiscountPercent > 0);

            // Filtering by brandId if provided


            // Paging logic
            if (pageIndex.HasValue && pageSize.HasValue)
            {
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10; // Assuming a default pageSize of 10 if an invalid value is passed

                query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }

            var products = await query.ToListAsync();

            if (products != null && products.Any())
            {
                return products;
            }
            else
            {
                throw new Exception("Don't have any Product");
            }
        }

        public static DateTime FirstDateOfWeek(int year, int week)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysToFirstDayOfWeek = (int)jan1.DayOfWeek - (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;

            if (daysToFirstDayOfWeek < 0)
            {
                daysToFirstDayOfWeek += 7;
            }
            int firstWeekDay = 7 * (week - 1) - daysToFirstDayOfWeek;
            return jan1.AddDays(firstWeekDay);
        }


        public async Task<IEnumerable<Product>> GetProductSoldAsync(int? pageIndex = null, int? pageSize = null)
        {
            var query = _dbContext.Products.Include(im => im.Images)
                                    .Include(p => p.Brand)
                                    .Include(p => p.Feedbacks)
                                           .ThenInclude(fb => fb.User)
                                    .Include(p => p.Discounts)
                                    .Include(p => p.Images)
                                    .Include(p => p.ProductMaterials)
                                           .ThenInclude(pm => pm.Material)
                                           .ThenInclude(m => m.ChildCategory)
                                           .ThenInclude(cc => cc.ParentCategory)
                                    .Where(im => im.Images.Any(im => im.Thumbnail == true) && im.IsDeleted == null && im.QuantitySold > 0);

            // Filtering by brandId if provided


            // Paging logic
            if (pageIndex.HasValue && pageSize.HasValue)
            {
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10; // Assuming a default pageSize of 10 if an invalid value is passed

                query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }

            var products = await query.ToListAsync();

            if (products != null && products.Any())
            {
                return products;
            }
            else
            {
                throw new Exception("Don't have any Product");
            }
        }
    }
}
