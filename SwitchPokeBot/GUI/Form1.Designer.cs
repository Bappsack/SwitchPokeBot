using System;
using System.Windows.Forms;

namespace SwitchPokeBot
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.Slot_SupriseTrade = new MetroFramework.Controls.MetroComboBox();
            this.btn_stop_Suprise = new MetroFramework.Controls.MetroButton();
            this.btn_Start_Suprise = new MetroFramework.Controls.MetroButton();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.btn_stop_link = new MetroFramework.Controls.MetroButton();
            this.btn_start_link = new MetroFramework.Controls.MetroButton();
            this.metroPanel6 = new MetroFramework.Controls.MetroPanel();
            this.LinkCodeBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.reconnectAfter_combo = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.showPokemon = new MetroFramework.Controls.MetroCheckBox();
            this.UseSync = new MetroFramework.Controls.MetroCheckBox();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel5 = new MetroFramework.Controls.MetroPanel();
            this.btn_clearLog = new MetroFramework.Controls.MetroButton();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.btn_refresh = new MetroFramework.Controls.MetroButton();
            this.comPort_select = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel7 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.slot_Link = new MetroFramework.Controls.MetroComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroTabPage4.SuspendLayout();
            this.metroPanel6.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.metroPanel5.SuspendLayout();
            this.metroPanel4.SuspendLayout();
            this.metroPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(333, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 72);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage4);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.CustomBackground = true;
            this.metroTabControl1.Location = new System.Drawing.Point(13, 141);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(419, 392);
            this.metroTabControl1.TabIndex = 1;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.metroPanel1);
            this.metroTabPage1.Controls.Add(this.btn_stop_Suprise);
            this.metroTabPage1.Controls.Add(this.btn_Start_Suprise);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(411, 353);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Suprise Trade";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.metroLabel6);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.Slot_SupriseTrade);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(3, 10);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(200, 51);
            this.metroPanel1.TabIndex = 9;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel6.Location = new System.Drawing.Point(3, 5);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(80, 15);
            this.metroLabel6.TabIndex = 9;
            this.metroLabel6.Text = "Trade Settings:";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 23);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(103, 19);
            this.metroLabel1.TabIndex = 8;
            this.metroLabel1.Text = "Start from Slot: ";
            // 
            // Slot_SupriseTrade
            // 
            this.Slot_SupriseTrade.FormattingEnabled = true;
            this.Slot_SupriseTrade.ItemHeight = 23;
            this.Slot_SupriseTrade.Location = new System.Drawing.Point(112, 15);
            this.Slot_SupriseTrade.Name = "Slot_SupriseTrade";
            this.Slot_SupriseTrade.Size = new System.Drawing.Size(74, 29);
            this.Slot_SupriseTrade.TabIndex = 8;
            // 
            // btn_stop_Suprise
            // 
            this.btn_stop_Suprise.Location = new System.Drawing.Point(231, 39);
            this.btn_stop_Suprise.Name = "btn_stop_Suprise";
            this.btn_stop_Suprise.Size = new System.Drawing.Size(177, 23);
            this.btn_stop_Suprise.TabIndex = 7;
            this.btn_stop_Suprise.Text = "Stop";
            this.btn_stop_Suprise.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // btn_Start_Suprise
            // 
            this.btn_Start_Suprise.Location = new System.Drawing.Point(231, 11);
            this.btn_Start_Suprise.Name = "btn_Start_Suprise";
            this.btn_Start_Suprise.Size = new System.Drawing.Size(177, 23);
            this.btn_Start_Suprise.TabIndex = 6;
            this.btn_Start_Suprise.Text = "Start";
            this.btn_Start_Suprise.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.Controls.Add(this.metroPanel7);
            this.metroTabPage4.Controls.Add(this.btn_stop_link);
            this.metroTabPage4.Controls.Add(this.btn_start_link);
            this.metroTabPage4.Controls.Add(this.metroPanel6);
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Size = new System.Drawing.Size(411, 353);
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "Link Trade";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            // 
            // btn_stop_link
            // 
            this.btn_stop_link.Location = new System.Drawing.Point(227, 31);
            this.btn_stop_link.Name = "btn_stop_link";
            this.btn_stop_link.Size = new System.Drawing.Size(177, 23);
            this.btn_stop_link.TabIndex = 12;
            this.btn_stop_link.Text = "Stop";
            // 
            // btn_start_link
            // 
            this.btn_start_link.Location = new System.Drawing.Point(227, 3);
            this.btn_start_link.Name = "btn_start_link";
            this.btn_start_link.Size = new System.Drawing.Size(177, 23);
            this.btn_start_link.TabIndex = 11;
            this.btn_start_link.Text = "Start";
            this.btn_start_link.Click += new System.EventHandler(this.metroButton6_Click);
            // 
            // metroPanel6
            // 
            this.metroPanel6.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel6.Controls.Add(this.LinkCodeBox);
            this.metroPanel6.Controls.Add(this.metroLabel10);
            this.metroPanel6.Controls.Add(this.metroLabel11);
            this.metroPanel6.HorizontalScrollbarBarColor = true;
            this.metroPanel6.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel6.HorizontalScrollbarSize = 10;
            this.metroPanel6.Location = new System.Drawing.Point(6, 3);
            this.metroPanel6.Name = "metroPanel6";
            this.metroPanel6.Size = new System.Drawing.Size(200, 51);
            this.metroPanel6.TabIndex = 10;
            this.metroPanel6.VerticalScrollbarBarColor = true;
            this.metroPanel6.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel6.VerticalScrollbarSize = 10;
            // 
            // LinkCodeBox
            // 
            this.LinkCodeBox.Location = new System.Drawing.Point(104, 19);
            this.LinkCodeBox.Name = "LinkCodeBox";
            this.LinkCodeBox.Size = new System.Drawing.Size(75, 23);
            this.LinkCodeBox.TabIndex = 10;
            this.LinkCodeBox.Text = "1234";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel10.Location = new System.Drawing.Point(3, 5);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(58, 15);
            this.metroLabel10.TabIndex = 9;
            this.metroLabel10.Text = "Link Code:";
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(3, 23);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(95, 19);
            this.metroLabel11.TabIndex = 8;
            this.metroLabel11.Text = "Use the Code: ";
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.metroPanel3);
            this.metroTabPage2.Controls.Add(this.metroPanel2);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(411, 353);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Settings";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            // 
            // metroPanel3
            // 
            this.metroPanel3.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel3.Controls.Add(this.metroLabel5);
            this.metroPanel3.Controls.Add(this.reconnectAfter_combo);
            this.metroPanel3.Controls.Add(this.metroLabel4);
            this.metroPanel3.Controls.Add(this.metroLabel3);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(152, 13);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(216, 81);
            this.metroPanel3.TabIndex = 9;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(167, 28);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(46, 19);
            this.metroLabel5.TabIndex = 13;
            this.metroLabel5.Text = "Trades";
            // 
            // reconnectAfter_combo
            // 
            this.reconnectAfter_combo.FormattingEnabled = true;
            this.reconnectAfter_combo.ItemHeight = 23;
            this.reconnectAfter_combo.Location = new System.Drawing.Point(102, 27);
            this.reconnectAfter_combo.Name = "reconnectAfter_combo";
            this.reconnectAfter_combo.Size = new System.Drawing.Size(61, 29);
            this.reconnectAfter_combo.TabIndex = 12;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(6, 28);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(90, 19);
            this.metroLabel4.TabIndex = 11;
            this.metroLabel4.Text = "Reconn. after:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.Location = new System.Drawing.Point(6, 5);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(105, 15);
            this.metroLabel3.TabIndex = 10;
            this.metroLabel3.Text = "Reconnect Settings:";
            // 
            // metroPanel2
            // 
            this.metroPanel2.AccessibleDescription = "";
            this.metroPanel2.AccessibleName = "";
            this.metroPanel2.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel2.Controls.Add(this.metroLabel2);
            this.metroPanel2.Controls.Add(this.showPokemon);
            this.metroPanel2.Controls.Add(this.UseSync);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(6, 13);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(130, 81);
            this.metroPanel2.TabIndex = 8;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel2.Location = new System.Drawing.Point(12, 4);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(32, 15);
            this.metroLabel2.TabIndex = 9;
            this.metroLabel2.Text = "Misc:";
            // 
            // showPokemon
            // 
            this.showPokemon.AutoSize = true;
            this.showPokemon.Location = new System.Drawing.Point(12, 55);
            this.showPokemon.Name = "showPokemon";
            this.showPokemon.Size = new System.Drawing.Size(106, 15);
            this.showPokemon.TabIndex = 8;
            this.showPokemon.Text = "Show Pokemon";
            this.showPokemon.UseVisualStyleBackColor = true;
            // 
            // UseSync
            // 
            this.UseSync.AutoSize = true;
            this.UseSync.Location = new System.Drawing.Point(12, 32);
            this.UseSync.Name = "UseSync";
            this.UseSync.Size = new System.Drawing.Size(91, 15);
            this.UseSync.TabIndex = 7;
            this.UseSync.Text = "Use Bot Sync";
            this.UseSync.UseVisualStyleBackColor = true;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.metroPanel5);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(411, 353);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Log";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            // 
            // metroPanel5
            // 
            this.metroPanel5.Controls.Add(this.btn_clearLog);
            this.metroPanel5.Controls.Add(this.LogBox);
            this.metroPanel5.Controls.Add(this.metroLabel9);
            this.metroPanel5.HorizontalScrollbarBarColor = true;
            this.metroPanel5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel5.HorizontalScrollbarSize = 10;
            this.metroPanel5.Location = new System.Drawing.Point(6, 5);
            this.metroPanel5.Name = "metroPanel5";
            this.metroPanel5.Size = new System.Drawing.Size(402, 345);
            this.metroPanel5.TabIndex = 11;
            this.metroPanel5.VerticalScrollbarBarColor = true;
            this.metroPanel5.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel5.VerticalScrollbarSize = 10;
            // 
            // btn_clearLog
            // 
            this.btn_clearLog.Location = new System.Drawing.Point(3, 308);
            this.btn_clearLog.Name = "btn_clearLog";
            this.btn_clearLog.Size = new System.Drawing.Size(396, 23);
            this.btn_clearLog.TabIndex = 12;
            this.btn_clearLog.Text = "Clear Log";
            this.btn_clearLog.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(3, 27);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(396, 275);
            this.LogBox.TabIndex = 11;
            this.LogBox.Text = "";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel9.Location = new System.Drawing.Point(3, 9);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(29, 15);
            this.metroLabel9.TabIndex = 10;
            this.metroLabel9.Text = "Log:";
            // 
            // metroPanel4
            // 
            this.metroPanel4.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel4.Controls.Add(this.metroLabel7);
            this.metroPanel4.Controls.Add(this.btn_refresh);
            this.metroPanel4.Controls.Add(this.comPort_select);
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 10;
            this.metroPanel4.Location = new System.Drawing.Point(17, 63);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(158, 68);
            this.metroPanel4.TabIndex = 6;
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 10;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel7.Location = new System.Drawing.Point(3, 5);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(108, 15);
            this.metroLabel7.TabIndex = 11;
            this.metroLabel7.Text = "COM Port Selection:";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(84, 33);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(65, 23);
            this.btn_refresh.TabIndex = 10;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // comPort_select
            // 
            this.comPort_select.FormattingEnabled = true;
            this.comPort_select.ItemHeight = 23;
            this.comPort_select.Location = new System.Drawing.Point(3, 29);
            this.comPort_select.Name = "comPort_select";
            this.comPort_select.Size = new System.Drawing.Size(74, 29);
            this.comPort_select.TabIndex = 9;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(13, 536);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(46, 19);
            this.metroLabel8.TabIndex = 10;
            this.metroLabel8.Text = "Status:";
            // 
            // metroPanel7
            // 
            this.metroPanel7.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel7.Controls.Add(this.metroLabel12);
            this.metroPanel7.Controls.Add(this.metroLabel13);
            this.metroPanel7.Controls.Add(this.slot_Link);
            this.metroPanel7.HorizontalScrollbarBarColor = true;
            this.metroPanel7.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel7.HorizontalScrollbarSize = 10;
            this.metroPanel7.Location = new System.Drawing.Point(6, 60);
            this.metroPanel7.Name = "metroPanel7";
            this.metroPanel7.Size = new System.Drawing.Size(200, 51);
            this.metroPanel7.TabIndex = 13;
            this.metroPanel7.VerticalScrollbarBarColor = true;
            this.metroPanel7.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel7.VerticalScrollbarSize = 10;
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel12.Location = new System.Drawing.Point(3, 5);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(80, 15);
            this.metroLabel12.TabIndex = 9;
            this.metroLabel12.Text = "Trade Settings:";
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Location = new System.Drawing.Point(3, 23);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(103, 19);
            this.metroLabel13.TabIndex = 8;
            this.metroLabel13.Text = "Start from Slot: ";
            // 
            // slot_Link
            // 
            this.slot_Link.FormattingEnabled = true;
            this.slot_Link.ItemHeight = 23;
            this.slot_Link.Location = new System.Drawing.Point(112, 15);
            this.slot_Link.Name = "slot_Link";
            this.slot_Link.Size = new System.Drawing.Size(74, 29);
            this.slot_Link.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(444, 557);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroPanel4);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = global::SwitchPokeBot.Properties.Resources.SwitchPokeBot;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Text = "SwitchPokeBot (Arduino/Teensy)";
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroTabPage4.ResumeLayout(false);
            this.metroPanel6.ResumeLayout(false);
            this.metroPanel6.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroTabPage3.ResumeLayout(false);
            this.metroPanel5.ResumeLayout(false);
            this.metroPanel5.PerformLayout();
            this.metroPanel4.ResumeLayout(false);
            this.metroPanel4.PerformLayout();
            this.metroPanel7.ResumeLayout(false);
            this.metroPanel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      


        #endregion
        private PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btn_stop_Suprise;
        private MetroFramework.Controls.MetroButton btn_Start_Suprise;
        private MetroFramework.Controls.MetroCheckBox UseSync;
        private MetroFramework.Controls.MetroComboBox Slot_SupriseTrade;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroCheckBox showPokemon;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroComboBox reconnectAfter_combo;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroPanel metroPanel4;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroButton btn_refresh;
        private MetroFramework.Controls.MetroComboBox comPort_select;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroPanel metroPanel5;
        private MetroFramework.Controls.MetroButton btn_clearLog;
        private RichTextBox LogBox;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTabPage metroTabPage4;
        private MetroFramework.Controls.MetroButton btn_stop_link;
        private MetroFramework.Controls.MetroButton btn_start_link;
        private MetroFramework.Controls.MetroPanel metroPanel6;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroTextBox LinkCodeBox;
        private MetroFramework.Controls.MetroPanel metroPanel7;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroComboBox slot_Link;
    }
}