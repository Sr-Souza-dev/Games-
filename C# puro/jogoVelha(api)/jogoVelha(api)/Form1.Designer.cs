namespace jogoVelha_api_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.url = new System.Windows.Forms.TextBox();
            this.label_url = new System.Windows.Forms.Label();
            this.select = new System.Windows.Forms.ComboBox();
            this.option = new System.Windows.Forms.Label();
            this.ps00 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ps01 = new System.Windows.Forms.Label();
            this.ps02 = new System.Windows.Forms.Label();
            this.ps10 = new System.Windows.Forms.Label();
            this.ps11 = new System.Windows.Forms.Label();
            this.ps12 = new System.Windows.Forms.Label();
            this.ps20 = new System.Windows.Forms.Label();
            this.ps21 = new System.Windows.Forms.Label();
            this.ps22 = new System.Windows.Forms.Label();
            this.analyze = new System.Windows.Forms.Button();
            this.approve = new System.Windows.Forms.Button();
            this.reload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // url
            // 
            this.url.Location = new System.Drawing.Point(86, 23);
            this.url.Name = "url";
            this.url.Size = new System.Drawing.Size(288, 23);
            this.url.TabIndex = 0;
            this.url.Text = "http://localhost:9000/";
            // 
            // label_url
            // 
            this.label_url.AutoSize = true;
            this.label_url.Location = new System.Drawing.Point(46, 26);
            this.label_url.Name = "label_url";
            this.label_url.Size = new System.Drawing.Size(34, 15);
            this.label_url.TabIndex = 1;
            this.label_url.Text = "URL: ";
            this.label_url.Click += new System.EventHandler(this.label1_Click);
            // 
            // select
            // 
            this.select.FormattingEnabled = true;
            this.select.Items.AddRange(new object[] {
            "X",
            "O"});
            this.select.Location = new System.Drawing.Point(518, 23);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(169, 23);
            this.select.TabIndex = 2;
            this.select.Text = "Select";
            this.select.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // option
            // 
            this.option.AutoSize = true;
            this.option.Location = new System.Drawing.Point(465, 26);
            this.option.Name = "option";
            this.option.Size = new System.Drawing.Size(47, 15);
            this.option.TabIndex = 3;
            this.option.Text = "Option:";
            // 
            // ps00
            // 
            this.ps00.AutoSize = true;
            this.ps00.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ps00.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ps00.Location = new System.Drawing.Point(121, 116);
            this.ps00.Name = "ps00";
            this.ps00.Size = new System.Drawing.Size(41, 47);
            this.ps00.TabIndex = 1;
            this.ps00.Text = "X";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(86, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(290, 290);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // ps01
            // 
            this.ps01.AutoSize = true;
            this.ps01.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ps01.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ps01.Location = new System.Drawing.Point(214, 116);
            this.ps01.Name = "ps01";
            this.ps01.Size = new System.Drawing.Size(41, 47);
            this.ps01.TabIndex = 5;
            this.ps01.Text = "X";
            // 
            // ps02
            // 
            this.ps02.AutoSize = true;
            this.ps02.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ps02.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ps02.Location = new System.Drawing.Point(302, 116);
            this.ps02.Name = "ps02";
            this.ps02.Size = new System.Drawing.Size(41, 47);
            this.ps02.TabIndex = 6;
            this.ps02.Text = "X";
            // 
            // ps10
            // 
            this.ps10.AutoSize = true;
            this.ps10.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ps10.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ps10.Location = new System.Drawing.Point(121, 200);
            this.ps10.Name = "ps10";
            this.ps10.Size = new System.Drawing.Size(41, 47);
            this.ps10.TabIndex = 7;
            this.ps10.Text = "X";
            // 
            // ps11
            // 
            this.ps11.AutoSize = true;
            this.ps11.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ps11.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ps11.Location = new System.Drawing.Point(214, 200);
            this.ps11.Name = "ps11";
            this.ps11.Size = new System.Drawing.Size(41, 47);
            this.ps11.TabIndex = 8;
            this.ps11.Text = "X";
            // 
            // ps12
            // 
            this.ps12.AutoSize = true;
            this.ps12.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ps12.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ps12.Location = new System.Drawing.Point(302, 200);
            this.ps12.Name = "ps12";
            this.ps12.Size = new System.Drawing.Size(41, 47);
            this.ps12.TabIndex = 9;
            this.ps12.Text = "X";
            // 
            // ps20
            // 
            this.ps20.AutoSize = true;
            this.ps20.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ps20.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ps20.Location = new System.Drawing.Point(121, 285);
            this.ps20.Name = "ps20";
            this.ps20.Size = new System.Drawing.Size(41, 47);
            this.ps20.TabIndex = 10;
            this.ps20.Text = "X";
            // 
            // ps21
            // 
            this.ps21.AutoSize = true;
            this.ps21.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ps21.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ps21.Location = new System.Drawing.Point(214, 285);
            this.ps21.Name = "ps21";
            this.ps21.Size = new System.Drawing.Size(41, 47);
            this.ps21.TabIndex = 11;
            this.ps21.Text = "X";
            // 
            // ps22
            // 
            this.ps22.AutoSize = true;
            this.ps22.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ps22.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ps22.Location = new System.Drawing.Point(302, 285);
            this.ps22.Name = "ps22";
            this.ps22.Size = new System.Drawing.Size(41, 47);
            this.ps22.TabIndex = 12;
            this.ps22.Text = "X";
            // 
            // analyze
            // 
            this.analyze.Location = new System.Drawing.Point(465, 200);
            this.analyze.Name = "analyze";
            this.analyze.Size = new System.Drawing.Size(258, 42);
            this.analyze.TabIndex = 14;
            this.analyze.Text = "Analyze";
            this.analyze.UseVisualStyleBackColor = true;
            this.analyze.Click += new System.EventHandler(this.analyze_Click);
            // 
            // approve
            // 
            this.approve.BackColor = System.Drawing.Color.Lime;
            this.approve.Location = new System.Drawing.Point(465, 285);
            this.approve.Name = "approve";
            this.approve.Size = new System.Drawing.Size(258, 42);
            this.approve.TabIndex = 15;
            this.approve.Text = "approve";
            this.approve.UseVisualStyleBackColor = false;
            this.approve.Click += new System.EventHandler(this.approve_Click);
            // 
            // reload
            // 
            this.reload.BackColor = System.Drawing.Color.Lime;
            this.reload.Location = new System.Drawing.Point(465, 116);
            this.reload.Name = "reload";
            this.reload.Size = new System.Drawing.Size(258, 42);
            this.reload.TabIndex = 16;
            this.reload.Text = "Reload";
            this.reload.UseVisualStyleBackColor = false;
            this.reload.Click += new System.EventHandler(this.reload_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reload);
            this.Controls.Add(this.approve);
            this.Controls.Add(this.analyze);
            this.Controls.Add(this.ps22);
            this.Controls.Add(this.ps21);
            this.Controls.Add(this.ps20);
            this.Controls.Add(this.ps12);
            this.Controls.Add(this.ps11);
            this.Controls.Add(this.ps10);
            this.Controls.Add(this.ps02);
            this.Controls.Add(this.ps01);
            this.Controls.Add(this.ps00);
            this.Controls.Add(this.option);
            this.Controls.Add(this.select);
            this.Controls.Add(this.label_url);
            this.Controls.Add(this.url);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox url;
        private Label label_url;
        private ComboBox select;
        private Label option;
        private Label ps00;
        private PictureBox pictureBox1;
        private Label ps01;
        private Label ps02;
        private Label ps10;
        private Label ps11;
        private Label ps12;
        private Label ps20;
        private Label ps21;
        private Label ps22;
        private Button analyze;
        private Button approve;
        private Button reload;
    }
}