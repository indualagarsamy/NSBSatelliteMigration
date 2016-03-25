using System;
using System.Threading.Tasks;
using NServiceBus.Pipeline;

class MySatelliteBehavior : PipelineTerminator<ISatelliteProcessingContext>
{
    protected override Task Terminate(ISatelliteProcessingContext context)
    {
        Console.WriteLine("Invoking Satellite behavior");
        return Task.FromResult(true);
    }
}

