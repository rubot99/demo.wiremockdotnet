namespace wiremockdotnet.console
{
    using System;
    using WireMock.RequestBuilders;
    using WireMock.ResponseBuilders;
    using WireMock.Server;
    using WireMock.Settings;

    public class Program
    {
        public static void Main(string[] args)
        {
            var stub = FluentMockServer.Start(new FluentMockServerSettings
            {
                Urls = new[] { "http://+:2001" },
                StartAdminInterface = true
            });


            stub.Given(
                    Request.Create()
                        .WithPath("/mytext/*")
                        .UsingGet())
                .RespondWith(Response.Create()
                    .WithStatusCode(200)
                    .WithHeader("Content-Type", "application/text")
                    .WithBodyAsJson("result: OK credits: 0"));

            Console.WriteLine("Press any key to stop the server");
            Console.ReadLine();
            stub.Stop();
        }
    }
}
