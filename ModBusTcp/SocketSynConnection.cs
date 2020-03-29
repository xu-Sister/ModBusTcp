using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModBusTcp
{
    public class SocketSynConnection
    {
        //同步连接
        Socket theSocket;

        private string remoteHost;

        private int remotePort;

        byte[] buffer = new byte[20];

        string Transf;

        bool state;

        public SocketSynConnection(string iPAddress, int iPort, Socket socket)
        {
            remoteHost = iPAddress;
            remotePort = iPort;
            theSocket = socket;

            socket_connected();
            //连接方法
        }
        private void socket_connected()
        {
            try
            {
                IPAddress iPAddress = IPAddress.Parse(remoteHost);
                IPEndPoint endPoint = new IPEndPoint(iPAddress, remotePort);

                IAsyncResult connResult = theSocket.BeginConnect(remoteHost, remotePort, null, null);
                connResult.AsyncWaitHandle.WaitOne(1000, true);

                if (!connResult.IsCompleted)
                {
                    Form1.form.OutPutText.Text += remoteHost + "  连接状态：" + "Time Out" + "  " + DateTime.Now.ToString() + "\r\n";
                    theSocket.Close();
                }
                else
                {
                    state = IsSocketConnected(theSocket);
                    if (state == true)
                    {
                        Form1.form.OutPutText.Text += remoteHost + "  连接状态：" + "True" + "  " + DateTime.Now.ToString() + "\r\n";

                        Form1.form.transf = true;
                    }
                    else
                    {
                        Form1.form.OutPutText.Text += remoteHost + "  连接状态：" + "False" + "  " + DateTime.Now.ToString() + "\r\n";
                    }

                    Thread thread = new Thread(SocketRecive);
                    thread.IsBackground = true;
                    thread.Start();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private bool IsSocketConnected(Socket socket)
        {
            bool blockingState = socket.Blocking;
            try
            {
                byte[] tmp = new byte[1];
                socket.Blocking = false;
                socket.Send(tmp, 0, 0);
                return true;
            }
            catch (SocketException ex)
            {
                if (ex.NativeErrorCode.Equals(10035))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            finally
            {
                socket.Blocking = blockingState;
            }
        }
        void SocketRecive()
        {
            try
            {
                while (state)
                {
                    int tr = theSocket.Receive(buffer);
                    if (tr > 0)
                    {
                        Transf = Encoding.ASCII.GetString(buffer);
                    }
                    Form1.form.OutPutText.Text += remoteHost + ": " + Transf + " " + DateTime.Now.ToString() + "\r\n";
                }
            }
            catch (SocketException ex)
            {
                Shutdown_Socket();
                Console.WriteLine(ex.Message);
            }
        }
        public bool sockket_Send(byte[] sendArray)
        {
            if (IsSocketConnected(theSocket))
            {
                return SocketSend(sendArray); 
            }
            return false;
        }
        private bool SocketSend(byte[] SendData) 
        {
            bool resule = false;

            if (SendData == null || SendData.Length < 0)
            {
                return resule;
            }

            try
            {
                int n = theSocket.Send(SendData);
                if (n < 1)
                {
                    resule = false;
                }
            }
            catch (Exception e) 
            {
                resule = false;
            }
            return false;
        }
        public void Shutdown_Socket()
        {
            state = false;

            theSocket.Shutdown(SocketShutdown.Both);
            theSocket.Disconnect(true);
            theSocket.Close();
        }
    }
}
