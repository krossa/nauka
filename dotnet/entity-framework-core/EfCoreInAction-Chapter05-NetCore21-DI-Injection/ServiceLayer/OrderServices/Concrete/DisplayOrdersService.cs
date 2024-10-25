﻿// Copyright (c) 2017 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.EfClasses;
using DataLayer.EfCode;
using Microsoft.AspNetCore.Http;
using ServiceLayer.CheckoutServices;
using ServiceLayer.CheckoutServices.Concrete;

namespace ServiceLayer.OrderServices.Concrete
{
    public class DisplayOrdersService
    {
        private readonly EfCoreContext _context;


        public DisplayOrdersService(EfCoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This lists existing orders
        /// </summary>
        /// <returns></returns>
        public List<OrderListDto> GetUsersOrders(IRequestCookieCollection cookiesIn)
        {
            var cookie = new CheckoutCookie(cookiesIn);
            var service = new CheckoutCookieService(cookie.GetValue());

            return SelectQuery(_context.Orders.OrderByDescending(x => x.DateOrderedUtc)
                               .Where(x => x.CustomerName == service.UserId)).ToList();
        }


        public OrderListDto GetOrderDetail(int orderId)
        {
            var order = SelectQuery(_context.Orders).SingleOrDefault(x => x.OrderId == orderId);

            if (order == null)
                throw new NullReferenceException($"Could not find the order with id of {orderId}.");

            return order;
        }

        //---------------------------------------------
        //private methods

        private IQueryable<OrderListDto> SelectQuery(IQueryable<Order> orders)
        {
            return orders.Select(x => new OrderListDto
                               {
                                   OrderId = x.OrderId,
                                   DateOrderedUtc = x.DateOrderedUtc,
                                   LineItems = x.LineItems.Select(lineItem => new CheckoutItemDto
                                   {
                                       BookId = lineItem.BookId,
                                       Title = lineItem.ChosenBook.Title,
                                       AuthorsName = string.Join(", ",
                                        lineItem.ChosenBook.AuthorsLink
                                            .OrderBy(q => q.Order)
                                            .Select(q => q.Author.Name)),
                                       BookPrice = lineItem.BookPrice,
                                       NumBooks = lineItem.NumBooks,
                                   })
                               });
        }

    }
}