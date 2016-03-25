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
        var messageProcessorPipeline = context.AddSatellitePipeline("AdvancedSatellite", TransportTransactionMode.TransactionScope, PushRuntimeSettings.Default, "targetQueue-adv");
        
        // register the critical error
        messageProcessorPipeline.Register("AdvancedSatellite", b => new MyAdvancedSatelliteBehavior(b.Build<CriticalError>()),
                "Description of what the advanced satellite does");

   }
}