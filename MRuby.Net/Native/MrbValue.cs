using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MRuby.Net.Native
{
    // This is very much based on the blind presumption that mruby has been built WIHOUT any of the boxing alternatives
    // (MRB_NAN_BOXING or MRB_WORD_BOXING) available, since enabling any of them changes the layout of the mrb_value sturcture...
    [StructLayout(LayoutKind.Sequential, Size = 16)]
    public struct MrbValue
    {
        // The exact meaning of the value parts vary greatly, based on the ValueType.
        public UInt32 ValuePart1;
        public UInt32 ValuePart2;
        public MrbValueType ValueType;
        public UInt32 ValuePart3;

        public bool IsNil
        {
            get
            {
                if (ValueType != MrbValueType.False) return false;

                // Borderline to testing MRuby (which we shouldn't), but for the time being, let's just keep these to be on the
                // safe(r) side...
                Debug.Assert(ValuePart1 == 0);
                Debug.Assert(ValuePart2 == 0);
                Debug.Assert(ValuePart3 == 0);

                return true;
            }
        }
    }
}