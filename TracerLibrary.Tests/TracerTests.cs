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
        public void Trace_OneThread_OneMethod_300Ms()
        {
            //Arrange
            const int testingTime = 300;
            const int acceptableDeviation = 50;
            
            void TestMethod()
            {
                _tracer.StartTrace();
                Thread.Sleep(testingTime);
                _tracer.StopTrace();
            }
            
            //Act
            TestMethod();
            
            //Assert
            var traceResult = _tracer.GetTraceResult();
            var time = traceResult.Threads[Thread.CurrentThread.ManagedThreadId].Time;
            Assert.GreaterOrEqual(time.TotalMilliseconds, testingTime, 
                "Elapsed time must be equal or greater than expected.");
            Assert.LessOrEqual(time.TotalMilliseconds, testingTime + acceptableDeviation, 
                "Elapsed time must be equal or less than acceptable deviation.");
        }
        
        [Test]
        public void Trace_InnerMethod_500Ms_OuterMethod_300Ms()
        {
            //Arrange
            const int testingTimeForOuterMethod = 300;
            const int testingTimeForInnerMethod = 500;
            const int acceptableDeviation = 50;
            
            void InnerMethod()
            {
                _tracer.StartTrace();
                Thread.Sleep(testingTimeForInnerMethod);
                _tracer.StopTrace();
            }

            void OuterMethod()
            {
                _tracer.StartTrace();
                Thread.Sleep(testingTimeForOuterMethod);
                InnerMethod();
                _tracer.StopTrace();
            }
            
            //Act
            OuterMethod();
            
            //Assert
            var traceResult = _tracer.GetTraceResult();
            var time = traceResult.Threads[Thread.CurrentThread.ManagedThreadId].Time;
            Assert.GreaterOrEqual(time.TotalMilliseconds, testingTimeForInnerMethod + testingTimeForOuterMethod, 
                "Elapsed time must be equal or greater than expected.");
            Assert.LessOrEqual(time.TotalMilliseconds, testingTimeForInnerMethod + testingTimeForOuterMethod + acceptableDeviation, 
                "Elapsed time must be equal or less than acceptable deviation.");
        }
        
        [Test]
        public void Trace_Serial_Methods_300Ms_500Ms()
        {
            //Arrange
            const int testingTimeForFirstMethod = 300;
            const int testingTimeForSecondMethod = 500;
            const int acceptableDeviation = 50;
            
            void FirstMethod()
            {
                _tracer.StartTrace();
                Thread.Sleep(testingTimeForFirstMethod);
                _tracer.StopTrace();
            }

            void SecondMethod()
            {
                _tracer.StartTrace();
                Thread.Sleep(testingTimeForSecondMethod);
                _tracer.StopTrace();
            }
            
            //Act
            FirstMethod();
            SecondMethod();
            
            //Assert
            var traceResult = _tracer.GetTraceResult();
            var time = traceResult.Threads[Thread.CurrentThread.ManagedThreadId].Time;

            Assert.GreaterOrEqual(time.TotalMilliseconds, testingTimeForFirstMethod + testingTimeForSecondMethod, 
                "Elapsed time must be equal or greater than expected.");
            Assert.LessOrEqual(time.TotalMilliseconds, testingTimeForFirstMethod + testingTimeForSecondMethod + acceptableDeviation, 
                "Elapsed time must be equal or less than acceptable deviation.");
        }
        
        
        [Test]
        public void Trace_TwoThreads_300Ms()
        {
            //Arrange
            const int testingTime = 300;
            const int acceptableDeviation = 50;
            
            void TestingMethod()
            {
                _tracer.StartTrace();
                Thread.Sleep(testingTime);
                _tracer.StopTrace();
            }

            var firstThread = new Thread(TestingMethod);
            var secondThread = new Thread(TestingMethod);

            //Act
            firstThread.Start();
            secondThread.Start();
            Thread.Sleep(500);
            
            //Assert
            var traceResult = _tracer.GetTraceResult();
            Assert.AreEqual(traceResult.Threads.Count, 2, "There are must be two threadInformation structs in dictionary.");
            foreach (var threadInformation in traceResult.Threads.Values)
            {
                var time = threadInformation.Time;
                Assert.GreaterOrEqual(time.TotalMilliseconds, testingTime, 
                    "Elapsed time must be equal or greater than expected.");
                Assert.LessOrEqual(time.TotalMilliseconds, testingTime + acceptableDeviation, 
                    "Elapsed time must be equal or less than acceptable deviation.");
            }
        }
    }
}