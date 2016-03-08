using System;
using NServiceBus;
using NServiceBus.Faults;

internal class SatelliteImportFailuresHandler : IManageMessageFailures
{   
    public void SerializationFailedForMessage(TransportMessage message, Exception e)
    {
        Console.WriteLine("Handle stuff for Serialization failure");
    }

    public void ProcessingAlwaysFailsForMessage(TransportMessage message, Exception e)
    {
        Console.WriteLine("Handle stuff for Processing failures");
    }

    public void Init(Address address)
    {
    }
}