namespace AnonTextAppGUI
{
    partial class ViewDocument
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
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label4 = new Label();
            textBox4 = new TextBox();
            button3 = new Button();
            listBox1 = new ListBox();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(99, 61);
            label1.Name = "label1";
            label1.Size = new Size(337, 57);
            label1.TabIndex = 0;
            label1.Text = "View Document";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(99, 150);
            label2.Name = "label2";
            label2.Size = new Size(56, 30);
            label2.TabIndex = 1;
            label2.Text = "Title";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(99, 201);
            label3.Name = "label3";
            label3.Size = new Size(102, 30);
            label3.TabIndex = 2;
            label3.Text = "Category";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(249, 150);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(615, 35);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(249, 201);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(615, 35);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(1018, 145);
            button1.Name = "button1";
            button1.Size = new Size(131, 40);
            button1.TabIndex = 5;
            button1.Text = "Update";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1018, 199);
            button2.Name = "button2";
            button2.Size = new Size(131, 40);
            button2.TabIndex = 6;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(99, 264);
            label4.Name = "label4";
            label4.Size = new Size(92, 30);
            label4.TabIndex = 7;
            label4.Text = "Content";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(99, 731);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(896, 35);
            textBox4.TabIndex = 9;
            // 
            // button3
            // 
            button3.Location = new Point(1018, 726);
            button3.Name = "button3";
            button3.Size = new Size(131, 40);
            button3.TabIndex = 10;
            button3.Text = "Comment";
            button3.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 30;
            listBox1.Location = new Point(99, 525);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(1050, 184);
            listBox1.TabIndex = 11;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(99, 297);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1050, 207);
            richTextBox1.TabIndex = 12;
            richTextBox1.Text = "";
            // 
            // ViewDocument
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1309, 824);
            Controls.Add(richTextBox1);
            Controls.Add(listBox1);
            Controls.Add(button3);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ViewDocument";
            Text = "ViewDocument";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private Label label4;
        private TextBox textBox4;
        private Button button3;
        private ListBox listBox1;
        private RichTextBox richTextBox1;
    }
}