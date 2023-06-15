namespace AnonTextAppGUI
{
    partial class CreateDocument
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
            label1 = new Label();
            panel1 = new Panel();
            checkBox1 = new CheckBox();
            textBox2 = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(6, 298);
            label1.Name = "label1";
            label1.Size = new Size(105, 30);
            label1.TabIndex = 0;
            label1.Text = "Password";
            label1.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(richTextBox1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 374);
            panel1.TabIndex = 1;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(706, 333);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(67, 23);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Visible";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(6, 331);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(694, 26);
            textBox2.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(714, 88);
            label5.Name = "label5";
            label5.Size = new Size(46, 19);
            label5.TabIndex = 5;
            label5.Text = "0/128";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(722, 13);
            label4.Name = "label4";
            label4.Size = new Size(38, 19);
            label4.TabIndex = 4;
            label4.Text = "0/32";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(6, 77);
            label3.Name = "label3";
            label3.Size = new Size(125, 30);
            label3.TabIndex = 3;
            label3.Text = "Description";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(6, 2);
            label2.Name = "label2";
            label2.Size = new Size(56, 30);
            label2.TabIndex = 2;
            label2.Text = "Title";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(6, 35);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(767, 35);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.Location = new Point(6, 110);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(767, 185);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            richTextBox1.KeyPress += richTextBox1_KeyPress;
            // 
            // button1
            // 
            button1.Location = new Point(322, 392);
            button1.Name = "button1";
            button1.Size = new Size(130, 35);
            button1.TabIndex = 2;
            button1.Text = "Publish";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // CreateDocument
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(panel1);
            Name = "CreateDocument";
            Text = "CreateDocument";
            Load += CreateDocument_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private TextBox textBox1;
        private RichTextBox richTextBox1;
        private Button button1;
        private Label label5;
        private Label label4;
        private TextBox textBox2;
        private CheckBox checkBox1;
    }
}