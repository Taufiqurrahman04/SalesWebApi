using AutoMapper;
using Moq;
using Net.AutoMapper;
using SalesOrderWebApi.Controllers;
using SalesOrderWebApi.Models.DataModifyViewModels;
using SalesOrderWebApi.Models.DataViewModels;
using SalesOrderWebApi.Models.MediatRRequestModels;
using SalesOrderWebApi.Resource;
namespace SalesOrderWebApi.Test
{
    public class OrderControllerTest : BaseControllerTest<OrderController>
    {

        [Fact]
        public async Task GetAllOrderData_AndReturnTwoRecord()
        {
            _mediatRMock.Setup(s => s.Send(It.IsAny<GetOrders>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    // Simulate the result you want to return
                    var orders = new List<order>
                    {
                        new order { id = "1" },
                        new order { id = "2" },
                    };

                    return orders;
                });

            var controller = new OrderController(_mediatRMock.Object, _loggerMock.Object, _mapper);

            var result = await controller.Get();

            Assert.NotNull(result);
            Assert.True(result.Datas?.Any());
            Assert.Equal(2, result.Datas?.Count());
            Assert.Equal(200,result.StatusCode);
        }

       [Fact]
       public async Task GetSalesB2BData_AndReturnTwoRecord()
       {
            _mediatRMock.Setup(s => s.Send(It.IsAny<GetSalesB2BOrders>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    // Simulate the result you want to return
                    var orders = new List<order>
                    {
                        new order { id = "1" },
                        new order { id = "2" },
                    };

                    return orders;
                });

            var controller = new OrderController(_mediatRMock.Object, _loggerMock.Object, _mapper);

            var result = await controller.GetSalesB2B();

           Assert.NotNull(result);
           Assert.True(result.Datas?.Any());
           Assert.Equal(2,result.Datas?.Count());
           Assert.Equal(200, result.StatusCode);
       }

