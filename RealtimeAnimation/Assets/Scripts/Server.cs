using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Server : MonoBehaviour
{
    static Socket listener;
    private CancellationTokenSource source;
    public ManualResetEvent allDone;
    public Vector2[] positionForJoints = new Vector2[17];
    
    public static readonly int PORT = 25001;
    public static readonly int WAITTIME = 1;


    Server()
    {
        source = new CancellationTokenSource();
        allDone = new ManualResetEvent(false);
    }

    // Start is called before the first frame update
    async void Start()
    {
        await Task.Run(() => ListenEvents(source.Token));

        for (int i = 0; i < positionForJoints.Length; i++)
        {
            
        }
    }

    // Update is called once per frame


    private void ListenEvents(CancellationToken token)
    {


        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, PORT);


        listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);


        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(10);


            while (!token.IsCancellationRequested)
            {
                allDone.Reset();

                print("Waiting for a connection... host :" + ipAddress.MapToIPv4().ToString() + " port : " + PORT);
                listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);

                while (!token.IsCancellationRequested)
                {
                    if (allDone.WaitOne(WAITTIME))
                    {
                        break;
                    }
                }

            }

        }
        catch (Exception e)
        {
            print(e.ToString());
        }
    }

    void AcceptCallback(IAsyncResult ar)
    {
        Socket listener = (Socket)ar.AsyncState;
        Socket handler = listener.EndAccept(ar);

        allDone.Set();

        StateObject state = new StateObject();
        state.workSocket = handler;
        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
    }

    void ReadCallback(IAsyncResult ar)
    {
        StateObject state = (StateObject)ar.AsyncState;
        Socket handler = state.workSocket;

        int read = handler.EndReceive(ar);

        if (read > 0)
        {
            state.colorCode.Append(Encoding.ASCII.GetString(state.buffer, 0, read));
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }
        else
        {
            if (state.colorCode.Length > 1)
            {
                string content = state.colorCode.ToString();
                char[] testsubject;
                string[] singlebodyPart = content.Split('|');
                //print($"Read {content.Length} bytes from socket.\n Data : {content}");
                for (int i = 0; i <  positionForJoints.Length; i++)
                {
                    //Debug.Log(singlebodyPart[i]);
                    for (int j = 0; j < singlebodyPart.Length; j++)
                    {
                        testsubject = new char[singlebodyPart.Length];
                        testsubject = singlebodyPart[j].ToCharArray();
                        if (testsubject.Length == 12)
                        {
                            int xvalue;
                            int yvalue;
                            int id;
                            string xstring = testsubject[3].ToString() + testsubject[4].ToString() + testsubject[5].ToString();
                            string ystring = testsubject[8].ToString() + testsubject[9].ToString() + testsubject[10].ToString();
                            string idstring = testsubject[0].ToString() + testsubject[1].ToString();
                            
                            int.TryParse(idstring, out id);
                            int.TryParse(xstring, out xvalue);
                            int.TryParse(ystring, out yvalue);
                            positionForJoints[id].x = xvalue;
                            positionForJoints[id].y = yvalue;
                            Debug.Log(idstring +": x:" + xvalue + " y: " + yvalue);
                            
                        }
                        else if ( testsubject.Length == 11)
                        {
                            int xvalue;
                            int yvalue;
                            int id;
                            string xstring = testsubject[2].ToString() + testsubject[3].ToString() + testsubject[4].ToString();
                            string ystring = testsubject[7].ToString() + testsubject[8].ToString() + testsubject[9].ToString();
                            string idstring = testsubject[0].ToString();
                            int.TryParse(idstring, out id);
                            int.TryParse(ystring, out yvalue);
                            int.TryParse(xstring, out xvalue);
                            positionForJoints[id].x = xvalue;
                            positionForJoints[id].y = yvalue;
                            Debug.Log(idstring + ": x:" + xvalue + " y: " + yvalue);
                            
                        }
                    }

                }
                
            }
            handler.Close();
        }

    }

    //Set color to the Materia
   

    private void OnDestroy()
    {
        source.Cancel();
    }

    public class StateObject
    {
        public Socket workSocket = null;
        public const int BufferSize = 1024;
        public byte[] buffer = new byte[BufferSize];
        public StringBuilder colorCode = new StringBuilder();
    }
}