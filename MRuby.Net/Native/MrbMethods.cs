using System;
using System.Runtime.InteropServices;

namespace MRuby.Net.Native
{
    public static class MrbMethods
    {
        // mrb_state* mrb_open(void);
        [DllImport("mruby", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr mrb_open();

        // void mrb_close(mrb_state*);
        [DllImport("mruby", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mrb_close(IntPtr env);

        // mrb_value mrb_load_string(mrb_state *mrb, const char *s);
        [DllImport("mruby", CallingConvention = CallingConvention.Cdecl)]
        public static extern MrbValue mrb_load_string(IntPtr env, string s);
    }
}
