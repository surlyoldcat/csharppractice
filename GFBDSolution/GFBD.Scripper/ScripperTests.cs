using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace GFBD.Scripper
{
    /// <summary>
    /// A bunch of pseudo-unit tests to validate
    /// different test cases for ObjectScripper
    /// </summary>
    internal class ScripperTests
    {
        /// <summary>
        /// Main method for running all the tests.
        /// This method will execute every method
        /// that has a name starting with "Test".
        /// </summary>
        public void RunTests()
        {
            
            Type myType = this.GetType();
            foreach(var m in myType.GetMethods())
            {
                string methodName = m.Name;
                if (methodName.StartsWith("Test"))
                {
                    m.Invoke(this, null);
                }
            }
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

            Dictionary<int, object> outerDict = new Dictionary<int, object>
            {
                { 1, "Fortinbras" },
                { 4, arrayOfDicts },
                { 17, dictOfLists }
            };
            object o = (object)outerDict;
            string js = ObjectScripper.RenderObject(o, OutputFormat.Javascript);
            ValidateJavascript(js);
            Console.WriteLine("Pass.");
            
        }

        public void TestJS_CustomClass()
        {
            Console.WriteLine("Testing JS rendering of anonymous type...");
            var monk = new
            {
                MonkeyName = "Micky",
                NumFingers = 9,
                FaveNumbers = new int[3] { 7, 19, 50 }
            };
            object o = (object)monk;
            string js = ObjectScripper.RenderObject(o, OutputFormat.Javascript);
            ValidateJavascript(js);
            Console.WriteLine("Pass.");
        }

        public void TestJS_ListWithNulls()
        {
            Console.WriteLine("Testing JS rendering of a list with nulls.");
            List<object> stuff = new List<object> { "this", null, "is", "not", null };
            object o = (object)stuff;
            string html = ObjectScripper.RenderObject(o, OutputFormat.Html);
            ValidateHtml(html);
            Console.WriteLine("Pass.");
        }

        public void TestJS_DictWithNulls()
        {
            Console.WriteLine("Testing JS rendering of a dict that involves some NULLage");
            Dictionary<object, object> dict = new Dictionary<object, object>
            {
                {"paper", "maserati" },
                {"plastic", null }
            };
            object o = (object)dict;
            string js = ObjectScripper.RenderObject(o, OutputFormat.Javascript);
            ValidateJavascript(js);
            Console.WriteLine("Pass.");
        }
        public void TestHTML_ListOfStrings()
        {
            Console.WriteLine("Testing HTML rendering of a list of strings");
            List<string> stuff = new List<string> { "here", "are", "some", "strings" };
            object o = (object)stuff;
            string html = ObjectScripper.RenderObject(o, OutputFormat.Html);
            ValidateHtml(html);
            Console.WriteLine("Pass.");
        }

        public void TestHTML_CustomClass()
        {
            Console.WriteLine("Testing HTML rendering of anonymous type.");
            var puppy = new
            {
                Color = "brown",
                Breed = "shepherd mix",
                DOB = new DateTime(2014, 3, 10),
                Name = "Buppo"
            };
            object o = (object)puppy;
            string html = ObjectScripper.RenderObject(o, OutputFormat.Html);
            ValidateHtml(html);
            Console.WriteLine("Pass.");
        }

        public void TestHtml_ListWithNulls()
        {
            Console.WriteLine("Testing HTML rendering for an array with a null.");
            object[] things = new object[4];
            things[0] = "banana";
            things[1] = new string[2] { "cranberry", "botox" };
            things[3] = 1200;
             object o = (object)things;
            string html = ObjectScripper.RenderObject(o, OutputFormat.Html);
            ValidateHtml(html);
            Console.WriteLine("Pass.");
            
        }

        public void TestHtml_MixedList()
        {

            object[] things = new object[4]
            {
                "Hamburg",
                140,
                new Dictionary<int, string>
                {
                    {2, "two" },
                    {5, "five" },
                    {117, "eleventy-seven" }
                },
                DateTime.Now
            };
             object o = (object)things;
            string html = ObjectScripper.RenderObject(o, OutputFormat.Html);
            ValidateHtml(html);
            Console.WriteLine("Pass.");

        }

        private static void ValidateHtml(string html)
        {
            // validate the HTML by running it through an XML parser.
            Console.WriteLine("HTML: " + html);
            Console.WriteLine("Validating HTML using XML parser...");
            string test = "<html>" + html + "</html>";
            try
            {
                XElement.Parse(test);
            }
            catch (Exception ex)
            {

                throw new ApplicationException("XML parser failed to parse generated HTML! " + ex.Message);
            }
            Console.WriteLine("The XML parser was able to parse the generated HTML.");
            

        }

        private static void ValidateJavascript(string js)
        {
            // use the Newtonsoft library to try to parse the generated Javascript.
            // it's not the perfect solution (Javascript != JSON) but it will do for now.
            Console.WriteLine("Javascript: " + js);
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
