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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.productBox = new System.Windows.Forms.ListBox();
            this.personBox = new System.Windows.Forms.ComboBox();
            this.addPersonButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem7);
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
            // menuItem6
            // 
            this.menuItem6.Text = "Admins";
            // 
            // menuItem7
            // 
            this.menuItem7.MenuItems.Add(this.menuItem8);
            this.menuItem7.MenuItems.Add(this.menuItem9);
            this.menuItem7.MenuItems.Add(this.menuItem10);
            this.menuItem7.Text = "Streeplijst";
            // 
            // menuItem8
            // 
            this.menuItem8.Text = "Nieuw";
            // 
            // menuItem9
            // 
            this.menuItem9.Text = "Open";
            // 
            // menuItem10
            // 
            this.menuItem10.Text = "Opslaan";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // productBox
            // 
            this.productBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.productBox.Location = new System.Drawing.Point(5, 66);
            this.productBox.Name = "productBox";
            this.productBox.Size = new System.Drawing.Size(230, 200);
            this.productBox.TabIndex = 0;
            // 
            // personBox
            // 
            this.personBox.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular);
            this.personBox.Location = new System.Drawing.Point(3, 29);
            this.personBox.Name = "personBox";
            this.personBox.Size = new System.Drawing.Size(193, 28);
            this.personBox.TabIndex = 1;
            // 
            // addPersonButton
            // 
            this.addPersonButton.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.addPersonButton.Location = new System.Drawing.Point(202, 29);
            this.addPersonButton.Name = "addPersonButton";
            this.addPersonButton.Size = new System.Drawing.Size(30, 28);
            this.addPersonButton.TabIndex = 2;
            this.addPersonButton.Text = "+";
            this.addPersonButton.Click += new System.EventHandler(this.addPersonButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 269);
            this.Controls.Add(this.addPersonButton);
            this.Controls.Add(this.personBox);
            this.Controls.Add(this.productBox);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Streeplijst";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.ListBox productBox;
        private System.Windows.Forms.ComboBox personBox;
        private System.Windows.Forms.Button addPersonButton;
    }
}