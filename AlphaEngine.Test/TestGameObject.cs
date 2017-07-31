using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Aiv.Fast2D;
using OpenTK;
using System.IO;
using AlphaEngine;
using System.Reflection;

namespace AlphaEngine.Test
{
    [TestFixture]
    public class TestGameObject
    {
        public class FakeComponent : Component
        {
            public int fakeVariable = 0;

            public override void Awake()
            {
                fakeVariable++;
            }
            public override void Start()
            {
                fakeVariable++;
            }
            public override void Update()
            {
                fakeVariable++;
            }
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
        [Test]
        public void GreenLight_ComponentAwake_Start_Update() //test gameobject side
        {
            FakeComponent fake = go.AddComponent<FakeComponent>();
            Assert.That(fake.fakeVariable, Is.EqualTo(1)); //only awake before start and update
            go.Update(); //here component will be started and updated (increment by 2)
            Assert.That(fake.fakeVariable, Is.EqualTo(3));
            go.Update();
            go.Update();
            Assert.That(fake.fakeVariable, Is.EqualTo(5));
        }
        [Test]
        public void RedLight_ComponentAwake_Start_Update() //test gameobject side
        {
            FakeComponent fake = go.AddComponent<FakeComponent>();
            fake.IsActive = false;
            go.Update();
            Assert.That(fake.fakeVariable, !Is.EqualTo(3));
            go.Update();
            go.Update();
            Assert.That(fake.fakeVariable, !Is.EqualTo(5));
            go.Update();
            Assert.That(fake.fakeVariable, !Is.EqualTo(5));
            Assert.That(fake.fakeVariable, Is.EqualTo(1));
        }
        [Test]
        public void GreenLight_ComponentCount()
        {
            Assert.That(go.ComponentsCount, Is.EqualTo(0));
            go.AddComponent<FakeComponent>();
            Assert.That(go.ComponentsCount, Is.EqualTo(1));
            go.AddComponent<FakeComponent>();
            go.AddComponent<FakeComponent>();
            Assert.That(go.ComponentsCount, Is.EqualTo(3));
        }
        [Test]
        public void GreenLight_GetComponents()
        {
            FakeComponent[] fakes = go.GetComponents<FakeComponent>();
            Assert.That(fakes.Length, Is.EqualTo(0));
            go.AddComponent<FakeComponent>();
            go.AddComponent<FakeComponent>();
            go.AddComponent<FakeComponent>();
            fakes = go.GetComponents<FakeComponent>();
            Assert.That(fakes.Length, Is.EqualTo(3));
        }
        [Test]
        public void RedLight_GetComponents()
        {
            go.AddComponent<FakeComponent>();
            go.AddComponent<FakeComponent>();
            go.AddComponent<FakeComponent2>();
            FakeComponent[] fakes = go.GetComponents<FakeComponent>();
            Assert.That(fakes.Length, !Is.EqualTo(0));
        }
        [Test]
        public void GreenLight_RemoveComponent()
        {
            go.AddComponent<FakeComponent>();
            go.AddComponent<FakeComponent2>();
            go.RemoveComponent<FakeComponent>();
            Assert.That(go.ComponentsCount, Is.EqualTo(1));
        }
        [Test]
        public void RedLight_RemoveComponent()
        {
            bool wasRemoved = go.RemoveComponent<FakeComponent>();
            Assert.That(wasRemoved, Is.EqualTo(false));
        }
        [Test]
        public void RedLight_ExeptionThrowingIsNotAComponent() 
        {
            
            Assert.That(() => GameObject.ParseGOFromFile("AlphaEngine.Test/TestFolder/NotAComponent.txt"), Throws.Exception.TypeOf<NotAComponentException>());
        }
    }
}
