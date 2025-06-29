

# README — Simple TCP Console Chat in C\#

## Overview

This project implements a **simple TCP-based chat system** between a server and a client using console applications in C#. The communication happens over a **TCP socket connection** established between the server and the client.

---

## Connection and Communication Flow

1. **Server Initialization**
   The server creates a `TcpListener` bound to `127.0.0.1` (localhost) on port `50000`. It then calls `Start()` to begin listening for incoming connections.

2. **Client Connection**
   The client creates a `TcpClient` and connects to the server's IP and port (`127.0.0.1:50000`).

3. **Socket Acceptance**
   The server waits for a client by calling `AcceptSocket()`. When a client connects, the server obtains a `Socket` object representing the connection.

4. **Network Stream Setup**
   Both server and client create a `NetworkStream` over their respective socket or TCP client. This stream facilitates bidirectional communication.

5. **BinaryReader/Writer Creation**
   To send and receive strings easily, both sides wrap the network stream in `BinaryReader` and `BinaryWriter`.

6. **Initial Handshake**
   The server sends a welcome message (`"SERVER>>> Welcome to the chat!"`) to the client as confirmation.

7. **Message Exchange Loop**

   * The client waits for user input, prefixes it with `"CLIENT>>> "`, and sends it to the server.
   * The server reads the incoming message, prints it to its console, then prompts the server user to type a reply prefixed with `"SERVER>>> "`.
   * The server sends this response back to the client.
   * This back-and-forth continues until either side sends `"TERMINATE"` to end the chat.

---

## Algorithm Explanation

### Server Algorithm

* **Start TcpListener** on localhost:50000.
* **Accept client connection** (blocking call).
* Create `NetworkStream`, `BinaryReader`, and `BinaryWriter` for the socket.
* Send a welcome message to the client.
* Enter a loop:

  * Read a string message from the client.
  * Display the message on the console.
  * Prompt server user to input a reply.
  * Send the reply to the client.
  * Break the loop if the reply is `"TERMINATE"`.
* Cleanly close streams, socket, and stop listener.
* Print connection closed message.

### Client Algorithm

* Connect to server at localhost:50000.
* Create `NetworkStream`, `BinaryReader`, and `BinaryWriter`.
* Read and display the welcome message.
* Enter a loop:

  * Prompt client user for input.
  * Send message to server prefixed with `"CLIENT>>> "`.
  * Exit if input is `"TERMINATE"`.
  * Read and display server reply.
* Cleanly close streams and TCP client.
* Print disconnection message.

---

## How to Compile and Run

### Compile

Use the C# compiler to create executables:

```bash
csc ChatServer.cs -out:server.exe
csc ChatClient.cs -out:client.exe
```

Or open your IDE (e.g., Visual Studio), create two Console App projects, and paste the server and client code respectively.

### Run

1. Run the server first:

   ```bash
   ./server.exe
   ```

2. Run the client in a separate terminal:

   ```bash
   ./client.exe
   ```

3. Chat interactively until either side types:

   ```
   TERMINATE
   ```

---

## Important Notes

* **Single Client Support**: The server handles only one client at a time.
* **Blocking Operations**: The code uses synchronous blocking calls (`AcceptSocket()`, `ReadString()`, etc.), which means the program waits at these points until the operation completes.
* **No Multithreading**: This implementation is single-threaded and meant for learning basic socket communication.
* **Localhost Only**: Uses `127.0.0.1` — server and client must run on the same machine.
* **Graceful Closure**: The chat ends when either client or server sends `"TERMINATE"`, which causes clean closing of connections and streams.

---

## Summary

This project demonstrates fundamental **TCP socket programming** in C# with clear, simple console-based chat. It covers:

* Setting up TCP server and client connections
* Sending/receiving messages via `NetworkStream` wrapped with `BinaryReader` and `BinaryWriter`
* Basic synchronous communication flow
* Handling clean shutdowns

---

Let me know if you want me to generate the full `.md` file or provide an extended version with threading or multi-client support!
