using Xunit;

namespace MRuby.Net.Tests
{
    public class MRubyEnvironmentTest
    {
        [Fact]
        public void Evaluate_CanCastResultToInt()
        {
            using (var mruby = new MRubyEnvironment())
            {
                dynamic result = mruby.Evaluate("10 + 20");
                var intResult = (int?)result;
                Assert.Equal(30, intResult);
            }
        }
    }
}
