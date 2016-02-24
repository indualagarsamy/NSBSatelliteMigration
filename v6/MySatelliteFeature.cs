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
        // In this example, the satellite input queue is targetqueue. 
        var messageProcessorPipeline = context.AddSatellitePipeline("CustomSatellite", "targetQueue", TransportTransactionMode.TransactionScope, PushRuntimeSettings.Default);
            
        // Register the satellite
        messageProcessorPipeline.Register("CustomSatellite", new MySatelliteBehavior(), "Description of what the satellite does");
    }
}

