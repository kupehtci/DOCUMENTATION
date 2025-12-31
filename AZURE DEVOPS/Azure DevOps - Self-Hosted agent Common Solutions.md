#AZURE_DEVOPS 

# Azure DevOps - Self-Hosted agent Common Solutions


## Update error SSL Certificate

When trying to update the agent it returns an error related with no-trusted SSL certificate: 
```log
[2025-12-31 08:44:31Z WARN SelfUpdater] Failed to get package 'D:\agent_work_update\agent1.zip' from 'https://download.agent.dev.azure.com/agent/4.266.2/vsts-agent-win-x64-4.266.2.zip'. Exception System.Net.Http.HttpRequestException: The SSL connection could not be established, see inner exception.
 ---> System.Security.Authentication.AuthenticationException: The remote certificate is invalid according to the validation procedure.
   at System.Net.Security.SslStream.StartSendAuthResetSignal(ProtocolToken message, AsyncProtocolRequest asyncRequest, ExceptionDispatchInfo exception)
   at System.Net.Security.SslStream.CheckCompletionBeforeNextReceive(ProtocolToken message, AsyncProtocolRequest asyncRequest)
   at System.Net.Security.SslStream.StartSendBlob(Byte[] incoming, Int32 count, AsyncProtocolRequest asyncRequest)
   at System.Net.Security.SslStream.ProcessReceivedBlob(Byte[] buffer, Int32 count, AsyncProtocolRequest asyncRequest)
   at System.Net.Security.SslStream.StartReceiveBlob(Byte[] buffer, AsyncProtocolRequest asyncRequest)
   at System.Net.Security.SslStream.CheckCompletionBeforeNextReceive(ProtocolToken message, AsyncProtocolRequest asyncRequest)
   at System.Net.Security.SslStream.StartSendBlob(Byte[] incoming, Int32 count, AsyncProtocolRequest asyncRequest)
   at System.Net.Security.SslStream.ProcessReceivedBlob(Byte[] buffer, Int32 count, AsyncProtocolRequest asyncRequest)
   at System.Net.Security.SslStream.StartReceiveBlob(Byte[] buffer, AsyncProtocolRequest asyncRequest)
   at System.Net.Security.SslStream.CheckCompletionBeforeNextReceive(ProtocolToken message, AsyncProtocolRequest asyncRequest)
   at System.Net.Security.SslStream.StartSendBlob(Byte[] incoming, Int32 count, AsyncProtocolRequest asyncRequest)
   at System.Net.Security.SslStream.ProcessReceivedBlob(Byte[] buffer, Int32 count, AsyncProtocolRequest asyncRequest)
   at System.Net.Security.SslStream.PartialFrameCallback(AsyncProtocolRequest asyncRequest)
— End of stack trace from previous location where exception was thrown —
   at System.Net.Security.SslStream.InternalEndProcessAuthentication(LazyAsyncResult lazyResult)
   at System.Net.Security.SslStream.EndProcessAuthentication(IAsyncResult result)
   at System.Net.Security.SslStream.EndAuthenticateAsClient(IAsyncResult asyncResult)
   at System.Net.Security.SslStream.<>c.<AuthenticateAsClientAsync>b__65_1(IAsyncResult iar)
   at System.Threading.Tasks.TaskFactory`1.FromAsyncCoreLogic(IAsyncResult iar, Func`2 endFunction, Action`1 endAction, Task`1 promise, Boolean requiresSynchronization)
— End of stack trace from previous location where exception was thrown —
   at System.Net.Http.ConnectHelper.EstablishSslConnectionAsyncCore(Stream stream, SslClientAuthenticationOptions sslOptions, CancellationToken cancellationToken)
   --- End of inner exception stack trace —
   at System.Net.Http.ConnectHelper.EstablishSslConnectionAsyncCore(Stream stream, SslClientAuthenticationOptions sslOptions, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.ConnectAsync(HttpRequestMessage request, Boolean allowHttp2, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.CreateHttp11ConnectionAsync(HttpRequestMessage request, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.GetHttpConnectionAsync(HttpRequestMessage request, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.SendWithRetryAsync(HttpRequestMessage request, Boolean doRequestAuth, CancellationToken cancellationToken)
   at System.Net.Http.RedirectHandler.SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
   at System.Net.Http.HttpClient.FinishSendAsyncUnbuffered(Task`1 sendTask, HttpRequestMessage request, CancellationTokenSource cts, Boolean disposeCts)
   at System.Net.Http.HttpClient.FinishGetStreamAsync(Task`1 getTask)
   at Microsoft.VisualStudio.Services.Agent.Listener.SelfUpdater.DownloadLatestAgent(CancellationToken token)
[2025-12-31 08:44:31Z INFO JobDispatcher] Shutting down JobDispatcher. Make sure all WorkerDispatcher has finished.
[2025-12-31 08:44:31Z ERR  Terminal] WRITE ERROR: Error: Agent package 'D:\agent_work_update\agent1.zip' failed after 3 download attempts.
[2025-12-31 08:44:31Z ERR  AgentProcess] System.Threading.Tasks.TaskCanceledException: Agent package 'D:\agent_work_update\agent1.zip' failed after 3 download attempts.
   at Microsoft.VisualStudio.Services.Agent.Listener.SelfUpdater.DownloadLatestAgent(CancellationToken token)
   at Microsoft.VisualStudio.Services.Agent.Listener.SelfUpdater.SelfUpdate(AgentRefreshMessage updateMessage, IJobDispatcher jobDispatcher, Boolean restartInteractiveAgent, CancellationToken token)
   at Microsoft.VisualStudio.Services.Agent.Listener.Agent.RunAsync(AgentSettings settings, Boolean runOnce)
   at Microsoft.VisualStudio.Services.Agent.Listener.Agent.RunAsync(AgentSettings settings, Boolean runOnce)
   at Microsoft.VisualStudio.Services.Agent.Listener.Agent.RunAsync(AgentSettings settings, Boolean runOnce)
   at Microsoft.VisualStudio.Services.Agent.Listener.Agent.ExecuteCommand(CommandSettings command)
   at Microsoft.VisualStudio.Services.Agent.Listener.Program.MainAsync(IHostContext context, String[] args)

 
```

Solve SSL certificate error:

```powershell
certutil -generateSSTFromWU roots.sst
```