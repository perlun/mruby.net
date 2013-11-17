using System;
using System.Runtime.InteropServices;

namespace MRuby.Net.Native
{
    public static class Mrb
    {
        // mrb_state* mrb_open(void);
        [DllImport("mruby", EntryPoint = "mrb_open", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Open();

        // void mrb_close(mrb_state*);
        [DllImport("mruby", EntryPoint = "mrb_close", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Close(IntPtr env);
    }
}
