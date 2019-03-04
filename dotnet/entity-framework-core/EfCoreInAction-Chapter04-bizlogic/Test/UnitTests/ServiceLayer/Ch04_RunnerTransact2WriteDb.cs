﻿// Copyright (c) 2017 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using BizDbAccess.Orders;
using BizLogic.Orders;
using BizLogic.Orders.Concrete;
using DataLayer.EfClasses;
using DataLayer.EfCode;
using ServiceLayer.BizRunners;
using test.EfHelpers;
using test.Mocks;
using Xunit;
using Xunit.Extensions.AssertExtensions;

namespace test.UnitTests.ServiceLayer
{
    public class Ch04_RunnerTransact2WriteDb
    {
        [Theory]
        [InlineData(MockBizActionTransact2Modes.Ok)]
        [InlineData(MockBizActionTransact2Modes.BizErrorPart1)]
        [InlineData(MockBizActionTransact2Modes.BizErrorPart2)]
        public void RunAction(MockBizActionTransact2Modes mode)
        {
            //SETUP
            var inMemDb = new SqliteInMemory();

            using (var context = inMemDb.GetContextWithSetup())
            {
                var action1 = new MockBizActionPart1(context);
                var action2 = new MockBizActionPart2(context);
                var runner = new RunnerTransact2WriteDb<TransactBizActionDto, TransactBizActionDto, TransactBizActionDto>(context, action1, action2);

                //ATTEMPT
                var output = runner.RunAction(new TransactBizActionDto(mode));

                //VERIFY
                runner.HasErrors.ShouldEqual(mode != MockBizActionTransact2Modes.Ok);
                context.Authors.Count().ShouldEqual(mode != MockBizActionTransact2Modes.Ok ? 0 : 2);
                if (mode == MockBizActionTransact2Modes.BizErrorPart1)
                    runner.Errors.Single().ErrorMessage.ShouldEqual("Failed in Part1");
                if (mode == MockBizActionTransact2Modes.BizErrorPart2)
                    runner.Errors.Single().ErrorMessage.ShouldEqual("Failed in Part2");
            }
        }

        [Fact]
        public void RunActionThrowException()
        {
            //SETUP
            var inMemDb = new SqliteInMemory();

            using (var context = inMemDb.GetContextWithSetup())
            {
                var action1 = new MockBizActionPart1(context);
                var action2 = new MockBizActionPart2(context);
                var runner = new RunnerTransact2WriteDb<TransactBizActionDto, TransactBizActionDto, TransactBizActionDto>(context, action1, action2);

                //ATTEMPT
                Assert.Throws<InvalidOperationException>(() => runner.RunAction(new TransactBizActionDto(MockBizActionTransact2Modes.ThrowExceptionPart2)));

                //VERIFY
                context.Authors.Count().ShouldEqual(0);
            }
        }


        [Fact]
        public void ExampleCodeForBook()
        {
            //SETUP
            var inMemDb = new SqliteInMemory();

            using (var context = inMemDb.GetContextWithSetup())
            {
                context.SeedDatabaseDummyBooks();
                var lineItems = new List<OrderLineItem>
                {
                    new OrderLineItem {BookId = 1, NumBooks = 4},
                    new OrderLineItem {BookId = 2, NumBooks = 5},
                    new OrderLineItem {BookId = 3, NumBooks = 6}
                };
                var userId = Guid.NewGuid();
                //ATTEMPT

                var dbAccess = new PlaceOrderDbAccess(context);
                var action1 = new PlaceOrderPart1(dbAccess);
                var action2 = new PlaceOrderPart2(dbAccess);
                var runner = new RunnerTransact2WriteDb<
                    PlaceOrderInDto, 
                    Part1ToPart2Dto, 
                    Order>(context, action1, action2);
                var order = runner.RunAction(new PlaceOrderInDto(true, userId, lineItems.ToImmutableList()));

                //VERIFY
                runner.HasErrors.ShouldBeFalse();
                context.Orders.Count().ShouldEqual(1);
            }
        }
    }
}