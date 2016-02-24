using System;
using System.Threading.Tasks;
using NServiceBus.Pipeline;

class MySatelliteBehavior : PipelineTerminator<IIncomingPhysicalMessageContext>
{
    protected override Task Terminate(IIncomingPhysicalMessageContext context)
    {
        Console.WriteLine("Invoking Satellite behavior");
        return Task.FromResult(true);
    }
}

