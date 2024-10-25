﻿// Copyright (c) 2017 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System;
using BizLogic.Orders;
using ServiceLayer.CheckoutServices.Concrete;
using Xunit;
using Xunit.Extensions.AssertExtensions;

namespace test.UnitTests.ServiceLayer
{
    public class Ch04_CookieService
    {
        [Fact]
        public void CreateNewCookie()
        {
            //SETUP

            //ATTEMPT
            var service = new CheckoutCookieService((string)null);

            //VERIFY
            service.UserId.ShouldNotEqual(Guid.Empty);
            service.LineItems.Count.ShouldEqual(0);
        }

        [Fact]
        public void EncodeDecodeNewCookie()
        {
            //SETUP
            var service = new CheckoutCookieService((string)null);
            var cString = service.EncodeForCookie();
            var userId = service.UserId;

            //ATTEMPT
            service = new CheckoutCookieService(cString);

            //VERIFY
            service.UserId.ShouldEqual(userId);
            service.LineItems.Count.ShouldEqual(0);
        }

        [Fact]
        public void AddLineItemEncodeDecode()
        {
            //SETUP
            var service = new CheckoutCookieService((string)null);
            service.AddLineItem(new OrderLineItem {BookId = 123, NumBooks = 456});
            var cString = service.EncodeForCookie();

            //ATTEMPT
            service = new CheckoutCookieService(cString);

            //VERIFY
            service.LineItems.Count.ShouldEqual(1);
            service.LineItems[0].BookId.ShouldEqual(123);
            service.LineItems[0].NumBooks.ShouldEqual((short)456);
        }

        [Fact]
        public void UpdateLineEncodeDecode()
        {
            //SETUP
            var service = new CheckoutCookieService((string)null);
            service.AddLineItem(new OrderLineItem { BookId = 1, NumBooks = 4 });
            service.AddLineItem(new OrderLineItem { BookId = 2, NumBooks = 5 });
            service.AddLineItem(new OrderLineItem { BookId = 3, NumBooks = 6 });

            //ATTEMPT
            service.UpdateLineItem(1, new OrderLineItem { BookId = 10, NumBooks = 11 });

            //VERIFY
            service.LineItems.Count.ShouldEqual(3);
            service.LineItems[0].BookId.ShouldEqual(1);
            service.LineItems[0].NumBooks.ShouldEqual((short)4);
            service.LineItems[1].BookId.ShouldEqual(10);
            service.LineItems[1].NumBooks.ShouldEqual((short)11);
            service.LineItems[2].BookId.ShouldEqual(3);
            service.LineItems[2].NumBooks.ShouldEqual((short)6);
        }

        [Fact]
        public void RemoveLineEncodeDecode()
        {
            //SETUP
            var service = new CheckoutCookieService((string)null);
            service.AddLineItem(new OrderLineItem { BookId = 1, NumBooks = 4 });
            service.AddLineItem(new OrderLineItem { BookId = 2, NumBooks = 5 });
            service.AddLineItem(new OrderLineItem { BookId = 3, NumBooks = 6 });

            //ATTEMPT
            service.DeleteLineItem(1);

            //VERIFY
            service.LineItems.Count.ShouldEqual(2);
            service.LineItems[0].BookId.ShouldEqual(1);
            service.LineItems[0].NumBooks.ShouldEqual((short)4);
            service.LineItems[1].BookId.ShouldEqual(3);
            service.LineItems[1].NumBooks.ShouldEqual((short)6);
        }
    }
}