using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AlphaEngine.Test
{
    [TestFixture]
    public class TestSolidRenderer
    {

        public GameObject go;
        [SetUp]
        public void Init()
        {
            AlphaEngine.Init("",new OpenTK.Vector2(100,100));  //window must be instanced for mesh testing
            go = new GameObject("go");
        }

        [Test]
        public void GreenLight_AddSolidRendWithoutTransform()
        {
            go.AddComponent<SolidRenderer>();
            Assert.That(go.GetComponent<Transform>(), Is.Not.EqualTo(null));
        }
    }
}
