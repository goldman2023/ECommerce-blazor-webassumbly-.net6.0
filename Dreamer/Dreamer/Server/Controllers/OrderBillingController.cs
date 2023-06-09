using Dapper;
using Dreamer.Server.Data;
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
    public class OrderBillingController : ControllerBase
    {
        private readonly DatabaseConnection _conn;
        private readonly ApplicationDbContext _context;
        public OrderBillingController(ApplicationDbContext context, DatabaseConnection conn)
        {
            _conn = conn;
            _context = context;
        }
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<OrderMaster>>> GetAll()
        {
            var result = await (from a in _context.OrderMaster
                                orderby a.OrderMasterId descending
                                select new
                                {
                                    OrderMasterId = a.OrderMasterId,
                                    OrderNo = a.OrderNo,
                                    UserId = a.UserId,
                                    FirstName = a.FirstName,
                                    LastName = a.LastName,
                                    CountryId = a.CountryId,
                                    StateId = a.StateId,
                                    Address = a.Address,
                                    EmailId = a.EmailId,
                                    Phone = a.Phone,
                                    Total = a.Total,
                                    CustomerId = a.CustomerId,
                                    IsActive = a.IsActive,
                                    OrderDate = a.OrderDate,
                                    DeliveredDate = a.DeliveredDate,
                                    AddedDate = a.AddedDate,
                                    ModifyDate = a.ModifyDate
                                }).Take(10).ToListAsync();
            return Ok(result);
        }



        [HttpGet]
        [ActionName("GetAllOrder")]
        public async Task<ActionResult<IEnumerable<OrderMaster>>> GetAllOrder(int id)
        {
            //string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await (from a in _context.OrderMaster
                                orderby a.OrderMasterId descending
                                where a.CustomerId == id
                                select new
                                {
                                    OrderMasterId = a.OrderMasterId,
                                    OrderNo = a.OrderNo,
                                    UserId = a.UserId,
                                    FirstName = a.FirstName,
                                    LastName = a.LastName,
                                    CountryId = a.CountryId,
                                    StateId = a.StateId,
                                    Address = a.Address,
                                    EmailId = a.EmailId,
                                    Total = a.Total,
                                    Phone = a.Phone,
                                    CustomerId = a.CustomerId,
                                    IsActive = a.IsActive,
                                    OrderDate = a.OrderDate,
                                    DeliveredDate = a.DeliveredDate,
                                    AddedDate = a.AddedDate,
                                    ModifyDate = a.ModifyDate
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet]
        [ActionName("GetAllOrderAdmin")]
        public async Task<ActionResult<IEnumerable<OrderMaster>>> GetAllOrderAdmin(int id)
        {
            //string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await (from a in _context.OrderMaster
                                orderby a.OrderMasterId descending
                                select new
                                {
                                    OrderMasterId = a.OrderMasterId,
                                    OrderNo = a.OrderNo,
                                    UserId = a.UserId,
                                    FirstName = a.FirstName,
                                    LastName = a.LastName,
                                    CountryId = a.CountryId,
                                    StateId = a.StateId,
                                    Address = a.Address,
                                    EmailId = a.EmailId,
                                    Total = a.Total,
                                    Phone = a.Phone,
                                    CustomerId = a.CustomerId,
                                    IsActive = a.IsActive,
                                    OrderDate = a.OrderDate,
                                    DeliveredDate = a.DeliveredDate,
                                    AddedDate = a.AddedDate,
                                    ModifyDate = a.ModifyDate
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet]
        [ActionName("GetAllpendingOrderAdmin")]
        public async Task<ActionResult<IEnumerable<OrderMaster>>> GetAllpendingOrderAdmin(int id)
        {
            //string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await (from a in _context.OrderMaster
                                where a.IsActive == "Order"
                                orderby a.OrderMasterId descending
                                select new
                                {
                                    OrderMasterId = a.OrderMasterId,
                                    OrderNo = a.OrderNo,
                                    UserId = a.UserId,
                                    FirstName = a.FirstName,
                                    LastName = a.LastName,
                                    CountryId = a.CountryId,
                                    StateId = a.StateId,
                                    Address = a.Address,
                                    EmailId = a.EmailId,
                                    Total = a.Total,
                                    Phone = a.Phone,
                                    CustomerId = a.CustomerId,
                                    IsActive = a.IsActive,
                                    OrderDate = a.OrderDate,
                                    DeliveredDate = a.DeliveredDate,
                                    AddedDate = a.AddedDate,
                                    ModifyDate = a.ModifyDate
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet]
        [ActionName("GetAllOnGoingOrderAdmin")]
        public async Task<ActionResult<IEnumerable<OrderMaster>>> GetAllOnGoingOrderAdmin(int id)
        {
            var result = await (from a in _context.OrderMaster
                                where a.IsActive == "OnGoing"
                                orderby a.OrderMasterId descending
                                select new
                                {
                                    OrderMasterId = a.OrderMasterId,
                                    OrderNo = a.OrderNo,
                                    UserId = a.UserId,
                                    FirstName = a.FirstName,
                                    LastName = a.LastName,
                                    CountryId = a.CountryId,
                                    StateId = a.StateId,
                                    Address = a.Address,
                                    EmailId = a.EmailId,
                                    Total = a.Total,
                                    Phone = a.Phone,
                                    CustomerId = a.CustomerId,
                                    IsActive = a.IsActive,
                                    OrderDate = a.OrderDate,
                                    DeliveredDate = a.DeliveredDate,
                                    AddedDate = a.AddedDate,
                                    ModifyDate = a.ModifyDate
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet]
        [ActionName("GetAlldeliveredOrderAdmin")]
        public async Task<ActionResult<IEnumerable<OrderMaster>>> GetAlldeliveredOrderAdmin(int id)
        {
            var result = await (from a in _context.OrderMaster
                                where a.IsActive == "Delivered"
                                orderby a.OrderMasterId descending
                                select new
                                {
                                    OrderMasterId = a.OrderMasterId,
                                    OrderNo = a.OrderNo,
                                    UserId = a.UserId,
                                    FirstName = a.FirstName,
                                    LastName = a.LastName,
                                    CountryId = a.CountryId,
                                    StateId = a.StateId,
                                    Address = a.Address,
                                    EmailId = a.EmailId,
                                    Total = a.Total,
                                    Phone = a.Phone,
                                    CustomerId = a.CustomerId,
                                    IsActive = a.IsActive,
                                    OrderDate = a.OrderDate,
                                    DeliveredDate = a.DeliveredDate,
                                    AddedDate = a.AddedDate,
                                    ModifyDate = a.ModifyDate
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet]
        [ActionName("GetAllrejectedOrderAdmin")]
        public async Task<ActionResult<IEnumerable<OrderMaster>>> GetAllrejectedOrderAdmin(int id)
        {
            var result = await (from a in _context.OrderMaster
                                where a.IsActive == "Rejected"
                                orderby a.OrderMasterId descending
                                select new
                                {
                                    OrderMasterId = a.OrderMasterId,
                                    OrderNo = a.OrderNo,
                                    UserId = a.UserId,
                                    FirstName = a.FirstName,
                                    LastName = a.LastName,
                                    CountryId = a.CountryId,
                                    StateId = a.StateId,
                                    Address = a.Address,
                                    EmailId = a.EmailId,
                                    Total = a.Total,
                                    Phone = a.Phone,
                                    CustomerId = a.CustomerId,
                                    IsActive = a.IsActive,
                                    OrderDate = a.OrderDate,
                                    DeliveredDate = a.DeliveredDate,
                                    AddedDate = a.AddedDate,
                                    ModifyDate = a.ModifyDate
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet]
        [ActionName("GetAllOrderAdminDeliver")]
        public async Task<ActionResult<IEnumerable<OrderMaster>>> GetAllOrderAdminDeliver(int id)
        {
            //string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await (from a in _context.OrderMaster
                                where a.IsActive == "Delivered"
                                orderby a.OrderMasterId descending
                                select new
                                {
                                    OrderMasterId = a.OrderMasterId,
                                    OrderNo = a.OrderNo,
                                    UserId = a.UserId,
                                    FirstName = a.FirstName,
                                    LastName = a.LastName,
                                    CountryId = a.CountryId,
                                    StateId = a.StateId,
                                    Address = a.Address,
                                    EmailId = a.EmailId,
                                    Total = a.Total,
                                    Phone = a.Phone,
                                    CustomerId = a.CustomerId,
                                    IsActive = a.IsActive,
                                    OrderDate = a.OrderDate,
                                    DeliveredDate = a.DeliveredDate,
                                    AddedDate = a.AddedDate,
                                    ModifyDate = a.ModifyDate
                                }).ToListAsync();
            return Ok(result);
        }



        [HttpGet("{Id}")]
        [ActionName("GetbyId")]
        public async Task<ActionResult> GetbyId(long id)
        {
            var dev = await _context.OrderMaster.FirstOrDefaultAsync(a => a.OrderMasterId == id);
            return Ok(dev);
        }
        [HttpGet("{Id}")]
        [ActionName("GetOrderDetailsId")]
        public async Task<ActionResult> GetOrderDetailsId(int id)
        {
            var result = await (from a in _context.OrderMaster
                                where a.CustomerId == id
                                select new
                                {
                                    OrderMasterId = a.OrderMasterId,
                                    UserId = a.UserId,
                                    FirstName = a.FirstName,
                                    LastName = a.LastName,
                                    CountryId = a.CountryId,
                                    StateId = a.StateId,
                                    Address = a.Address,
                                    EmailId = a.EmailId,
                                    Phone = a.Phone,
                                    CustomerId = a.CustomerId,
                                    IsActive = a.IsActive,
                                    OrderDate = a.OrderDate,
                                    DeliveredDate = a.DeliveredDate,
                                    AddedDate = a.AddedDate,
                                    ModifyDate = a.ModifyDate
                                }).Take(1).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{Id}")]
        [ActionName("GetOrderCustomer")]
        public async Task<ActionResult> GetOrderCustomer(int id)
        {
            //string userId = User.FindFirst(ClaimTypes.Name).Value;
            //string email = User.FindFirst(ClaimTypes.Email).Value;
            var result = await (from a in _context.OrderMaster
                                where a.CustomerId == id
                                select new
                                {
                                    OrderMasterId = a.OrderMasterId,
                                    OrderNo = a.OrderNo,
                                    UserId = a.UserId,
                                    FirstName = a.FirstName,
                                    LastName = a.LastName,
                                    CountryId = a.CountryId,
                                    StateId = a.StateId,
                                    Address = a.Address,
                                    EmailId = a.EmailId,
                                    Phone = a.Phone,
                                    Total = a.Total,
                                    CustomerId = a.CustomerId,
                                    IsActive = a.IsActive,
                                    OrderDate = a.OrderDate,
                                    DeliveredDate = a.DeliveredDate,
                                    AddedDate = a.AddedDate,
                                    ModifyDate = a.ModifyDate
                                }).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{Id}")]
        [ActionName("GetOrderDeliveryboy")]
        public async Task<ActionResult> GetOrderDeliveryboy(string id)
        {
            //string userId = User.FindFirst(ClaimTypes.Name).Value;
            //string email = User.FindFirst(ClaimTypes.Email).Value;
            var result = await (from a in _context.OrderMaster
                                where a.UserId == id
                                select new
                                {
                                    OrderMasterId = a.OrderMasterId,
                                    OrderNo = a.OrderNo,
                                    UserId = a.UserId,
                                    FirstName = a.FirstName,
                                    LastName = a.LastName,
                                    CountryId = a.CountryId,
                                    StateId = a.StateId,
                                    Address = a.Address,
                                    EmailId = a.EmailId,
                                    Phone = a.Phone,
                                    Total = a.Total,
                                    CustomerId = a.CustomerId,
                                    IsActive = a.IsActive,
                                    OrderDate = a.OrderDate,
                                    DeliveredDate = a.DeliveredDate,
                                    AddedDate = a.AddedDate,
                                    ModifyDate = a.ModifyDate
                                }).ToListAsync();
            return Ok(result);
        }



        [HttpGet("{Id}")]
        [ActionName("GetOrderCustomerDetails")]
        public async Task<ActionResult> GetOrderCustomerDetails(int id)
        {
            var result = await (from a in _context.OrderDetails
                                join b in _context.Product on a.ProductId equals b.ProductId
                                where a.OrderMasterId == id
                                select new
                                {
                                    OrderMasterId = a.OrderMasterId,
                                    OrderDetailsId = a.OrderDetailsId,
                                    Name = b.Name,
                                    Qty = a.Qty,
                                    Rate = a.Rate,
                                    Amount = a.Amount
                                }).ToListAsync();
            return Ok(result);
        }
        [HttpGet("{Id}")]
        [ActionName("GetOrderCustomerlatest")]
        public async Task<ActionResult> GetOrderCustomerlatest(int id)
        {
            var result = await (from a in _context.OrderDetails
                                join b in _context.Product on a.ProductId equals b.ProductId
                                where a.OrderMasterId == id
                                select new
                                {
                                    OrderMasterId = a.OrderMasterId,
                                    OrderDetailsId = a.OrderDetailsId,
                                    Name = b.Name,
                                    Qty = a.Qty,
                                    Rate = a.Rate,
                                    Amount = a.Amount
                                }).Take(10).ToListAsync();
            return Ok(result);
        }
        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> Save([FromBody] OrderMaster model)
        {
            //Order table
            //GetOrderNo
            long val;
            using (SqlConnection sqlcon = new SqlConnection(_conn.DbConn))
            {
                //para.Add("@yearId", yearId);
                val = sqlcon.Query<long>("SELECT ISNULL( MAX(OrderNo+1),1) FROM OrderMaster", null, null, true, 0, commandType: CommandType.Text).SingleOrDefault();
            }
            if (val > 0)
            {
                model.OrderNo = val.ToString();
                _context.OrderMaster.Add(model);
                await _context.SaveChangesAsync();
                //OrderItems table
                foreach (var item in model.listOrder)
                {
                    if (item != null)
                    {
                        item.OrderMasterId = model.OrderMasterId;
                        _context.OrderDetails.Add(item);
                        await _context.SaveChangesAsync();
                    }
                }
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> Update([FromBody] OrderMaster model)
        {
            _context.OrderMaster.Update(model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [ActionName("OrderPending")]
        public async Task<ActionResult<OrderDetailsView>> OrderPending()
        {
            using (SqlConnection sqlcon = new SqlConnection(_conn.DbConn))
            {
                var para = new DynamicParameters();
                var returnView = sqlcon.Query<OrderDetailsView>("SELECT COUNT(OrderMasterId) as OrderPending FROM OrderMaster where IsActive='Order'", null, null, true, 0, CommandType.Text).SingleOrDefault();
                return returnView;
            }
        }
        [HttpGet]
        [ActionName("OrderCancel")]
        public async Task<ActionResult<OrderDetailsView>> OrderCancel()
        {
            using (SqlConnection sqlcon = new SqlConnection(_conn.DbConn))
            {
                var para = new DynamicParameters();
                var returnView = sqlcon.Query<OrderDetailsView>("SELECT COUNT(OrderMasterId) as OrderCancel FROM OrderMaster where IsActive='Cancelled'", null, null, true, 0, CommandType.Text).SingleOrDefault();
                return returnView;
            }
        }
        [HttpGet]
        [ActionName("OnGoing")]
        public async Task<ActionResult<OrderDetailsView>> OnGoing()
        {
            using (SqlConnection sqlcon = new SqlConnection(_conn.DbConn))
            {
                var para = new DynamicParameters();
                var returnView = sqlcon.Query<OrderDetailsView>("SELECT COUNT(OrderMasterId) as OnGoing FROM OrderMaster where IsActive='OnGoing'", null, null, true, 0, CommandType.Text).SingleOrDefault();
                return returnView;
            }
        }
        //Vendor

        [HttpGet]
        [ActionName("TotalIncome")]
        public async Task<ActionResult<OrderDetailsView>> TotalIncome()
        {
            //string UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            using (SqlConnection sqlcon = new SqlConnection(_conn.DbConn))
            {
                var para = new DynamicParameters();
                //para.Add("@UserId", UserId);
                var returnView = sqlcon.Query<OrderDetailsView>("SELECT SUM(Total) as TotalIncome FROM OrderMaster where IsActive='Delivered'", null, null, true, 0, CommandType.Text).SingleOrDefault();
                return returnView;
            }
        }
    }
}
