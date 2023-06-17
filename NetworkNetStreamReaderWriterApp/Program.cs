using System.Net.Sockets;

using TcpClient client = new();
string server = "www.yandex.ru";
await client.ConnectAsync(server, 80);

var stream = client.GetStream();
var message = $"GET / HTTP/1.1\r\nHost: {server}\r\nConnection: Close\r\n\r\n";

using var writer  = new StreamWriter(stream);
await writer.WriteAsync(message);
await writer.FlushAsync();

using var reader = new StreamReader(stream);
var response = await reader.ReadToEndAsync();
Console.WriteLine(response);
