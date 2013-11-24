#pragma once

namespace MRuby {
    namespace Net {
        namespace Native {
            public ref class MrbState {
            internal:
                property mrb_state* NativeMrbState;

                MrbState(mrb_state* mrb)
                {
                    NativeMrbState = mrb;
                }
            };
        }
    }
}
