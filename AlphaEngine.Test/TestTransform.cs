using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AlphaEngine.Test
{
    [TestFixture]
    public class TestTransform
    {
        GameObject fakeGO;
        GameObject otherFakeGO;
        [SetUp]
        public void Init()
        {
            fakeGO = new GameObject("test");
            otherFakeGO = new GameObject("test2");
        }

        [Test]
        public void GreenLight_AddChild()
        {
            Transform t = fakeGO.AddComponent<Transform>();
            Transform otherT = otherFakeGO.AddComponent<Transform>();

            t.SetParent(otherT);
            Assert.That(() => t.ChildCount, Throws.Nothing); //not throw null ref exception
            Assert.That(otherT.ChildCount, Is.EqualTo(1)); //have one child (t)
        }
    }
}
