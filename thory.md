

## 🧩 **1. TCP vs UDP — Understanding the Foundation of Internet Communication**

### 🧠 **Introduction**

When two devices communicate over a network (like your computer and a website), they use rules called **protocols**. The two most common protocols are **TCP** and **UDP**. They control **how data is sent and received**, similar to how you might choose between sending a registered letter (TCP) or a quick postcard (UDP).

---

### 🔄 **TCP: Transmission Control Protocol**

* 📦 **Reliable:** Guarantees that data arrives in the correct order.
* 🔐 **Connection-Oriented:** A connection (like a phone call) is set up before data is sent.
* 🕓 **Slower:** Adds overhead to ensure everything is perfect.
* 💬 **Used For:**

  * Websites (HTTP/HTTPS)
  * Emails (SMTP)
  * File transfers (FTP)

### 🔁 **UDP: User Datagram Protocol**

* 🏃 **Fast but Unreliable:** No guarantees, just send and hope.
* 🚫 **Connectionless:** Data is just fired off—like a text with no read receipt.
* ⚡ **Faster:** Minimal overhead, great for time-sensitive apps.
* 🎮 **Used For:**

  * Video calls
  * Gaming
  * Live broadcasts

---

### 🔍 Summary Table

| Feature       | TCP               | UDP                |
| ------------- | ----------------- | ------------------ |
| Reliable      | ✅ Yes             | ❌ No               |
| Connection    | ✅ Required        | ❌ Not needed       |
| Speed         | 🐢 Slower         | ⚡ Faster           |
| Order of data | ✅ Guaranteed      | ❌ Not guaranteed   |
| Use case      | Web, Email, Files | Video, VoIP, Games |

---

## 🧩 **2. Sockets in .NET — Connecting Applications Over the Network**

### 🧠 **Introduction**

A **socket** is like a phone line between two programs on different machines. .NET provides a rich library to handle sockets via **TCP** or **UDP**.

---

### 🔧 **Key .NET Socket Classes**

* `TcpListener`: Listens for incoming TCP connections (server-side).
* `TcpClient`: Connects to a TCP server.
* `Socket`: Lower-level class for full protocol control.
* `NetworkStream`: A stream over a socket to read/write data.
* `BinaryReader` / `BinaryWriter`: For reading/writing primitive data.

---

### 👨‍💻 **Basic TCP Server Example**

```csharp
TcpListener server = new TcpListener(IPAddress.Any, 5000);
server.Start();
Socket client = server.AcceptSocket(); // Blocking
```

### 👩‍💻 **Basic TCP Client Example**

```csharp
TcpClient client = new TcpClient("127.0.0.1", 5000);
NetworkStream stream = client.GetStream();
```

📌 With TCP, after setting up the connection, you use `NetworkStream` to communicate by reading and writing data.

---

## 🧩 **3. Multithreading in .NET — Doing More at the Same Time**

### 🧠 **Introduction**

Your computer can **do many things at once** — this is thanks to multithreading. In .NET, this means letting multiple pieces of code run in **parallel**.

---

### 💡 **Why Use Threads?**

* Handling multiple clients on a server at once
* Doing background work (e.g., downloading files) without freezing the UI
* Improving performance by splitting heavy tasks

---

### 🎯 **Creating and Starting a Thread**

```csharp
void MyWork() { Console.WriteLine("Running!"); }
Thread t = new Thread(MyWork);
t.Start();
```

### 🚀 **Advanced Options**

* `ThreadPool`: Reuses threads to save resources
* `Task` / `async-await`: Modern and easier to manage

---

### ⚠️ **When Threads Go Wrong**

* Race conditions: two threads modify the same variable at once
* Deadlocks: threads wait for each other forever
* UI crashes (see next section)

---

## 🧩 **4. Invoke in Windows Forms — Safely Updating the UI**

### 🧠 **Introduction**

In a Windows Forms app, only the **UI thread** (the main thread) is allowed to update controls like `Label`, `TextBox`, etc. If you try to update the UI from a background thread (e.g., a socket or file thread), you’ll get an exception.

---

### ⚠️ **What Happens If You Don't Use `Invoke`?**

Your app crashes with "Cross-thread operation not valid" error.

---

### 🛡️ **How to Use `Invoke` Safely**

```csharp
if (label.InvokeRequired)
{
    label.Invoke(new Action(() => label.Text = "Updated!"));
}
else
{
    label.Text = "Updated!";
}
```

### 🧰 **Concepts**

* `InvokeRequired`: Checks if you’re on the wrong thread.
* `Invoke`: Executes your method on the right (UI) thread.

---

## 🧩 **5. Web Services — Making Applications Talk Over the Web**

### 🧠 **Introduction**

A **Web Service** is a function or API exposed over the internet that lets other systems interact with it. It’s how apps like weather widgets, maps, and social media integrations work.

---

### 🧱 **Types of Web Services**

* **SOAP (Simple Object Access Protocol)**: XML-based, standardized, strict.
* **REST (Representational State Transfer)**: Simpler, uses JSON, more popular today.

---

### 🛠️ **ASP.NET Tools**

* **ASP.NET Web API** – for creating RESTful services
* **WCF** – for SOAP or REST (older but powerful)

---

### 🧪 **RESTful Web Service Example**

```http
GET /api/students
POST /api/students
```

* Uses HTTP methods
* Returns JSON or XML
* Easy to use with JavaScript, mobile, or desktop apps

---

## 🧪 6. Practice Multiple Choice Questions

1. ✅ **TCP is connection-oriented while UDP is connectionless**
2. ✅ **TcpListener** is used to listen for TCP connections
3. ✅ **AcceptSocket()** is used to accept a connection in TcpListener
4. ✅ `Thread t = new Thread(Run); t.Start();` is the correct way
5. ✅ `Invoke` is used to run code on the **UI thread**
6. ✅ Use `InvokeRequired` when updating the UI from another thread
7. ✅ You send data with `client.GetStream()`
8. ✅ Web services use **HTTP (SOAP or JSON)**
9. ✅ Real-time chat uses **TCP Socket Server**
10. ✅ `BinaryReader` / `BinaryWriter` handle **network streams of primitive types**

---
