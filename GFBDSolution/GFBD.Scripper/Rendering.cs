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
            Value = obj?.ToString() ?? Constants.NULL_VALUE;
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
    /// Special IRenderer implementation to handle DateTimes.
    /// Note, this renderer only renders the Date portion.
    /// </summary>
    internal class DateTimeRenderer : IRenderer
    {
        public DateTime Value { get; private set; }

        public DateTimeRenderer(DateTime obj)
        {
            Value = obj;
        }

        public string Render(OutputFormat format)
        {
            //convert to string, then hand off to SimpleRenderer
            string dateText = Value.ToLongDateString();
            SimpleRenderer renderer = new SimpleRenderer(dateText);
            return renderer.Render(format);
        }
    }

    /// <summary>
    /// Renders a class instance by extracting public
    /// properties into a dictionary
    /// </summary>
    internal class UnknownClassRenderer : IRenderer
    {
        public object Value { get; private set; }

        public UnknownClassRenderer(object obj)
        {
            Value = obj;
        }

        public string Render(OutputFormat format)
        {
            //rip the objects properties into a Dictionary,
            //then just use the regular Dictionary renderer
            Dictionary<string, object> members = new Dictionary<string, object>();
            Type typ = Value.GetType();
            foreach (var prop in typ.GetProperties())
            {
                string name = prop.Name;
                object val = prop.GetValue(Value);
                members.Add(name, val  ?? Constants.NULL_VALUE);
            }
            DictionaryRenderer renderer = new DictionaryRenderer(members);
            return renderer.Render(format);
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
                //get the right renderer for this list item
                var itemRenderer = RendererFactory.GetRenderer(item ?? Constants.NULL_VALUE);
                renderedItems.Add(itemRenderer.Render(format));
            }

            //format the list
            string output = format == OutputFormat.Javascript
                ? FormatAsJavascript(renderedItems)
                : FormatAsHtml(renderedItems);
            return output;
        }

        private static string FormatAsHtml(List<string> renderedItems)
        {
            StringBuilder output = new StringBuilder(Constants.HTML_LIST_OPEN);
            string listItems = string.Join("",
                renderedItems.Select(s => Constants.HTML_LIST_ITEM_OPEN + s + Constants.HTML_LIST_ITEM_CLOSE)
                );
            output.Append(listItems);
            output.Append(Constants.HTML_LIST_CLOSE);
            return output.ToString();
        }

        private static string FormatAsJavascript(List<string> renderedItems)
        {
            StringBuilder output = new StringBuilder(Constants.JS_ARRAY_OPEN);
            output.Append(string.Join(",", renderedItems));
            output.Append(Constants.JS_ARRAY_CLOSE);
            return output.ToString();
        }
       
    }

   
    /// <summary>
    /// Renderer for types that can be represented as hash tables (Dictionaries)
    /// </summary>
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
                //build appropriate renderings for the Key and Value
                var keyRenderer = RendererFactory.GetRenderer(key ?? Constants.NULL_VALUE);
                string renderedKey = keyRenderer.Render(format);
                var valueRenderer = RendererFactory.GetRenderer(Items[key] ?? Constants.NULL_VALUE);
                string renderedVal = valueRenderer.Render(format);
                renderedPairs.Add(renderedKey, renderedVal);
            }

            //format the Dictionary
            string output = format == OutputFormat.Javascript
                ? FormatAsJavascript(renderedPairs)
                : FormatAsHtml(renderedPairs);
            return output;
        }

        private static string FormatAsHtml(Dictionary<string, string> renderedPairs)
        {
            StringBuilder output = new StringBuilder(Constants.HTML_DICT_OPEN);
            foreach(var pair in renderedPairs)
            {
                output.Append(Constants.HTML_DICT_KEY_OPEN + pair.Key + Constants.HTML_DICT_KEY_CLOSE);
                output.Append(Constants.HTML_DICT_VAL_OPEN + pair.Value + Constants.HTML_DICT_VAL_CLOSE);
            }
            output.Append(Constants.HTML_DICT_CLOSE);
            return output.ToString();
        }

        private static string FormatAsJavascript(Dictionary<string, string> renderedPairs)
        {
            StringBuilder output = new StringBuilder(Constants.JS_DICT_OPEN);
            string formattedPairs = string.Join(
                ",",
                renderedPairs.Select(kvp => kvp.Key + Constants.JS_DICT_SEP + kvp.Value));
            output.Append(formattedPairs);            
            output.Append(Constants.JS_DICT_CLOSE);
            return output.ToString();
        }
    }
}
