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
    public class TestTime
    {
        
        [SetUp]
        public void Init()
        {
            AlphaEngine.Init("test", new Vector2(50, 50),"not correct path");
        }

        [Test]
        public void GreenLight_DeltaTime()
        {
            AlphaEngine.Tick();
            AlphaEngine.Tick(); //need 2 tick of game engine for deltatime start

            Assert.That(AlphaEngine.Time.DeltaTime, Is.Not.EqualTo(0)); //time updated from window
        }
        [Test]
        public void RedLight_DeltaTime()
        {
            Assert.That(AlphaEngine.Time.DeltaTime,Is.EqualTo(0)); //time not updated from window
        }

        [Test]
        public void GreenLight_TimeScale()
        {
            AlphaEngine.Tick();
            AlphaEngine.Tick();
            float originalTimeScale = AlphaEngine.Time.DeltaTime;
            AlphaEngine.Time.TimeScale = 5f;
            Assert.That(AlphaEngine.Time.DeltaTime,Is.EqualTo(originalTimeScale *5f).Within(0.00001f));
        }
        [Test]
        public void RedLight_TimeScale()
        {
            AlphaEngine.Tick();
            AlphaEngine.Tick();
            float originalTimeScale = AlphaEngine.Time.DeltaTime;
            AlphaEngine.Time.TimeScale = 5f;
            Assert.That(AlphaEngine.Time.DeltaTime, Is.Not.EqualTo(originalTimeScale));
        }
        [Test]
        public void Test_TimeScale()
        {
            Assert.That(AlphaEngine.Time.TimeScale, Is.EqualTo(1f).Within(0.0000001f));
            AlphaEngine.Tick();
            Assert.That(AlphaEngine.Time.TimeScale, Is.EqualTo(1f).Within(0.0000001f));
            AlphaEngine.Time.TimeScale = 50.5f;
            Assert.That(AlphaEngine.Time.TimeScale, Is.EqualTo(50.5f).Within(0.0000001f));
        }

        [Test]
        public void GreenLight_UnscaledDeltaTime()
        {
            AlphaEngine.Tick();
            AlphaEngine.Tick();
            float originalTimeScale = AlphaEngine.Time.DeltaTime;  //is correct pass delta time and no unscaled?
            AlphaEngine.Time.TimeScale = 5f;
            Assert.That(AlphaEngine.Time.UnscaledDeltaTime, Is.EqualTo(originalTimeScale));
        }
        [Test]
        public void RedLight_UnscaledDeltaTime()
        {
            AlphaEngine.Tick();
            AlphaEngine.Tick();
            float originalTimeScale = AlphaEngine.Time.DeltaTime;  //is correct pass delta time and no unscaled?
            AlphaEngine.Time.TimeScale = 1000f;
            Assert.That(AlphaEngine.Time.UnscaledDeltaTime, Is.Not.EqualTo(originalTimeScale*1000f));
        }

    }
}
