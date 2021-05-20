using NUnit.Framework;
using System.Threading.Tasks;

namespace GeorgiaTechLibrary.Tests
{
    using static Testing;

    public class TestBase
    {
        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
        }
    }
}