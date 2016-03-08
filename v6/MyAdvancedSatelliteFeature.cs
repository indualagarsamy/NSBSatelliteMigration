using NServiceBus;
using NServiceBus.Features;
using NServiceBus.Transports;

public class MyAdvancedSatelliteFeature : Feature
{

    public MyAdvancedSatelliteFeature()
    {
        EnableByDefault();
    }

    protected override void Setup(FeatureConfigurationContext context)
    {
        // In this example, the satellite input queue is targetqueue. 
        var messageProcessorPipeline = context.AddSatellitePipeline("AdvancedSatellite", "targetQueue-adv", TransportTransactionMode.TransactionScope, PushRuntimeSettings.Default);
            
        // Register the satellite
        messageProcessorPipeline.Register("AdvancedSatellite", new MyAdvancedSatelliteBehavior(), "Description of what the advanced satellite does");
    }
}