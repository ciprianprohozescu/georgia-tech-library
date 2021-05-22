using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests.Application.IntegrationTests
{
    using static Testing;

    public class TestBase
    {
        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
        }

        [TearDown]
        public async Task TestTearDown()
        {
            await ResetState();
        }
    }
}