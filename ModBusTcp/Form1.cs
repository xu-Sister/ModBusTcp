using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModBusTcp
{
    public partial class Form1 : Form
    {
        public static Form1 form;

        static SocketSynConnection socketSynConnection;

        static int readBit = 0;

        static int writeBit = 0;

        static int fifoLen = 0;

        private byte[] RecData = new byte[500];

        private byte[] Rx_Temp = new byte[500];

        private byte[] SendArray = new byte[12];

        private byte[] ComArray = new byte[12];

        private FiFO FiFO { get; set; } = new FiFO(1200);

        public bool transf = false;
        public Form1()
        {
            InitializeComponent();
            form = this;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            connectBtn.Click += new EventHandler(ConnectIP);
            this.OutPutText.TextChanged += new System.EventHandler(this.textChangeMessage);
            CheckForIllegalCrossThreadCalls = false;
        }
        private void ConnectIP(object sender, EventArgs e) 
        {
            if (string.IsNullOrEmpty(IPBox.Text) || string.IsNullOrEmpty(portBox.Text) || string.IsNullOrEmpty(addBox.Text)
                || string.IsNullOrEmpty(startBox.Text) || string.IsNullOrEmpty(LengthBox.Text) || string.IsNullOrEmpty(orderBox.Text))
            {
                MessageBox.Show("不能为空", "提示");
            }
            else 
            {
                Socket theSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                string IPAddress = IPBox.Text;
                int IPort = int.Parse(portBox.Text);

                socketSynConnection = new SocketSynConnection(IPAddress, IPort, theSocket);
                if (!transf)
                {
                    Com(addBox.Text, orderBox.Text, startBox.Text, LengthBox.Text);

                    Timer timer = new Timer();

                    timer.Enabled = true;
                    timer.Interval = 1000;
                    timer.Tick += new EventHandler(Timer_Trik);
                }
            }
        }
        private void Com(string address , string code,string position , string length) 
        {
            //MBAP
            ComArray[0] = 0x00;
            ComArray[1] = 0x00;
            ComArray[2] = 0x00;
            ComArray[3] = 0x00;
            ComArray[4] = 0x00;
            ComArray[5] = 0x06;
            //PTU
            ComArray[6] = StringChange(address);    //ModBus地址
            ComArray[7] = StringChange(code);    //命令码
            ComArray[8] = 0x00;
            ComArray[9] = StringChange(position);    //起始位
            ComArray[10] = 0x00;
            ComArray[11] = StringChange(length);   //长度

            FiFO.ForCopy(ComArray, writeBit * 12);
            writeBit++;
        }
        private void textChangeMessage(object sender, EventArgs e)
        {
            OutPutText.SelectionStart = OutPutText.TextLength;
            OutPutText.ScrollToCaret();
        }
        private void Timer_Trik(object sender,EventArgs e) 
        {
            socketSynConnection.sockket_Send(ComArray);
        }
        private void SendFiFo(int transf)
        {
            try
            {
                fifoLen = readBit * 12;
                if (FiFO.FiFoBuffer[fifoLen] != 0x00)
                {
                    FiFO.LopoCopy(SendArray, fifoLen, SendArray.Length);
                }
            }
            catch (Exception ex) { }
        }
        private byte StringChange(string text)   //进制转换
        {
            byte transf = 0x00;
            int length = text.Length;
            switch (length)
            {
                case 1:
                    transf = (byte)(text[0] - '0');
                    break;
                case 2:
                    transf = (byte)((text[0] - '0') * 10 + (text[1] - '0'));
                    break;
                case 3:
                    transf = (byte)(((text[0] - '0') * 100) + ((text[1] - '0') * 10) + (text[2] - '0'));
                    break;
                default:
                    break;
            }
            return transf;
        }
    }
}
