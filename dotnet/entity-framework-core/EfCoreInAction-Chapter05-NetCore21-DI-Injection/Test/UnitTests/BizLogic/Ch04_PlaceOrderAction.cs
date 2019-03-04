﻿// Copyright (c) 2017 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using BizLogic.Orders;
using BizLogic.Orders.Concrete;
using test.Mocks;
using Xunit;
using Xunit.Extensions.AssertExtensions;

namespace test.UnitTests.BizLogic
{
    public class Ch04_PlaceOrderAction
    {
        [Fact]
        public void PlaceOrderOk()
        {
            //SETUP
            var mockDbA = new MockPlaceOrderDbAccess();
            var service = new PlaceOrderAction(mockDbA);
            var lineItems = new List<OrderLineItem>
            {
                new OrderLineItem {BookId = 1, NumBooks = 4},
                new OrderLineItem {BookId = 2, NumBooks = 5},
                new OrderLineItem {BookId = 3, NumBooks = 6}
            };
            var userId = Guid.NewGuid();

            //ATTEMPT
            var result = service.Action(new PlaceOrderInDto(true, userId, lineItems.ToImmutableList()));

            //VERIFY
            service.Errors.Any().ShouldEqual(false);
            mockDbA.AddedOrder.CustomerName.ShouldEqual(userId);
            mockDbA.AddedOrder.DateOrderedUtc.Subtract(DateTime.UtcNow).TotalSeconds.ShouldBeInRange(-1,0);
            mockDbA.AddedOrder.LineItems.Count.ShouldEqual(lineItems.Count);
            var orderLineItems = mockDbA.AddedOrder.LineItems.ToImmutableList();
            for (int i = 0; i < lineItems.Count; i++)
            {
                orderLineItems[i].LineNum.ShouldEqual((byte)(i+1));
                orderLineItems[i].ChosenBook.BookId.ShouldEqual(lineItems[i].BookId);
                orderLineItems[i].NumBooks.ShouldEqual(lineItems[i].NumBooks);
            }
        }

        [Fact]
        public void PlaceOrderWithPromotionOk()
        {
            //SETUP
            var mockDbA = new MockPlaceOrderDbAccess(false, 999);
            var service = new PlaceOrderAction(mockDbA);
            var lineItems = new List<OrderLineItem>
            {
                new OrderLineItem {BookId = 1, NumBooks = 1},
                new OrderLineItem {BookId = 2, NumBooks = 1},
            };
            var userId = Guid.NewGuid();

            //ATTEMPT
            var result = service.Action(new PlaceOrderInDto(true, userId, lineItems.ToImmutableList()));

            //VERIFY
            service.Errors.Any().ShouldEqual(false);

            var orderLineItems = mockDbA.AddedOrder.LineItems.ToList();
            orderLineItems.First().BookPrice.ShouldEqual(999);
            orderLineItems.Last().BookPrice.ShouldEqual(2);

        }

        //------------------------------------------------
        //failure mode

        [Fact]
        public void MissingBookError()
        {
            //SETUP
            var mockDbA = new MockPlaceOrderDbAccess();
            var service = new PlaceOrderAction(mockDbA);
            var lineItems = new List<OrderLineItem>
            {
                new OrderLineItem {BookId = 1, NumBooks = 4},
                new OrderLineItem {BookId = 1000, NumBooks = 5},
                new OrderLineItem {BookId = 3, NumBooks = 6}
            };
            var userId = Guid.NewGuid();

            //ATTEMPT
            var ex = Assert.Throws<InvalidOperationException>( 
                () => service.Action(new PlaceOrderInDto(true, userId, lineItems.ToImmutableList())));

            //VERIFY
            ex.Message.ShouldEqual("An order failed because book, id = 1000 was missing.");
        }

        [Fact]
        public void NotAcceptTsAndCs()
        {
            //SETUP
            var mockDbA = new MockPlaceOrderDbAccess(true);
            var service = new PlaceOrderAction(mockDbA);
            var userId = Guid.NewGuid();

            //ATTEMPT
            service.Action(new PlaceOrderInDto(false, userId, null));

            //VERIFY
            service.Errors.Any().ShouldEqual(true);
            service.Errors.Count.ShouldEqual(1);
            service.Errors.First().ErrorMessage.ShouldEqual("You must accept the T&Cs to place an order.");
        }

        [Fact]
        public void BookNotForSale()
        {
            //SETUP
            var mockDbA = new MockPlaceOrderDbAccess(false, -1);
            var service = new PlaceOrderAction(mockDbA);
            var lineItems = new List<OrderLineItem>
            {
                new OrderLineItem {BookId = 1, NumBooks = 1},
            };
            var userId = Guid.NewGuid();

            //ATTEMPT
            service.Action(new PlaceOrderInDto(true, userId, lineItems.ToImmutableList()));

            //VERIFY
            service.Errors.Any().ShouldEqual(true);
            service.Errors.Count.ShouldEqual(1);
            service.Errors.First().ErrorMessage.ShouldEqual("Sorry, the book 'Book0000 Title' is not for sale.");
        }
    }
}