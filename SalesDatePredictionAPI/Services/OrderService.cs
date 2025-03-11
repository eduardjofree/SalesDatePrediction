using SalesDatePredictionAPI.DTOs;
using SalesDatePredictionAPI.Interfaces;
using SalesDatePredictionAPI.Models;
using SalesDatePredictionAPI.Repositories;

namespace SalesDatePredictionAPI.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IShipperRepository _shipperRepository;

        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository, IEmployeesRepository employeesRepository, IShipperRepository shipperRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _employeesRepository = employeesRepository;
            _shipperRepository = shipperRepository;
        }

        public async Task<List<OrdersDto>> GetOrdersByCustomerAsync(int customerId)
        {
            var resultCustomers = await _customerRepository.GetCustomerAsync();
            var resultEmployees = await _employeesRepository.GetEmployeesAsync();
            var resultShippers = await _shipperRepository.GetShipperAsync();
            var resultOrders = await _orderRepository.GetOrdersByCustomerAsync(customerId);

            var responseOrders = resultOrders.Select(order =>
            {
                var customer = resultCustomers.FirstOrDefault(c => c.custid == order.custid);
                var employee = resultEmployees.FirstOrDefault(e => e.EmpId == order.empid);
                var shipper = resultShippers.FirstOrDefault(s => s.Shipperid == order.shipperid);

                return new OrdersDto
                {
                    Orderid = order.orderid,
                    Requireddate = order.requireddate.ToString("yyyy-MM-dd"),
                    Shippeddate = order.shippeddate.HasValue ? order.shippeddate.Value.ToString("yyyy-MM-dd") : null,
                    Shipname = order.shipname,
                    Shipaddress = order.shipaddress,
                    Shipcity = order.shipcity
                };
            }).ToList();

            return responseOrders;
        }

        public async Task<List<ResponsePredictOrderForDateDto>> GetCustomersWithOrderPredictionAsync()
        {
            return await _orderRepository.GetCustomersWithOrderPredictionAsync();
        }

        public async Task<Order> CreateOrderAsync(
            int customerId, int empId, int shipperId, string shipName, string shipAddress,
            string shipCity, string shipCountry, string? shipRegion, string shipPostalCode,
            int productId, decimal unitPrice, int quantity,
            DateTime orderDate, DateTime requiredDate, DateTime? shippedDate, decimal freight, decimal discount)
        {

            // Crear la orden
            var newOrder = new Order
            {
                custid = customerId,
                empid = empId,
                shipperid = shipperId,
                orderdate = orderDate,
                requireddate = requiredDate,
                shippeddate = shippedDate,
                freight = freight, // Se usa el parámetro en lugar de un valor fijo
                shipname = shipName,
                shipaddress = shipAddress,
                shipcity = shipCity,
                shipregion = shipRegion,
                shippostalcode = shipPostalCode,
                shipcountry = shipCountry
            };

            // Crear el detalle de la orden
            var newOrderDetail = new OrderDetail
            {
                productid = productId,
                unitprice = unitPrice,
                qty = quantity,
                discount = discount // Se usa el parámetro en lugar de un valor fijo
            };

            // Guardar en la BD utilizando el repositorio con transacción
            return await _orderRepository.CreateOrderAsync(newOrder, newOrderDetail);
        }

        public async Task<IEnumerable<ResponsePredictOrderForDateDto>> GetOrderByCustomersPrediceAsync(string search)
        {
            return await _orderRepository.GetByCustomersWithOrderPredictionAsync(search);
        }

    }
}


