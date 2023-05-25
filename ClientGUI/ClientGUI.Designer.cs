namespace ClientGUI
{
    partial class ClientGUI
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
            richTextBox1 = new RichTextBox();
            button4 = new Button();
            button1 = new Button();
            richTextBox2 = new RichTextBox();
            richTextBox3 = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(38, 43);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(300, 294);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "";
            // 
            // button4
            // 
            button4.Location = new Point(163, 448);
            button4.Name = "button4";
            button4.Size = new Size(119, 27);
            button4.TabIndex = 7;
            button4.Text = "Send";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // button1
            // 
            button1.Location = new Point(38, 448);
            button1.Name = "button1";
            button1.Size = new Size(119, 27);
            button1.TabIndex = 1;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(38, 378);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(606, 64);
            richTextBox2.TabIndex = 8;
            richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(344, 43);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(300, 294);
            richTextBox3.TabIndex = 9;
            richTextBox3.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 20);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 10;
            label1.Text = "TEXT:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(344, 20);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 11;
            label2.Text = "SIGNATURE:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 355);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 12;
            label3.Text = "PUBLIC KEY:";
            // 
            // button2
            // 
            button2.Location = new Point(525, 448);
            button2.Name = "button2";
            button2.Size = new Size(119, 27);
            button2.TabIndex = 13;
            button2.Text = "Sign";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ClientGUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 517);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(richTextBox3);
            Controls.Add(richTextBox2);
            Controls.Add(button4);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Name = "ClientGUI";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RichTextBox richTextBox1;
        private Button button4;
        private Button button1;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button2;
    }
}