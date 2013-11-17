using MRuby.Net.Native;
using Xunit;

namespace MRuby.Net.Tests.Native
{
    public class MrbTest
    {
        [Fact]
        public void Can_Close_an_environment_previously_openeded_with_Open()
        {
            var env = Mrb.Open();
            Mrb.Close(env);
        }
    }
}
