
namespace FlightCompany.form
{
    partial class MenuForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Search = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.Buy = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.NumberOfSeats = new System.Windows.Forms.Label();
            this.ClientAddress = new System.Windows.Forms.Label();
            this.TouristsName = new System.Windows.Forms.Label();
            this.ClientName = new System.Windows.Forms.Label();
            this.Logout = new System.Windows.Forms.Button();
            this.IdFlight = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(70, 66);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1315, 528);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1307, 499);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(287, 114);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(964, 300);
            this.dataGridView1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Search);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Location = new System.Drawing.Point(44, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 300);
            this.panel1.TabIndex = 0;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(75, 174);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 32);
            this.Search.TabIndex = 2;
            this.Search.Text = "button1";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(13, 71);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 121);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 24);
            this.comboBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1307, 499);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.IdFlight);
            this.panel2.Controls.Add(this.textBox5);
            this.panel2.Controls.Add(this.Buy);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.NumberOfSeats);
            this.panel2.Controls.Add(this.ClientAddress);
            this.panel2.Controls.Add(this.TouristsName);
            this.panel2.Controls.Add(this.ClientName);
            this.panel2.Location = new System.Drawing.Point(281, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(720, 399);
            this.panel2.TabIndex = 0;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(369, 282);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 9;
            // 
            // Buy
            // 
            this.Buy.Location = new System.Drawing.Point(382, 344);
            this.Buy.Name = "Buy";
            this.Buy.Size = new System.Drawing.Size(75, 33);
            this.Buy.TabIndex = 1;
            this.Buy.Text = "button2";
            this.Buy.UseVisualStyleBackColor = true;
            this.Buy.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(369, 226);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(369, 174);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(369, 120);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(369, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 4;
            // 
            // NumberOfSeats
            // 
            this.NumberOfSeats.AutoSize = true;
            this.NumberOfSeats.Location = new System.Drawing.Point(235, 231);
            this.NumberOfSeats.Name = "NumberOfSeats";
            this.NumberOfSeats.Size = new System.Drawing.Size(46, 17);
            this.NumberOfSeats.TabIndex = 3;
            this.NumberOfSeats.Text = "label4";
            // 
            // ClientAddress
            // 
            this.ClientAddress.AutoSize = true;
            this.ClientAddress.Location = new System.Drawing.Point(235, 179);
            this.ClientAddress.Name = "ClientAddress";
            this.ClientAddress.Size = new System.Drawing.Size(46, 17);
            this.ClientAddress.TabIndex = 2;
            this.ClientAddress.Text = "label3";
            // 
            // TouristsName
            // 
            this.TouristsName.AutoSize = true;
            this.TouristsName.Location = new System.Drawing.Point(235, 120);
            this.TouristsName.Name = "TouristsName";
            this.TouristsName.Size = new System.Drawing.Size(46, 17);
            this.TouristsName.TabIndex = 1;
            this.TouristsName.Text = "label2";
            // 
            // ClientName
            // 
            this.ClientName.AutoSize = true;
            this.ClientName.Location = new System.Drawing.Point(235, 69);
            this.ClientName.Name = "ClientName";
            this.ClientName.Size = new System.Drawing.Size(46, 17);
            this.ClientName.TabIndex = 0;
            this.ClientName.Text = "label1";
            // 
            // Logout
            // 
            this.Logout.Location = new System.Drawing.Point(1303, 53);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(75, 32);
            this.Logout.TabIndex = 1;
            this.Logout.Text = "button3";
            this.Logout.UseVisualStyleBackColor = true;
            this.Logout.Click += new System.EventHandler(this.button3_Click);
            // 
            // IdFlight
            // 
            this.IdFlight.AutoSize = true;
            this.IdFlight.Location = new System.Drawing.Point(235, 287);
            this.IdFlight.Name = "IdFlight";
            this.IdFlight.Size = new System.Drawing.Size(46, 17);
            this.IdFlight.TabIndex = 10;
            this.IdFlight.Text = "label1";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1487, 630);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.tabControl1);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Buy;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label NumberOfSeats;
        private System.Windows.Forms.Label ClientAddress;
        private System.Windows.Forms.Label TouristsName;
        private System.Windows.Forms.Label ClientName;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label IdFlight;
    }
}