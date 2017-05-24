using System;

namespace WindowsColourChangeController
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.currentColourLabel = new System.Windows.Forms.Label();
            this.sendColourLabel = new System.Windows.Forms.Label();
            this.cRed = new System.Windows.Forms.Label();
            this.cGreen = new System.Windows.Forms.Label();
            this.cBlue = new System.Windows.Forms.Label();
            this.sRed = new System.Windows.Forms.Label();
            this.sGreen = new System.Windows.Forms.Label();
            this.sBlue = new System.Windows.Forms.Label();
            this.sRedEntry = new System.Windows.Forms.TextBox();
            this.sGreenEntry = new System.Windows.Forms.TextBox();
            this.sBlueEntry = new System.Windows.Forms.TextBox();
            this.ColourPickButton = new System.Windows.Forms.Button();
            this.cRedVal = new System.Windows.Forms.Label();
            this.cGreenVal = new System.Windows.Forms.Label();
            this.cBlueVal = new System.Windows.Forms.Label();
            this.SendButton = new System.Windows.Forms.Button();
            this.cColourDisplay = new System.Windows.Forms.Label();
            this.sColourDisplay = new System.Windows.Forms.Label();
            this.comSelect = new System.Windows.Forms.ComboBox();
            this.comLabel = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // currentColourLabel
            // 
            this.currentColourLabel.AutoSize = true;
            this.currentColourLabel.Location = new System.Drawing.Point(13, 13);
            this.currentColourLabel.Name = "currentColourLabel";
            this.currentColourLabel.Size = new System.Drawing.Size(74, 13);
            this.currentColourLabel.TabIndex = 0;
            this.currentColourLabel.Text = "Current Colour";
            // 
            // sendColourLabel
            // 
            this.sendColourLabel.AutoSize = true;
            this.sendColourLabel.Location = new System.Drawing.Point(328, 13);
            this.sendColourLabel.Name = "sendColourLabel";
            this.sendColourLabel.Size = new System.Drawing.Size(81, 13);
            this.sendColourLabel.TabIndex = 1;
            this.sendColourLabel.Text = "Colour To Send";
            // 
            // cRed
            // 
            this.cRed.AutoSize = true;
            this.cRed.Location = new System.Drawing.Point(13, 64);
            this.cRed.Name = "cRed";
            this.cRed.Size = new System.Drawing.Size(27, 13);
            this.cRed.TabIndex = 2;
            this.cRed.Text = "Red";
            // 
            // cGreen
            // 
            this.cGreen.AutoSize = true;
            this.cGreen.Location = new System.Drawing.Point(12, 111);
            this.cGreen.Name = "cGreen";
            this.cGreen.Size = new System.Drawing.Size(36, 13);
            this.cGreen.TabIndex = 3;
            this.cGreen.Text = "Green";
            // 
            // cBlue
            // 
            this.cBlue.AutoSize = true;
            this.cBlue.Location = new System.Drawing.Point(12, 154);
            this.cBlue.Name = "cBlue";
            this.cBlue.Size = new System.Drawing.Size(28, 13);
            this.cBlue.TabIndex = 4;
            this.cBlue.Text = "Blue";
            // 
            // sRed
            // 
            this.sRed.AutoSize = true;
            this.sRed.Location = new System.Drawing.Point(328, 64);
            this.sRed.Name = "sRed";
            this.sRed.Size = new System.Drawing.Size(27, 13);
            this.sRed.TabIndex = 5;
            this.sRed.Text = "Red";
            // 
            // sGreen
            // 
            this.sGreen.AutoSize = true;
            this.sGreen.Location = new System.Drawing.Point(328, 111);
            this.sGreen.Name = "sGreen";
            this.sGreen.Size = new System.Drawing.Size(36, 13);
            this.sGreen.TabIndex = 6;
            this.sGreen.Text = "Green";
            // 
            // sBlue
            // 
            this.sBlue.AutoSize = true;
            this.sBlue.Location = new System.Drawing.Point(328, 154);
            this.sBlue.Name = "sBlue";
            this.sBlue.Size = new System.Drawing.Size(28, 13);
            this.sBlue.TabIndex = 7;
            this.sBlue.Text = "Blue";
            // 
            // sRedEntry
            // 
            this.sRedEntry.Location = new System.Drawing.Point(391, 64);
            this.sRedEntry.Name = "sRedEntry";
            this.sRedEntry.Size = new System.Drawing.Size(100, 20);
            this.sRedEntry.TabIndex = 8;
            this.sRedEntry.TextChanged += new System.EventHandler(this.sRedEntry_TextChanged);
            // 
            // sGreenEntry
            // 
            this.sGreenEntry.Location = new System.Drawing.Point(391, 104);
            this.sGreenEntry.Name = "sGreenEntry";
            this.sGreenEntry.Size = new System.Drawing.Size(100, 20);
            this.sGreenEntry.TabIndex = 9;
            this.sGreenEntry.TextChanged += new System.EventHandler(this.sGreenEntry_TextChanged);
            // 
            // sBlueEntry
            // 
            this.sBlueEntry.Location = new System.Drawing.Point(391, 147);
            this.sBlueEntry.Name = "sBlueEntry";
            this.sBlueEntry.Size = new System.Drawing.Size(100, 20);
            this.sBlueEntry.TabIndex = 10;
            this.sBlueEntry.TextChanged += new System.EventHandler(this.sBlueEntry_TextChanged);
            // 
            // ColourPickButton
            // 
            this.ColourPickButton.Location = new System.Drawing.Point(391, 185);
            this.ColourPickButton.Name = "ColourPickButton";
            this.ColourPickButton.Size = new System.Drawing.Size(100, 23);
            this.ColourPickButton.TabIndex = 11;
            this.ColourPickButton.Text = "Colour Picker";
            this.ColourPickButton.UseVisualStyleBackColor = true;
            this.ColourPickButton.Click += new System.EventHandler(this.ColourPickButton_Click);
            // 
            // cRedVal
            // 
            this.cRedVal.AutoSize = true;
            this.cRedVal.Location = new System.Drawing.Point(80, 64);
            this.cRedVal.Name = "cRedVal";
            this.cRedVal.Size = new System.Drawing.Size(48, 13);
            this.cRedVal.TabIndex = 12;
            this.cRedVal.Text = "cRedVal";
            // 
            // cGreenVal
            // 
            this.cGreenVal.AutoSize = true;
            this.cGreenVal.Location = new System.Drawing.Point(80, 111);
            this.cGreenVal.Name = "cGreenVal";
            this.cGreenVal.Size = new System.Drawing.Size(57, 13);
            this.cGreenVal.TabIndex = 13;
            this.cGreenVal.Text = "cGreenVal";
            // 
            // cBlueVal
            // 
            this.cBlueVal.AutoSize = true;
            this.cBlueVal.Location = new System.Drawing.Point(80, 154);
            this.cBlueVal.Name = "cBlueVal";
            this.cBlueVal.Size = new System.Drawing.Size(49, 13);
            this.cBlueVal.TabIndex = 14;
            this.cBlueVal.Text = "cBlueVal";
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(520, 185);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(100, 23);
            this.SendButton.TabIndex = 15;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // cColourDisplay
            // 
            this.cColourDisplay.Location = new System.Drawing.Point(134, 61);
            this.cColourDisplay.Name = "cColourDisplay";
            this.cColourDisplay.Size = new System.Drawing.Size(143, 106);
            this.cColourDisplay.TabIndex = 16;
            // 
            // sColourDisplay
            // 
            this.sColourDisplay.Location = new System.Drawing.Point(497, 61);
            this.sColourDisplay.Name = "sColourDisplay";
            this.sColourDisplay.Size = new System.Drawing.Size(143, 106);
            this.sColourDisplay.TabIndex = 17;
            // 
            // comSelect
            // 
            this.comSelect.FormattingEnabled = true;
            this.comSelect.Items.AddRange(new object[] {
            "COM1",
            "COM3"});
            this.comSelect.Location = new System.Drawing.Point(83, 185);
            this.comSelect.Name = "comSelect";
            this.comSelect.Size = new System.Drawing.Size(121, 21);
            this.comSelect.TabIndex = 18;
            this.comSelect.DropDownClosed += new System.EventHandler(this.comSelect_DropDownClosed);
            // 
            // comLabel
            // 
            this.comLabel.AutoSize = true;
            this.comLabel.Location = new System.Drawing.Point(13, 190);
            this.comLabel.Name = "comLabel";
            this.comLabel.Size = new System.Drawing.Size(28, 13);
            this.comLabel.TabIndex = 19;
            this.comLabel.Text = "Com";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "ArduinoColourControler";
            this.notifyIcon.Visible = false;
            this.notifyIcon.Text = currentColour.ToString();
            this.notifyIcon.Icon = this.Icon;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.mouse_doubleclick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 241);
            this.Controls.Add(this.comLabel);
            this.Controls.Add(this.comSelect);
            this.Controls.Add(this.sColourDisplay);
            this.Controls.Add(this.cColourDisplay);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.cBlueVal);
            this.Controls.Add(this.cGreenVal);
            this.Controls.Add(this.cRedVal);
            this.Controls.Add(this.ColourPickButton);
            this.Controls.Add(this.sBlueEntry);
            this.Controls.Add(this.sGreenEntry);
            this.Controls.Add(this.sRedEntry);
            this.Controls.Add(this.sBlue);
            this.Controls.Add(this.sGreen);
            this.Controls.Add(this.sRed);
            this.Controls.Add(this.cBlue);
            this.Controls.Add(this.cGreen);
            this.Controls.Add(this.cRed);
            this.Controls.Add(this.sendColourLabel);
            this.Controls.Add(this.currentColourLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.form_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }      

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label currentColourLabel;
        private System.Windows.Forms.Label sendColourLabel;
        private System.Windows.Forms.Label cRed;
        private System.Windows.Forms.Label cGreen;
        private System.Windows.Forms.Label cBlue;
        private System.Windows.Forms.Label sRed;
        private System.Windows.Forms.Label sGreen;
        private System.Windows.Forms.Label sBlue;
        private System.Windows.Forms.TextBox sRedEntry;
        private System.Windows.Forms.TextBox sGreenEntry;
        private System.Windows.Forms.TextBox sBlueEntry;
        private System.Windows.Forms.Button ColourPickButton;
        private System.Windows.Forms.Label cRedVal;
        private System.Windows.Forms.Label cGreenVal;
        private System.Windows.Forms.Label cBlueVal;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Label cColourDisplay;
        private System.Windows.Forms.Label sColourDisplay;
        private System.Windows.Forms.ComboBox comSelect;
        private System.Windows.Forms.Label comLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

