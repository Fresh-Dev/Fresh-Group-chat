using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Text;

namespace FreshGroupChat
{
    /// <summary>
    /// Summary description for Client.
    /// </summary>
    public delegate void ConnectedHandler(object sender);
    public delegate void DisconnectedHandler(object sender);
    public delegate void IncomingMessageHandler(object sender, string strMessage);
    public class Client
    {
        public event ConnectedHandler Connected;
        public event DisconnectedHandler Disconnected;
        public event IncomingMessageHandler IncomingMessage;
        private Guid mgID = Guid.NewGuid();
        private byte[] marData = new byte[1024];
        private StringBuilder mstrText = new StringBuilder();
        private TcpClient mobjClient;
        private Socket mobjSocket;
        private string strUserName = "";
        public long dbID = 0;

        public Client(Socket s)
        {
            // When the client is started from a socket call set up the socket,
            // call the connected event and set up the DoReceive as the callback
            // for incoming messages from that socket.
            mobjSocket = s;
            OnConnected();
            mobjSocket.BeginReceive(marData, 0, 1024, SocketFlags.None, new AsyncCallback(this.DoReceive), null);
        }

        public Client(TcpClient client)
        {
            // When the client is started from a TcpClient, set the client up
            // as an internal variable, raise the connected Event and set up the 
            // DoStreamReceive method as the callback for incoming messages from that client
            mobjClient = client;
            OnConnected();
            mobjClient.GetStream().BeginRead(marData, 0, 1024, new AsyncCallback(this.DoStreamReceive), null);
        }

        private void OnConnected()
        {
            // Internal handler for OnConnected. If the method is not null [not clear why this happens
            // but it sometimes does!], raise it.
            if (Connected != null)
                Connected(this);
        }

        private void OnDisconnected()
        {
            // As OnConnected
            if (Disconnected != null)
                Disconnected(this);
        }

        public string ID
        {
            // The ID is a GUID specifying an identifier for the client before it has
            // been synchronized with the Database. The ID property returns it -- this is
            // the ID handler
            get
            {
                return mgID.ToString();
            }

        }

