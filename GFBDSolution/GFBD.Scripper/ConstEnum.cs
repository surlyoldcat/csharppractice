using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFBD.Scripper
{
    public enum OutputFormat
    {
        Html,
        Javascript
    }

    public static class ConstEnum
    {

        
        public const string JS_ARRAY_OPEN = "[";
        public const string JS_ARRAY_CLOSE = "]";
        public const string JS_DICT_OPEN = "{";
        public const string JS_DICT_CLOSE = "}";
        public const string JS_DICT_SEP = ":";
    }
}
