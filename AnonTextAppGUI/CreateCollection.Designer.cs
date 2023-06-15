namespace AnonTextAppGUI
{
    partial class CreateCollection
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
            textBox4 = new TextBox();
            groupBox1 = new GroupBox();
            textBox3 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(197, 32);
            label1.TabIndex = 0;
            label1.Text = "Create Collection";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Location = new Point(12, 55);
            label2.Name = "label2";
            label2.Size = new Size(64, 23);
            label2.TabIndex = 1;
            label2.Text = "Title";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Location = new Point(12, 87);
            label3.Name = "label3";
            label3.Size = new Size(64, 23);
            label3.TabIndex = 2;
            label3.Text = "Password";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(82, 55);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Collection Title";
            textBox1.Size = new Size(300, 23);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(82, 87);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Collection Password (Optional)";
            textBox2.Size = new Size(300, 23);
            textBox2.TabIndex = 4;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(12, 415);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Collection Code";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(418, 23);
            textBox4.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox3);
            groupBox1.Location = new Point(12, 126);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(499, 283);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Document Codes";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(6, 22);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "One document code per line";
            textBox3.Size = new Size(487, 255);
            textBox3.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(388, 55);
            button1.Name = "button1";
            button1.Size = new Size(123, 55);
            button1.TabIndex = 8;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(436, 415);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "Copy";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // CreateCollection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(523, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(textBox4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CreateCollection";
            Text = "CreateCollection";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox4;
        private GroupBox groupBox1;
        private TextBox textBox3;
        private Button button1;
        private Button button2;
    }
}