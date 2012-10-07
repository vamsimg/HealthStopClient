using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;
using Microsoft.CSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

using System.Web.Script.Serialization;
using HealthStopClient.com.healthstop;


namespace HealthStopClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{


        private System.Windows.Forms.TextBox lbLog; 
	   private NotifyIcon TraynotifyIcon;
        private OpenFileDialog RMOpenFileDialog;
	   private TabPage DatabasesTab;
        private Button SaveDatabaseSettingsButton;
	   private TabPage ConnectionTab;
	   private Label ConnectionErrorlabel;
	   private TextBox StoreIDtextBox;
	   private TextBox PasswordTextBox;
	   private Label TestConnectionErrorlabel;
	   private Button SaveConnectionSettingsButton;
	   private Label Storelabel;
	   private Label Passwordlabel;
	   private Button TestConnectionButton;
	   private TabControl MainTabControl;
	   private TabPage POTab;
	   private GroupBox POSSoftwareGroupBox;
	   private RadioButton MicrosoftRMSRadioButton;
	   private RadioButton MYOBRadioButton;
	   private SplitContainer POSSoftwareSplitContainer;
	   private Label label2;
	   private Button FindRMDBbutton;
	   private Label label1;
	   private TextBox RMDBTextBox;
	   private TextBox MicrosoftDBTextBox;
	   private Label label7;
	   private Label TestMicrosoftConnectionErrorLabel;
	   private Button MicrosoftTestConnectionButton;
	   private Label label6;
	   private TextBox MicrosoftPasswordTextBox;
	   private Label label5;
	   private TextBox MicrosoftUserTextBox;
	   private Label label4;
	   private TextBox MicrosoftLocationTextBox;
	   private Label label3;
	   private Label DatabaseSettingsErrorLabel;
        private Panel panel2;
	   
