#pragma once

#include <mruby.h>

using namespace System;
using namespace System::Runtime::InteropServices;

namespace MRuby {
    namespace Net {
        namespace Native {
            public enum struct MrbValueType {
                False = MRB_TT_FALSE,
                Free = MRB_TT_FREE,
                True = MRB_TT_TRUE,
                Fixnum = MRB_TT_FIXNUM,
                Symbol = MRB_TT_SYMBOL,
                Undef = MRB_TT_UNDEF,
                Float = MRB_TT_FLOAT,
                Cptr = MRB_TT_CPTR,
                Object = MRB_TT_OBJECT,
                Class = MRB_TT_CLASS,
                Module = MRB_TT_MODULE,
                IClass = MRB_TT_ICLASS,
                SClass = MRB_TT_SCLASS,
                Proc = MRB_TT_PROC,
                Array = MRB_TT_ARRAY,
                Hash = MRB_TT_HASH,
                String = MRB_TT_STRING,
                Range = MRB_TT_RANGE,
                Exception = MRB_TT_EXCEPTION,
                File = MRB_TT_FILE,
                Env = MRB_TT_ENV,
                Data = MRB_TT_DATA,
                Fiber = MRB_TT_FIBER
            };

            public ref class MrbValue {
            public:
                property bool IsNil {
                    bool get() {
                        return mrb_nil_p(*NativeMrbValue);
                    }
                }

                property bool IsFalse {
                    bool get() {
                        return mrb_type(*NativeMrbValue) == MRB_TT_FALSE &&
                            NativeMrbValue->value.i != 0;
                    }
                }

                property MrbValueType ValueType {
                    MrbValueType get() {
                        return (MrbValueType)NativeMrbValue->tt;
                    }
                }

                property uint32_t IntegerValue {
                    uint32_t get() {
                        return NativeMrbValue->value.i;
                    }
                }

                String^ ToString() override
                {
                    auto mrb_string = mrb_funcall(NativeMrbState, *NativeMrbValue, "to_s", 0);
                    auto c_string = mrb_string_value_cstr(NativeMrbState, &mrb_string);
                    return Marshal::PtrToStringAnsi((IntPtr)c_string);
                }

            internal:
                property mrb_state* NativeMrbState;
                property mrb_value* NativeMrbValue;
               
                MrbValue(mrb_state* mrb, mrb_value value) {
                    NativeMrbState = mrb;
                    NativeMrbValue = new mrb_value(value);
                }

                // Only need a finalizer, since we don't fine-grained control over when the deletion should take place.
                !MrbValue() {
                    // FIXME: What about pointers within the mrb_value, who will be resonsible for freeing them...?
                    delete NativeMrbValue;
                }
            };
        }
    }
}
