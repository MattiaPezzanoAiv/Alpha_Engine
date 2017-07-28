using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Aiv.Fast2D;
using OpenTK;

namespace AlphaEngine.Test
{
    [TestFixture]
    public class TestGameObject
    {
        public class FakeComponent:Component
        {
            
        }
        public class FakeComponent2 : Component
        {

        }

        private GameObject go;

        [SetUp]
        public void Init()
        {
            AlphaEngine.Init("test", new Vector2(50, 50));
            go = new GameObject("TEST");
        }

        [Test]
        public void GreenLight_NameAssignation()
        {
            Assert.That(go.Name, Is.EqualTo("TEST"));
        }
        [Test]
        public void RedLight_NameAssignation()
        {
            go.Name = "RedLight";
            Assert.That(go.Name, Is.EqualTo("RedLight"));
        }

        [Test]
        public void GreenLight_AddComponentAndGetComponent()
        {
            FakeComponent fake = go.AddComponent<FakeComponent>();
            Assert.That(go.GetComponent<FakeComponent>(), Is.EqualTo(fake));
        }
        [Test]
        public void RedLight_AddComponentAndGetComponent()
        {
            FakeComponent2 fake = go.AddComponent<FakeComponent2>();
            Assert.That(go.GetComponent<FakeComponent>(), Is.EqualTo(null));
        }
        [Test]
        public void Test_MultipleAddComponent()
        {
            FakeComponent2 fake = go.AddComponent<FakeComponent2>();
            FakeComponent2 fake2 = go.AddComponent<FakeComponent2>();
            FakeComponent2 fake3 = go.AddComponent<FakeComponent2>();
            Assert.That(go.GetComponent<FakeComponent2>(), Is.EqualTo(fake)); //list is ordered
        }
        [Test]
        public void Test_TryToUseSetOwnerManually()
        {
            GameObject go1 = new GameObject("mario");
            GameObject go2 = new GameObject("paolo");

            FakeComponent c = go1.AddComponent<FakeComponent>();
            Assert.That(c.GameObject, Is.EqualTo(go1));
            c.SetOwner(go2);  //will be ignored
            Assert.That(c.GameObject, Is.EqualTo(go1));
        }
    }
}
