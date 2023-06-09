using Dapper;
using Dreamer.Server.Data;
using Dreamer.Shared.DTOs;
using Dreamer.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace Dreamer.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly DatabaseConnection _conn;
        public ProductController(ApplicationDbContext context, DatabaseConnection conn)
        {
            _context = context;
            _conn = conn;
        }
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<List<ProductView>>> GetAll()
        {
            var result = await (from a in _context.Product
                                join b in _context.Category on a.CategoryId equals b.CategoryId
                                //join d in _context.Cities on a.CitiesId equals d.CitiesId
                                join e in _context.Area on a.AreaId equals e.AreaId

                                select new ProductView
                                {
                                    ProductId = a.ProductId,
                                    Name = a.Name,
                                    Quantity = a.Quantity,
                                    SalePrice = a.SalePrice,
                                    Image = a.Image,
                                    IsActive = a.IsActive,
                                    CategoryName = b.Name,
                                    //CitiyName = d.CitiyName,
                                    AreaName = e.AreaName,
                                    ShortDetails = a.ShortDetails,
                                    OriginalPrice = a.OriginalPrice,
                                    ProductType = a.ProductType,
                                    YoutubeLink = a.YoutubeLink,
                                    Description = a.Description,
                                    UserId = a.UserId
                                }).ToListAsync();
            return Ok(result);
        }



        [HttpGet]
        [ActionName("GetAllStore")]
        public async Task<ActionResult<List<ProductView>>> GetAllStore()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await (from a in _context.Product
                                join b in _context.Category on a.CategoryId equals b.CategoryId
                                join d in _context.Cities on a.CitiesId equals d.CitiesId
                                join e in _context.Area on a.AreaId equals e.AreaId
                                where a.UserId == Convert.ToInt32(userId)
                                select new ProductView
                                {
                                    ProductId = a.ProductId,
                                    Name = a.Name,
                                    Quantity = a.Quantity,
                                    SalePrice = a.SalePrice,
                                    Image = a.Image,
                                    IsActive = a.IsActive,
                                    CategoryName = b.Name,
                                    CitiyName = d.CitiyName,
                                    AreaName = e.AreaName,
                                    ShortDetails = a.ShortDetails,
                                    OriginalPrice = a.OriginalPrice,
                                    ProductType = a.ProductType,
                                    YoutubeLink = a.YoutubeLink,
                                    Description = a.Description,
                                    UserId = a.UserId
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet]
        [ActionName("Hightolow")]
        public async Task<ActionResult<List<Product>>> Hightolow()
        {
            var result = await (from a in _context.Product
                                 orderby a.SalePrice descending
                                select new Product
                                {
                                    ProductId = a.ProductId,
                                    Name = a.Name,
                                    UserId = a.UserId,
                                    Quantity = a.Quantity,
                                    SalePrice = a.SalePrice,
                                    Image = a.Image,
                                    IsActive = a.IsActive,
                                    ShortDetails = a.ShortDetails,
                                    Code = a.Code,
                                    Discount = a.Discount,
                                    OriginalPrice = a.OriginalPrice,
                                    ProductType = a.ProductType,
                                    YoutubeLink = a.YoutubeLink,
                                    Description = a.Description
                                }).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [ActionName("Lowtohigh")]
        public async Task<ActionResult<List<Product>>> Lowtohigh()
        {
            var result = await (from a in _context.Product
                                orderby a.SalePrice ascending
                                select new Product
                                {
                                    ProductId = a.ProductId,
                                    Name = a.Name,
                                    UserId = a.UserId,
                                    Quantity = a.Quantity,
                                    SalePrice = a.SalePrice,
                                    Image = a.Image,
                                    IsActive = a.IsActive,
                                    ShortDetails = a.ShortDetails,
                                    Code = a.Code,
                                    OriginalPrice = a.OriginalPrice,
                                    Discount = a.Discount,
                                    ProductType = a.ProductType,
                                    YoutubeLink = a.YoutubeLink,
                                    Description = a.Description
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet]
        [ActionName("Discountlowtohigh")]
        public async Task<ActionResult<List<Product>>> Discountlowtohigh()
        {
            var result = await (from a in _context.Product
                                orderby a.Discount descending
                                select new Product
                                {
                                    ProductId = a.ProductId,
                                    Name = a.Name,
                                    UserId = a.UserId,
                                    Quantity = a.Quantity,
                                    SalePrice = a.SalePrice,
                                    Image = a.Image,
                                    IsActive = a.IsActive,
                                    ShortDetails = a.ShortDetails,
                                    Code = a.Code,
                                    Discount = a.Discount,
                                    OriginalPrice = a.OriginalPrice,
                                    ProductType = a.ProductType,
                                    YoutubeLink = a.YoutubeLink,
                                    Description = a.Description
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet]
        [ActionName("Sortatoz")]
        public async Task<ActionResult<List<Product>>> Sortatoz()
        {
            var result = await (from a in _context.Product
                                orderby a.Name ascending
                                select new Product
                                {
                                    ProductId = a.ProductId,
                                    Name = a.Name,
                                    UserId = a.UserId,
                                    Quantity = a.Quantity,
                                    SalePrice = a.SalePrice,
                                    Image = a.Image,
                                    IsActive = a.IsActive,
                                    ShortDetails = a.ShortDetails,
                                    Code = a.Code,
                                    OriginalPrice = a.OriginalPrice,
                                    Discount = a.Discount,
                                    ProductType = a.ProductType,
                                    YoutubeLink = a.YoutubeLink,
                                    Description = a.Description
                                }).ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetAllDetails")]
        public async Task<ActionResult<List<Product>>> GetAllDetails()
        {
            using (SqlConnection sqlcon = new SqlConnection(_conn.DbConn))
            {
                var result = sqlcon.Query<Product>("SELECT *FROM Product", null, null, true, 0, commandType: CommandType.Text).ToList();
                return Ok(result);
            }
            //var result = await (from a in _context.Product
            //                    select new
            //                    {
            //                        ProductId = a.ProductId,
            //                        Name = a.Name,
            //                        UserId = a.UserId,
            //                        Quantity = a.Quantity,
            //                        SalePrice = a.SalePrice,
            //                        Image = a.Image,
            //                        IsActive = a.IsActive,
            //                        ShortDetails = a.ShortDetails,
            //                        Code = a.Code,
            //                        OriginalPrice = a.OriginalPrice,
            //                        ProductType = a.ProductType,
            //                        YoutubeLink = a.YoutubeLink,
            //                        Description = a.Description
            //                    }).ToListAsync();
            //return Ok(result);
        }
        [HttpGet]
        [ActionName("GetAllNew")]
        public async Task<ActionResult<List<Product>>> GetAllNew()
        {
            using (SqlConnection sqlcon = new SqlConnection(_conn.DbConn))
            {
                var result = sqlcon.Query<Product>("SELECT TOP 8 *FROM Product where IsNew='true'", null, null, true, 0, commandType: CommandType.Text).ToList();
                return Ok(result);
            }
        }
        [HttpGet]
        [ActionName("GetAllSales")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllSales()
        {
            using (SqlConnection sqlcon = new SqlConnection(_conn.DbConn))
            {
                var result = sqlcon.Query<Product>("SELECT TOP 8 *FROM Product where IsSale='true'", null, null, true, 0, commandType: CommandType.Text).ToList();
                return Ok(result);
            }
        }
        [HttpGet("{Id}")]
        [ActionName("GetAllByCategoryId")]
        public async Task<ActionResult<Product>> GetAllByCategoryId(int id)
        {
            var result = await (from a in _context.Product
                                where a.CategoryId == id
                                select new
                                {
                                    ProductId = a.ProductId,
                                    Name = a.Name,
                                    UserId = a.UserId,
                                    Quantity = a.Quantity,
                                    SalePrice = a.SalePrice,
                                    Discount = a.Discount,
                                    Image = a.Image,
                                    IsActive = a.IsActive,
                                    ShortDetails = a.ShortDetails,
                                    OriginalPrice = a.OriginalPrice,
                                    Code = a.Code,
                                    ProductType = a.ProductType,
                                    YoutubeLink = a.YoutubeLink,
                                    Description = a.Description
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet("{Id}")]
        [ActionName("GetAllProductVariation")]
        public async Task<ActionResult<ProductVariation>> GetAllProductVariation(int id)
        {
            var result = await (from a in _context.ProductVariation
                                where a.ProductId == id
                                select new
                                {
                                    ProductvariationId = a.ProductvariationId,
                                    ProductId = a.ProductId,
                                    Price = a.Price,
                                    Variation = a.Variation,
                                    Stock = a.Stock
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet("{isActive}")]
        [ActionName("GetAllProductnewDetails")]
        public async Task<ActionResult<Product>> GetAllProductnewDetails(bool isActive)
        {
            var result = await (from a in _context.Product
                                where a.IsNew == true
                                select new
                                {
                                    ProductId = a.ProductId,
                                    Name = a.Name,
                                    UserId = a.UserId,
                                    Quantity = a.Quantity,
                                    SalePrice = a.SalePrice,
                                    Discount = a.Discount,
                                    Image = a.Image,
                                    IsActive = a.IsActive,
                                    ShortDetails = a.ShortDetails,
                                    OriginalPrice = a.OriginalPrice,
                                    Code = a.Code,
                                    ProductType = a.ProductType,
                                    YoutubeLink = a.YoutubeLink,
                                    Description = a.Description
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet("{isActive}")]
        [ActionName("GetAllProductfeatureDetails")]
        public async Task<ActionResult<Product>> GetAllProductfeatureDetails(bool isActive)
        {
            var result = await (from a in _context.Product
                                where a.IsSale == true
                                select new
                                {
                                    ProductId = a.ProductId,
                                    Name = a.Name,
                                    UserId = a.UserId,
                                    Quantity = a.Quantity,
                                    SalePrice = a.SalePrice,
                                    Discount = a.Discount,
                                    Image = a.Image,
                                    IsActive = a.IsActive,
                                    ShortDetails = a.ShortDetails,
                                    OriginalPrice = a.OriginalPrice,
                                    Code = a.Code,
                                    ProductType = a.ProductType,
                                    YoutubeLink = a.YoutubeLink,
                                    Description = a.Description
                                }).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{Id}")]
        [ActionName("GetAllByCategorysubId")]
        public async Task<ActionResult> GetAllByCategorysubId(int id)
        {
            var result = await (from a in _context.Product
                                where a.CategoryId == id
                                select new
                                {
                                    ProductId = a.ProductId,
                                    Name = a.Name,
                                    UserId = a.UserId,
                                    Quantity = a.Quantity,
                                    SalePrice = a.SalePrice,
                                    Discount = a.Discount,
                                    Image = a.Image,
                                    IsActive = a.IsActive,
                                    ShortDetails = a.ShortDetails,
                                    Code = a.Code,
                                    OriginalPrice = a.OriginalPrice,
                                    ProductType = a.ProductType,
                                    YoutubeLink = a.YoutubeLink,
                                    Description = a.Description
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet("{Id}")]
        [ActionName("GetAllByBrandId")]
        public async Task<ActionResult> GetAllByBrandId(int id)
        {
            var result = await (from a in _context.Product
                                where a.BrandId == id
                                select new
                                {
                                    ProductId = a.ProductId,
                                    Name = a.Name,
                                    UserId = a.UserId,
                                    Quantity = a.Quantity,
                                    SalePrice = a.SalePrice,
                                    Image = a.Image,
                                    IsActive = a.IsActive,
                                    ShortDetails = a.ShortDetails,
                                    Code = a.Code,
                                    Discount = a.Discount,
                                    OriginalPrice = a.OriginalPrice,
                                    ProductType = a.ProductType,
                                    YoutubeLink = a.YoutubeLink,
                                    Description = a.Description
                                }).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{FromRate}/{ToRate}")]
        [ActionName("GetAllByRate")]
        public async Task<ActionResult> GetAllByRate(decimal FromRate , decimal ToRate)
        {
            var result = await (from a in _context.Product
                                where a.SalePrice >= FromRate && a.SalePrice <= ToRate
                                select new
                                {
                                    ProductId = a.ProductId,
                                    Name = a.Name,
                                    UserId = a.UserId,
                                    Quantity = a.Quantity,
                                    SalePrice = a.SalePrice,
                                    Image = a.Image,
                                    IsActive = a.IsActive,
                                    ShortDetails = a.ShortDetails,
                                    Code = a.Code,
                                    Discount = a.Discount,
                                    OriginalPrice = a.OriginalPrice,
                                    ProductType = a.ProductType,
                                    YoutubeLink = a.YoutubeLink,
                                    Description = a.Description
                                }).ToListAsync();
            return Ok(result);
        }



        [HttpGet("{areaid}/{productname}")]
        [ActionName("GetAllProductSearch")]
        public async Task<ActionResult<IList<Product>>> GetAllProductSearch(int areaid, string productname)
        {
            using (SqlConnection sqlcon = new SqlConnection(_conn.DbConn))
            {
                var para = new DynamicParameters();
                para.Add("@AreaId", areaid);
                para.Add("@Name", productname);
                var ListofPlan = sqlcon.Query<Product>("SearchView", para, null, true, 0, commandType: CommandType.StoredProcedure).ToList();
                return ListofPlan;
            }
        }
        [HttpGet("{areaid}")]
        [ActionName("GetAllProductSearchall")]
        public async Task<ActionResult<IList<Product>>> GetAllProductSearchall(int areaid)
        {
            using (SqlConnection sqlcon = new SqlConnection(_conn.DbConn))
            {
                var para = new DynamicParameters();
                para.Add("@AreaId", areaid);
                var ListofPlan = sqlcon.Query<Product>("SearchViewAll", para, null, true, 0, commandType: CommandType.StoredProcedure).ToList();
                return ListofPlan;
            }
        }
        [HttpGet("{shop}")]
        [ActionName("GetAllNewShop")]
        public async Task<ActionResult> GetAllNewShop(bool shop)
        {
            var result = await (from a in _context.Product
                                where a.IsNew == shop
                                select new
                                {
                                    ProductId = a.ProductId,
                                    Name = a.Name,
                                    UserId = a.UserId,
                                    Quantity = a.Quantity,
                                    SalePrice = a.SalePrice,
                                    Image = a.Image,
                                    IsActive = a.IsActive,
                                    ShortDetails = a.ShortDetails,
                                    Code = a.Code,
                                    Discount = a.Discount,
                                    OriginalPrice = a.OriginalPrice,
                                    ProductType = a.ProductType,
                                    YoutubeLink = a.YoutubeLink,
                                    Description = a.Description
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet("{shop}")]
        [ActionName("GetAllNewShopsale")]
        public async Task<ActionResult> GetAllNewShopsale(bool shop)
        {
            var result = await (from a in _context.Product
                                where a.IsSale == shop
                                select new
                                {
                                    ProductId = a.ProductId,
                                    Name = a.Name,
                                    UserId = a.UserId,
                                    Quantity = a.Quantity,
                                    SalePrice = a.SalePrice,
                                    Image = a.Image,
                                    IsActive = a.IsActive,
                                    ShortDetails = a.ShortDetails,
                                    Code = a.Code,
                                    OriginalPrice = a.OriginalPrice,
                                    Discount = a.Discount,
                                    ProductType = a.ProductType,
                                    YoutubeLink = a.YoutubeLink,
                                    Description = a.Description
                                }).ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> Save([FromBody] Product model)
        {
            _context.Product.Add(model);
            await _context.SaveChangesAsync();
            int id = model.ProductId;
            foreach (var item in model.Addresses)
            {
                    item.ProductId = id;
                    _context.ProductVariation.Add(item);
                    await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpPost]
        [ActionName("SaveStore")]
        public async Task<IActionResult> SaveStore([FromBody] Product model)
        {
            return Ok();
            }
        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> Update([FromBody] Product model)
        {
                _context.Product.Update(model);
                await _context.SaveChangesAsync();
                return Ok();
        }
        [HttpPost]
        [ActionName("UpdateStore")]
        public async Task<IActionResult> UpdateStore([FromBody] Product model)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            model.UserId = Convert.ToInt32(userId);
            _context.Product.Update(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{Id}")]
        [ActionName("GetbyId")]
        public async Task<ActionResult> GetbyId(int id)
        {
            var result = await (from a in _context.Product
                                where a.ProductId == id
                                select new
                                {
                                    ProductId = a.ProductId,
                                    UserId = a.UserId,
                                    CitiesId = a.CitiesId,
                                    AreaId = a.AreaId,
                                    CategoryId = a.CategoryId,
                                    BrandId = a.BrandId,
                                    Name = a.Name,
                                    Title = a.Title,
                                    Code = a.Code,
                                    OriginalPrice = a.OriginalPrice,
                                    SalePrice = a.SalePrice,
                                    ShortDetails = a.ShortDetails,
                                    Description = a.Description,
                                    Quantity = a.Quantity,
                                    Discount = a.Discount,
                                    IsNew = a.IsNew,
                                    IsSale = a.IsSale,
                                    ProductType = a.ProductType,
                                    Image = a.Image,
                                    YoutubeLink = a.YoutubeLink,
                                    IsActive = a.IsActive,
                                    IsSlider = a.IsSlider,
                                    CreatedOn = a.CreatedOn,
                                    ModifiedOn = a.ModifiedOn
                                }).FirstOrDefaultAsync();
            return Ok(result);
            //var dev = await _context.Product.FirstOrDefaultAsync(a => a.ProductId == id);
            //return Ok(dev);
        }




        [HttpGet("{Id}")]
        [ActionName("GetbydetailsId")]
        public async Task<ActionResult<ProductView>> GetbydetailsId(int id)
        {
            var result = await (from a in _context.Product
                                join b in _context.Category on a.CategoryId equals b.CategoryId
                                join br in _context.Brand on a.BrandId equals br.BrandId
                                where a.ProductId == id
                                select new ProductView
                                {
                                    ProductId = a.ProductId,
                                    Name = a.Name,
                                    Quantity = a.Quantity,
                                    Discount = a.Discount,
                                    SalePrice = a.SalePrice,
                                    Image = a.Image,
                                    IsActive = a.IsActive,
                                    CategoryName = b.Name,
                                    BrandName = br.BrandName,
                                    BrandId = br.BrandId,
                                    CategoryId = a.CategoryId,
                                    ShortDetails = a.ShortDetails,
                                    Description = a.Description,
                                    OriginalPrice = a.OriginalPrice,
                                    ProductType = a.ProductType,
                                    YoutubeLink = a.YoutubeLink,
                                    UserId = a.UserId
                                }).FirstOrDefaultAsync();
            return Ok(result);
        }
            [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(ProductView master)
        {
            var result = (from progm in _context.ProductPictureMapping
                          where progm.ProductId == master.ProductId
                          select progm.ProductId).Count();
            if (result > 0)
            {
                return BadRequest();
            }
            else
            {
                var dev = await _context.Product.FirstOrDefaultAsync(a => a.ProductId == master.ProductId);
                _context.Product.Remove(dev);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
        [HttpPost]
        [ActionName("SaveMapping")]
        public async Task<IActionResult> SaveMapping([FromBody] ProductPictureMapping model)
        {
            _context.ProductPictureMapping.Add(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost]
        [ActionName("DeleteMapping")]
        public async Task<ActionResult> DeleteMapping(ProductPictureMapping master)
        {
            var dev = await _context.ProductPictureMapping.FirstOrDefaultAsync(a => a.ProductPictureMappingId == master.ProductPictureMappingId);
            _context.ProductPictureMapping.Remove(dev);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("{Id}")]
        [ActionName("GetAllProductMapping")]
        public async Task<ActionResult> GetAllProductMapping(int id)
        {
            var result = await (from a in _context.ProductPictureMapping
                                where a.ProductId == id
                                select new
                                {
                                    ProductPictureMappingId = a.ProductPictureMappingId,
                                    ProductId = a.ProductId,
                                    PictureName = a.PictureName,
                                    PicturePath = a.PicturePath
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet]
        [ActionName("GetSlider")]
        public async Task<ActionResult<IEnumerable<Product>>> GetSlider()
        {
            var result = await (from a in _context.Product
                                where a.IsSlider == true
                                select new
                                {
                                    ProductId = a.ProductId,
                                    Name = a.Name,
                                    UserId = a.UserId,
                                    Quantity = a.Quantity,
                                    SalePrice = a.SalePrice,
                                    Image = a.Image,
                                    IsActive = a.IsActive,
                                    ShortDetails = a.ShortDetails,
                                    Code = a.Code,
                                    OriginalPrice = a.OriginalPrice,
                                    ProductType = a.ProductType,
                                    YoutubeLink = a.YoutubeLink,
                                    Description = a.Description
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet("{name}")]
        [ActionName("GetAllDetailsSearch")]
        public async Task<ActionResult<IList<ProductView>>> GetAllDetailsSearch(string name)
        {
            using (SqlConnection sqlcon = new SqlConnection(_conn.DbConn))
            {
                var para = new DynamicParameters();
                para.Add("@name", name);
                var ListofPlan = sqlcon.Query<ProductView>("SearchView", para, null, true, 0, commandType: CommandType.StoredProcedure).ToList();
                return ListofPlan;
            }
        }
        [HttpGet]
        [ActionName("GetUser")]
        public async Task<ActionResult<IList<UserDTO>>> GetUser(string name)
        {
            return await _context.Users
                 .Select(x => new UserDTO { Email = x.Email }).ToListAsync();
        }
    }
}
