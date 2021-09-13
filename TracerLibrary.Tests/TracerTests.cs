using System;
using System.Threading;
using NUnit.Framework;
using TracerLibrary.Interfaces;

namespace TracerLibrary.Tests
{
    public class TracerTests
    {
        private ITracer _tracer;
        
        [SetUp]
        public void Setup()
        {
            _tracer = new Tracer();
        }

        [Test]
        public void OneThread_OneMethod_300Ms()
        {
            //Arrange
            void TestMethod()
            {
                _tracer.StartTrace();
                Thread.Sleep(300);
                _tracer.StopTrace();
            }
            
            //Act
            TestMethod();
            
            //Assert
            var traceResult = _tracer.GetTraceResult();
            var time = traceResult.Threads[Thread.CurrentThread.ManagedThreadId].Time;
            var result = time.TotalMilliseconds is >= 300 and <= 310;
            Assert.IsTrue(result, "Traced time in one thread with one method is incorrect.");
        }
        
        [Test]
        public void Inner_Method_300Ms_500Ms()
        {
            //Arrange
            void InnerMethod()
            {
                _tracer.StartTrace();
                Thread.Sleep(500);
                _tracer.StopTrace();
            }

            void OuterMethod()
            {
                _tracer.StartTrace();
                Thread.Sleep(300);
                InnerMethod();
                _tracer.StopTrace();
            }
            
            //Act
            OuterMethod();
            
            //Assert
            var traceResult = _tracer.GetTraceResult();
            var time = traceResult.Threads[Thread.CurrentThread.ManagedThreadId].Time;
            var result = time.TotalMilliseconds is >= 800 and <= 810;
            
            Assert.IsTrue(result, "Traced time in one thread with inner method is incorrect.");
        }
    }
}