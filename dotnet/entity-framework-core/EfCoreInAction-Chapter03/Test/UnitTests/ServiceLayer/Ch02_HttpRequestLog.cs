﻿// Copyright (c) 2016 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using ServiceLayer.Logger;
using Xunit;
using Xunit.Extensions.AssertExtensions;

namespace test.UnitTests.ServiceLayer
{
    public class Ch02_HttpRequestLog
    {
        public Ch02_HttpRequestLog()
        {
            HttpRequestLog.ClearOldLogs(-1);
        }

        [Fact]
        public void CreateNewLog()
        {
            //SETUP
            const string traceIdent = "t";

            //ATTEMPT
            HttpRequestLog.AddLog(traceIdent, LogLevel.Information, 1, "Unit Test");

            //VERIFY
            var log = HttpRequestLog.GetHttpRequestLog(traceIdent);
            log.TraceIdentifier.ShouldEqual(traceIdent);
            log.LastAccessed.ShouldBeInRange(DateTime.UtcNow.AddSeconds(-1), DateTime.UtcNow);
            log.RequestLogs.Count.ShouldEqual(1);
        }

        [Fact]
        public void CreateLogNoEventName()
        {
            //SETUP
            const string traceIdent = "t";

            //ATTEMPT
            HttpRequestLog.AddLog(traceIdent, LogLevel.Information, 1, "Unit Test");

            //VERIFY
            var log = HttpRequestLog.GetHttpRequestLog(traceIdent);
            log.RequestLogs.Count.ShouldEqual(1);
            log.RequestLogs.First().EventString.ShouldEqual("Unit Test");
            log.RequestLogs.First().IsDb.ShouldBeFalse();
        }

        [Fact]
        public void CreateNormalLog()
        {
            //SETUP
            const string traceIdent = "t";

            //ATTEMPT
            HttpRequestLog.AddLog(traceIdent, LogLevel.Information, new EventId(1, "SomeOtherEvent"), "Unit Test");

            //VERIFY
            var log = HttpRequestLog.GetHttpRequestLog(traceIdent);
            log.RequestLogs.Count.ShouldEqual(1);
            log.RequestLogs.First().EventString.ShouldEqual("Unit Test");
            log.RequestLogs.First().IsDb.ShouldBeFalse();
        }

        [Fact]
        public void CreateEfCoreLog()
        {
            //SETUP
            const string traceIdent = "t";

            //ATTEMPT
            HttpRequestLog.AddLog(traceIdent, LogLevel.Information, new EventId(1, "Microsoft.EntityFrameworkCore.Something"), "Unit Test");

            //VERIFY
            var log = HttpRequestLog.GetHttpRequestLog(traceIdent);
            log.RequestLogs.Count.ShouldEqual(1);
            log.RequestLogs.First().EventString.ShouldEqual("Unit Test");
            log.RequestLogs.First().IsDb.ShouldBeTrue();
        }

        [Fact]
        public void AddToExistingLog()
        {
            //SETUP
            const string traceIdent = "t";
            HttpRequestLog.AddLog(traceIdent, LogLevel.Information, 1, "Unit Test1");

            //ATTEMPT
            HttpRequestLog.AddLog(traceIdent, LogLevel.Information, 2, "Unit Test2");

            //VERIFY
            var log = HttpRequestLog.GetHttpRequestLog(traceIdent);
            log.TraceIdentifier.ShouldEqual(traceIdent);
            log.LastAccessed.ShouldBeInRange(DateTime.UtcNow.AddSeconds(-1), DateTime.UtcNow);
            
            log.RequestLogs.First().EventString.ShouldEqual("Unit Test1");
            log.RequestLogs.Last().EventString.ShouldEqual("Unit Test2");
        }

        [Fact]
        public void CreateNewLogWhenOneExistsLog()
        {
            //SETUP
            const string traceIdent1 = "t1";
            const string traceIdent2 = "t2";
            HttpRequestLog.AddLog(traceIdent1, LogLevel.Information, 1, "Unit Test1");

            //ATTEMPT
            HttpRequestLog.AddLog(traceIdent2, LogLevel.Information, 2, "Unit Test2");

            //VERIFY
            var log1 = HttpRequestLog.GetHttpRequestLog(traceIdent1);
            log1.TraceIdentifier.ShouldEqual(traceIdent1);
            log1.RequestLogs.Count.ShouldEqual(1);
            var log2 = HttpRequestLog.GetHttpRequestLog(traceIdent2);
            log2.TraceIdentifier.ShouldEqual(traceIdent2);
            log2.RequestLogs.Count.ShouldEqual(1);
        }

        [Fact]
        public void AccessMissingLog()
        {
            //SETUP
            const string traceIdent = "t1";

            //ATTEMPT
            var log = HttpRequestLog.GetHttpRequestLog(traceIdent);

            //VERIFY
            log.TraceIdentifier.ShouldEqual(traceIdent);
            log.RequestLogs.Count.ShouldEqual(1);
            log.RequestLogs.First().EventString.ShouldContain("Could not find the log you asked for.");
        }

    }
}