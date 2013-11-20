﻿using System;
using System.Runtime.InteropServices;
using MRuby.Net.Native;
using Xunit;

namespace MRuby.Net.Tests.Native
{
    public class MrbTest
    {
        [Fact]
        public void Can_Close_an_environment_previously_openeded_with_Open()
        {
            var env = MrbMethods.mrb_open();
            MrbMethods.mrb_close(env);
        }

        [Fact]
        public void Can_run_some_code_and_get_a_Fixnum_back()
        {
            var env = MrbMethods.mrb_open();

            var value = MrbMethods.mrb_load_string(env, "10 + 20");
            Assert.Equal(MrbValueType.Fixnum, value.ValueType);
            Assert.Equal(30U, value.ValuePart1);

            MrbMethods.mrb_close(env);
        }

        [Fact]
        public void Can_run_some_code_and_get_nil_back()
        {
            var env = MrbMethods.mrb_open();

            var value = MrbMethods.mrb_load_string(env, "nil");
            Assert.True(value.IsNil);

            MrbMethods.mrb_close(env);
        }

        [Fact]
        public void Can_run_some_code_and_get_false_back()
        {
            var env = MrbMethods.mrb_open();

            var value = MrbMethods.mrb_load_string(env, "false");
            Assert.True(value.IsFalse);

            MrbMethods.mrb_close(env);
        }

        [Fact]
        public void Raises_an_exception_for_invalid_code()
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
