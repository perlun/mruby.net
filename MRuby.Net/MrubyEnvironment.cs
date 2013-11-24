using MRuby.Net.Native;
using System;

namespace MRuby.Net
{
    public class MrubyEnvironment : IDisposable
    {
        private readonly MrbState mrbState;

        public MrubyEnvironment()
        {
            mrbState = MrbMethods.mrb_open();
        }

        public void Dispose()
        {
            MrbMethods.mrb_close(mrbState);
        }

        public dynamic Evaluate(string line)
        {
            return MrbMethods.mrb_load_string(mrbState, line);
        }
    }
}
