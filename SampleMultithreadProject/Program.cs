using System;
using System.Threading;
using TracerLibrary;
using TracerLibrary.Interfaces;

namespace SampleMultithreadProject
{
    class Program
    {
        private static ITracer _tracer;
        
        static void MethodA()
        {
            _tracer.StartTrace();
            MethodB();
            Thread.Sleep(500);
            _tracer.StopTrace();
        }

        static void MethodB()
        {
            _tracer.StartTrace();
            Thread.Sleep(300);
            _tracer.StopTrace();
        }

        static void MethodC()
        {
            MethodB();
            MethodA();
        }
        
        
        static void Main(string[] args)
        {
            _tracer = new Tracer();
            MethodC();
            var result2 = _tracer.GetTraceResult();
            MethodB();
            Thread thread = new Thread(MethodC);
            thread.Start();
            Thread.Sleep(1000);
            var result = _tracer.GetTraceResult();
        }
    }
}