
namespace UDPClient
{
    partial class client
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
            this.Mess = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.listMess = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // Mess
            // 
            this.Mess.Location = new System.Drawing.Point(12, 374);
            this.Mess.Name = "Mess";
            this.Mess.Size = new System.Drawing.Size(776, 22);
            this.Mess.TabIndex = 2;
            this.Mess.TextChanged += new System.EventHandler(this.Mess_TextChanged);
            // 
            // buttonSend
            // 
            this.buttonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSend.Location = new System.Drawing.Point(640, 402);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(148, 36);
            this.buttonSend.TabIndex = 3;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // listMess
            // 
            this.listMess.HideSelection = false;
            this.listMess.Location = new System.Drawing.Point(12, 3);
            this.listMess.Name = "listMess";
            this.listMess.Size = new System.Drawing.Size(776, 365);
            this.listMess.TabIndex = 4;
            this.listMess.UseCompatibleStateImageBehavior = false;
            this.listMess.View = System.Windows.Forms.View.List;
            this.listMess.SelectedIndexChanged += new System.EventHandler(this.listMess_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listMess);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.Mess);
            this.Name = "Form1";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Mess;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.ListView listMess;
    }
}

