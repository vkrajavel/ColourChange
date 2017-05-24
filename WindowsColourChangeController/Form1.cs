using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace WindowsColourChangeController
{
    public partial class Form1 : Form
    {
        private Color sendColour;
        private Color currentColour;
        private String comPort;
        private string filePath;
        delegate void SetTextCallback(string text, System.Windows.Forms.Label label);
        delegate void SetColourCallback(Color colour, System.Windows.Forms.Label label);
        
        public Form1()
        {
            filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + Application.ProductName;
            try
            {
                // Determine whether the directory exists, if not create it!.
                if (!Directory.Exists(filePath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(filePath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not create Directory" + e.Message);
            }

            InitializeComponent();
            loadXML();
            updateColour();
        }
        private void form_Resize(Object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                this.ShowInTaskbar = false;
            }
        }
        private void mouse_doubleclick(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }
        private void updateSentColour()
        {
            this.setText(String.Format("{0}", currentColour.R), cRedVal);
            this.setText(String.Format("{0}", currentColour.G), cGreenVal);
            this.setText(String.Format("{0}", currentColour.B), cBlueVal);
            this.setColour(currentColour, cColourDisplay);
            //cColourDisplay.BackColor = currentColour;
        }
        private void updateColour()
        {
            
            //setCurrent
            this.setText(String.Format("{0}", currentColour.R),cRedVal);
            this.setText(String.Format("{0}", currentColour.G), cGreenVal);
            this.setText(String.Format("{0}", currentColour.B), cBlueVal);
            cColourDisplay.BackColor = currentColour;

            //setSend
            sRedEntry.Text = String.Format("{0}", sendColour.R);
            sGreenEntry.Text = String.Format("{0}", sendColour.G);
            sBlueEntry.Text = String.Format("{0}", sendColour.B);
            sColourDisplay.BackColor = sendColour;
        }

        private void loadXML()
        {      
            int tRed = 0;
            int tGreen = 0;
            int tBlue = 0;
            List<int> customCol = new List<int>();
            try
            {
                using (XmlReader reader = XmlReader.Create(filePath + "\\Settings.xml"))
                {
                    reader.MoveToContent();
                    while (reader.Read())
                    {
                        if (reader.IsEmptyElement) { reader.Read(); }

                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            Console.WriteLine(reader.Name);
                            switch (reader.Name)
                            {
                                case "CustomColours":
                                    break;
                                case "Color":
                                    reader.Read();
                                    Console.WriteLine(reader.Value);
                                    int temp;
                                    int.TryParse(reader.Value, out temp);
                                    customCol.Add(temp);
                                    break;
                                case "COM":
                                    break;
                                case "COM-PORT":
                                    setComPort(reader.ReadElementContentAsString());
                                    break;
                                case "LastColour":
                                    break;
                                case "Red":
                                    reader.Read();
                                    int.TryParse(reader.Value, out tRed);
                                    break;
                                case "Green":
                                    reader.Read();
                                    int.TryParse(reader.Value, out tGreen);
                                    break;
                                case "Blue":
                                    reader.Read();
                                    int.TryParse(reader.Value, out tBlue);
                                    break;
                            }
                        }
                    }
                }
            }
            catch (System.IO.FileNotFoundException)
            {

            }
            sendColour = Color.FromArgb(tRed, tGreen, tBlue);
            colorDialog1.CustomColors = customCol.ToArray<int>();
        }
        private void setText(string Text, System.Windows.Forms.Label label)
        {
            if (label.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setText);
                this.Invoke(d, new object[] {Text, label});
            }
            else
            {
                label.Text = Text;
            }
        }
        private void setColour(Color colour, System.Windows.Forms.Label label)
        {
            if (label.InvokeRequired)
            {
                SetColourCallback d = new SetColourCallback(setColour);
                this.Invoke(d, new object[] { colour, label });
            }
            else
            {
                label.BackColor = colour;
            }
        }

        private void setComPort(String port){
            comPort = port;
            serialPort1.BaudRate = 9600;
            comSelect.SelectedItem = port;
            serialPort1.Close();
            comPort = (String)comSelect.SelectedItem;
            if (comPort != null)
            {
                serialPort1.PortName = port;
            }
            try
            {
                serialPort1.Open();

            }
            catch (UnauthorizedAccessException ex)
            {

            }
            catch (System.IO.IOException eio)
            {

            }
        }

        private void ColourPickButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = sendColour;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                sendColour = colorDialog1.Color;
            }
            updateColour();
        }

        private void serialPort1_DataReceived(object sender, EventArgs e)
        {
            String colourString = serialPort1.ReadLine();
            Char splitChar = ',';
            String[] colours = colourString.Split(splitChar);
            if (colours.Length == 3)
            {
                int r = int.Parse(colours[0]);
                int g = int.Parse(colours[1]);
                int b = int.Parse(colours[2]);
                if (r < 255 & g < 255 & b < 255)
                {
                    currentColour = Color.FromArgb(r,g,b);
                    updateSentColour();
                }
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            String send = String.Format("{0},{1},{2},{3}",5000, sendColour.R, sendColour.G, sendColour.B);
            try
            {
                serialPort1.Write(send);
            }
            catch (System.UnauthorizedAccessException eu)
            {

            }
            catch (System.InvalidOperationException ei)
            {

            }
        }
        private void comSelect_DropDownClosed(object sender, EventArgs e)
        {
            serialPort1.Close();
            comPort = (String)comSelect.SelectedItem;
            if (comPort != null){
                serialPort1.PortName = comPort;
            }
            try{
                serialPort1.Open();

            }catch(UnauthorizedAccessException ex ){

            }
            catch (System.IO.IOException eio)
            {

            }
                      
        }

        private void sRedEntry_TextChanged(object sender, EventArgs e)
        {
            int rNumber;
            if (int.TryParse(sRedEntry.Text, out rNumber))
            {
                if (rNumber <= 255 && rNumber >= 0)
                {
                    sendColour = Color.FromArgb(rNumber,sendColour.G,sendColour.B);
                    updateColour();
                }      
            }           
        }

        private void sGreenEntry_TextChanged(object sender, EventArgs e)
        {
            int gNumber;
            if (int.TryParse(sGreenEntry.Text, out gNumber))
            {
                if (gNumber <= 255 && gNumber >= 0)
                {
                    sendColour = Color.FromArgb(sendColour.R, gNumber, sendColour.B);
                    updateColour();
                }
            }        
        }

        private void sBlueEntry_TextChanged(object sender, EventArgs e)
        {
            int bNumber;
            if (int.TryParse(sBlueEntry.Text, out bNumber))
            {
                if (bNumber <= 255 && bNumber >= 0)
                {
                    sendColour = Color.FromArgb(sendColour.R, sendColour.G, bNumber);
                    updateColour();
                }
            }      
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (XmlWriter writer = XmlWriter.Create(filePath + "\\Settings.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("WindowsColourChangeControllerSettings");

                //CUSTOM COLOURS
                writer.WriteStartElement("CustomColors");
                foreach (int i in colorDialog1.CustomColors){
                    writer.WriteElementString("Color",i.ToString());
                }
                writer.WriteEndElement();
                
                //COM-PORT
                writer.WriteStartElement("COM");
                writer.WriteElementString("COM-PORT", serialPort1.PortName);
                writer.WriteEndElement();

                //LAST COLOUR
                writer.WriteStartElement("LastColor");
                writer.WriteElementString("Red", sendColour.R.ToString());
                writer.WriteElementString("Green", sendColour.G.ToString());
                writer.WriteElementString("Blue", sendColour.B.ToString());
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