	   private Button CommitStocktakeButton;
	   private Label GetStocktakeItemsErrorLabel;
	   private Button GetStocktakeItemsButton;
        private Label label9;
        private Button GetPurchaseOrdersButton;
        private Label GetPurchaseOrdersErrorLabel;
        private Button WritePurchaseOrdersButton;
        private Label WritePurchaseOrdersErrorLabel;
        private Button SendOrdersButton;
        private Label SendOrdersErrorLabel;
        private TabPage InvoicesTab;
        private Label CommitInvoicesErrorLabel;
        private Button CommitInvoicesButton;
        private Label GetInvoicesErrorLabel;
        private Label DateLabel;
        private DateTimePicker PODateTimePicker;
        private Button GetInvoicesButton;
        private TextBox InvoicesTextBox;
        private RadioListBox AvailableInvoicesRadioListBox;
        private CheckBox UpdateRRPCheckBox;
        private TextBox OrderTextBox;
        private RadioListBox OrdersRadioListBox;
        private TextBox WebServiceTextBox;
        private Label ServiceLabel;
        private IContainer components;

		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
               this.components = new System.ComponentModel.Container();
               this.lbLog = new System.Windows.Forms.TextBox();
               this.TraynotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
               this.RMOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
               this.DatabasesTab = new System.Windows.Forms.TabPage();
               this.DatabaseSettingsErrorLabel = new System.Windows.Forms.Label();
               this.POSSoftwareSplitContainer = new System.Windows.Forms.SplitContainer();
               this.label2 = new System.Windows.Forms.Label();
               this.FindRMDBbutton = new System.Windows.Forms.Button();
               this.label1 = new System.Windows.Forms.Label();
               this.RMDBTextBox = new System.Windows.Forms.TextBox();
               this.MicrosoftDBTextBox = new System.Windows.Forms.TextBox();
               this.label7 = new System.Windows.Forms.Label();
               this.TestMicrosoftConnectionErrorLabel = new System.Windows.Forms.Label();
               this.MicrosoftTestConnectionButton = new System.Windows.Forms.Button();
               this.label6 = new System.Windows.Forms.Label();
               this.MicrosoftPasswordTextBox = new System.Windows.Forms.TextBox();
               this.label5 = new System.Windows.Forms.Label();
               this.MicrosoftUserTextBox = new System.Windows.Forms.TextBox();
               this.label4 = new System.Windows.Forms.Label();
               this.MicrosoftLocationTextBox = new System.Windows.Forms.TextBox();
               this.label3 = new System.Windows.Forms.Label();
               this.POSSoftwareGroupBox = new System.Windows.Forms.GroupBox();
               this.MicrosoftRMSRadioButton = new System.Windows.Forms.RadioButton();
               this.MYOBRadioButton = new System.Windows.Forms.RadioButton();
               this.SaveDatabaseSettingsButton = new System.Windows.Forms.Button();
               this.ConnectionTab = new System.Windows.Forms.TabPage();
               this.ConnectionErrorlabel = new System.Windows.Forms.Label();
               this.StoreIDtextBox = new System.Windows.Forms.TextBox();
               this.PasswordTextBox = new System.Windows.Forms.TextBox();
               this.TestConnectionErrorlabel = new System.Windows.Forms.Label();
               this.SaveConnectionSettingsButton = new System.Windows.Forms.Button();
               this.Storelabel = new System.Windows.Forms.Label();
               this.Passwordlabel = new System.Windows.Forms.Label();
               this.TestConnectionButton = new System.Windows.Forms.Button();
               this.MainTabControl = new System.Windows.Forms.TabControl();
               this.POTab = new System.Windows.Forms.TabPage();
               this.panel2 = new System.Windows.Forms.Panel();
               this.OrdersRadioListBox = new System.Windows.Forms.RadioListBox();
               this.OrderTextBox = new System.Windows.Forms.TextBox();
               this.DateLabel = new System.Windows.Forms.Label();
               this.PODateTimePicker = new System.Windows.Forms.DateTimePicker();
               this.SendOrdersButton = new System.Windows.Forms.Button();
               this.SendOrdersErrorLabel = new System.Windows.Forms.Label();
               this.label9 = new System.Windows.Forms.Label();
               this.InvoicesTab = new System.Windows.Forms.TabPage();
               this.AvailableInvoicesRadioListBox = new System.Windows.Forms.RadioListBox();
               this.InvoicesTextBox = new System.Windows.Forms.TextBox();
               this.GetInvoicesButton = new System.Windows.Forms.Button();
               this.CommitInvoicesErrorLabel = new System.Windows.Forms.Label();
               this.UpdateRRPCheckBox = new System.Windows.Forms.CheckBox();
               this.CommitInvoicesButton = new System.Windows.Forms.Button();
               this.GetInvoicesErrorLabel = new System.Windows.Forms.Label();
               this.GetPurchaseOrdersButton = new System.Windows.Forms.Button();
               this.GetPurchaseOrdersErrorLabel = new System.Windows.Forms.Label();
               this.WritePurchaseOrdersButton = new System.Windows.Forms.Button();
               this.WritePurchaseOrdersErrorLabel = new System.Windows.Forms.Label();
               this.GetStocktakeItemsButton = new System.Windows.Forms.Button();
               this.GetStocktakeItemsErrorLabel = new System.Windows.Forms.Label();
               this.CommitStocktakeButton = new System.Windows.Forms.Button();
               this.WebServiceTextBox = new System.Windows.Forms.TextBox();
               this.ServiceLabel = new System.Windows.Forms.Label();
               this.DatabasesTab.SuspendLayout();
               ((System.ComponentModel.ISupportInitialize)(this.POSSoftwareSplitContainer)).BeginInit();
               this.POSSoftwareSplitContainer.Panel1.SuspendLayout();
               this.POSSoftwareSplitContainer.Panel2.SuspendLayout();
               this.POSSoftwareSplitContainer.SuspendLayout();
               this.POSSoftwareGroupBox.SuspendLayout();
               this.ConnectionTab.SuspendLayout();
               this.MainTabControl.SuspendLayout();
               this.POTab.SuspendLayout();
               this.panel2.SuspendLayout();
               this.InvoicesTab.SuspendLayout();
               this.SuspendLayout();
               // 
               // lbLog
               // 
               this.lbLog.Location = new System.Drawing.Point(947, 48);
               this.lbLog.Multiline = true;
               this.lbLog.Name = "lbLog";
               this.lbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
               this.lbLog.Size = new System.Drawing.Size(559, 688);
               this.lbLog.TabIndex = 22;
               // 
               // DatabasesTab
               // 
               this.DatabasesTab.Controls.Add(this.DatabaseSettingsErrorLabel);
               this.DatabasesTab.Controls.Add(this.POSSoftwareSplitContainer);
               this.DatabasesTab.Controls.Add(this.POSSoftwareGroupBox);
               this.DatabasesTab.Controls.Add(this.SaveDatabaseSettingsButton);
               this.DatabasesTab.Location = new System.Drawing.Point(4, 22);
               this.DatabasesTab.Name = "DatabasesTab";
               this.DatabasesTab.Padding = new System.Windows.Forms.Padding(3);
               this.DatabasesTab.Size = new System.Drawing.Size(885, 684);
               this.DatabasesTab.TabIndex = 2;
               this.DatabasesTab.Text = "Databases";
               this.DatabasesTab.UseVisualStyleBackColor = true;
               // 
               // DatabaseSettingsErrorLabel
               // 
               this.DatabaseSettingsErrorLabel.AutoSize = true;
               this.DatabaseSettingsErrorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.DatabaseSettingsErrorLabel.ForeColor = System.Drawing.Color.Red;
               this.DatabaseSettingsErrorLabel.Location = new System.Drawing.Point(125, 401);
               this.DatabaseSettingsErrorLabel.Name = "DatabaseSettingsErrorLabel";
               this.DatabaseSettingsErrorLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
               this.DatabaseSettingsErrorLabel.Size = new System.Drawing.Size(12, 15);
               this.DatabaseSettingsErrorLabel.TabIndex = 49;
               // 
               // POSSoftwareSplitContainer
               // 
               this.POSSoftwareSplitContainer.Location = new System.Drawing.Point(9, 135);
               this.POSSoftwareSplitContainer.Name = "POSSoftwareSplitContainer";
               this.POSSoftwareSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
               // 
               // POSSoftwareSplitContainer.Panel1
               // 
               this.POSSoftwareSplitContainer.Panel1.Controls.Add(this.label2);
               this.POSSoftwareSplitContainer.Panel1.Controls.Add(this.FindRMDBbutton);
               this.POSSoftwareSplitContainer.Panel1.Controls.Add(this.label1);
               this.POSSoftwareSplitContainer.Panel1.Controls.Add(this.RMDBTextBox);
               // 
               // POSSoftwareSplitContainer.Panel2
               // 
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.MicrosoftDBTextBox);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.label7);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.TestMicrosoftConnectionErrorLabel);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.MicrosoftTestConnectionButton);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.label6);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.MicrosoftPasswordTextBox);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.label5);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.MicrosoftUserTextBox);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.label4);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.MicrosoftLocationTextBox);
               this.POSSoftwareSplitContainer.Panel2.Controls.Add(this.label3);
               this.POSSoftwareSplitContainer.Size = new System.Drawing.Size(526, 228);
               this.POSSoftwareSplitContainer.SplitterDistance = 77;
               this.POSSoftwareSplitContainer.TabIndex = 48;
               // 
               // label2
               // 
               this.label2.AutoSize = true;
               this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label2.Location = new System.Drawing.Point(13, 9);
               this.label2.Name = "label2";
               this.label2.Size = new System.Drawing.Size(132, 13);
               this.label2.TabIndex = 34;
               this.label2.Text = "MYOB Retail Manager";
               // 
               // FindRMDBbutton
               // 
               this.FindRMDBbutton.Location = new System.Drawing.Point(438, 35);
               this.FindRMDBbutton.Name = "FindRMDBbutton";
               this.FindRMDBbutton.Size = new System.Drawing.Size(75, 23);
               this.FindRMDBbutton.TabIndex = 33;
               this.FindRMDBbutton.Text = "Find RMDB";
               this.FindRMDBbutton.UseVisualStyleBackColor = true;
               this.FindRMDBbutton.Click += new System.EventHandler(this.FindRMDBbutton_Click);
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Location = new System.Drawing.Point(13, 38);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(86, 13);
               this.label1.TabIndex = 29;
               this.label1.Text = "RM DB Location";
               // 
               // RMDBTextBox
               // 
               this.RMDBTextBox.Location = new System.Drawing.Point(131, 35);
               this.RMDBTextBox.Name = "RMDBTextBox";
               this.RMDBTextBox.Size = new System.Drawing.Size(268, 20);
               this.RMDBTextBox.TabIndex = 30;
               // 
               // MicrosoftDBTextBox
               // 
               this.MicrosoftDBTextBox.Location = new System.Drawing.Point(131, 63);
               this.MicrosoftDBTextBox.Name = "MicrosoftDBTextBox";
               this.MicrosoftDBTextBox.Size = new System.Drawing.Size(127, 20);
               this.MicrosoftDBTextBox.TabIndex = 45;
               // 
               // label7
               // 
               this.label7.AutoSize = true;
               this.label7.Location = new System.Drawing.Point(13, 67);
               this.label7.Name = "label7";
               this.label7.Size = new System.Drawing.Size(84, 13);
               this.label7.TabIndex = 44;
               this.label7.Text = "Database Name";
               // 
               // TestMicrosoftConnectionErrorLabel
               // 
               this.TestMicrosoftConnectionErrorLabel.AutoSize = true;
               this.TestMicrosoftConnectionErrorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.TestMicrosoftConnectionErrorLabel.ForeColor = System.Drawing.Color.Red;
               this.TestMicrosoftConnectionErrorLabel.Location = new System.Drawing.Point(131, 122);
               this.TestMicrosoftConnectionErrorLabel.Name = "TestMicrosoftConnectionErrorLabel";
               this.TestMicrosoftConnectionErrorLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
               this.TestMicrosoftConnectionErrorLabel.Size = new System.Drawing.Size(12, 15);
               this.TestMicrosoftConnectionErrorLabel.TabIndex = 43;
               // 
               // MicrosoftTestConnectionButton
               // 
               this.MicrosoftTestConnectionButton.Location = new System.Drawing.Point(16, 117);
               this.MicrosoftTestConnectionButton.Name = "MicrosoftTestConnectionButton";
               this.MicrosoftTestConnectionButton.Size = new System.Drawing.Size(97, 23);
               this.MicrosoftTestConnectionButton.TabIndex = 42;
               this.MicrosoftTestConnectionButton.Text = "Test Connection";
               this.MicrosoftTestConnectionButton.UseVisualStyleBackColor = true;
               this.MicrosoftTestConnectionButton.Click += new System.EventHandler(this.MicrosoftTestConnectionButton_Click);
               // 
               // label6
               // 
               this.label6.AutoSize = true;
               this.label6.Location = new System.Drawing.Point(278, 67);
               this.label6.Name = "label6";
               this.label6.Size = new System.Drawing.Size(53, 13);
               this.label6.TabIndex = 40;
               this.label6.Text = "Password";
               // 
               // MicrosoftPasswordTextBox
               // 
               this.MicrosoftPasswordTextBox.Location = new System.Drawing.Point(356, 64);
               this.MicrosoftPasswordTextBox.Name = "MicrosoftPasswordTextBox";
               this.MicrosoftPasswordTextBox.PasswordChar = '*';
               this.MicrosoftPasswordTextBox.Size = new System.Drawing.Size(157, 20);
               this.MicrosoftPasswordTextBox.TabIndex = 41;
               // 
               // label5
               // 
               this.label5.AutoSize = true;
               this.label5.Location = new System.Drawing.Point(276, 34);
               this.label5.Name = "label5";
               this.label5.Size = new System.Drawing.Size(55, 13);
               this.label5.TabIndex = 38;
               this.label5.Text = "Username";
               // 
               // MicrosoftUserTextBox
               // 
               this.MicrosoftUserTextBox.Location = new System.Drawing.Point(356, 34);
               this.MicrosoftUserTextBox.Name = "MicrosoftUserTextBox";
               this.MicrosoftUserTextBox.Size = new System.Drawing.Size(157, 20);
               this.MicrosoftUserTextBox.TabIndex = 39;
               // 
               // label4
               // 
               this.label4.AutoSize = true;
               this.label4.Location = new System.Drawing.Point(13, 37);
               this.label4.Name = "label4";
               this.label4.Size = new System.Drawing.Size(69, 13);
               this.label4.TabIndex = 36;
               this.label4.Text = "Server Name";
               // 
               // MicrosoftLocationTextBox
               // 
               this.MicrosoftLocationTextBox.Location = new System.Drawing.Point(131, 34);
               this.MicrosoftLocationTextBox.Name = "MicrosoftLocationTextBox";
               this.MicrosoftLocationTextBox.Size = new System.Drawing.Size(127, 20);
               this.MicrosoftLocationTextBox.TabIndex = 37;
               // 
               // label3
               // 
               this.label3.AutoSize = true;
               this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label3.Location = new System.Drawing.Point(11, 13);
               this.label3.Name = "label3";
               this.label3.Size = new System.Drawing.Size(90, 13);
               this.label3.TabIndex = 35;
               this.label3.Text = "Microsoft RMS";
               // 
               // POSSoftwareGroupBox
               // 
               this.POSSoftwareGroupBox.Controls.Add(this.MicrosoftRMSRadioButton);
               this.POSSoftwareGroupBox.Controls.Add(this.MYOBRadioButton);
               this.POSSoftwareGroupBox.Location = new System.Drawing.Point(140, 6);
               this.POSSoftwareGroupBox.Name = "POSSoftwareGroupBox";
               this.POSSoftwareGroupBox.Size = new System.Drawing.Size(285, 101);
               this.POSSoftwareGroupBox.TabIndex = 47;
               this.POSSoftwareGroupBox.TabStop = false;
               this.POSSoftwareGroupBox.Text = "POS Software";
               // 
               // MicrosoftRMSRadioButton
               // 
               this.MicrosoftRMSRadioButton.AutoSize = true;
               this.MicrosoftRMSRadioButton.Location = new System.Drawing.Point(30, 42);
               this.MicrosoftRMSRadioButton.Name = "MicrosoftRMSRadioButton";
               this.MicrosoftRMSRadioButton.Size = new System.Drawing.Size(95, 17);
               this.MicrosoftRMSRadioButton.TabIndex = 1;
               this.MicrosoftRMSRadioButton.TabStop = true;
               this.MicrosoftRMSRadioButton.Text = "Microsoft RMS";
               this.MicrosoftRMSRadioButton.UseVisualStyleBackColor = true;
               this.MicrosoftRMSRadioButton.CheckedChanged += new System.EventHandler(this.MicrosoftRMSRadioButton_CheckedChanged);
               // 
               // MYOBRadioButton
               // 
               this.MYOBRadioButton.AutoSize = true;
               this.MYOBRadioButton.Location = new System.Drawing.Point(30, 19);
               this.MYOBRadioButton.Name = "MYOBRadioButton";
               this.MYOBRadioButton.Size = new System.Drawing.Size(131, 17);
               this.MYOBRadioButton.TabIndex = 0;
               this.MYOBRadioButton.TabStop = true;
               this.MYOBRadioButton.Text = "MYOB Retail Manager";
               this.MYOBRadioButton.UseVisualStyleBackColor = true;
               this.MYOBRadioButton.CheckedChanged += new System.EventHandler(this.MYOBRadioButton_CheckedChanged);
               // 
               // SaveDatabaseSettingsButton
               // 
               this.SaveDatabaseSettingsButton.Location = new System.Drawing.Point(25, 396);
               this.SaveDatabaseSettingsButton.Name = "SaveDatabaseSettingsButton";
               this.SaveDatabaseSettingsButton.Size = new System.Drawing.Size(83, 23);
               this.SaveDatabaseSettingsButton.TabIndex = 35;
               this.SaveDatabaseSettingsButton.Text = "Save Settings";
               this.SaveDatabaseSettingsButton.UseVisualStyleBackColor = true;
               this.SaveDatabaseSettingsButton.Click += new System.EventHandler(this.SaveDatabaseSettingsButton_Click);
               // 
               // ConnectionTab
               // 
               this.ConnectionTab.Controls.Add(this.WebServiceTextBox);
               this.ConnectionTab.Controls.Add(this.ServiceLabel);
               this.ConnectionTab.Controls.Add(this.ConnectionErrorlabel);
               this.ConnectionTab.Controls.Add(this.StoreIDtextBox);
               this.ConnectionTab.Controls.Add(this.PasswordTextBox);
               this.ConnectionTab.Controls.Add(this.TestConnectionErrorlabel);
               this.ConnectionTab.Controls.Add(this.SaveConnectionSettingsButton);
               this.ConnectionTab.Controls.Add(this.Storelabel);
               this.ConnectionTab.Controls.Add(this.Passwordlabel);
               this.ConnectionTab.Controls.Add(this.TestConnectionButton);
               this.ConnectionTab.Location = new System.Drawing.Point(4, 22);
               this.ConnectionTab.Name = "ConnectionTab";
               this.ConnectionTab.Padding = new System.Windows.Forms.Padding(3);
               this.ConnectionTab.Size = new System.Drawing.Size(885, 684);
               this.ConnectionTab.TabIndex = 0;
               this.ConnectionTab.Text = "Connection";
               this.ConnectionTab.UseVisualStyleBackColor = true;
               // 
               // ConnectionErrorlabel
               // 
               this.ConnectionErrorlabel.AutoSize = true;
               this.ConnectionErrorlabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.ConnectionErrorlabel.ForeColor = System.Drawing.Color.Red;
               this.ConnectionErrorlabel.Location = new System.Drawing.Point(138, 161);
               this.ConnectionErrorlabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
               this.ConnectionErrorlabel.Name = "ConnectionErrorlabel";
               this.ConnectionErrorlabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
               this.ConnectionErrorlabel.Size = new System.Drawing.Size(12, 15);
               this.ConnectionErrorlabel.TabIndex = 35;
               // 
               // StoreIDtextBox
               // 
               this.StoreIDtextBox.Location = new System.Drawing.Point(108, 16);
               this.StoreIDtextBox.Name = "StoreIDtextBox";
               this.StoreIDtextBox.Size = new System.Drawing.Size(386, 20);
               this.StoreIDtextBox.TabIndex = 26;
               // 
               // PasswordTextBox
               // 
               this.PasswordTextBox.Location = new System.Drawing.Point(108, 56);
               this.PasswordTextBox.Name = "PasswordTextBox";
               this.PasswordTextBox.Size = new System.Drawing.Size(386, 20);
               this.PasswordTextBox.TabIndex = 28;
               // 
               // TestConnectionErrorlabel
               // 
               this.TestConnectionErrorlabel.AutoSize = true;
               this.TestConnectionErrorlabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.TestConnectionErrorlabel.ForeColor = System.Drawing.Color.Red;
               this.TestConnectionErrorlabel.Location = new System.Drawing.Point(16, 265);
               this.TestConnectionErrorlabel.Name = "TestConnectionErrorlabel";
               this.TestConnectionErrorlabel.Size = new System.Drawing.Size(2, 15);
               this.TestConnectionErrorlabel.TabIndex = 36;
               // 
               // SaveConnectionSettingsButton
               // 
               this.SaveConnectionSettingsButton.Location = new System.Drawing.Point(16, 156);
               this.SaveConnectionSettingsButton.Name = "SaveConnectionSettingsButton";
               this.SaveConnectionSettingsButton.Size = new System.Drawing.Size(87, 23);
               this.SaveConnectionSettingsButton.TabIndex = 34;
               this.SaveConnectionSettingsButton.Text = "Save Settings";
               this.SaveConnectionSettingsButton.UseVisualStyleBackColor = true;
               this.SaveConnectionSettingsButton.Click += new System.EventHandler(this.SaveConnectionSettingsButton_Click);
               // 
               // Storelabel
               // 
               this.Storelabel.AutoSize = true;
               this.Storelabel.Location = new System.Drawing.Point(13, 16);
               this.Storelabel.Name = "Storelabel";
               this.Storelabel.Size = new System.Drawing.Size(49, 13);
               this.Storelabel.TabIndex = 25;
               this.Storelabel.Text = "Store ID:";
               // 
               // Passwordlabel
               // 
               this.Passwordlabel.AutoSize = true;
               this.Passwordlabel.Location = new System.Drawing.Point(13, 56);
               this.Passwordlabel.Name = "Passwordlabel";
               this.Passwordlabel.Size = new System.Drawing.Size(56, 13);
               this.Passwordlabel.TabIndex = 27;
               this.Passwordlabel.Text = "Password:";
               // 
               // TestConnectionButton
               // 
               this.TestConnectionButton.Location = new System.Drawing.Point(16, 210);
               this.TestConnectionButton.Name = "TestConnectionButton";
               this.TestConnectionButton.Size = new System.Drawing.Size(102, 23);
               this.TestConnectionButton.TabIndex = 24;
               this.TestConnectionButton.Text = "Test Connection";
               this.TestConnectionButton.UseVisualStyleBackColor = true;
               this.TestConnectionButton.Click += new System.EventHandler(this.TestConnectionButton_Click);
               // 
               // MainTabControl
               // 
               this.MainTabControl.Controls.Add(this.ConnectionTab);
               this.MainTabControl.Controls.Add(this.DatabasesTab);
               this.MainTabControl.Controls.Add(this.POTab);
               this.MainTabControl.Controls.Add(this.InvoicesTab);
               this.MainTabControl.Location = new System.Drawing.Point(28, 26);
               this.MainTabControl.Name = "MainTabControl";
               this.MainTabControl.SelectedIndex = 0;
               this.MainTabControl.Size = new System.Drawing.Size(893, 710);
               this.MainTabControl.TabIndex = 39;
               // 
               // POTab
               // 
               this.POTab.Controls.Add(this.panel2);
               this.POTab.Location = new System.Drawing.Point(4, 22);
               this.POTab.Name = "POTab";
               this.POTab.Padding = new System.Windows.Forms.Padding(3);
               this.POTab.Size = new System.Drawing.Size(885, 684);
               this.POTab.TabIndex = 3;
               this.POTab.Text = "Purchase Orders";
               this.POTab.UseVisualStyleBackColor = true;
               // 
               // panel2
               // 
               this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.panel2.Controls.Add(this.OrdersRadioListBox);
               this.panel2.Controls.Add(this.OrderTextBox);
               this.panel2.Controls.Add(this.DateLabel);
               this.panel2.Controls.Add(this.PODateTimePicker);
               this.panel2.Controls.Add(this.SendOrdersButton);
               this.panel2.Controls.Add(this.SendOrdersErrorLabel);
               this.panel2.Controls.Add(this.label9);
               this.panel2.Location = new System.Drawing.Point(29, 28);
               this.panel2.Name = "panel2";
               this.panel2.Size = new System.Drawing.Size(850, 650);
               this.panel2.TabIndex = 46;
               // 
               // OrdersRadioListBox
               // 
               this.OrdersRadioListBox.BackColor = System.Drawing.SystemColors.Window;
               this.OrdersRadioListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
               this.OrdersRadioListBox.FormattingEnabled = true;
               this.OrdersRadioListBox.Location = new System.Drawing.Point(28, 97);
               this.OrdersRadioListBox.Name = "OrdersRadioListBox";
               this.OrdersRadioListBox.Size = new System.Drawing.Size(343, 277);
               this.OrdersRadioListBox.TabIndex = 51;
               this.OrdersRadioListBox.SelectedIndexChanged += new System.EventHandler(this.OrdersRadioListBox_SelectedIndexChanged);
               // 
               // OrderTextBox
               // 
               this.OrderTextBox.Location = new System.Drawing.Point(389, 19);
               this.OrderTextBox.Multiline = true;
               this.OrderTextBox.Name = "OrderTextBox";
               this.OrderTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
               this.OrderTextBox.Size = new System.Drawing.Size(456, 552);
               this.OrderTextBox.TabIndex = 50;
               // 
               // DateLabel
               // 
               this.DateLabel.AutoSize = true;
               this.DateLabel.Location = new System.Drawing.Point(25, 66);
               this.DateLabel.Name = "DateLabel";
               this.DateLabel.Size = new System.Drawing.Size(64, 13);
               this.DateLabel.TabIndex = 44;
               this.DateLabel.Text = "Orders Date";
               // 
               // PODateTimePicker
               // 
               this.PODateTimePicker.Location = new System.Drawing.Point(171, 59);
               this.PODateTimePicker.Name = "PODateTimePicker";
               this.PODateTimePicker.Size = new System.Drawing.Size(200, 20);
               this.PODateTimePicker.TabIndex = 43;
               this.PODateTimePicker.ValueChanged += new System.EventHandler(this.PODateTimePicker_ValueChanged);
               // 
               // SendOrdersButton
               // 
               this.SendOrdersButton.Location = new System.Drawing.Point(28, 387);
               this.SendOrdersButton.Name = "SendOrdersButton";
               this.SendOrdersButton.Size = new System.Drawing.Size(139, 38);
               this.SendOrdersButton.TabIndex = 1;
               this.SendOrdersButton.Text = "Send Purchase Orders to HealthStop";
               this.SendOrdersButton.UseVisualStyleBackColor = true;
               this.SendOrdersButton.Click += new System.EventHandler(this.SendOrdersButton_Click);
               // 
               // SendOrdersErrorLabel
               // 
               this.SendOrdersErrorLabel.AutoSize = true;
               this.SendOrdersErrorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.SendOrdersErrorLabel.ForeColor = System.Drawing.Color.Red;
               this.SendOrdersErrorLabel.Location = new System.Drawing.Point(28, 442);
               this.SendOrdersErrorLabel.Name = "SendOrdersErrorLabel";
               this.SendOrdersErrorLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
               this.SendOrdersErrorLabel.Size = new System.Drawing.Size(12, 15);
               this.SendOrdersErrorLabel.TabIndex = 42;
               // 
               // label9
               // 
               this.label9.AutoSize = true;
               this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label9.Location = new System.Drawing.Point(24, 19);
               this.label9.Name = "label9";
               this.label9.Size = new System.Drawing.Size(153, 24);
               this.label9.TabIndex = 0;
               this.label9.Text = "Purchase Orders";
               // 
               // InvoicesTab
               // 
               this.InvoicesTab.Controls.Add(this.AvailableInvoicesRadioListBox);
               this.InvoicesTab.Controls.Add(this.InvoicesTextBox);
               this.InvoicesTab.Controls.Add(this.GetInvoicesButton);
               this.InvoicesTab.Controls.Add(this.CommitInvoicesErrorLabel);
               this.InvoicesTab.Controls.Add(this.UpdateRRPCheckBox);
               this.InvoicesTab.Controls.Add(this.CommitInvoicesButton);
               this.InvoicesTab.Controls.Add(this.GetInvoicesErrorLabel);
               this.InvoicesTab.Location = new System.Drawing.Point(4, 22);
               this.InvoicesTab.Name = "InvoicesTab";
               this.InvoicesTab.Padding = new System.Windows.Forms.Padding(3);
               this.InvoicesTab.Size = new System.Drawing.Size(885, 684);
               this.InvoicesTab.TabIndex = 4;
               this.InvoicesTab.Text = "Invoices";
               this.InvoicesTab.UseVisualStyleBackColor = true;
               // 
               // AvailableInvoicesRadioListBox
               // 
               this.AvailableInvoicesRadioListBox.BackColor = System.Drawing.SystemColors.Window;
               this.AvailableInvoicesRadioListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
               this.AvailableInvoicesRadioListBox.FormattingEnabled = true;
               this.AvailableInvoicesRadioListBox.Location = new System.Drawing.Point(16, 94);
               this.AvailableInvoicesRadioListBox.Name = "AvailableInvoicesRadioListBox";
               this.AvailableInvoicesRadioListBox.Size = new System.Drawing.Size(293, 277);
               this.AvailableInvoicesRadioListBox.TabIndex = 50;
               this.AvailableInvoicesRadioListBox.SelectedIndexChanged += new System.EventHandler(this.AvailableInvoicesRadioListBox_SelectedIndexChanged);
               // 
               // InvoicesTextBox
               // 
               this.InvoicesTextBox.Location = new System.Drawing.Point(315, 94);
               this.InvoicesTextBox.Multiline = true;
               this.InvoicesTextBox.Name = "InvoicesTextBox";
               this.InvoicesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
               this.InvoicesTextBox.Size = new System.Drawing.Size(551, 552);
               this.InvoicesTextBox.TabIndex = 49;
               // 
               // GetInvoicesButton
               // 
               this.GetInvoicesButton.Location = new System.Drawing.Point(16, 24);
               this.GetInvoicesButton.Name = "GetInvoicesButton";
               this.GetInvoicesButton.Size = new System.Drawing.Size(157, 38);
               this.GetInvoicesButton.TabIndex = 48;
               this.GetInvoicesButton.Text = "1. Get Invoices Available at HealthStop";
               this.GetInvoicesButton.UseVisualStyleBackColor = true;
               this.GetInvoicesButton.Click += new System.EventHandler(this.SeeInvoicesButton_Click);
               // 
               // CommitInvoicesErrorLabel
               // 
               this.CommitInvoicesErrorLabel.AutoSize = true;
               this.CommitInvoicesErrorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.CommitInvoicesErrorLabel.ForeColor = System.Drawing.Color.Red;
               this.CommitInvoicesErrorLabel.Location = new System.Drawing.Point(16, 472);
               this.CommitInvoicesErrorLabel.Name = "CommitInvoicesErrorLabel";
               this.CommitInvoicesErrorLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
               this.CommitInvoicesErrorLabel.Size = new System.Drawing.Size(12, 15);
               this.CommitInvoicesErrorLabel.TabIndex = 46;
               // 
               // UpdateRRPCheckBox
               // 
               this.UpdateRRPCheckBox.AutoSize = true;
               this.UpdateRRPCheckBox.Checked = true;
               this.UpdateRRPCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
               this.UpdateRRPCheckBox.Location = new System.Drawing.Point(202, 429);
               this.UpdateRRPCheckBox.Name = "UpdateRRPCheckBox";
               this.UpdateRRPCheckBox.Size = new System.Drawing.Size(93, 17);
               this.UpdateRRPCheckBox.TabIndex = 45;
               this.UpdateRRPCheckBox.Text = "Update RRP?";
               this.UpdateRRPCheckBox.UseVisualStyleBackColor = true;
               // 
               // CommitInvoicesButton
               // 
               this.CommitInvoicesButton.Location = new System.Drawing.Point(16, 417);
               this.CommitInvoicesButton.Name = "CommitInvoicesButton";
               this.CommitInvoicesButton.Size = new System.Drawing.Size(157, 38);
               this.CommitInvoicesButton.TabIndex = 43;
               this.CommitInvoicesButton.Text = "2. Commit Selected Invoice to POS Database";
               this.CommitInvoicesButton.UseVisualStyleBackColor = true;
               this.CommitInvoicesButton.Click += new System.EventHandler(this.CommitInvoicesButton_Click);
               // 
               // GetInvoicesErrorLabel
               // 
               this.GetInvoicesErrorLabel.AutoSize = true;
               this.GetInvoicesErrorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.GetInvoicesErrorLabel.ForeColor = System.Drawing.Color.Red;
               this.GetInvoicesErrorLabel.Location = new System.Drawing.Point(186, 37);
               this.GetInvoicesErrorLabel.Name = "GetInvoicesErrorLabel";
               this.GetInvoicesErrorLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
               this.GetInvoicesErrorLabel.Size = new System.Drawing.Size(12, 15);
               this.GetInvoicesErrorLabel.TabIndex = 42;
               // 
               // GetPurchaseOrdersButton
               // 
               this.GetPurchaseOrdersButton.Location = new System.Drawing.Point(0, 0);
               this.GetPurchaseOrdersButton.Name = "GetPurchaseOrdersButton";
               this.GetPurchaseOrdersButton.Size = new System.Drawing.Size(75, 23);
               this.GetPurchaseOrdersButton.TabIndex = 0;
               // 
               // GetPurchaseOrdersErrorLabel
               // 
               this.GetPurchaseOrdersErrorLabel.Location = new System.Drawing.Point(0, 0);
               this.GetPurchaseOrdersErrorLabel.Name = "GetPurchaseOrdersErrorLabel";
               this.GetPurchaseOrdersErrorLabel.Size = new System.Drawing.Size(100, 23);
               this.GetPurchaseOrdersErrorLabel.TabIndex = 0;
               // 
               // WritePurchaseOrdersButton
               // 
               this.WritePurchaseOrdersButton.Location = new System.Drawing.Point(0, 0);
               this.WritePurchaseOrdersButton.Name = "WritePurchaseOrdersButton";
               this.WritePurchaseOrdersButton.Size = new System.Drawing.Size(75, 23);
               this.WritePurchaseOrdersButton.TabIndex = 0;
               // 
               // WritePurchaseOrdersErrorLabel
               // 
               this.WritePurchaseOrdersErrorLabel.Location = new System.Drawing.Point(0, 0);
               this.WritePurchaseOrdersErrorLabel.Name = "WritePurchaseOrdersErrorLabel";
               this.WritePurchaseOrdersErrorLabel.Size = new System.Drawing.Size(100, 23);
               this.WritePurchaseOrdersErrorLabel.TabIndex = 0;
               // 
               // GetStocktakeItemsButton
               // 
               this.GetStocktakeItemsButton.Location = new System.Drawing.Point(0, 0);
               this.GetStocktakeItemsButton.Name = "GetStocktakeItemsButton";
               this.GetStocktakeItemsButton.Size = new System.Drawing.Size(75, 23);
               this.GetStocktakeItemsButton.TabIndex = 0;
               // 
               // GetStocktakeItemsErrorLabel
               // 
               this.GetStocktakeItemsErrorLabel.Location = new System.Drawing.Point(0, 0);
               this.GetStocktakeItemsErrorLabel.Name = "GetStocktakeItemsErrorLabel";
               this.GetStocktakeItemsErrorLabel.Size = new System.Drawing.Size(100, 23);
               this.GetStocktakeItemsErrorLabel.TabIndex = 0;
               // 
               // CommitStocktakeButton
               // 
               this.CommitStocktakeButton.Location = new System.Drawing.Point(0, 0);
               this.CommitStocktakeButton.Name = "CommitStocktakeButton";
               this.CommitStocktakeButton.Size = new System.Drawing.Size(75, 23);
               this.CommitStocktakeButton.TabIndex = 0;
               // 
               // WebServiceTextBox
               // 
               this.WebServiceTextBox.Location = new System.Drawing.Point(108, 99);
               this.WebServiceTextBox.Name = "WebServiceTextBox";
               this.WebServiceTextBox.Size = new System.Drawing.Size(386, 20);
               this.WebServiceTextBox.TabIndex = 40;
               // 
               // ServiceLabel
               // 
               this.ServiceLabel.AutoSize = true;
               this.ServiceLabel.Location = new System.Drawing.Point(13, 102);
               this.ServiceLabel.Name = "ServiceLabel";
               this.ServiceLabel.Size = new System.Drawing.Size(69, 13);
               this.ServiceLabel.TabIndex = 39;
               this.ServiceLabel.Text = "WebService:";
               // 
               // FormMain
               // 
               this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
               this.ClientSize = new System.Drawing.Size(1554, 866);
               this.Controls.Add(this.MainTabControl);
               this.Controls.Add(this.lbLog);
               this.Name = "FormMain";
               this.Text = "HealthStop POS Client";
               this.DatabasesTab.ResumeLayout(false);
               this.DatabasesTab.PerformLayout();
               this.POSSoftwareSplitContainer.Panel1.ResumeLayout(false);
               this.POSSoftwareSplitContainer.Panel1.PerformLayout();
               this.POSSoftwareSplitContainer.Panel2.ResumeLayout(false);
               this.POSSoftwareSplitContainer.Panel2.PerformLayout();
               ((System.ComponentModel.ISupportInitialize)(this.POSSoftwareSplitContainer)).EndInit();
               this.POSSoftwareSplitContainer.ResumeLayout(false);
               this.POSSoftwareGroupBox.ResumeLayout(false);
               this.POSSoftwareGroupBox.PerformLayout();
               this.ConnectionTab.ResumeLayout(false);
               this.ConnectionTab.PerformLayout();
               this.MainTabControl.ResumeLayout(false);
               this.POTab.ResumeLayout(false);
               this.panel2.ResumeLayout(false);
               this.panel2.PerformLayout();
               this.InvoicesTab.ResumeLayout(false);
               this.InvoicesTab.PerformLayout();
               this.ResumeLayout(false);
               this.PerformLayout();

		}
		#endregion

          #region Temp Storage

          private LocalInvoice[] tempInvoices;
          private List<LocalPurchaseOrder> tempOrders;

          #endregion



          /// <summary>
		/// The main entry point for the application.
		/// </summary>
		
		[STAThread]
		static void Main() 
		{
            try
            {
                Application.Run(new FormMain());
            }
            catch (Exception ex)
            {
                bool flag = false;
            }
		}

		public void AddLog(string entry, bool writeToFile)
		{
			DateTime dt = DateTime.Now;
			lbLog.AppendText("[" + dt.ToLongDateString() + " " + dt.ToLongTimeString() + "] " + entry + "\r\n");

			try
			{

				if (writeToFile)
				{
					string logentry = dt.ToLongDateString() + " " + dt.ToLongTimeString() + "\t" + entry + "\r\n";

					string path = System.Environment.CurrentDirectory + "\\log.txt";

					if (!File.Exists(path))
					{
						// Create a reference to a file.
						FileInfo fi = new FileInfo(path);
						// Actually create the file.
						FileStream fs = fi.Create();
						// Modify the file as required, and then close the file.
						fs.Close();
					}

					File.AppendAllText(path, logentry);
				}
			}
			catch (Exception ex)
			{
				lbLog.AppendText("[" + dt.ToLongDateString() + " " + dt.ToLongTimeString() + "] " + ex.ToString() + "\r\n");
			}

		}


		
		public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
				
			//Load Connection settings
			StoreIDtextBox.Text = Properties.Settings.Default.store_id;
			PasswordTextBox.Text = Properties.Settings.Default.password;
               WebServiceTextBox.Text = Properties.Settings.Default.WebService;


			

			if (Properties.Settings.Default.POSSoftware == "MYOB")
			{
				MYOBRadioButton.Checked = true;
				MicrosoftRMSRadioButton.Checked = false;
				ToggleSoftwarePanels(true);

				RMDBTextBox.Text = Properties.Settings.Default.RMDBLocation;
			}
			else if (Properties.Settings.Default.POSSoftware == "Microsoft")
			{
				MYOBRadioButton.Checked = false;
				MicrosoftRMSRadioButton.Checked = true;
				ToggleSoftwarePanels(false);

				MicrosoftLocationTextBox.Text = Properties.Settings.Default.POSServerLocation;
				MicrosoftDBTextBox.Text = Properties.Settings.Default.POSServerDBName;
				MicrosoftUserTextBox.Text = Properties.Settings.Default.POSServerUser;
				MicrosoftPasswordTextBox.Text = Properties.Settings.Default.POSServerPassword;
			}
		}

         	
		#region Button Events
	        
		private void ClearErrorMessages()
		{
			ConnectionErrorlabel.Text = "";
			TestConnectionErrorlabel.Text = "";
			
			TestMicrosoftConnectionErrorLabel.Text = "";
			DatabaseSettingsErrorLabel.Text = "";
			


               SendOrdersErrorLabel.Text = "";
               GetInvoicesErrorLabel.Text = "";
               CommitInvoicesErrorLabel.Text = "";

               
		}		

		private void SaveConnectionSettingsButton_Click(object sender, EventArgs e)
		   {
			  ClearErrorMessages();
			  string error_message = "";
			  bool is_valid = true;

			  if(StoreIDtextBox.Text == "")
			  {
				 error_message = "Please enter the store ID from the website.";
				 is_valid = false;
			  }
			  else if(PasswordTextBox.Text == "")
			  {
				 error_message = "Please enter the password for the store ID from the website.";
				 is_valid = false;
			  }
                 else if (WebServiceTextBox.Text == "")
                 {
                      error_message = "Please enter URL of the webservice";
                      is_valid = false;
                 }
	            
			  try
			  {
				 if (is_valid)
				 {
	                    
					Properties.Settings.Default.store_id = StoreIDtextBox.Text;
					Properties.Settings.Default.password = PasswordTextBox.Text;
                         Properties.Settings.Default.WebService = WebServiceTextBox.Text;	
	                   
					Properties.Settings.Default.Save();
					ConnectionErrorlabel.Text = "Settings saved successfully";
				 }
				 else
				 {
					ConnectionErrorlabel.Text = error_message;
				 }
			  }
			  catch (Exception ex)
			  {
				 ConnectionErrorlabel.Text = ex.ToString();
			  }
		}		


		private void SaveDatabaseSettingsButton_Click(object sender, EventArgs e)
		{
			ClearErrorMessages();
			string error_message = "";
			bool is_valid = false;

			if (MYOBRadioButton.Checked)
			{
				if (String.IsNullOrEmpty(RMDBTextBox.Text))
				{
					error_message = "Please enter the location of the Retail Manager database.";

				}
                    else if (!MYOB.TestRMDBConnection(RMDBTextBox.Text))
                    {
                         error_message = "Incorrect Retail Manager Database";
                    }
                    else
                    {
                         is_valid = true;
                         Properties.Settings.Default.RMDBLocation = RMDBTextBox.Text;
                         Properties.Settings.Default.POSSoftware = "MYOB";
                    }
			}
			else if (MicrosoftRMSRadioButton.Checked)
			{
				if (String.IsNullOrEmpty(MicrosoftLocationTextBox.Text))
				{
					error_message = "Please enter the location of the Microsoft RMS server.";
				}
				else if (String.IsNullOrEmpty(MicrosoftDBTextBox.Text))
				{
					error_message = "Please enter the name of the Microsoft RMS database.";
				}
				else if (String.IsNullOrEmpty(MicrosoftUserTextBox.Text))
				{
					error_message = "Please enter the user name to connect to the Microsoft RMS database.";
				}
				else if (String.IsNullOrEmpty(MicrosoftPasswordTextBox.Text))
				{
					error_message = "Please enter the password to connect to the Microsoft RMS database.";
				}
				else
				{
					is_valid = true;
					Properties.Settings.Default.POSSoftware = "Microsoft";
					Properties.Settings.Default.POSServerLocation = MicrosoftLocationTextBox.Text;
					Properties.Settings.Default.POSServerDBName = MicrosoftDBTextBox.Text;
					Properties.Settings.Default.POSServerUser = MicrosoftUserTextBox.Text;
					Properties.Settings.Default.POSServerPassword = MicrosoftPasswordTextBox.Text;
				}                    
			}

			

			try
			{
				if (is_valid)
				{
					Properties.Settings.Default.Save();
					DatabaseSettingsErrorLabel.Text = "Settings saved successfully";
				}
				else
				{
					DatabaseSettingsErrorLabel.Text = error_message;
				}
			}
			catch (Exception ex)
			{
				DatabaseSettingsErrorLabel.Text = ex.ToString();
			}
		}

		private void TestConnectionButton_Click(object sender, EventArgs e)
		{
			ClearErrorMessages();
			try
			{
                    var webService = new POSWebService();
                    webService.Url = WebServiceTextBox.Text;
				OrderResponse newResponse = webService.TestConnection(Convert.ToInt32(StoreIDtextBox.Text), PasswordTextBox.Text);

				if (newResponse.is_error)
				{
					AddLog(newResponse.errorMessage, true);					
				}
				else
				{
					ConnectionErrorlabel.Text = "Connection is solid";
				}
			}		
			catch (System.Net.WebException ex)
			{
				ConnectionErrorlabel.Text = "No internet connection";
			}			
		}

	
		

	
		private void MYOBRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (MYOBRadioButton.Checked)
			{
				ToggleSoftwarePanels(true);                    
			}
		}

		private void MicrosoftRMSRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (MicrosoftRMSRadioButton.Checked)
			{
				ToggleSoftwarePanels(false);                    
			}
		}

		private void ToggleSoftwarePanels(bool MYOBPicked)
		{
			POSSoftwareSplitContainer.Panel1Collapsed = !MYOBPicked;
			POSSoftwareSplitContainer.Panel2Collapsed = MYOBPicked;
		}

		private void MicrosoftTestConnectionButton_Click(object sender, EventArgs e)
		{
			ClearErrorMessages();
			if (TestSQLConnection(MicrosoftLocationTextBox.Text, MicrosoftDBTextBox.Text, MicrosoftUserTextBox.Text, MicrosoftPasswordTextBox.Text))
			{
				TestMicrosoftConnectionErrorLabel.Text = "Connection is solid";
			}
			else
			{
				TestMicrosoftConnectionErrorLabel.Text = "Error connecting to SQL Server.";
			}
		}


	

		private bool TestSQLConnection(string location, string DBname, string user, string password)
		{
               ClearErrorMessages();
			string connectionString = MicrosoftRMS.MakeConnectionString(location, DBname, user, password);
			SqlConnection conn = new SqlConnection(connectionString);

			try
			{
				conn.Open();
				return true;
			}
			catch (Exception ex)
			{
				lbLog.AppendText(ex.ToString() + "\r\n");
				return false;
			}
			finally
			{
				conn.Close();
			}
		}

		private void FindRMDBbutton_Click(object sender, EventArgs e)
		{
               ClearErrorMessages();
			if (RMOpenFileDialog.ShowDialog() == DialogResult.OK)
			{
				string fileName = RMOpenFileDialog.FileName;
				RMDBTextBox.Text = fileName;
			}
		}     

      

		#endregion        

          private void SendOrdersButton_Click(object sender, EventArgs e)
          {
               ClearErrorMessages();

               if (OrdersRadioListBox.Items.Count <= 0)
               {
                    SendOrdersErrorLabel.Text = "No purchase orders available";
               }
               else
               {

                    Cursor.Current = Cursors.WaitCursor;

                    // Initializes the variables to pass to the MessageBox.Show method.

                    string message = "Are you sure ? This action will send the latest Purchase Orders to HealthStop and submit them to your registered suppliers";
                    string caption = "Confirm ";

                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                         if (!MYOB.TestRMDBConnection(RMDBTextBox.Text))
                         {
                              GetPurchaseOrdersErrorLabel.Text = "Error see log";
                              AddLog("Unable to connect to  the Retail Manager database", true);
                         }
                         else
                         {
                              try
                              {
                                   //Check if all fields are filled.
                                   if ((StoreIDtextBox.Text == "") || (PasswordTextBox.Text == ""))
                                   {
                                        GetPurchaseOrdersErrorLabel.Text = "Store ID or Password are empty";
                                        return;
                                   }

                                   int storeID = Convert.ToInt32(StoreIDtextBox.Text);




                                   if (tempOrders.Count > 0)
                                   {
                                        AddLog(tempOrders.Count + " Orders to send", false);
                                        POSWebService handler = new POSWebService();
                                        handler.Url = WebServiceTextBox.Text;

                                        OrderResponse newResponse = handler.UploadPurchaseOrders(storeID, PasswordTextBox.Text, tempOrders.ToArray());

                                        AddLog(newResponse.statusMessage.Replace("\n", "\r\n"), true);


                                        if (newResponse.is_error)
                                        {
                                             AddLog(newResponse.errorMessage.Replace("\n", "\r\n"), true);
                                             SendOrdersErrorLabel.Text = "Error sending Purchase Orders. See log to the right";
                                        }
                                   }
                              }
                              catch (Exception ex)
                              {
                                   AddLog(ex.ToString(), true);
                                   SendOrdersErrorLabel.Text = "An error has occurred. See log";
                              }
                         }
                    }
               }
          }

          private void PODateTimePicker_ValueChanged(object sender, EventArgs e)
          {
               OrdersRadioListBox.Items.Clear();
               DateTime ordersDate = PODateTimePicker.Value.Date;

               var orders = new List<KeyValuePair<int,string>>();
               try
               {
                    switch (Properties.Settings.Default.POSSoftware)
                    {
                         case "MYOB":
                              orders = MYOB.GetLatestPurchaseOrders(ordersDate);                              
                              tempOrders = MYOB.GetSelectedPurchaseOrders(orders.Select(p=>p.Key).ToList());
                              break;
                         case "Microsoft":
                              orders = MicrosoftRMS.GetLatestPurchaseOrders(ordersDate);
                              break;
                    }

                    foreach (var item in orders)
                    {
                         OrdersRadioListBox.Items.Add(item);                        
                    }
               }
               catch (Exception ex)
               {
                    AddLog(ex.ToString(), false);
               }

          }

          private void DisplayPurchaseOrder(LocalPurchaseOrder order, string supplierName)
          {
               OrderTextBox.Text = "";
               string display = "";

               display += "Supplier:\t" + supplierName + "\r\n\r\n";
               display += "Purchase Order:\t" + order.local_code + "\r\n\r\n";

               
               display += "Placed On:\t" + order.order_datetime.ToLongDateString() + "\r\n";
               display += "Order Due:\t" + order.due_datetime.ToLongDateString() + "\r\n\r\n";

               display += "Barcode\t\tQuantity\tDescripition\r\n\r\n";

               foreach (var item in order.itemList)
               {                    
                    display += item.barcode + "\t" + item.quantity + "\t" + item.description + "\r\n";
               }

               display += "\r\n\r\n\r\n\r\n";
               OrderTextBox.Text = display;
          }

          private LocalPurchaseOrder GetSelectedPurchaseOrder()
          {
               KeyValuePair<int, string> item = (KeyValuePair<int, string>)OrdersRadioListBox.SelectedItem;
               LocalPurchaseOrder order = new LocalPurchaseOrder();
               switch (Properties.Settings.Default.POSSoftware)
               {
                    case "MYOB":
                         order = MYOB.GetPurchaseOrderByID(item.Key);
                         break;
                    case "Microsoft":                       
                         break;
               }
               return order;
          }


          private void OrdersRadioListBox_SelectedIndexChanged(object sender, EventArgs e)
          {
               KeyValuePair<int, string> item = (KeyValuePair<int, string>)OrdersRadioListBox.SelectedItem;
               DisplayPurchaseOrder(GetSelectedPurchaseOrder(), item.Value);
          }    
        

          private void SeeInvoicesButton_Click(object sender, EventArgs e)
          {    
               tempInvoices = null;
               try
               {
                    //Check if all fields are filled.
                    if ((StoreIDtextBox.Text == "") || (PasswordTextBox.Text == ""))
                    {
                         GetInvoicesErrorLabel.Text = "Store ID or Password are empty";
                         return;
                    }

                    int storeID = Convert.ToInt32(StoreIDtextBox.Text);

                   
                    POSWebService handler = new POSWebService();
                    handler.Url = WebServiceTextBox.Text;

                    OrderResponse newResponse = handler.DownloadInvoices(storeID,PasswordTextBox.Text);

                    if (!newResponse.is_error)
                    {
                         AddLog(newResponse.statusMessage.Replace("\n","\r\n"), true);

                         tempInvoices = newResponse.localInvoices;

                         if (newResponse.localInvoices != null)
                         {
                              PopulateInvoices();
                         }
                    }
                    else
                    {                                       
                         AddLog(newResponse.errorMessage.Replace("\n", "\r\n"), true);
                         SendOrdersErrorLabel.Text = "Error sending Purchase Orders. See log to the right";
                    }
                 
               }
               catch (Exception ex)
               {
                    AddLog(ex.ToString(), true);
                    GetPurchaseOrdersErrorLabel.Text = "An error has occurred. See log";
               }
          }

          private void PopulateInvoices()
          {              
               AvailableInvoicesRadioListBox.Items.Clear();
               InvoicesTextBox.Text = "";
               foreach (var item in tempInvoices)
               {
                    AvailableInvoicesRadioListBox.Items.Add(new KeyValuePair<int, string>(item.invoice_id, item.supplierName + " " + item.itemList.Count() + " Items"));
               }
          }

          private void DisplayInvoice(LocalInvoice invoice)
          {
               InvoicesTextBox.Text = "";
               string display = "";

               display += "Healthstop Invoice Number:\t" + invoice.invoice_id.ToString() + "\r\n\r\n";
               display += "Supplier:\t\t\t" + invoice.supplierName + "\r\n\r\n";
               display += "Supplier Invoice Number:\t" + invoice.supplier_code + "\r\n\r\n";

               display += "Purchase Order:\t\t" + invoice.purchaseorder_code + "\r\n\r\n";
               display += "Freight:\t\t\t$" + invoice.freight_inc.ToString("#.00") + "\r\n";
               display += "Tax:\t\t\t$" + invoice.tax.ToString("#.00") + "\r\n";
               display += "Total:\t\t\t$" + invoice.total_inc.ToString("#.00") + "\r\n\r\n";
               display += "Barcode\t\tGST\tRRP\tQuantity\tCostEx\tDescripition\r\n\r\n";

               foreach (var item in invoice.itemList)
               {
                    string gst = item.isGST ? "GST" : "FRE";                    

                    display += item.barcode + "\t" + gst + "\t" + item.RRP.ToString("#0.00") + "\t" + item.quantity + "\t" + item.cost_ex.ToString("#0.00") + "\t" + item.description + "\r\n";
               }

               display += "\r\n\r\n\r\n\r\n";            
               InvoicesTextBox.Text += display;
          }

          private void CommitInvoicesButton_Click(object sender, EventArgs e)
          {
               if (AvailableInvoicesRadioListBox.Items.Count <= 0)
               {
                    CommitInvoicesErrorLabel.Text = "No invoices available";
               }
               else
               {

                    Cursor.Current = Cursors.WaitCursor;


                    KeyValuePair<int, string> item = (KeyValuePair<int, string>)AvailableInvoicesRadioListBox.SelectedItem;
                    var selectedInvoice = tempInvoices.Where(i => i.invoice_id == item.Key).First();

                    bool updateRRP = UpdateRRPCheckBox.Checked;

                    AddLog("Committing Invoice #:" + selectedInvoice.invoice_id.ToString(), true);

                    try
                    {
                         switch (Properties.Settings.Default.POSSoftware)
                         {
                              case "MYOB":

                                   AddLog(MYOB.CommitInvoice(selectedInvoice, updateRRP), true);

                                   break;
                              case "Microsoft":

                                   break;
                         }
                         AddLog("Invoice committed successfully", true);


                         //Check if all fields are filled.
                         if ((StoreIDtextBox.Text == "") || (PasswordTextBox.Text == ""))
                         {
                              CommitInvoicesErrorLabel.Text = "Store ID or Password are empty";
                              return;
                         }

                         int storeID = Convert.ToInt32(StoreIDtextBox.Text);

                         POSWebService handler = new POSWebService();
                         handler.Url = WebServiceTextBox.Text;
                         OrderResponse newResponse = handler.MarkInvoiceAsDownloaded(storeID, PasswordTextBox.Text, selectedInvoice.invoice_id);

                         if (!newResponse.is_error)
                         {
                              AddLog(newResponse.statusMessage.Replace("\n", "\r\n"), true);
                         }
                         else
                         {
                              AddLog(newResponse.errorMessage.Replace("\n", "\r\n"), true);
                              CommitInvoicesErrorLabel.Text = "Error updating Invoice.See log to the right";
                         }

                         tempInvoices = tempInvoices.Where(i => i.invoice_id != selectedInvoice.invoice_id).ToArray();
                         PopulateInvoices();
                    }
                    catch (Exception ex)
                    {
                         AddLog(ex.Message, true);
                         CommitInvoicesErrorLabel.Text = "An error has occurred. See log";
                    }

                    Cursor.Current = Cursors.Default;
               }
          }

          private void AvailableInvoicesRadioListBox_SelectedIndexChanged(object sender, EventArgs e)
          {
               KeyValuePair<int, string> item = (KeyValuePair<int, string>) AvailableInvoicesRadioListBox.SelectedItem;

               DisplayInvoice(tempInvoices.Where(i=>i.invoice_id == item.Key).First());
          }
      
	}	
}		