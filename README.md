# moxiworks-dotnet ![Codacy Badge](https://api.codacy.com/project/badge/Grade/d3e46b3d41624fea8f61b1da33cb7139)

 SDK for interacting with Moxi Works API.
 
 Currently based on the [.NET Standard 2.0](https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md)


The current implemtation uses the [HttpClient](https://msdn.microsoft.com/en-us/library/system.net.http.httpclient(v=vs.118).aspx) for session handling.

> **HttpClient** is intended to be instantiated once and re-used throughout the life of an application. Especially in server applications, creating a new HttpClient instance for every request will exhaust the number of sockets available under heavy loads. This will result in SocketException errors.

Like the HttpClient only an instance of the MoxiWorks.Platform SDK sould be re-used for the life of the application. 