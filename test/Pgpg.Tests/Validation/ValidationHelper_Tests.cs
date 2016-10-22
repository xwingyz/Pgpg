using Pgpg.Validation;
using Shouldly;
using Xunit;

namespace Pgpg.Tests.Validation
{
    public class ValidationHelper_Tests : AppTestBase
    {
        ValidationHelper helper = new ValidationHelper();

        [Fact]
        public void Should_IsPhoneNumber()
        {
            bool a = helper.IsPhoneNumber("18516354062");
            bool b = helper.IsPhoneNumber("13539985110");
            bool c = helper.IsPhoneNumber("15356151207");
            true.ShouldBe(a && b && c);
        }
        [Fact]
        public void Should_IsPhoneNumber_Error()
        {
            bool result = helper.IsPhoneNumber("08516354062");
            false.ShouldBe(result);
        }

        [Fact]
        public void Should_IsChinaMobilePhoneNumber()
        {
            bool result = helper.IsChinaMobilePhoneNumber("13539985110");
            true.ShouldBe(result);
        }
        [Fact]
        public void Should_IsChinaMobilePhoneNumber_Error()
        {
            bool a = helper.IsChinaMobilePhoneNumber("18516354062");
            bool b = helper.IsChinaMobilePhoneNumber("15356151207");
            false.ShouldBe(a);
            false.ShouldBe(b);
        }
        [Fact]
        public void Should_IsChinaUnicomPhoneNumber()
        {
            bool result = helper.IsChinaUnicomPhoneNumber("18516354062");
            result.ShouldBe(true);
        }
        [Fact]
        public void Should_IsChinaUnicomPhoneNumber_Error()
        {
            bool a = helper.IsChinaUnicomPhoneNumber("13539985110");
            bool b = helper.IsChinaUnicomPhoneNumber("15356151207");
            false.ShouldBe(a);
            false.ShouldBe(b);
        }

        [Fact]
        public void Should_IsChinaTelecomPhoneNumber()
        {
            bool result = helper.IsChinaTelecomPhoneNumber("15356151207");
            result.ShouldBe(true);
        }
        [Fact]
        public void Should_IsChinaTelecomPhoneNumber_Error()
        {
            bool a = helper.IsChinaTelecomPhoneNumber("13539985110");
            bool b = helper.IsChinaTelecomPhoneNumber("18516354062");
            false.ShouldBe(a);
            false.ShouldBe(b);
        }
    }
}
