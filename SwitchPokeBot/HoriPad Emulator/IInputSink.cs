using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchPokeBot




{
    interface IInputSink
    {
        void Reset();
        void Update(InputFrame newFrame);
        void WaitFrames(int numFrames);
        string GetStateStr();
        void AddStateListener(OnUpdateCallback cb);
    }
}
