using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Pipeline;

class MyAdvancedSatelliteBehavior : PipelineTerminator<ISatelliteProcessingContext>
{

    CriticalError CriticalError { get; set; }
    public MyAdvancedSatelliteBehavior(CriticalError CriticalError)
    {
        this.CriticalError = CriticalError;
    }

    protected override Task Terminate(ISatelliteProcessingContext context)
    {
        Console.WriteLine("Invoking Advanced Satellite behavior");
        CriticalError.Raise("Something bad happened - trigger critical error", new Exception("CriticalError occured!!"));
        return Task.FromResult(true);
    }
}

