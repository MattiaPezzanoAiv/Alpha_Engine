using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenTK;

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
        [Test]
        public void GreenLight_Position()
        {
            Transform t = fakeGO.AddComponent<Transform>();
            t.Position = Vector2.Zero;
            t.Position += new Vector2(10, 10);
            Assert.That(t.Position, Is.EqualTo(new Vector2(10,10)));
            t.Position -= new Vector2(5, 5);
            Assert.That(t.Position, Is.EqualTo(new Vector2(5, 5)));
        }
        [Test]
        public void RedLight_Position()
        {
            Transform t = fakeGO.AddComponent<Transform>();
            t.Position += new Vector2(10, 10);
            Assert.That(t.Position, Is.Not.EqualTo(new Vector2(5, 5)));
        }
        [Test]
        public void GreenLight_PositionWithParent()  //position assignation when parented, ignore parenting (like i want)
        {
            Transform t = fakeGO.AddComponent<Transform>();
            Transform t2 = otherFakeGO.AddComponent<Transform>();
            t.Parent = t2;
            t.Position += new Vector2(10, 10);
            Assert.That(t.Position, Is.EqualTo(new Vector2(10, 10)));
            t2.Position = new Vector2(100, 10);
            Assert.That(t2.Position, Is.EqualTo(new Vector2(100,10)));
        }
        [Test]
        public void GreenLight_LocalPositionAssignation() //with parenting and without parenting
        {
            Transform t = fakeGO.AddComponent<Transform>();
            Transform t2 = otherFakeGO.AddComponent<Transform>();
            t.Parent = t2;

            t2.LocalPosition = new Vector2(10, 10); //without parenting i expect that is assigned like position

            t.LocalPosition = new Vector2(10, 10); // t have a parent
            Assert.That(t2.Position, Is.EqualTo(new Vector2(10,10)));
            Assert.That(t2.LocalPosition, Is.EqualTo(new Vector2(10, 10)));

            Assert.That(t.Position, Is.EqualTo(new Vector2(20, 20)));
            Assert.That(t.LocalPosition, Is.EqualTo(new Vector2(10, 10)));
        }
        [Test]
        public void RedLight_LocalPositionAssignation() //with parenting and without parenting
        {
            Transform t = fakeGO.AddComponent<Transform>();
            Transform t2 = otherFakeGO.AddComponent<Transform>();
            t.Parent = t2;

            t2.Position = new Vector2(10, 10);

            t.LocalPosition = t2.Position + new Vector2(10, 10);
            Assert.That(t.LocalPosition, Is.Not.EqualTo(new Vector2(10, 10)));
            Assert.That(t.LocalPosition, Is.EqualTo(new Vector2(20, 20)));
        }
        [Test]
        public void GreenLight_PositionAssignationWithParenting()
        {
            Transform t = fakeGO.AddComponent<Transform>();
            Transform t2 = otherFakeGO.AddComponent<Transform>();
            t.Parent = t2;

            t2.Position = new Vector2(10, 10);
            t.Position = new Vector2(-10, -10);

            Assert.That(t.LocalPosition, Is.EqualTo(new Vector2(-20, -20)));
            Assert.That(t.Position, Is.EqualTo(new Vector2(-10, -10)));
        }
    }
}
