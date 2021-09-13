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
            //Act
            _tracer.StartTrace();
            Thread.Sleep(300);
            _tracer.StopTrace();
            
            //Assert
            var traceResult = _tracer.GetTraceResult();
            var time = traceResult.Threads[Thread.CurrentThread.ManagedThreadId].Time;
            var result = time.TotalMilliseconds is >= 300 and <= 310;
            Assert.IsTrue(result, "Traced time in one thread with one method is incorrect.");
        }
    }
}