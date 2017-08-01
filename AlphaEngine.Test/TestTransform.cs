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
        public void GreenLight_SetParent()
        {
            Transform t = fakeGO.AddComponent<Transform>();
            Transform otherT = otherFakeGO.AddComponent<Transform>();

            t.SetParent(otherT);
            Assert.That(() => t.ChildCount, Throws.Nothing); //not throw null ref exception
            Assert.That(otherT.ChildCount, Is.EqualTo(1)); //have one child (t)
        }
        [Test]
        public void GreenLight_SetNullParent()
        {
            Transform t = fakeGO.AddComponent<Transform>();
            Transform otherT = otherFakeGO.AddComponent<Transform>();

            t.SetParent(otherT);
            t.SetParent(null);
            Assert.That(otherT.ChildCount, Is.EqualTo(0));
        }

        [Test]
        public void RedLight_Parenting()
        {
            Transform t = fakeGO.AddComponent<Transform>();
            Transform otherT = otherFakeGO.AddComponent<Transform>();

            t.SetParent(otherT);
            Assert.That(() => otherT.SetParent(t), Throws.Exception.TypeOf<RedundantFatherException>());
        }
        [Test]
        public void GreenLight_MultipleObjectParenting()
        {
            GameObject a = new GameObject("g1");
            GameObject b = new GameObject("g2");
            GameObject c = new GameObject("g3");

            Transform aT = a.AddComponent<Transform>();
            Transform bT = b.AddComponent<Transform>();
            Transform cT = c.AddComponent<Transform>();

            cT.SetParent(bT);
            bT.SetParent(aT);

            cT.SetParent(aT);
            Assert.That(aT.ChildCount, Is.EqualTo(2));
            Assert.That(bT.ChildCount, Is.EqualTo(0));

            cT.SetParent(bT);
            Assert.That(aT.ChildCount, Is.Not.EqualTo(2));
            Assert.That(bT.ChildCount, Is.EqualTo(1));

            Assert.That(() => aT.SetParent(cT), Throws.Exception.TypeOf<RedundantFatherException>());
        }

    }
}
