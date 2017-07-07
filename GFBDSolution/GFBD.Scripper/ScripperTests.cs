using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFBD.Scripper
{
    internal class ScripperTests
    {
        public object JavascriptParser { get; private set; }

        public void TestAllTheThings()
        {
            TestJS_Simple();
            TestJS_PlainArray();
            TestJS_PlainDict();
            TestJS_NestedArray();
            TestJS_MultiplyNestedDict();
        }

        public void TestJS_Simple()
        {
            Console.WriteLine("Testing simple Javascript rendering...");
            object o = (object)"i'm a string";
            string js = ObjectScripper.RenderObject(o, OutputFormat.Javascript);
            string expected = "\"i'm a string\"";
            if (js != expected)
                throw new ApplicationException($"Test failed! Expected: {expected} Actual:{js}");

            
            ValidateJavascript(js);
            Console.WriteLine("Pass.");
        }

        public void TestJS_PlainArray()
        {
            Console.WriteLine("Testing JS rendering of a simple, single-type array...");
            int[] numbers = new int[5] { 5, 10, 11, 66, 2265 };
            object o = (object)numbers;
            string js = ObjectScripper.RenderObject(o, OutputFormat.Javascript);
            string expected = "[\"5\",\"10\",\"11\",\"66\",\"2265\"]";
            if (js != expected)
                throw new ApplicationException($"Test failed! Expected: {expected} Actual:{js}");

            Console.WriteLine(js);
            ValidateJavascript(js);
            Console.WriteLine("Pass.");
        }

        public void TestJS_PlainDict()
        {
            Console.WriteLine("Testing JS rendering of a simple hashtable...");
            Dictionary<string, int> dict = new Dictionary<string, int>
            {
                {"a", 1 },
                {"b", 2 },
                {"c", 3 },
                {"foobyboo", 1234 }
            };
            object o = (object)dict;
            string js = ObjectScripper.RenderObject(o, OutputFormat.Javascript);
            Console.WriteLine(js);
            ValidateJavascript(js);

            string expected = "{\"a\":\"1\",\"b\":\"2\",\"c\":\"3\",\"foobyboo\":\"1234\"}";
            if (js != expected)
                throw new ApplicationException($"Test failed! Expected: {expected} Actual:{js}");

            Console.WriteLine("Pass.");
        }

        public void TestJS_NestedArray()
        {
            Console.WriteLine("Testing JS rendering of an array with nested types...");
            object[] things = new object[4];
            things[0] = "a";
            things[1] = 2;
            things[2] = new int[3] { 10, 20, 30 };
            things[3] = new List<string> { "help", "me", "mommy" };
            object o = (object)things;


            string js = ObjectScripper.RenderObject(o, OutputFormat.Javascript);
            Console.WriteLine(js);
            ValidateJavascript(js);

            Console.WriteLine("Pass.");
        }

        public void TestJS_MultiplyNestedDict()
        {
            Console.WriteLine("Testing JS rendering of complex nested structure...");

            var arrayOfDicts = new Dictionary<int, double>[3];
            arrayOfDicts[0] = new Dictionary<int, double>
            {
                {1, 3.445 },
                {10, 884.34239 },
                {12, -4.32 }
            };
            arrayOfDicts[1] = new Dictionary<int, double>
            {
                {100, 100.10 },
                {110, 55443.20094 },
                {0, 1.8 },
                {98, 98.6 }
            };
            arrayOfDicts[2] = new Dictionary<int, double>
            {
                {1044, -44.2 },
                {8664, -101.8 },
                {25663, 9000.01 },
                {-5, 34.9999999 }
            };

            Dictionary<string, List<int>> dictOfLists = new Dictionary<string, List<int>>
            {
                {"this", new List<int>{1,3,5,7} },
                {"is", new List<int>{101, 102, 103, 104, 105, 106 } },
                {"so", new List<int> {66, 77, 88 } },
                {"ugly", new List<int> {2, 4, 6, 8, 10, 12} }
            };

            Dictionary<int, object> outerDict = new Dictionary<int, object>();
            outerDict.Add(1, "Fortinbras");
            outerDict.Add(4, arrayOfDicts);
            outerDict.Add(17, dictOfLists);

            object o = (object)outerDict;
            string js = ObjectScripper.RenderObject(o, OutputFormat.Javascript);
            Console.WriteLine(js);

            Console.WriteLine("Attempting to validate with Newtonsoft.Json...");
            ValidateJavascript(js);
      

            Console.WriteLine("Pass.");
            
        }

        private static void ValidateJavascript(string js)
        {
            Console.WriteLine("Attempting to validate with Newtonsoft.Json...");
            string testJS = "{testing: " + js + "}";
            try
            {
                Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Parse(testJS);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("JSON parser failed to parse generated string!" + ex.Message);
            }
            Console.WriteLine("Generated Javascript was parsed successfully.");
        }
    }
}
