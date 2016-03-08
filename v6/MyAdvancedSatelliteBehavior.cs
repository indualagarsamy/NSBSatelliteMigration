using System;
using System.Threading.Tasks;
using NServiceBus.Pipeline;

class MyAdvancedSatelliteBehavior : PipelineTerminator<IIncomingPhysicalMessageContext>
{
    protected override Task Terminate(IIncomingPhysicalMessageContext context)
    {
        Console.WriteLine("Invoking Advanced Satellite behavior");
        return Task.FromResult(true);
    }
}

