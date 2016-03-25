using System;
using System.Threading.Tasks;
using NServiceBus;

class Program
{
    private static void Main(string[] args)
    {

        AsyncMain().GetAwaiter().GetResult();
    }

    static async Task AsyncMain()
    {
        EndpointConfiguration endpointConfiguration = new EndpointConfiguration("NsbSatellite - v6");
        endpointConfiguration.SendFailedMessagesTo("error");
        endpointConfiguration.EnableInstallers();
        endpointConfiguration.UsePersistence<InMemoryPersistence>();
        endpointConfiguration.DefineCriticalErrorAction(OnCriticalError);

        IEndpointInstance endpoint = await Endpoint.Start(endpointConfiguration);
        try
        {
            Start(endpoint);
        }
        finally
        {
            await endpoint.Stop();
        }
    }

    static Task OnCriticalError(ICriticalErrorContext context)
    {
        // If you want the process to be active, stop the endpoint. 
        Console.WriteLine("CriticalError action triggered!");
        return context.Stop();


        // If you want to kill the process, await the above, then raise a fail fast error as shown below. 
        //string failMessage = string.Format("Critical error shutting down:'{0}'.", context.Error);
        //Environment.FailFast(failMessage, context.Exception);
    }


    static void Start(IEndpointInstance busSession)
    {
        Console.WriteLine("Press Enter to send the DoSomething command to trigger the satellite behavior");
        Console.WriteLine("Press any key to exit");

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key != ConsoleKey.Enter)
            {
                return;
            }
            busSession.Send("targetQueue", new DoSomething());
            busSession.Send("targetQueue-adv", new DoSomething());
        }
    }
}

public class DoSomething : ICommand
{
}

