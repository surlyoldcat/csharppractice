using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFBD.Scripper
{
    

    public class ObjectScripper
    {
        public ObjectScripper(object obj)
        {
            /*
            1. get base type (simple/scalar or collection (or composite?))
            2. build up a hierarchy of Thingys that matches the object's structure
            3. recursively populate the hierarchy- it stops when it reaches
                    a simple type;
            4. call Render on the 'root.' this should trigger a recursive Render all the way down.
            */
        }

       
    }
}
