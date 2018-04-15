using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AlphaEngine.Test
{
    [TestFixture]
    public class TestSceneManager
    {

        [Test]
        public void RedLight_LoadScene()
        {
            //load a scene with 2 gameobjects with the same name (not possible because windows cant save 2 files with same name)
        }
        [Test]
        public void GreenLight_LoadScene()
        {
            //load a simple scene with 2 objects and components
            //assert what you expect
        }
        [Test]
        public void ChangeSceneTest()
        {
            //load a scene with 3 go
            //assert 3 go loaded
            //load scene with no 3 go (5 or 2)
            //assert the new number of go loaded
        }
        [Test]
        public void RedLight_GetObject()
        {
            //reload a scene
            //get object with scenemanager.getobject(name), put unreal name
            //asert object is null
        }
        [Test]
        public void GreenLight_Getobject()
        {
            //like upper method, but assert that is not null
        }
        [Test]
        public void TickGOTest()
        {
            // load scene with a go with fake component
            //tick scene
            //assert that component variable is incremented
        }
        [Test]
        public void TickGOTestWithNoActiveGO()
        {
            //same like upper test but set go as not active
        }
    }
}
