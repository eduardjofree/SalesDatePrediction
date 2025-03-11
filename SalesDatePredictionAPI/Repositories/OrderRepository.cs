using Microsoft.EntityFrameworkCore;
using SalesDatePredictionAPI.Data;
using SalesDatePredictionAPI.DTOs;
using SalesDatePredictionAPI.Interfaces;
using SalesDatePredictionAPI.Models;

namespace SalesDatePredictionAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreSampleDbContext _context;

        public OrderRepository(StoreSampleDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByCustomerAsync(int customerId)
        {
            return await _context.Orders
                .Where(o => o.custid == customerId)
                .OrderByDescending(o => o.orderdate)
                .ToListAsync();
        }

        public async Task<List<ResponsePredictOrderForDateDto>> GetCustomersWithOrderPredictionAsync()
        {
            var customers = await _context.Customers
                .Select(c => new
                {
                    CustomerID = c.custid,
                    CustomerName = c.companyname,
                    LastOrderDate = _context.Orders
                        .Where(o => o.custid == c.custid)
                        .OrderByDescending(o => o.orderdate)
                        .Select(o => (DateTime?)o.orderdate)
                        .FirstOrDefault(),
                    OrderDates = _context.Orders
                        .Where(o => o.custid == c.custid)
                        .OrderBy(o => o.orderdate)
                        .Select(o => o.orderdate)
                        .ToList()
                })
                .ToListAsync();

            var result = customers.Select(c => new ResponsePredictOrderForDateDto
            {
                CustomerId = c.CustomerID,
                CustomerName = c.CustomerName,
                LastOrderDate = c.LastOrderDate,
                NextPredictOrder = c.LastOrderDate.HasValue
                    ? c.LastOrderDate.Value.AddDays(
                        c.OrderDates.Zip(c.OrderDates.Skip(1), (prev, next) => (next - prev).TotalDays)
                            .DefaultIfEmpty(30)
                            .Average()
                    )
                    : null
            }).ToList();

            return result;
        }

        public async Task<Order> CreateOrderAsync(Order order, OrderDetail orderDetail)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();

                    orderDetail.orderid = order.orderid;
                    _context.OrderDetails.Add(orderDetail);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                    return order;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<List<ResponsePredictOrderForDateDto>> GetByCustomersWithOrderPredictionAsync(string search)
        {
            var customers = await _context.Customers
                .Where(c => string.IsNullOrEmpty(search) || c.companyname.Contains(search))
                .Select(c => new
                {
                    CustomerID = c.custid,
                    CustomerName = c.companyname,
                    LastOrderDate = _context.Orders
                        .Where(o => o.custid == c.custid)
                        .OrderByDescending(o => o.orderdate)
                        .Select(o => (DateTime?)o.orderdate)
                        .FirstOrDefault(),
                    OrderDates = _context.Orders
                        .Where(o => o.custid == c.custid)
                        .OrderBy(o => o.orderdate)
                        .Select(o => o.orderdate)
                        .ToList()
                })
                .ToListAsync();

            var result = customers.Select(c => new ResponsePredictOrderForDateDto
            {
                CustomerId = c.CustomerID,
                CustomerName = c.CustomerName,
                LastOrderDate = c.LastOrderDate,
                NextPredictOrder = c.OrderDates.Count > 1
                    ? c.LastOrderDate.Value.AddDays(
                        c.OrderDates.Zip(c.OrderDates.Skip(1), (prev, next) => (next - prev).TotalDays)
                            .DefaultIfEmpty(30)
                            .Average()
                    )
                    : c.LastOrderDate?.AddDays(30)
            }).ToList();

            return result;
        }


    }
}

