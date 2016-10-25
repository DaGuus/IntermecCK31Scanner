namespace BarcodeReader_ce
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
            this.label1 = new System.Windows.Forms.Label();
            this.categoryBox = new System.Windows.Forms.ComboBox();
            this.productBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.personListBox = new System.Windows.Forms.ListBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.statusReport = new System.Windows.Forms.Label();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 23);
            this.label1.Text = "Wie ben je?";
            // 
            // categoryBox
            // 
            this.categoryBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.categoryBox.Location = new System.Drawing.Point(98, 29);
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.Size = new System.Drawing.Size(134, 25);
            this.categoryBox.TabIndex = 27;
            this.categoryBox.SelectedIndexChanged += new System.EventHandler(this.categoryBox_SelectedIndexChanged);
            // 
            // productBox
            // 
            this.productBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.productBox.Location = new System.Drawing.Point(98, 189);
            this.productBox.Name = "productBox";
            this.productBox.Size = new System.Drawing.Size(134, 25);
            this.productBox.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(0, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 23);
            this.label2.Text = "Wat wil je?";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(0, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 25);
            this.button1.TabIndex = 31;
            this.button1.Text = "Streep Af!";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // personListBox
            // 
            this.personListBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.personListBox.Location = new System.Drawing.Point(0, 57);
            this.personListBox.Name = "personListBox";
            this.personListBox.Size = new System.Drawing.Size(232, 128);
            this.personListBox.TabIndex = 38;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItem2);
            this.menuItem1.Text = "Bestand";
            // 
            // menuItem2
            // 
            this.menuItem2.MenuItems.Add(this.menuItem3);
            this.menuItem2.MenuItems.Add(this.menuItem4);
            this.menuItem2.MenuItems.Add(this.menuItem5);
            this.menuItem2.MenuItems.Add(this.menuItem6);
            this.menuItem2.Text = "Refresh";
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "Personen";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Text = "Producten";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Text = "Barcodes";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // statusReport
            // 
            this.statusReport.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.statusReport.Location = new System.Drawing.Point(0, 245);
            this.statusReport.Name = "statusReport";
            this.statusReport.Size = new System.Drawing.Size(232, 24);
            this.statusReport.Text = "Status";
            // 
            // menuItem6
            // 
            this.menuItem6.Text = "Admins";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 269);
            this.Controls.Add(this.statusReport);
            this.Controls.Add(this.personListBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.productBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.categoryBox);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Barcode Reader";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox categoryBox;
        private System.Windows.Forms.ComboBox productBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox personListBox;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.Label statusReport;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
    }
}