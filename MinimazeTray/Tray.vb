Imports System
Imports System.Text
Imports System.IO.Ports
Imports LibUsbDotNet
Imports LibUsbDotNet.Main
Imports MonoLibUsb
Imports System.Globalization.NumberStyles
Imports System.IO


Public Class Form1


    Private Delegate Sub OnDataReceivedDelegate(sender As Object, e As EndpointDataEventArgs)

    Private Delegate Sub UsbErrorEventDelegate(sender As Object, e As UsbError)
    Public Shared MyUsbDevice As UsbDevice
    Public Shared MyUsbFinder As New UsbDeviceFinder(2303, 9)

    Private mUsbDevice As UsbDevice
    Private mEpReader As UsbEndpointReader
    Private mEpWriter As UsbEndpointWriter
    Private mLogFileName As String = [String].Empty
    Private mLogFileStream As FileStream
    Private mRegDevices As UsbRegDeviceList
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'Dim vid As Integer
        'Dim pid As Integer
        ''Dim vid As Integer = Convert.ToInt32(vendorId, 16)
        ''Dim pid As Integer = Convert.ToInt32(productID, 16)
        '' or if you don't like "base 16" and want to have self-documenting code:
        'vid = Int32.Parse(vendorId, System.Globalization.NumberStyles.HexNumber)
        'pid = Int32.Parse(productID, System.Globalization.NumberStyles.HexNumber)
        'Dim MyUsbFinder As New UsbDeviceFinder(vendorId, ProductId)
       

    End Sub

   


   
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim ec As ErrorCode = ErrorCode.None
        Try
            Dim MyUsbDevice As UsbDevice

            MyUsbDevice = UsbDevice.OpenUsbDevice(MyUsbFinder)
            If MyUsbDevice Is Nothing Then
                Throw New Exception("Device Not Found.")
            End If

            Dim wholeUsbDevice As IUsbDevice = TryCast(MyUsbDevice, IUsbDevice)
            If Not ReferenceEquals(wholeUsbDevice, Nothing) Then
                ' This is a "whole" USB device. Before it can be used, 
                ' the desired configuration and interface must be selected.


                ' Select config #1
                wholeUsbDevice.SetConfiguration(1)

                ' Claim interface #0.
                wholeUsbDevice.ClaimInterface(0)
            End If

            Dim reader As UsbEndpointReader = MyUsbDevice.OpenEndpointReader(ReadEndpointID.Ep01)


            Dim readBuffer As Byte() = New Byte(1023) {}
            While ec = ErrorCode.None
                Dim bytesRead As Integer

                ' If the device hasn't sent data in the last 5 seconds,
                ' a timeout error (ec = IoTimedOut) will occur. 
                ec = reader.Read(readBuffer, 10000, bytesRead)

                If bytesRead = 0 Then
                    Throw New Exception(String.Format("{0}:No more bytes!", ec))
                End If
                MsgBox("{0} bytes read", bytesRead)

                ' Write that output to the console.
                MsgBox(Encoding.[Default].GetString(readBuffer, 0, bytesRead))
            End While
        Catch ex As Exception
            MsgBox(((If(ec <> ErrorCode.None, ec & ":", [String].Empty)) & ex.Message))
        Finally
            If MyUsbDevice IsNot Nothing Then
                If MyUsbDevice.IsOpen Then
                    ' If this is a "whole" usb device (libusb-win32, linux libusb-1.0)
                    ' it exposes an IUsbDevice interface. If not (WinUSB) the 
                    ' 'wholeUsbDevice' variable will be null indicating this is 
                    ' an interface of a device; it does not require or support 
                    ' configuration and interface selection.
                    Dim wholeUsbDevice As IUsbDevice = TryCast(MyUsbDevice, IUsbDevice)
                    If Not ReferenceEquals(wholeUsbDevice, Nothing) Then
                        ' Release interface #0.
                        wholeUsbDevice.ReleaseInterface(0)
                    End If

                    MyUsbDevice.Close()
                End If
                MyUsbDevice = Nothing

                ' Free usb resources


                UsbDevice.[Exit]()
            End If

            ' Wait for user input..
            'Console.ReadKey()


        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub


    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

    End Sub



End Class
