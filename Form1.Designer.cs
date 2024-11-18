
namespace Elgamal_crypt_для_конфы
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
            this.publicKeyText = new System.Windows.Forms.TextBox();
            this.privateKeyText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.messageText = new System.Windows.Forms.TextBox();
            this.sessionalKeyText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.createElgamalSysButton = new System.Windows.Forms.Button();
            this.encryptButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // publicKeyText
            // 
            this.publicKeyText.Location = new System.Drawing.Point(12, 38);
            this.publicKeyText.Name = "publicKeyText";
            this.publicKeyText.Size = new System.Drawing.Size(145, 23);
            this.publicKeyText.TabIndex = 0;
            // 
            // privateKeyText
            // 
            this.privateKeyText.Location = new System.Drawing.Point(163, 38);
            this.privateKeyText.Name = "privateKeyText";
            this.privateKeyText.Size = new System.Drawing.Size(120, 23);
            this.privateKeyText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Открытый ключ (y, g, p)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Закрытый ключ (x)";
            // 
            // messageText
            // 
            this.messageText.Location = new System.Drawing.Point(12, 126);
            this.messageText.Multiline = true;
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(271, 105);
            this.messageText.TabIndex = 4;
            // 
            // sessionalKeyText
            // 
            this.sessionalKeyText.Location = new System.Drawing.Point(12, 82);
            this.sessionalKeyText.Name = "sessionalKeyText";
            this.sessionalKeyText.Size = new System.Drawing.Size(127, 23);
            this.sessionalKeyText.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Сесионный ключ (k)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Сообщение";
            // 
            // createElgamalSysButton
            // 
            this.createElgamalSysButton.Location = new System.Drawing.Point(303, 38);
            this.createElgamalSysButton.Name = "createElgamalSysButton";
            this.createElgamalSysButton.Size = new System.Drawing.Size(127, 68);
            this.createElgamalSysButton.TabIndex = 8;
            this.createElgamalSysButton.Text = "Создать систему Эль-гамаля";
            this.createElgamalSysButton.UseVisualStyleBackColor = true;
            this.createElgamalSysButton.Click += new System.EventHandler(this.createElgamalSysButton_Click);
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(303, 126);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(127, 45);
            this.encryptButton.TabIndex = 9;
            this.encryptButton.Text = "Зашифровать";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(303, 186);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(127, 45);
            this.decryptButton.TabIndex = 10;
            this.decryptButton.Text = "Расшифровать";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 257);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.createElgamalSysButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sessionalKeyText);
            this.Controls.Add(this.messageText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.privateKeyText);
            this.Controls.Add(this.publicKeyText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox publicKeyText;
        private System.Windows.Forms.TextBox privateKeyText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox messageText;
        private System.Windows.Forms.TextBox sessionalKeyText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button createElgamalSysButton;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button decryptButton;
    }
}

