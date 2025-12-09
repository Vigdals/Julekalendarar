using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Julekalendarar.Kode24
{
    public static class NisseSocketClient
    {
        public static async Task RunAsync()
        {
            var uri = new Uri("wss://nisseserver-1.onrender.com/…"); 
            using var ws = new ClientWebSocket();

            Console.WriteLine("Koblar til nissesocket …");
            await ws.ConnectAsync(uri, CancellationToken.None);
            Console.WriteLine("Tilkopla!");

            // forbanna enkelt. Tenkte alt for komplisert i starten.
            var payload = "fattigmann";
            var payloadBytes = Encoding.UTF8.GetBytes(payload);

            await ws.SendAsync(
                payloadBytes,
                WebSocketMessageType.Text,
                endOfMessage: true,
                cancellationToken: CancellationToken.None);

            Console.WriteLine("Sendte melding: " + payload);

            var buffer = new byte[4 * 1024];

            while (ws.State == WebSocketState.Open)
            {
                var result = await ws.ReceiveAsync(
                    new ArraySegment<byte>(buffer),
                    CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    Console.WriteLine("Serveren lukka forbindelsen.");
                    await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "ok", CancellationToken.None);
                    break;
                }

                var msg = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.WriteLine(msg);
            }
        }


        public static async Task OldCode()
        {
            using var ws = new ClientWebSocket();
            await ws.ConnectAsync(new Uri("wss://nisseserver-1.onrender.com/…"), CancellationToken.None);

            //var payload = Encoding.UTF8.GetBytes("43543113133");
            //var payload = Encoding.UTF8.GetBytes("{\"kake\":\"fattigmann\"}");
            var payload = Encoding.UTF8.GetBytes("fattigmann");
            await ws.SendAsync(payload, WebSocketMessageType.Text, true, CancellationToken.None);

            // var buffer = new byte[1024];
            // var result = await ws.ReceiveAsync(buffer, CancellationToken.None);
            // var response = Encoding.UTF8.GetString(buffer, 0, result.Count);

            // Console.WriteLine("Velkommen mesling: " + response);
            var buffer = new byte[1024];

            while (true)
            {
                var result = await ws.ReceiveAsync(buffer, CancellationToken.None);
                var msg = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.WriteLine("WS: " + msg);
            }
        }
    }
}
