﻿using Application.Interfaces;
using Application.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Application.ViewModels.ImageProductDTOs;

namespace Infrastructures.Repositories
{
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;
        private readonly IWebHostEnvironment _enviroment;
        private readonly IUrlService _urlService;

        public ImageRepository(
            AppDbContext context,
            ICurrentTime timeService,
            IClaimsService claimsService,
            IWebHostEnvironment enviroment,
            IUrlService urlService
        )
            : base(context, timeService, claimsService)
        {
            _dbContext = context;
            _enviroment = enviroment;
            _urlService = urlService;
        }

        public async Task<Image> CreateImageAsync(CreateImageDTO file, int productId)
        {
            
            int passcount = 0;
            int errorcount = 0;
            
            try
            {
                string filePath = GetFileProductPath(productId);
                if(!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                
                        var image = new Image()
                        {
                            ProductId = productId,
                            ImageLink = GetImageProductPath(productId),
                            Thumbnail = file.Thumbnail


                        };

                        string imagepath = Path.Combine(filePath, file.File.FileName);
                        if (System.IO.File.Exists(imagepath))
                        {
                            System.IO.File.Delete(imagepath);
                        }
                        using (FileStream stream = System.IO.File.Create(imagepath))
                        {
                            await file.File.CopyToAsync(stream);
                          
                        }

                        _dbContext.Images.Add(image);
                        await _dbContext.SaveChangesAsync();
                        
                        passcount++;
                if (errorcount > 0)
                {
                    throw new Exception($"có {errorcount} tệp ảnh không được xử lý thành công.");
                }
                return image;
            }catch (Exception ex)
            {
                errorcount++;
                throw new Exception("Đã xảy ra lỗi khi tạo hình ảnh.", ex);
            }
        }

        public async Task DeleteImageAsync(int productId)
        {
           string Filepath = GetFileProductPath(productId);
            if(System.IO.Directory.Exists(Filepath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(Filepath);
                FileInfo[] fileInfos = directoryInfo.GetFiles();
                foreach (FileInfo fileInfo in fileInfos)
                {
                    fileInfo.Delete();
                }
            }

            var imagesToRemove = await _dbContext.Images.Where(i => i.ProductId == productId).ToListAsync();
            _dbContext.Images.RemoveRange(imagesToRemove);
            await _dbContext.SaveChangesAsync();

            
        }

        private string GetFileProductPath(int productId)
        {
            return this._enviroment.WebRootPath + "\\user-content\\product\\" + productId.ToString();
        }

        private string GetImageProductPath(int productId)
        {
            string hosturl = _urlService.GetHostUrl();
            return hosturl + "/user-content/product/" + productId + "/" + productId + ".png";
        }
    }
        
    
}
