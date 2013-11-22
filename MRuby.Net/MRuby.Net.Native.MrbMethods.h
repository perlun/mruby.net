#pragma once

#include <mruby/compile.h>
#include <vcclr.h>

#include "MRuby.Net.Native.MrbState.h"
#include "MRuby.Net.Native.MrbValue.h"

using namespace System;
using namespace System::Runtime::InteropServices;

namespace MRuby {
    namespace Net {
        namespace Native {
            /// <summary>
            /// Thin wrapper over the native methods in mruby.
            /// </summary>
            public ref class MrbMethods {
            public:
                static MrbState^ mrb_open() {
                    return gcnew MrbState(::mrb_open());
                }

                static void mrb_close(MrbState^ mrb) {
                    return ::mrb_close(mrb->NativeMrbState);
                }

                static MrbValue^ mrb_load_string(MrbState^ mrb, String^ s)
                {
                    auto str = (char*)Marshal::StringToHGlobalAnsi(s).ToPointer();
                    auto result = ::mrb_load_string(mrb->NativeMrbState, str);
                    Marshal::FreeHGlobal((IntPtr)str);
                    
                    return gcnew MrbValue(result);
                }
            };
        }
    }
}
