using MRuby.Net.Native;
using Xunit;

namespace MRuby.Net.Tests.Native
{
    public unsafe class MrbTest
    {
        [Fact]
        public void mrb_close_CanCloseAnEnvironment()
        {
            var mrb = MrbMethods.mrb_open();
            MrbMethods.mrb_close(mrb);
        }

        [Fact]
        public void mrb_load_string_CanRunSomeCodeAndGetAFixnumBack()
        {
            var mrb = MrbMethods.mrb_open();

            var value = MrbMethods.mrb_load_string(mrb, "10 + 20");
            Assert.Equal(MrbValueType.Fixnum, value.ValueType);
            Assert.Equal(30U, value.IntegerValue);

            MrbMethods.mrb_close(mrb);
        }

        [Fact]
        public void mrb_load_stirng_CanRunSomeCodeAndGetNilBack()
        {
            var env = MrbMethods.mrb_open();

            var value = MrbMethods.mrb_load_string(env, "nil");
            Assert.True(value.IsNil);

            MrbMethods.mrb_close(env);
        }

        [Fact]
        public void mrb_load_string_CanRunSomeCodeAndGetFalseBack()
        {
            var env = MrbMethods.mrb_open();

            var value = MrbMethods.mrb_load_string(env, "false");
            Assert.True(value.IsFalse);

            MrbMethods.mrb_close(env);
        }

        [Fact]
        public void mrb_load_string_RaisesAnExceptionForInvalidCode()
        {
            var env = MrbMethods.mrb_open();

            var value = MrbMethods.mrb_load_string(env, "this is just some junk (not valid Ruby code)");
            Assert.True(value.IsNil);

            // TODO: This is hard to check in "pure CLR" (using P/Invoke); we don't want to have to duplicate a lot of the mruby
            // TODO: internals on the CLR side. Perhaps we have to consider the C++/CLR track after all...
            // if (mrb->exc) {

            MrbMethods.mrb_close(env);
        }
    }
}
