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
        
        
        static void Main(string[] args)
        {
            _tracer = new Tracer();
            MethodA();
            MethodB();
            var result = _tracer.GetTraceResult();
        }
    }
}