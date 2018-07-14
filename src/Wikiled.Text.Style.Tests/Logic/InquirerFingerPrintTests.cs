using System;
using System.Linq;
using NUnit.Framework;

namespace Wikiled.Text.Style.Tests.Logic
{
    [TestFixture]
    public class InquirerFingerPrintTests
    {
        [Test]
        public void GetDataFirst()
        {
            var document = Global.InitDocument();
            var block = Global.StyleFactory.Construct(document.Sentences.ToArray());
            Assert.AreEqual(205, block.InquirerFinger.InquirerProbabilities.AllLeafs.Count());
            int index = 27;
            Assert.AreEqual("PLACE", block.InquirerFinger.InquirerProbabilities.AllLeafs.Skip(1 + index).First().Name);
            Assert.AreEqual(0.0, Math.Round((double)block.InquirerFinger.InquirerProbabilities.AllLeafs.First().Value, 2));
            Assert.AreEqual("Hostile", block.InquirerFinger.InquirerProbabilities.AllLeafs.Skip(36 + index).First().Name);
            Assert.AreEqual(0.05, Math.Round((double)block.InquirerFinger.InquirerProbabilities.AllLeafs.Skip(35 + index).First().Value, 2));
            Assert.AreEqual("Exch", block.InquirerFinger.InquirerProbabilities.AllLeafs.Skip(24 + index).First().Name);
            Assert.AreEqual(0.0, Math.Round((double)block.InquirerFinger.InquirerProbabilities.AllLeafs.Skip(24 + index).First().Value, 2));
            Assert.AreEqual("Strong", block.InquirerFinger.InquirerProbabilities.AllLeafs.Skip(34 + index).First().Name);
            Assert.AreEqual(0.12, Math.Round((double)block.InquirerFinger.InquirerProbabilities.AllLeafs.Skip(34 + index).First().Value, 2));
            Assert.AreEqual(3, block.InquirerFinger.InquirerProbabilities.Branches.Count);
            Assert.AreEqual(17, block.InquirerFinger.InquirerProbabilities.Branches[1].Branches.Count);
            Assert.AreEqual("Location", block.InquirerFinger.InquirerProbabilities.Branches[1].Branches[0].Name);
            Assert.AreEqual(0.01, Math.Round((double)block.InquirerFinger.InquirerProbabilities.Branches[1].Branches[0].Leafs[0].Value, 2));
        }

        [Test]
        public void GetDataSecond()
        {
            var document = Global.InitDocument("cv001_19502.txt");
            var block = Global.StyleFactory.Construct(document.Sentences.ToArray());
            int index = 27;
            Assert.AreEqual(205, block.InquirerFinger.InquirerProbabilities.AllLeafs.Count());
            Assert.AreEqual("PLACE", block.InquirerFinger.InquirerProbabilities.AllLeafs.Skip(1 + index).First().Name);
            Assert.AreEqual(0.0, Math.Round((double)block.InquirerFinger.InquirerProbabilities.AllLeafs.First().Value, 2));
            Assert.AreEqual("Hostile", block.InquirerFinger.InquirerProbabilities.AllLeafs.Skip(36 + index).First().Name);
            Assert.AreEqual(0.04, Math.Round((double)block.InquirerFinger.InquirerProbabilities.AllLeafs.Skip(35 + index).First().Value, 2));
            Assert.AreEqual("Exch", block.InquirerFinger.InquirerProbabilities.AllLeafs.Skip(24 + index).First().Name);
            Assert.AreEqual(0.0, Math.Round((double)block.InquirerFinger.InquirerProbabilities.AllLeafs.Skip(24 + index).First().Value, 2));
            Assert.AreEqual("Strong", block.InquirerFinger.InquirerProbabilities.AllLeafs.Skip(34 + index).First().Name);
            Assert.AreEqual(0.12, Math.Round((double)block.InquirerFinger.InquirerProbabilities.AllLeafs.Skip(34 + index).First().Value, 2));
            Assert.AreEqual(3, block.InquirerFinger.InquirerProbabilities.Branches.Count);
            Assert.AreEqual(17, block.InquirerFinger.InquirerProbabilities.Branches[1].Branches.Count);
            Assert.AreEqual("Location", block.InquirerFinger.InquirerProbabilities.Branches[1].Branches[0].Name);
            Assert.AreEqual(0.01, Math.Round((double)block.InquirerFinger.InquirerProbabilities.Branches[1].Branches[0].Leafs[0].Value, 2));
        }
    }
}