        public string UserName
        {
            // The USerName for a client is fetched from the DB by the server and handled as
            // a property. This function handles the property setting and getting.
            get
            {
                return strUserName;
            }
            set
            {
                strUserName = value;
            }
        }
        private void DoStreamReceive(IAsyncResult ar)
        {
            // DoStreamReceive callback for TCPClients
            int intCount;
            try
            {
                // Lock the stream and read it.
                lock (mobjClient.GetStream())
                {
                    intCount = 0;
                    try { intCount = mobjClient.GetStream().EndRead(ar); }
                    catch { }
                }
                // If empty, we should disconnect
                if (intCount < 1)
                {
                    OnDisconnected();
                }
                else
                {
                    // Take the bytes from the stream and build a string out of them
                    BuildString(marData, 0, intCount);
                    lock (mobjClient.GetStream())
                    {
                        // And start reading again
                        mobjClient.GetStream().BeginRead(marData, 0, 1024, new AsyncCallback(this.DoStreamReceive), null);
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                OnDisconnected();
            }
        }

        private void DoReceive(IAsyncResult ar)
        {
            // Callback handler for incoming socket connections. As DoStreamreceive
            int intCount;
            try
            {
                intCount = mobjSocket.EndReceive(ar);
                if (intCount < 1)
                {
                    OnDisconnected();
                }
                else
                {
                    BuildString(marData, 0, intCount);
                    mobjSocket.BeginReceive(marData, 0, 1024, SocketFlags.None, new AsyncCallback(this.DoReceive), null);
                }
            }
            catch (Exception e)
            {
                string strStack = e.StackTrace.ToString();
                OnDisconnected();
            }
        }

        private String ByteToString(byte[] bytes)
        {
            // Convert a byte array into a string.

            StringBuilder objSB = new StringBuilder(bytes.Length + 1);
            int intIndex;
            for (intIndex = 0; intIndex < bytes.Length; intIndex++)
            {
                objSB.Append(bytes[intIndex].ToString());
            }
            return objSB.ToString();
        }

        private String ByteToString(byte[] bytes, int offset, int count)
        {
            // Convert a series of bytes in an array from a specific location
            // for a specific length into a string
            StringBuilder objSB = new StringBuilder(count);
            int intIndex;
            for (intIndex = offset; intIndex < (offset + count - 1); intIndex++)
            {
                objSB.Append(bytes[intIndex].ToString());
            }
            return objSB.ToString();
        }

        private void BuildString(byte[] bytes, int offset, int count)
        {
            // Build up a string to transmit 
            int intIndex;
            mstrText.Remove(0, mstrText.Length);
            for (intIndex = offset; intIndex <= (offset + count - 1); intIndex++)
            {
                if (bytes[intIndex] == 13)
                {
                    IncomingMessage(this, mstrText.ToString());
                    mstrText = new StringBuilder();
                }
                else
                {
                    mstrText.Append(Convert.ToChar(bytes[intIndex]));
                }
            }
        }

        public void send(String strData)
        {
            // Send the data down the appropriate connection
            if (mobjClient == null)
            {
                // Socket version
                byte[] arData = new byte[strData.Length - 1];
                int intIndex;
                for (intIndex = 1; intIndex <= strData.Length; intIndex++)
                {
                    arData[intIndex - 1] = Convert.ToByte(strData.Substring(intIndex, 1));
                }
                mobjSocket.BeginSend(arData, 0, arData.Length, SocketFlags.None, null, null);


            }
            else
            {
                // TCPClient Version
                lock (mobjClient.GetStream())
                {
                    System.IO.StreamWriter w = new System.IO.StreamWriter(mobjClient.GetStream());
                    w.Write(strData);
                    w.Flush();
                }
            }
        }

        public void send(byte[] bData, int offset, int count)
        {
            // Overload for Send where a bytearray is being sent instead of a string
            if (mobjClient == null)
            {
                // Socket version
                mobjSocket.BeginSend(bData, offset, count, SocketFlags.None, null, null);
            }
            else
            {
                lock (mobjClient.GetStream())
                {
                    // TcpClient version
                    mobjClient.GetStream().BeginWrite(bData, offset, count, null, null);
                }
            }
        }



    }
}

namespace FreshGroupChat
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    class ChatServer
    {
        // Hashtables to hold the various client, distant server and room objects
        private static Hashtable tmpClients = new Hashtable();
        private static Hashtable clClients = new Hashtable();
        private static Hashtable rmRooms = new Hashtable();

        // My local address settings
        private static IPAddress localHost;
        // The port on which clients connect
        private static int myPort;

        // Threads and listeners for handling client connections
        private static Thread myThread;
        private static TcpListener myListener;

        [STAThread]
        static void Main(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "█████████████╗████████████████╗  ██╗    ██████╗█████████╗   ██╗██████╗███████╗"));
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "██╔════██╔══████╔════██╔════██║  ██║    ██╔══████╔════██║   ██║██╔══████╔════╝"));
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "█████╗ ██████╔█████╗ █████████████████████║  ███████╗ ██║   ██║██║  ███████╗  "));
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "██╔══╝ ██╔══████╔══╝ ╚════████╔══██╚════██║  ████╔══╝ ╚██╗ ██╔╝██║  ████╔══╝  "));
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "██║    ██║  ██████████████████║  ██║    ██████╔███████╗╚████╔████████╔███████╗"));
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "╚═╝    ╚═╝  ╚═╚══════╚══════╚═╝  ╚═╝    ╚═════╝╚══════╝ ╚═══╝╚═╚═════╝╚══════╝"));
            Console.WriteLine();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Stare Server..."));
            if (args.Length < 2)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "█████████████╗████████████████╗  ██╗    ██████╗█████████╗   ██╗██████╗███████╗"));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "██╔════██╔══████╔════██╔════██║  ██║    ██╔══████╔════██║   ██║██╔══████╔════╝"));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "█████╗ ██████╔█████╗ █████████████████████║  ███████╗ ██║   ██║██║  ███████╗  "));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "██╔══╝ ██╔══████╔══╝ ╚════████╔══██╚════██║  ████╔══╝ ╚██╗ ██╔╝██║  ████╔══╝  "));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "██║    ██║  ██████████████████║  ██║    ██████╔███████╗╚████╔████████╔███████╗"));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "╚═╝    ╚═╝  ╚═╚══════╚══════╚═╝  ╚═╝    ╚═════╝╚══════╝ ╚═══╝╚═╚═════╝╚══════╝"));
                Console.WriteLine();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Zum Starten bitte die Serveradresse und den Port als Startparameter angeben."));
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Beispiel: mono server.exe fresh-dev.de 51"));
            }
            else
            {
                localHost = Dns.GetHostEntry(args[0]).AddressList[0];
                myPort = Convert.ToInt32(args[1]);
                // Write out our status
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Server gestartet, erwarte Verbindungen auf: " + localHost.ToString() + ":" + myPort));
                Console.WriteLine();
                Console.WriteLine();
                myThread = new Thread(new System.Threading.ThreadStart(DoListen)); myThread.Start();
            }
        }
        private static void OnConnected(string sender)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("\t" + sender + " hat sich eingeloggt.");
        }
        private static void OnDisconnected(object sender)
        {
            tmpClients.Clear();
            clClients.Clear();
            // Remove the client from the clients hash when a client
            // sends a disconnect message
            Client cSender = (Client)sender;
            ////LogStatus("Disconnected");
            clClients.Remove(cSender.ID);
            // Remove it from the logged in users GUI
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine(cSender.UserName + " hat sich ausgeloggt.");
        }

        private static void OnIncomingMessage(object sender, String strMessage)
        {
            // Handle an incoming message from one of our connected clients.
            StringBuilder strOutgoing = new StringBuilder();
            StringBuilder strClearMsg = new StringBuilder();
            StringBuilder strFriendMsg = new StringBuilder();
            string strUserName = "";
            Client theSender = (Client)sender;
            Client qn;

            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                bool isMessage = true;
                if (strMessage.IndexOf("closenow") >= 0)
                {
                    strUserName = strMessage.Substring(8, strMessage.Length - 8);
                    // Disconnect the sender
                    clClients.Remove(theSender.ID);
                    OnDisconnected(theSender);
                    isMessage = false;
                }

                if (strMessage.IndexOf("username") >= 0)
                {
                    strUserName = strMessage.Substring(9, strMessage.Length - 9);

                    foreach (DictionaryEntry qd in tmpClients)
                    {
                        qn = (Client)qd.Value;
                        qn.UserName = strUserName;

                        {
                            int nKey = clClients.Count;
                            clClients.Add(nKey, qn);
                            tmpClients.Remove(qn.ID);
                            break;
                        }

                    }
                    OnConnected(strUserName);
                    isMessage = false;
                }

                char crCR = (char)13;
                char crLF = (char)10;
                if (strMessage.IndexOf("sagte") >= 0)
                {
                    for (int lp = 0; lp < clClients.Count; lp++)
                    {
                        StringBuilder strM = new StringBuilder(strMessage);
                        strM.Append(crCR);
                        strM.Append(crLF);
                        Client toSend = (Client)clClients[lp];
                        toSend.send(strM.ToString());
                    }
                }
                if (isMessage == true)
                {
                    System.Console.WriteLine(theSender.UserName + " : " + strMessage);
                }

            }
            catch (Exception e)
            {
                string strError = e.StackTrace.ToString();
            }

        }


        private static void DoListen()
        {
            // This is the callback handler for the thread that listens on the client
            // port. At present the port is hardcoded. This will later change to be
            // configurable
            myListener = new TcpListener(localHost, myPort);

            // Start off the listener
            myListener.Start();

            // Local throwaway client variable to put into the hashtable
            Client x;

            // Main loop accept clients and load them into the 'temporary' client hash.
            // Once they set their identity in the server, then move them to the main hash.
            do
            {
                TcpClient s = myListener.AcceptTcpClient();

                // Get the clients IP address and log it for debugging
                String strServerIP = IPAddress.Parse(((IPEndPoint)myListener.LocalEndpoint).Address.ToString()).ToString();
                ////LogStatus(strServerIP);

                // Create the client and attach its' delegates/events to the appropriate functions
                x = new Client(s);
                //x.Connected += new ConnectedHandler(OnConnected);
                x.Disconnected += new DisconnectedHandler(OnDisconnected);
                x.IncomingMessage += new IncomingMessageHandler(OnIncomingMessage);

                // And add it to the 'temporrary' hash
                tmpClients.Add(x.ID, x);
            }
            while (true);
        }
    }
}


