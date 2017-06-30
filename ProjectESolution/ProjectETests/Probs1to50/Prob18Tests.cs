using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProjectEProbs._1to50;

namespace ProjectETests.Probs1to50
{
    [TestFixture]
    [Category("Problem 18")]
    public class Prob18Tests
    {
        FileInfo Datafile { get; set; }
        [SetUp]
        public void Setup()
        {
            var binDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string p = Path.Combine(binDir, @"Data\Prob18Data.txt");
            Datafile = new FileInfo(p);
            if (!Datafile.Exists)
            {
                throw new FileNotFoundException(p);
            }
        }

        [Test]
        public void TestProb18()
        {
            var result = Prob18.GetMaxPathSum(Datafile);
            Assert.AreEqual(1079, result);

        }
    }
}
