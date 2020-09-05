using System;
using System.Collections.Generic;

namespace Atc.XUnit
{
    internal class DebugLimitData
    {
        public DebugLimitData(List<Tuple<string, List<string>>> classMethodNames)
        {
            this.ClassMethodNames = classMethodNames;
        }

        internal List<Tuple<string, List<string>>> ClassMethodNames { get; }

        internal bool HasClassNames => this.ClassMethodNames.Count != 0;
    }
}