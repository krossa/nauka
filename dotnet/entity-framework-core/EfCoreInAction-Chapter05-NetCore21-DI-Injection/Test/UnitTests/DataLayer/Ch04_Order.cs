﻿// Copyright (c) 2017 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.EfClasses;
using DataLayer.EfCode;
using Microsoft.EntityFrameworkCore;
using test.EfHelpers;
using Xunit;
using Xunit.Extensions.AssertExtensions;

namespace test.UnitTests.DataLayer
{
    public class Ch04_Order
    {
        [Fact]
        public void TestCreateOrderWithOneLineItems()
        {
            //SETUP
            var inMemDb = new SqliteInMemory();

            using (var context = inMemDb.GetContextWithSetup())
            {
                context.SeedDatabaseFourBooks();
                var userId = Guid.NewGuid();

                //ATTEMPT
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
                            NumBooks = 1
                        }
                    }
                };
                context.Orders.Add(order);
                context.SaveChanges();

                //VERIFY
                context.Orders.Count().ShouldEqual(1);
                order.LineItems.First().ChosenBook.ShouldNotBeNull();
            }
        }

        [Fact]
        public void TestCreateOrderWithTwoLineItemsDifferentBooks()
        {
            //SETUP
            var inMemDb = new SqliteInMemory();

            using (var context = inMemDb.GetContextWithSetup())
            {
                context.SeedDatabaseFourBooks();
                var userId = Guid.NewGuid();

                //ATTEMPT
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
                            NumBooks = 1
                        },
                        new LineItem
                        {
                            BookId = 2,
                            LineNum = 0,
                            BookPrice = 123,
                            NumBooks = 1
                        }
                    }
                };
                context.Orders.Add(order);
                context.SaveChanges();

                //VERIFY
                context.Orders.Count().ShouldEqual(1);
                order.LineItems.First().ChosenBook.ShouldNotBeNull();
            }
        }

        [Fact]
        public void TestCreateOrderWithTwoLineItemsSameBooks()
        {
            //SETUP
            var inMemDb = new SqliteInMemory();

            using (var context = inMemDb.GetContextWithSetup())
            {
                context.SeedDatabaseFourBooks();
                var userId = Guid.NewGuid();

                //ATTEMPT
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
                            NumBooks = 1
                        },
                        new LineItem
                        {
                            BookId = 1,
                            LineNum = 0,
                            BookPrice = 123,
                            NumBooks = 1
                        }
                    }
                };
                context.Orders.Add(order);
                context.SaveChanges();

                //VERIFY
                context.Orders.Count().ShouldEqual(1);
                order.LineItems.First().ChosenBook.ShouldNotBeNull();
            }
        }

        [Fact]
        public void TestCreateTwoOrderWithOneLineItemSameBooks()
        {
            //SETUP
            var inMemDb = new SqliteInMemory();

            using (var context = inMemDb.GetContextWithSetup())
            {
                context.SeedDatabaseFourBooks();
                var userId = Guid.NewGuid();

                //ATTEMPT
                var order1 = new Order
                {
                    CustomerName = userId,
                    LineItems = new List<LineItem>
                    {
                        new LineItem
                        {
                            BookId = 1,
                            LineNum = 0,
                            BookPrice = 123,
                            NumBooks = 1
                        }
                    }
                };
                var order2 = new Order
                {
                    CustomerName = userId,
                    LineItems = new List<LineItem>
                    {
                        new LineItem
                        {
                            BookId = 1,
                            LineNum = 0,
                            BookPrice = 123,
                            NumBooks = 1
                        }
                    }
                };
                context.Orders.Add(order1);
                context.Orders.Add(order2);
                context.SaveChanges();

                //VERIFY
                context.Orders.Count().ShouldEqual(2);
            }
        }


        /// <summary>
        /// This test is there because of the PK+FK issue - see https://github.com/aspnet/EntityFramework/issues/7340
        /// I have changed the LineItem definition to overcome that issue.
        /// </summary>
        [Fact]
        public void TestUpdateLineItemInOrder()
        {
            //SETUP
            var options = EfInMemory.CreateNewContextOptions();

            using (var context = new EfCoreContext(options))
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
                            NumBooks = 1
                        }
                    }
                };
                context.Orders.Add(order);
                context.SaveChanges();
            }
            
            //ATTEMPT
            using (var context = new EfCoreContext(options))
            {
                var order = context.Orders.Include(x => x.LineItems).First();
                order.LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        BookId = 1,
                        LineNum = 0,
                        BookPrice = 456,
                        NumBooks = 1
                    }
                };
                context.SaveChanges();

            }

            //VERIFY
            using (var context = new EfCoreContext(options))
            {
                var order = context.Orders.Include(x => x.LineItems).First();
                order.LineItems.First().BookPrice.ShouldEqual(456);
            }
        }
    }
}