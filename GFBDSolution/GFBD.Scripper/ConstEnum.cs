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

    public static class Constants
    {
        public const string JS_ARRAY_OPEN = "[";
        public const string JS_ARRAY_CLOSE = "]";
        public const string JS_DICT_OPEN = "{";
        public const string JS_DICT_CLOSE = "}";
        public const string JS_DICT_SEP = ":";
        public const string HTML_LIST_OPEN = "<ol>";
        public const string HTML_LIST_CLOSE = "</ol>";
        public const string HTML_LIST_ITEM_OPEN = "<li>";
        public const string HTML_LIST_ITEM_CLOSE = "</li>";
        public const string HTML_DICT_OPEN = "<dl>";
        public const string HTML_DICT_CLOSE = "</dl>";
        public const string HTML_DICT_KEY_OPEN = "<dt>";
        public const string HTML_DICT_KEY_CLOSE = "</dt>";
        public const string HTML_DICT_VAL_OPEN = "<dd>";
        public const string HTML_DICT_VAL_CLOSE = "</dd>";
        public const string NULL_VALUE = "NULL";
    }
}
