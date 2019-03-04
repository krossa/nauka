﻿// Copyright (c) 2017 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.EfClasses;
using ServiceLayer.CheckoutServices.Concrete;
using ServiceLayer.OrderServices.Concrete;
using test.EfHelpers;
using test.Mocks;
using Xunit;
using Xunit.Extensions.AssertExtensions;

namespace test.UnitTests.ServiceLayer
{
    public class Ch04_DisplayOrderService
    {
        [Fact]
        public void TestGetUsersOrdersOk()
        {
            //SETUP
            var inMemDb = new SqliteInMemory();

            using (var context = inMemDb.GetContextWithSetup())
            {
                context.SeedDatabaseFourBooks();
                var userId = Guid.NewGuid();

                var order = new Order
                {
                    CustomerName = userId,
                    LineItems = new List<LineItem>
                    {
                        new LineItem
                        {
                            BookId = 1,
                            LineNum = 0,
                            BookPrice = 123,
                            NumBooks = 456
                        }
                    }
                };
                context.Orders.Add(order);
                context.SaveChanges();
                var mockCookieRequests = new MockHttpCookieAccess(CheckoutCookie.CheckoutCookieName, $"{userId}");
                var service = new DisplayOrdersService(context);

                //ATTEMPT
                var orders = service.GetUsersOrders(mockCookieRequests.CookiesIn);

                //VERIFY
                orders.Count.ShouldEqual(1);
                orders.First().LineItems.ShouldNotBeNull();
                var lineItems = orders.First().LineItems.ToList();
                lineItems.Count.ShouldEqual(1);
                lineItems.First().BookId.ShouldEqual(1);
                lineItems.First().BookPrice.ShouldEqual(123);
                lineItems.First().NumBooks.ShouldEqual((short)456);
            }
        }


        [Fact]
        public void TestGetOrderDetailOk()
        {
            //SETUP
            var inMemDb = new SqliteInMemory();

            using (var context = inMemDb.GetContextWithSetup())
            {
                context.SeedDatabaseFourBooks();
                var userId = Guid.NewGuid();

                var order = new Order
                {
                    CustomerName = userId,
                    LineItems = new List<LineItem>
                    {
                        new LineItem
                        {
                            BookId = 1,
                            LineNum = 0,
                            BookPrice = 123,
                            NumBooks = 456
                        }
                    }
                };
                context.Orders.Add(order);
                context.SaveChanges();
                var service = new DisplayOrdersService(context);

                //ATTEMPT
                var dto = service.GetOrderDetail(1);

                //VERIFY
                var lineItems = dto.LineItems.ToList();
                lineItems.Count.ShouldEqual(1);
                lineItems.First().BookId.ShouldEqual(1);
                lineItems.First().BookPrice.ShouldEqual(123);
                lineItems.First().NumBooks.ShouldEqual((short)456);
            }
        }

        [Fact]
        public void TestGetOrderDetailNotFound()
        {
            //SETUP
            var inMemDb = new SqliteInMemory();

            using (var context = inMemDb.GetContextWithSetup())
            {
                var service = new DisplayOrdersService(context);

                //ATTEMPT
                var ex = Assert.Throws<NullReferenceException>(() => service.GetOrderDetail(1));

                //VERIFY
                ex.Message.ShouldEqual("Could not find the order with id of 1.");
            }
        }
    }
}