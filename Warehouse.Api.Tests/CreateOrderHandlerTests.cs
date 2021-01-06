using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Api.Domain.Repositories;
using Warehouse.Api.Features.CreateOrder;
using Warehouse.Api.Features.CreateOrder.Dto;
using Warehouse.Api.Infrastructure.Database;
using Warehouse.Api.Infrastructure.Database.Repositories;
using Warehouse.Api.Infrastructure.ExternalServices;

namespace Warehouse.Api.Tests
{
    class CreateOrderHandlerTests
    {
        private WarehouseDbContext _mockDbContext;
        private IOrdersRepository ordersRepository;
        private IItemsRepository itemsRepository;

        [SetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder().UseInMemoryDatabase("test_db").Options;
            _mockDbContext = new WarehouseDbContext(dbContextOptions);
            ordersRepository = new OrdersRepository(_mockDbContext);
            itemsRepository = new ItemsRepository(_mockDbContext);
        }

        [Test]
        public async Task CreateOrderHandlerWorks()
        {
            var warrantyServiceMock = new Mock<IWarrantyService>();
            var handler = new CreateOrderCommandHandler(itemsRepository, ordersRepository, _mockDbContext, warrantyServiceMock.Object);

            var guid = Guid.NewGuid();

            SeedDb(guid);

            var result = await handler.Handle(new CreateOrderCommand { Model="1", Size="2" }, It.IsAny<CancellationToken>());

            Assert.That(result.IsCompleted);
            Assert.That(_mockDbContext.Items.Find(1).AvailableCount == 1);
            Assert.That((await ordersRepository.GetById(guid)).Canceled == false);
        }

        private void SeedDb(params Guid[] guids)
        {
            _mockDbContext.Orders.AddRange(guids.Select(x => new Domain.Order
            {
                Canceled = false,
                ItemId = 1,
                OrderUid = x,
                OrderItemUid = x,
            }));
            _mockDbContext.Items.Add(new Domain.Item { Id = 1, AvailableCount = 2, Model = "1", Size = "2" });
            _mockDbContext.SaveChanges();
        }
    }
}
