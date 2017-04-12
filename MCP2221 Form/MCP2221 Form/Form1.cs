using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using System.Threading;

/* ATmega I2C Commands:
 *  0 = Reset
 *  1 to 5 = Test Connection - Return 5 on next request for read
 * 
 * 
 */

namespace MCP2221_Form {

    public partial class Form1 : Form {
        MCPFunctions mcp = new MCPFunctions();

        int DeviceNumber = 0;
        byte ATMEGAAddress = 1;

        public Form1() {
            InitializeComponent();
            GetDevices();
            RefreshPresetList();
        }

        /* Form Return Function
        public string label1_text {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        */

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void BrowseFlashFileButton_Click(object sender, EventArgs e) {
            DialogResult result = openFileDialog1.ShowDialog(); // Open file Dialog
            if (result == DialogResult.OK) { // Test Result
                FlashFilePathTextBox.Text = openFileDialog1.FileName; // Send Path to Path Textbox
                ProgConsole.Items.Add("Opening " + openFileDialog1.FileName);
            }
        }

        /* Numeric Data Only */
        private void WordSizeTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) {
                e.Handled = true;
            }
        }
        /* Numeric Data Only */
        private void PageSizeTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) {
                e.Handled = true;
            }
        }
        /* Numeric Data Only */
        private void NumPagesTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) {
                e.Handled = true;
            }
        }

        private void RefreshDevButton_Click(object sender, EventArgs e) {
            GetDevices(); // Update Devices in Listbox
            ProgConsole.Items.Add("Devices Refreshed");
        }

        void GetDevices() { // Get device discriptors and add, with indexes, to listbox for selection
            DevConnListBox.Items.Clear(); // Clear Listbox
            string[] devices = mcp.GetDevices(); // Get Strings from devices
            for (int i = 0; i < devices.Length; i++) {
                DevConnListBox.Items.Add(devices[i]); // Add All Device Discriptors to Listbox
            }
        }

        private void SelDevButton_Click(object sender, EventArgs e) {
            if (DevConnListBox.SelectedItem != null && DevConnListBox.SelectedItem.ToString() != "No Devices Connected") { // Check Data to prevent null exceptions
                CurrentDevTextbox.Text = DevConnListBox.SelectedItem.ToString(); // Add Selected Item to Listbox
                DeviceNumber = DevConnListBox.SelectedIndex; // Set Current Device Index to listbox index
                ProgConsole.Items.Add("Device " + DeviceNumber.ToString() + " selected");
            }
        }

        private void SavePresetButton_Click(object sender, EventArgs e) {

            XmlDocument presetDoc = new XmlDocument(); // Define XMLdoc
            presetDoc.Load(Path.GetFullPath("../data/presets.xml")); // load xml
            XmlElement root = presetDoc.DocumentElement; // Create root element to add onto

            XmlNode newPreset = presetDoc.CreateNode("element", "preset",""); // Create new preset element

            XmlElement presetName = presetDoc.CreateElement("Name"); // Create Name Element
            presetName.InnerText = WordSizeTextBox.Text + " " + PageSizeTextBox.Text + " " + NumPagesTextBox.Text; // Set name to text from text boxes
            XmlElement presetWordSize = presetDoc.CreateElement("WordSize");
            presetWordSize.InnerText = WordSizeTextBox.Text;
            XmlElement presetPageSize = presetDoc.CreateElement("PageSize");
            presetPageSize.InnerText = PageSizeTextBox.Text;
            XmlElement presetNumPages = presetDoc.CreateElement("NumPages");
            presetNumPages.InnerText = NumPagesTextBox.Text;


            root.AppendChild(newPreset);
            newPreset.AppendChild(presetName);
            newPreset.AppendChild(presetWordSize);
            newPreset.AppendChild(presetPageSize);
            newPreset.AppendChild(presetNumPages);

            presetDoc.Save(Path.GetFullPath("../data/presets.xml"));

            RefreshPresetList(); // Refresh List after xml is updated
        }

        private void LoadPresetButton_Click(object sender, EventArgs e) {

            XmlDocument presetDoc = new XmlDocument(); // Define XMLdoc
            presetDoc.Load(Path.GetFullPath("../data/presets.xml")); // load xml

            XmlNodeList presetList = presetDoc.GetElementsByTagName("preset"); // create list of preset nodes
            int presetIndex = PresetsListBox.SelectedIndex; // Get selected index from listbox
            if (presetIndex < 0) return; // Return Function if no index has been selected
            XmlNode selectedPreset = presetList[presetIndex];

            // Get Individual Children by name
            XmlNode wordSize = selectedPreset.SelectSingleNode("WordSize");
            XmlNode pageSize = selectedPreset.SelectSingleNode("PageSize");
            XmlNode numPages = selectedPreset.SelectSingleNode("NumPages");

            // Store values in textboxes
            WordSizeTextBox.Text = wordSize.InnerText;
            PageSizeTextBox.Text = pageSize.InnerText;
            NumPagesTextBox.Text = numPages.InnerText;
        }

        public void RefreshPresetList() { // Update presets in listbox from presets.xml

            XmlDocument presetDoc = new XmlDocument(); // Define XMLdoc
            presetDoc.Load(Path.GetFullPath("../data/presets.xml")); // load xml

            XmlNodeList presetList = presetDoc.GetElementsByTagName("preset"); // create list of preset nodes
            PresetsListBox.Items.Clear(); // clear listbox
            for (int i = 0; i < presetList.Count; i++) {
                XmlNode currentNode = presetList[i]; //get single node from nodelist
                XmlNode presetNameNode = currentNode.SelectSingleNode("Name"); // get child with tag "Name"
                string presetName = presetNameNode.InnerText; // Get Name Child's content
                PresetsListBox.Items.Add(presetName); // Add to listbox
            }
        }

        private void TstConnButton_Click(object sender, EventArgs e) {
            ATMEGAAddress = mcp.TestConnection(DeviceNumber);
            if (ATMEGAAddress == 0) { // If address is zero throw error
                ProgConsole.Items.Add("Error Connecting");
            }
            else {
                ProgConsole.Items.Add("Connected at address " + ATMEGAAddress.ToString());
            }
        }
    }
    public class MCPFunctions {
        // DLL Imports
        [DllImport("MCP2221DLL-UM_x86.dll", EntryPoint = "DllInit", CharSet = CharSet.Unicode)]
        static extern void DllInit(); // Import DllInit()

        [DllImport("MCP2221DLL-UM_x86.dll", EntryPoint = "GetConnectionStatus", CharSet = CharSet.Unicode)]
        static extern bool GetConnectionStatus(); // Import GetConnectionStatus() to check connection between device

        [DllImport("MCP2221DLL-UM_x86.dll", EntryPoint = "GetDevCount", CharSet = CharSet.Unicode)]
        static extern int GetDevCount(); // Import GetDevCount() for detecting # of connected devices

        [DllImport("MCP2221DLL-UM_x86.dll", EntryPoint = "SelectDev", CharSet = CharSet.Unicode)]
        static extern int SelectDev(int whichDevice); // Import SelectDev to select which device to connect to

        [DllImport("MCP2221DLL-UM_x86.dll", EntryPoint = "ReadI2cData", CharSet = CharSet.Unicode)]
        static extern int ReadI2cData(byte i2cAddress, byte[] i2cDataReceived, UInt32 numberOfBytesToRead, UInt32 i2cBusSpeed); // Import I2C Read Function

        [DllImport("MCP2221DLL-UM_x86.dll", EntryPoint = "WriteI2cData", CharSet = CharSet.Unicode)]
        static extern int WriteI2cData(byte i2cAddress, byte[] i2cDataToSend, UInt32 numberOfBytesToWrite, UInt32 i2cBusSpeed);

        [DllImport("MCP2221DLL-UM_x86.dll", EntryPoint = "SetGpPinDirection", CharSet = CharSet.Unicode)]
        static extern int SetGpPinDirection(int whichToSet, byte pinNumber, byte directionToSet);

        [DllImport("MCP2221DLL-UM_x86.dll", EntryPoint = "ReadGpioPinValue", CharSet = CharSet.Unicode)]
        static extern int ReadGpioPinValue(byte pinNumber);
        
        [DllImport("MCP2221DLL-UM_x86.dll", EntryPoint = "GetUsbStringDescriptor", CharSet = CharSet.Unicode)]
        static extern int GetUsbStringDescriptor(char[] descriptor);

        [DllImport("MCP2221DLL-UM_x86.dll", EntryPoint = "GetSelectedDevInfo", CharSet = CharSet.Unicode)]
        static extern int GetSelectedDevInfo(char[] devInformation);

        public string[] GetDevices() { // Executes first in setup code
            DllInit();
            SelectDev(0);
            if (GetConnectionStatus()) {
                int numDev = GetDevCount();
                // int numDev = 10;
                string[] devices = new string[numDev];
                for (int i = 0; i < numDev; i++) {
                    char[] descript = new char[31];
                    SelectDev(i);
                    GetUsbStringDescriptor(descript);
                    string d = new string(descript);
                    devices[i] = i.ToString() + ": " + d;
                    // devices[i] = "Raan" + i.ToString();
                }

                return devices.ToArray();
            }
            else {
                string[] failed = new string[1];
                failed[0] = "No Devices Connected";
                return failed.ToArray();
            }
            
        }

        public byte TestConnection(int index) {
            byte address = 0;
            SelectDev(index);

            if (GetConnectionStatus()) {
                bool connected = false;
                int errorCount = 0;

                while (!connected) {
                    for (byte addr = 0; addr < 128; addr ++) {
                        byte[] tstCommand = { 5 }; // Create byte array to write
                        byte[] returnedData = new byte[1]; // Create byte array to read to

                        int ackWrite = WriteI2cData(Convert.ToByte(addr << 1), tstCommand, 1, 100000);
                        // Shift address over one to send  7 bit address
                        int ackRead = ReadI2cData(Convert.ToByte(addr << 1), returnedData, 1, 100000);

                        if (ackWrite == 0 && ackRead == 0 && returnedData[0] == 5) { // If both methods worked and recieved data is correct
                            connected = true;
                            address = addr;
                            break;
                        }
                    }
                    errorCount++;
                    if (errorCount > 1) return 0; // Try twice
                }
                return address;
            }
            else {
                return 0; // Conection Failed
            }
        }
    }
}
