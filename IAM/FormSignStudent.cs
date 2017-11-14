using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using LibUsbDotNet;
using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;
using LibUsbDotNet.LudnMonoLibUsb;
using EC = LibUsbDotNet.Main.ErrorCode;
using System.IO;


namespace IAM
{

    public partial class FormSignStudent : Form
    {
        public static DateTime LastDataEventDate = DateTime.Now;
        public static UsbDevice MyUsbDevice;
        private UsbEndpointReader mEpReader;
        private FileStream mLogFileStream;


        #region SET YOUR USB Vendor and Product ID!

        public static UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(2303, 9);

        #endregion
        private UsbRegDeviceList mRegDevices;
       
      
        public FormSignStudent()
        {
            InitializeComponent();
    
        }




        private void FormSignStudent_Load(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipText = "Application Minimized";
            notifyIcon1.BalloonTipTitle = "IAM";
            // txtsmartcard.Focus();
           
        }

        private static void OnRxEndPointData(object sender, EndpointDataEventArgs e)
        {
            LastDataEventDate = DateTime.Now;
           // Console.Write(Encoding.Default.GetString(e.Buffer, 0, e.Count));
            MessageBox.Show(Encoding.Default.GetString(e.Buffer, 0, e.Count));
        }

        private void FormSignStudent_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) {
                ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);

            }

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            notifyIcon1.Visible = true;
            WindowState = FormWindowState.Normal;
        }

  

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            mRegDevices = UsbDevice.AllDevices;
            foreach (UsbRegistry regDevice in mRegDevices) 
            {
                string sItem = String.Format("Vid:{0} Pid:{1} {2}",
                                             regDevice.Vid.ToString("X4"),
                                             regDevice.Pid.ToString("X4"),
                                             regDevice.FullName);
                comboBox1.Items.Add(sItem);


            }
            label1.Text = comboBox1.Items.Count.ToString();

        }

        private void btnconnect_Click(object sender, EventArgs e)
        {
            btnconnect.Enabled = false;
             ErrorCode ec = ErrorCode.None;
            try
            {
                MyUsbDevice = UsbDevice.OpenUsbDevice(MyUsbFinder);
                IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
                if (ReferenceEquals(wholeUsbDevice, null))
                {
                    wholeUsbDevice.SetConfiguration(1);
                    wholeUsbDevice.ClaimInterface(0);

                }
                UsbEndpointReader reader = MyUsbDevice.OpenEndpointReader(ReadEndpointID.Ep01);
                //string cmdLine = Regex.Replace(Environment.CommandLine, "^\".+?\"^.*? |^.*? ", "", RegexOptions.Singleline);

                //if (!String.IsNullOrEmpty(cmdLine))
                //{
                    reader.DataReceived += (OnRxEndPointData);
                    reader.DataReceivedEnabled = true;

                    //int bytesWritten;
                    //ec = writer.Write(Encoding.Default.GetBytes(cmdLine), 2000, out bytesWritten);
                    if (ec != ErrorCode.None) throw new Exception(UsbDevice.LastErrorString);

                    LastDataEventDate = DateTime.Now;
                    while ((DateTime.Now - LastDataEventDate).TotalMilliseconds < 100)
                    {
                    }

                    // Always disable and unhook event when done.
                    //reader.DataReceivedEnabled = false;
                    reader.DataReceived -= (OnRxEndPointData);

                    //Console.WriteLine("\r\nDone!\r\n");
                    MessageBox.Show("\r\nDone!\r\n");
                //}
                //else
                    //throw new Exception("Nothing to do.");

            }
            catch (Exception ex)
            {
                //Console.WriteLine();
                MessageBox.Show((ec != ErrorCode.None ? ec + ":" : String.Empty) + ex.Message);
            }
            finally
            {
                if (MyUsbDevice != null)
                {
                    if (MyUsbDevice.IsOpen)
                    {
                        // If this is a "whole" usb device (libusb-win32, linux libusb-1.0)
                        // it exposes an IUsbDevice interface. If not (WinUSB) the 
                        // 'wholeUsbDevice' variable will be null indicating this is 
                        // an interface of a device; it does not require or support 
                        // configuration and interface selection.
                        IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
                        if (!ReferenceEquals(wholeUsbDevice, null))
                        {
                            // Release interface #0.
                            wholeUsbDevice.ReleaseInterface(0);
                        }

                        MyUsbDevice.Close();
                    }
                    MyUsbDevice = null;

                    // Free usb resources
                    //UsbDevice.Exit();

                }

                // Wait for user input..
                //Console.ReadKey();
            }
        }

        //method untuk open device
        private bool opendevice(int index) 
        {
            bool bRtn = false;
            closeDevice();
            if (mRegDevices[index].Open(out MyUsbDevice))
            {
                bRtn = true;
                IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
                if (ReferenceEquals(wholeUsbDevice, null))
                {
                    wholeUsbDevice.SetConfiguration(1);
                    wholeUsbDevice.ClaimInterface(0);
                }
                if (bRtn)
                {
                    //byte epnum = byte.Parse(ReadEndpointID.Ep01.ToString);
                    mEpReader = MyUsbDevice.OpenEndpointReader(ReadEndpointID.Ep01);
                    mEpReader.DataReceived += mEp_DataReceived;
                    mEpReader.Flush();
                    mEpReader = null;


                }
            }
            if (bRtn)
            {
                label1.Text = "Device Opened.";
            }
            else
            {
                label1.Text = "Device Failed to Opened!";
                if (!ReferenceEquals(MyUsbDevice, null))
                {
                    if (MyUsbDevice.IsOpen) MyUsbDevice.Close();
                    MyUsbDevice = null;
                }
            }

            return bRtn;
        }

        //method utk close device !
        private void closeDevice()
        {   
            //Cek Device available
            if (MyUsbDevice != null)
            {   
                // cek jika device masih open
                if (MyUsbDevice.IsOpen) 
                {   
                    //untuk proses Read
                    if (mEpReader != null)
                    {
                        mEpReader.DataReceivedEnabled = false;
                        mEpReader.DataReceived -= mEp_DataReceived;
                        mEpReader.Dispose();
                        mEpReader = null;

                    }
                    // untuk Write Device
                    /* if (mEpWriter != null)
                    {
                        mEpWriter.Abort();
                        mEpWriter.Dispose();
                        mEpWriter = null;
                    }*/

                    IUsbDevice wholeUSBDevice = MyUsbDevice as IUsbDevice;
                    if (!ReferenceEquals(wholeUSBDevice, null))
                    {
                        wholeUSBDevice.ReleaseInterface(0);

                    }
                    MyUsbDevice.Close();
                    MyUsbDevice = null;
                }
            }
        }

        //method untuk data received
        private void mEp_DataReceived(object sender, EndpointDataEventArgs e) 
        {
            Invoke(new OnDataReceivedDelegate(OnDataReceived),new object[]{sender,e});
        }

        private void OnDataReceived(object sender, EndpointDataEventArgs e)
        { 
            //StringBuilder sb = (e.Buffer,0,e.Count);
            mLogFileStream.Write(e.Buffer, 0, e.Count);
            txtdata.AppendText(System.Text.Encoding.UTF8.GetString(e.Buffer, 0, e.Count));
        }

        private delegate void OnDataReceivedDelegate(object sender, EndpointDataEventArgs e);

      
    }
}
