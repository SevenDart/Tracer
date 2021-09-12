using TracerLibrary.DataModels;

namespace TracerLibrary.Interfaces
{
    public interface IPrinter
    {
        void Print(ISerializer serializer, TraceResult traceResult);
    }
}