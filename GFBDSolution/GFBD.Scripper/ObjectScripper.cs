using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFBD.Scripper
{
    
    /// <summary>
    /// Takes an object of unknown type and renders it 
    /// to a string of a particulr format (HTML or Javascript)
    /// </summary>
    /// <remarks>This should work with simple/scalar types, lists, arrays, and dictionaries,
    /// and nesting is allowed.</remarks>
    public static class ObjectScripper
    {
        /// <summary>
        /// Entry point for the object-to-string rendering process
        /// </summary>
        /// <param name="obj">object we want to see as a string</param>
        /// <param name="format">the format to render</param>
        /// <returns>string representation of the object, in the specified format</returns>
        public static string RenderObject(object obj, OutputFormat format)
        {            
            IRenderer renderer = RendererFactory.GetRenderer(obj);
            string result = renderer.Render(format);
            return result;
        }

      
        

        
    }
}
