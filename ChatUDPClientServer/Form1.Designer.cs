
namespace UDPServer
{
    partial class ServerForm
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
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.lstClients = new System.Windows.Forms.ListBox();
            this.Chat = new System.Windows.Forms.Label();
            this.Mess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(639, 353);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(126, 75);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(155, 306);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(610, 22);
            this.txtMessage.TabIndex = 3;
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(155, 213);
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(610, 22);
            this.txtChat.TabIndex = 4;
            // 
            // lstClients
            // 
            this.lstClients.FormattingEnabled = true;
            this.lstClients.ItemHeight = 16;
            this.lstClients.Location = new System.Drawing.Point(155, 3);
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(610, 180);
            this.lstClients.TabIndex = 5;
            // 
            // Chat
            // 
            this.Chat.AutoSize = true;
            this.Chat.Location = new System.Drawing.Point(62, 213);
            this.Chat.Name = "Chat";
            this.Chat.Size = new System.Drawing.Size(37, 17);
            this.Chat.TabIndex = 6;
            this.Chat.Text = "Chat";
            // 
            // Mess
            // 
            this.Mess.AutoSize = true;
            this.Mess.Location = new System.Drawing.Point(62, 306);
            this.Mess.Name = "Mess";
            this.Mess.Size = new System.Drawing.Size(65, 17);
            this.Mess.TabIndex = 7;
            this.Mess.Text = "Message";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Mess);
            this.Controls.Add(this.Chat);
            this.Controls.Add(this.lstClients);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.ListBox lstClients;
        private System.Windows.Forms.Label Chat;
        private System.Windows.Forms.Label Mess;
    }
}

