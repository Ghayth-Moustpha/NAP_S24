using System;
using System.Net.Sockets;
using System.IO;

class ChatClient
{
    static void Main()
    {
        // Connect to server at localhost:50000
        TcpClient client = new TcpClient("127.0.0.1", 50000);
        NetworkStream stream = client.GetStream();

        // Wrap stream with BinaryReader and BinaryWriter for string I/O
        BinaryReader reader = new BinaryReader(stream);
        BinaryWriter writer = new BinaryWriter(stream);

        // Read and display welcome message from server
        Console.WriteLine(reader.ReadString());

        string message = "";
        while (message != "TERMINATE")
        {
            // Read user input to send
            Console.Write("CLIENT>>> ");
            message = Console.ReadLine();

            // Send message prefixed with "CLIENT>>> "
            writer.Write("CLIENT>>> " + message);

            if (message == "TERMINATE") break;

            // Read and display server response
            Console.WriteLine(reader.ReadString());
        }

        // Close streams and client connection
        writer.Close();
        reader.Close();
        stream.Close();
        client.Close();

        Console.WriteLine("Disconnected from server.");
    }
}
