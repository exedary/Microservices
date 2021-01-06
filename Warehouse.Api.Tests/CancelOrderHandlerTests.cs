using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Api.Domain.Repositories;
using Warehouse.Api.Features.CancelOrder;
using Warehouse.Api.Features.CancelOrder.Dto;
using Warehouse.Api.Infrastructure.Database;
using Warehouse.Api.Infrastructure.Database.Repositories;
using Warehouse.Api.Infrastructure.ExternalServices;

namespace Warehouse.Api.Tests
{
    public class CancelOrderTests
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
        public async Task CancelOrderHandlerWorks()
        {
            var warrantyServiceMock = new Mock<IWarrantyService>();
            var handler = new CancelOrderCommandHandler(itemsRepository, ordersRepository, _mockDbContext, warrantyServiceMock.Object);

            var guid = Guid.NewGuid();

            SeedDb(guid);

            var result = await handler.Handle(new CancelOrderCommand(guid), It.IsAny<CancellationToken>());

            Assert.That(result.IsCompleted);
            Assert.That(_mockDbContext.Items.Find(1).AvailableCount == 3);
            Assert.That((await ordersRepository.GetById(guid)).Canceled == true);
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