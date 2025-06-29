using System;
using System.Net;
using System.Net.Sockets;
using System.IO;

class ChatServer
{
    static void Main()
    {
        // Create TcpListener to listen on localhost:50000
        TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 50000);
        listener.Start();
        Console.WriteLine("Server started. Waiting for connection...");

        // Accept incoming client connection (blocking)
        Socket socket = listener.AcceptSocket();
        Console.WriteLine("Client connected.");

        // Create NetworkStream over the accepted socket
        NetworkStream stream = new NetworkStream(socket);
        // Wrap stream with BinaryReader and BinaryWriter for easy string I/O
        BinaryReader reader = new BinaryReader(stream);
        BinaryWriter writer = new BinaryWriter(stream);

        // Send welcome message to client
        writer.Write("SERVER>>> Welcome to the chat!");

        string message = "";
        while (message != "CLIENT>>> TERMINATE")
        {
            try
            {
                // Read message from client
                message = reader.ReadString();
                Console.WriteLine(message);

                // Prompt server user for reply
                Console.Write("SERVER>>> ");
                string response = Console.ReadLine();

                // Send response to client
                writer.Write("SERVER>>> " + response);

                // If termination message sent, break loop
                if (response == "TERMINATE") break;
            }
            catch
            {
                // Handle any exceptions silently and exit loop
                break;
            }
        }

        // Close all streams and sockets
        writer.Close();
        reader.Close();
        stream.Close();
        socket.Close();
        listener.Stop();

        Console.WriteLine("Connection closed.");
    }
}