        [Fact]
        public async Task GetSalesRetailData_AndReturnTwoRecord()
        {
            _mediatRMock.Setup(s => s.Send(It.IsAny<GetSalesRetailOrders>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    // Simulate the result you want to return
                    var orders = new List<order>
                    {
                        new order { id = "1" },
                        new order { id = "2" },
                    };

                    return orders;
                });

            var controller = new OrderController(_mediatRMock.Object, _loggerMock.Object, _mapper);

            var result = await controller.GetSalesRetail();

            Assert.NotNull(result);
            Assert.True(result.Datas?.Any());
            Assert.Equal(2, result.Datas?.Count());
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetOrderDataById_AndReturnADataWithCorrectId()
        {
            _mediatRMock.Setup(s => s.Send(It.IsAny<GetOrderById>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    // Simulate the result you want to return
                    var order = new order
                    {
                        id = "1" 
                    };

                    return order;
                });

            var controller = new OrderController(_mediatRMock.Object, _loggerMock.Object, _mapper);

            string input = "1";

            var result = await controller.Get(input);

            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.Equal(input, result.Data.id);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task GetOrderDataById_WithWrongParameter_AndReturnCorrectResponse()
        {
            _mediatRMock.Setup(s => s.Send(It.Is<GetOrderById>(a=>a.Id == "1"), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    // Simulate the result you want to return
                    var order = new order
                    {
                        id = "1"
                    };

                    return order;
                });

            var controller = new OrderController(_mediatRMock.Object, _loggerMock.Object, _mapper);

            string input = "23";

            var result = await controller.Get(input);

            Assert.NotNull(result);
            Assert.Null(result.Data);
            Assert.NotEqual(input, result.Data?.id);
            Assert.Equal(204, result.StatusCode);
        }

        [Fact]
        public async Task GetOrderDataById_WithNullParameter_AndReturnCorrectResponse()
        {
            _mediatRMock.Setup(s => s.Send(It.Is<GetOrderById>(s=>s.Id == "1"), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    // Simulate the result you want to return
                    var order = new order
                    {
                        id = "1"
                    };

                    return order;
                });

            var controller = new OrderController(_mediatRMock.Object, _loggerMock.Object, _mapper);

            string input = null;

            var result = await controller.Get(input);

            Assert.NotNull(result);
            Assert.Null(result.Data);
            Assert.Equal(input, result.Data?.id);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task CreateNewOrder_WithCorrectParameter_andReturnCorrectResponse()
        {
            _mediatRMock.Setup(s => s.Send(It.Is<CreateOrder>(s => s.customer_id == "1" && s.order_type == OrderType.BtoB), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    // Simulate the result you want to return
                    var order = new order
                    {
                        customer_id = "1",
                        order_type = OrderType.BtoB
                    };

                    return order;
                });

            var controller = new OrderController(_mediatRMock.Object, _loggerMock.Object, _mapper);

            var input = new base_order
            {
                customer_id = "1",
                order_type = OrderType.BtoB,
                store_id = "1",
                order_date = DateTime.Now,
                total_amount = 20000
            };

            var response = await controller.Post(input);

            Assert.NotNull(response);
            Assert.NotNull(response.Data);
            Assert.Equal(input.customer_id, response.Data?.customer_id);
            Assert.Equal(input.order_type, response.Data?.order_type);
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async Task CreateNewOrder_WithInvalidParameter_andReturnCorrectResponse()
        {
            _mediatRMock.Setup(s => s.Send(It.Is<CreateOrder>(s => s.customer_id == "1" && s.order_type == OrderType.BtoB), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    // Simulate the result you want to return
                    var order = new order
                    {
                        customer_id = "1",
                        order_type = OrderType.BtoB
                    };

                    return order;
                });

            

            var controller = new OrderController(_mediatRMock.Object, _loggerMock.Object, _mapper);

            var input = new base_order
            {
                customer_id = "",
                order_type = OrderType.BtoB,
                store_id = "",
                order_date = DateTime.Now,
                total_amount = 20000
            };

            var response = await controller.Post(input);

            Assert.NotNull(response);
            Assert.Null(response.Data);
            Assert.Equal(304, response.StatusCode);
        }

        [Fact]
        public async Task UpdateOrder_WithCorrectParameter_andReturnCorrectResponse()
        {
            _mediatRMock.Setup(s => s.Send(It.Is<UpdateOrder>(s => s.id == "11" && s.customer_id == "1" && s.order_type == OrderType.BtoB), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    // Simulate the result you want to return
                    var order = new order
                    {
                        id = "11",
                        customer_id = "1",
                        order_type = OrderType.BtoB
                    };

                    return order;
                });

            var controller = new OrderController(_mediatRMock.Object, _loggerMock.Object, _mapper);

            string id = "11";
            var input = new base_order
            {
                customer_id = "1",
                order_type = OrderType.BtoB,
                store_id = "1",
                order_date = DateTime.Now,
                total_amount = 20000
            };

            var response = await controller.Put(id, input);

            Assert.NotNull(response);
            Assert.NotNull(response.Data);
            Assert.Equal(id, response.Data?.id);
            Assert.Equal(input.customer_id, response.Data?.customer_id);
            Assert.Equal(input.order_type, response.Data?.order_type);
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async Task UpdateOrder_WithIdNull_andReturnCorrectResponse()
        {
            _mediatRMock.Setup(s => s.Send(It.Is<UpdateOrder>(s => s.id == "11" && s.customer_id == "1" && s.order_type == OrderType.BtoB), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    // Simulate the result you want to return
                    var order = new order
                    {
                        id = "11",
                        customer_id = "1",
                        order_type = OrderType.BtoB
                    };

                    return order;
                });

            var controller = new OrderController(_mediatRMock.Object, _loggerMock.Object, _mapper);

            string id = null;
            var input = new base_order
            {
                customer_id = "1",
                order_type = OrderType.BtoB,
                store_id = "1",
                order_date = DateTime.Now,
                total_amount = 20000
            };

            var response = await controller.Put(id, input);

            Assert.NotNull(response);
            Assert.Null(response.Data);
            Assert.Equal(400, response.StatusCode);
        }

        [Fact]
        public async Task DeleteOrder_WithCorrectParameter_andReturnCorrectResponse()
        {
            _mediatRMock.Setup(s => s.Send(It.Is<DeleteOrder>(s => s.Id == "11"), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    // Simulate the result you want to return
                    var order = new order
                    {
                        id = "11",
                        customer_id = "1",
                        order_type = OrderType.BtoB
                    };

                    return order;
                });

            var controller = new OrderController(_mediatRMock.Object, _loggerMock.Object, _mapper);

            string id = "11";

            var response = await controller.Delete(id);

            Assert.NotNull(response);
            Assert.NotNull(response.Data);
            Assert.Equal(id, response.Data?.id);
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async Task DeleteOrder_WithInvalidParameter_andReturnCorrectResponse()
        {
            _mediatRMock.Setup(s => s.Send(It.Is<DeleteOrder>(s => s.Id == "11"), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() =>
                {
                    // Simulate the result you want to return
                    var order = new order
                    {
                        id = "11",
                        customer_id = "1",
                        order_type = OrderType.BtoB
                    };

                    return order;
                });

            var controller = new OrderController(_mediatRMock.Object, _loggerMock.Object, _mapper);

            string id = "";

            var response = await controller.Delete(id);

            Assert.NotNull(response);
            Assert.Null(response.Data);
            Assert.Equal(400, response.StatusCode);
        }
    }
}