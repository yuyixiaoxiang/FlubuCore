﻿using FlubuCore.Tasks.Linux;
using System.Net.Sockets;
using Xunit;

namespace Flubu.Tests.Tasks
{
    [Collection(nameof(FlubuTestCollection))]
    public class LinuxTaskTests : FlubuTestBase
    {
        private readonly FlubuTestFixture _fixture;

        public LinuxTaskTests(FlubuTestFixture fixture)
            : base(fixture.LoggerFactory)
        {
            _fixture = fixture;
        }

        [Fact]
        public void RunCommandUnknownHost()
        {
            var task = new SshCommandTask("10.10.1.143", "zoroz");
            Assert.Throws<SocketException>(() => task
                .WithPassword("sfdfjkskdf")
                .WithCommand("tail -f /var/8d/edigital.import/import-2017-03-16.log")
                .Execute(Context));
        }
    }
}