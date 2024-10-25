﻿// Copyright (c) 2017 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System.Linq;
using System.Threading.Tasks;
using DataLayer.EfCode;
using ServiceLayer.BizRunners;
using test.EfHelpers;
using test.Mocks;
using Xunit;
using Xunit.Extensions.AssertExtensions;

namespace test.UnitTests.ServiceLayer
{
    public class Ch04_RunnerWriteDbWithValidationAsync
    {
        [Theory]
        [InlineData(MockBizActionWithWriteModes.Ok)]
        [InlineData(MockBizActionWithWriteModes.BizError)]
        [InlineData(MockBizActionWithWriteModes.SaveChangesError)]
        public async Task RunActionAsync(MockBizActionWithWriteModes mode)
        {
            //SETUP
            var options = EfInMemory.CreateNewContextOptions();
            using (var context = new EfCoreContext(options))
            {
                context.SeedDatabaseFourBooks();

                var action = new MockBizActionWithWriteAsync(context);
                var runner = new RunnerWriteDbWithValidationAsync<MockBizActionWithWriteModes, string>(action, context);

                //ATTEMPT
                var output = await runner.RunActionAsync(mode);

                //VERIFY
                output.ShouldEqual(mode.ToString());
                runner.HasErrors.ShouldEqual(mode != MockBizActionWithWriteModes.Ok);
                context.Orders.Count().ShouldEqual(mode != MockBizActionWithWriteModes.Ok ? 0 : 1);

                if (mode == MockBizActionWithWriteModes.BizError)
                    runner.Errors.Single().ErrorMessage.ShouldEqual("There is a biz error.");
                if (mode == MockBizActionWithWriteModes.SaveChangesError)
                    runner.Errors.Single().ErrorMessage.ShouldEqual("If you want to order a 100 or more books please phone us on 01234-5678-90");
            }
        }

    }
}