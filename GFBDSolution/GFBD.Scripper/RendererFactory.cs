using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFBD.Scripper
{
    /// <summary>
    /// Simple factory class which creates IRenderer instances
    /// for supported data structures
    /// </summary>
    internal static class RendererFactory
    {
        /// <summary>
        /// Get an IRenderer that can work with the supplied object type
        /// </summary>
        /// <param name="obj">the object to be rendered</param>
        /// <returns>A real live IRenderer!</returns>
        public static IRenderer GetRenderer(object obj)
        {
            Type typ = obj.GetType();
            if (typ.IsPrimitive || typ == typeof(string))
            {
                return new SimpleRenderer(obj);
            }
            else if (typeof(IDictionary).IsAssignableFrom(typ))
            {
                IDictionary dict = (IDictionary)obj;
                return new DictionaryRenderer(dict);
            }
            else if (typeof(IEnumerable).IsAssignableFrom(typ))
            {
                IEnumerable arr = (IEnumerable)obj;
                return new EnumerableRenderer(arr);
            }
            else
            {
                //big bad
                throw new ApplicationException("I don't know how to deal with type: " + typ.Name);
            }
        }

       
    }
}
