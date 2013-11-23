#pragma once

#include <vcclr.h>
#include <mruby/compile.h>
#include <mruby/string.h>

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
                    auto mrb_state = mrb->NativeMrbState;

                    auto str = (char*)Marshal::StringToHGlobalAnsi(s).ToPointer();
                    auto result = ::mrb_load_string(mrb_state, str);
                    Marshal::FreeHGlobal((IntPtr)str);
                    
                    if (mrb_state->exc != nullptr) {
                        auto mrb_exception = mrb_obj_value(mrb_state->exc);
                        
                        // The mrb_exception is the actual MRuby "exception" object, so we call its "to_s" method to get the
                        // exception message.
                        auto exception_message = mrb_funcall(mrb_state, mrb_exception, "to_s", 0);
                        auto c_string = mrb_string_value_cstr(mrb_state, &exception_message);
                        throw gcnew Exception(Marshal::PtrToStringAnsi((IntPtr)c_string));
                    }

                    return gcnew MrbValue(mrb_state, result);
                }
            };
        }
    }
}
