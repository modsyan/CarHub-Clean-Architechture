// using System.Net.Http.Json;
// using System.Text.Json.Nodes;
// using Microsoft.AspNetCore.Hosting.Server;
// using Microsoft.AspNetCore.Hosting.Server.Features;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.Hosting;
// using Microsoft.Extensions.Logging;
//
// namespace Mac.CarHub.Infrastructure.Tunnel;
//
// public class TunnelService(
//     IServer server,
//     IHostApplicationLifetime hostApplicationLifetime,
//     // IConfiguration config,
//     ILogger<TunnelService> logger)
//     : BackgroundService
// {
//     // private readonly IConfiguration config = config;
//
//     protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//     {
//         await WaitForApplicationStarted();
//
//         var urls = server.Features.Get<IServerAddressesFeature>()!.Addresses;
//         // Use https:// if you authenticated ngrok, otherwise, you can only use http://
//         var localUrl = urls.Single(u => u.StartsWith("http://"));
//
//         logger.LogInformation("Starting ngrok tunnel for {LocalUrl}", localUrl);
//         var ngrokTask = StartNgrokTunnel(localUrl, stoppingToken);
//
//         var publicUrl = await GetNgrokPublicUrl();
//         logger.LogInformation("Public ngrok URL: {NgrokPublicUrl}", publicUrl);
//
//         await ngrokTask;
//
//         logger.LogInformation("Ngrok tunnel stopped");
//     }
//
//     private Task WaitForApplicationStarted()
//     {
//         var completionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
//         hostApplicationLifetime.ApplicationStarted.Register(() => completionSource.TrySetResult());
//         return completionSource.Task;
//     }
//
//     private CommandTask<CommandResult> StartNgrokTunnel(string localUrl, CancellationToken stoppingToken)
//     {
//         var ngrokTask = Cli.Wrap("ngrok")
//             .WithArguments(args => args
//                 .Add("http")
//                 .Add(localUrl)
//                 .Add("--log")
//                 .Add("stdout"))
//             .WithStandardOutputPipe(PipeTarget.ToDelegate(s => logger.LogDebug(s)))
//             .WithStandardErrorPipe(PipeTarget.ToDelegate(s => logger.LogError(s)))
//             .ExecuteAsync(stoppingToken);
//         return ngrokTask;
//     }
//
//     private async Task<string> GetNgrokPublicUrl()
//     {
//         using var httpClient = new HttpClient();
//         for (var ngrokRetryCount = 0; ngrokRetryCount < 10; ngrokRetryCount++)
//         {
//             logger.LogDebug("Get ngrok tunnels attempt: {RetryCount}", ngrokRetryCount + 1);
//
//             try
//             {
//                 var json = await httpClient.GetFromJsonAsync<JsonNode>("http://127.0.0.1:4040/api/tunnels");
//                 var publicUrl = json["tunnels"].AsArray()
//                     .Select(e => e["public_url"].GetValue<string>())
//                     .SingleOrDefault(u => u.StartsWith("https://"));
//                 if (!string.IsNullOrEmpty(publicUrl)) return publicUrl;
//             }
//             catch
//             {
//                 // ignored
//             }
//
//             await Task.Delay(200);
//         }
//
//         throw new Exception("Ngrok dashboard did not start in 10 tries");
//     }
// }
