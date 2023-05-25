namespace ServerGUI
{
    partial class ServerGUI
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
            button3 = new Button();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(12, 12);
            button3.Name = "button3";
            button3.Size = new Size(214, 29);
            button3.TabIndex = 5;
            button3.Text = "Listen";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ServerGUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(236, 53);
            Controls.Add(button3);
            Name = "ServerGUI";
            Text = "Server";
            ResumeLayout(false);
        }

        #endregion
        private Button button3;
    }
}