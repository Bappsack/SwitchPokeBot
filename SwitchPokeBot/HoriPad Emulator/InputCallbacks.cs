using System;
using System.Collections.Generic;
using System.Text;
using WebSocketSharp.Server;

namespace SwitchPokeBot



{
    public delegate void OnOpenCallback(string id);


    public delegate void OnAddListenerCallback(WebSocketBehavior client);

    public delegate void OnUpdateCallback(string stateStr);
}
