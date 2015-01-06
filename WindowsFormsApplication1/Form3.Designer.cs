namespace WindowsFormsApplication1
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ssid = new System.Windows.Forms.TextBox();
            this.pswdlAB = new System.Windows.Forms.Label();
            this.pswd = new System.Windows.Forms.TextBox();
            this.update = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter ssid/name of hotspot:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mistral", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hotspot configration";
            // 
            // ssid
            // 
            this.ssid.Location = new System.Drawing.Point(13, 71);
            this.ssid.Name = "ssid";
            this.ssid.Size = new System.Drawing.Size(259, 20);
            this.ssid.TabIndex = 2;
            // 
            // pswdlAB
            // 
            this.pswdlAB.AutoSize = true;
            this.pswdlAB.Location = new System.Drawing.Point(54, 106);
            this.pswdlAB.Name = "pswdlAB";
            this.pswdlAB.Size = new System.Drawing.Size(170, 13);
            this.pswdlAB.TabIndex = 3;
            this.pswdlAB.Text = "Enter desired password of hotspot:";
            // 
            // pswd
            // 
            this.pswd.Location = new System.Drawing.Point(12, 122);
            this.pswd.Name = "pswd";
            this.pswd.Size = new System.Drawing.Size(259, 20);
            this.pswd.TabIndex = 4;
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(57, 157);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(167, 23);
            this.update.TabIndex = 5;
            this.update.Text = "Update WiFi hotspot";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(86, 186);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(107, 23);
            this.close.TabIndex = 6;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // status
            // 
            this.status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.status.Location = new System.Drawing.Point(13, 217);
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Size = new System.Drawing.Size(259, 13);
            this.status.TabIndex = 7;
            this.status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 249);
            this.Controls.Add(this.status);
            this.Controls.Add(this.close);
            this.Controls.Add(this.update);
            this.Controls.Add(this.pswd);
            this.Controls.Add(this.pswdlAB);
            this.Controls.Add(this.ssid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "Form3";
            this.Text = "Hotspot Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ssid;
        private System.Windows.Forms.Label pswdlAB;
        private System.Windows.Forms.TextBox pswd;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.TextBox status;
    }
}