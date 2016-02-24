using NServiceBus;
using NServiceBus.Features;
using NServiceBus.Transports;

public class MySatelliteFeature : Feature
{

    public MySatelliteFeature()
    {
        EnableByDefault();
    }

    protected override void Setup(FeatureConfigurationContext context)
    {
        string processorAddress;

        // TODO: How can I specify a queue that's different from the endpoint instance name. 
        var messageProcessorPipeline = context.AddSatellitePipeline("CustomSatellite", "targetQueue", TransportTransactionMode.TransactionScope, PushRuntimeSettings.Default, out processorAddress);
        // In this example, the satellite input queue is [endpointname].targetqueue. Where targetQueue is the qualifier. What if I want a queue that's say "InputQueue"?
            
        // Register the satellite
        messageProcessorPipeline.Register("CustomSatellite", new MySatelliteBehavior(), "Description of what the satellite does");
    }
}

