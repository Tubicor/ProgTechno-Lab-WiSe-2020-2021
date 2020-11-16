using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace ClassLibrary1.Data
{
    public class State
    {
        public Dictionary<int, Event> bookStates { get; set; } = new Dictionary<int, Event>();
    }
}
