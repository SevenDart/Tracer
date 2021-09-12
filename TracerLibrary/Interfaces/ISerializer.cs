using TracerLibrary.DataModels;

namespace TracerLibrary.Interfaces
{
    public interface ISerializer
    {
        string Serialize(TraceResult traceResult);
    }
}