using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFBD.Scripper
{
    /// <summary>
    /// Interface used to create special string representation of an object
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Creates string representation of an object
        /// </summary>
        /// <param name="format">desired output text format</param>
        /// <returns>the string representation</returns>
        string Render(OutputFormat format);
    }

    /// <summary>
    /// Renderer for basic types (int, bool, etc) and strings
    /// </summary>
    /// <remarks>This simply calls the objects built-in ToString() method.</remarks>
    internal class SimpleRenderer : IRenderer
    {
        public string Value { get; private set; }

        public SimpleRenderer(object obj)
        {
            Value = obj.ToString();
        }

        public string Render(OutputFormat format)
        {
            string retval = format == OutputFormat.Javascript
                ? WrapInQuotes(Value)
                : Value;
            return retval;
        }

        private static string WrapInQuotes(string s)
        {
            return @"""" + s + @"""";
        }
        
    }

    /// <summary>
    /// Renderer for arrays and lists
    /// </summary>
    internal class EnumerableRenderer : IRenderer
    {
        public IEnumerable Values { get; private set; }

        public EnumerableRenderer(IEnumerable obj)
        {
            Values = obj;
        }

        public string Render(OutputFormat format)
        {
            //a little inefficient- we store the rendered
            //strings in a list, so we can more easily
            //stitch them together for our pretty output
            List<string> renderedItems = new List<string>();
            foreach(var item in Values)
            {
                var itemRenderer = RendererFactory.GetRenderer(item);
                renderedItems.Add(itemRenderer.Render(format));
            }
            string output = format == OutputFormat.Javascript
                ? FormatAsJavascript(renderedItems)
                : FormatAsHtml(renderedItems);
            return output;
        }

        private static string FormatAsHtml(List<string> renderedItems)
        {
            throw new NotImplementedException();
        }

        private static string FormatAsJavascript(List<string> renderedItems)
        {
            string output = ConstEnum.JS_ARRAY_OPEN + string.Join(",", renderedItems) + ConstEnum.JS_ARRAY_CLOSE;
            return output;
        }
       
    }

   

    internal class DictionaryRenderer : IRenderer
    {
        public IDictionary Items { get; private set; }

        public DictionaryRenderer(IDictionary obj)
        {
            Items = obj;
        }
        public string Render(OutputFormat format)
        {
            Dictionary<string, string> renderedPairs = new Dictionary<string, string>();
            foreach(var key in Items.Keys)
            {
                var keyRenderer = RendererFactory.GetRenderer(key);
                string renderedKey = keyRenderer.Render(format);
                var valueRenderer = RendererFactory.GetRenderer(Items[key]);
                string renderedVal = valueRenderer.Render(format);
                renderedPairs.Add(renderedKey, renderedVal);
            }
            string output = format == OutputFormat.Javascript
                ? FormatAsJavascript(renderedPairs)
                : FormatAsHtml(renderedPairs);
            return output;
        }

        private static string FormatAsHtml(Dictionary<string, string> renderedPairs)
        {
            throw new NotImplementedException();
        }

        private static string FormatAsJavascript(Dictionary<string, string> renderedPairs)
        {
            StringBuilder output = new StringBuilder();
            output.Append(ConstEnum.JS_DICT_OPEN);
            string formattedPairs = string.Join(
                ",",
                renderedPairs.Select(kvp => kvp.Key + ConstEnum.JS_DICT_SEP + kvp.Value));
            output.Append(formattedPairs);
            
            output.Append(ConstEnum.JS_DICT_CLOSE);
            return output.ToString();
        }
    }
}
