namespace WindowsFormsApplication1
{
    partial class authServerPage
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.encKeyBox = new System.Windows.Forms.TextBox();
            this.ticketBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.getTGSkey = new System.Windows.Forms.Button();
            this.idBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pwBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.decKeyBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.timeStamp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.Tickey = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "P/W";
            // 
            // encKeyBox
            // 
            this.encKeyBox.Enabled = false;
            this.encKeyBox.Location = new System.Drawing.Point(428, 195);
            this.encKeyBox.Name = "encKeyBox";
            this.encKeyBox.Size = new System.Drawing.Size(451, 21);
            this.encKeyBox.TabIndex = 16;
            // 
            // ticketBox
            // 
            this.ticketBox.Enabled = false;
            this.ticketBox.Location = new System.Drawing.Point(428, 137);
            this.ticketBox.Name = "ticketBox";
            this.ticketBox.Size = new System.Drawing.Size(451, 21);
            this.ticketBox.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "Encrypted Message";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "Key TGS";
            // 
            // getTGSkey
            // 
            this.getTGSkey.Location = new System.Drawing.Point(18, 74);
            this.getTGSkey.Name = "getTGSkey";
            this.getTGSkey.Size = new System.Drawing.Size(75, 23);
            this.getTGSkey.TabIndex = 12;
            this.getTGSkey.Text = "Send Request";
            this.getTGSkey.UseVisualStyleBackColor = true;
            this.getTGSkey.Click += new System.EventHandler(this.button5_Click);
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(110, 15);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(100, 21);
            this.idBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "ID";
            // 
            // pwBox
            // 
            this.pwBox.Location = new System.Drawing.Point(69, 253);
            this.pwBox.Name = "pwBox";
            this.pwBox.Size = new System.Drawing.Size(100, 21);
            this.pwBox.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(188, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 292);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "Decrypted Message";
            // 
            // decKeyBox
            // 
            this.decKeyBox.Enabled = false;
            this.decKeyBox.Location = new System.Drawing.Point(188, 292);
            this.decKeyBox.Name = "decKeyBox";
            this.decKeyBox.Size = new System.Drawing.Size(658, 21);
            this.decKeyBox.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 356);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 12);
            this.label6.TabIndex = 22;
            this.label6.Text = "Time Stamp";
            // 
            // timeStamp
            // 
            this.timeStamp.Enabled = false;
            this.timeStamp.Location = new System.Drawing.Point(188, 353);
            this.timeStamp.Name = "timeStamp";
            this.timeStamp.Size = new System.Drawing.Size(658, 21);
            this.timeStamp.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 480);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "Encrypted Message";
            // 
            // messageBox
            // 
            this.messageBox.Enabled = false;
            this.messageBox.Location = new System.Drawing.Point(188, 477);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(658, 21);
            this.messageBox.TabIndex = 25;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(18, 403);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 26;
            this.button2.Text = "Create Message";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(20, 444);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(101, 12);
            this.label.TabIndex = 27;
            this.label.Text = "Message to TGS";
            // 
            // messageTextBox
            // 
            this.messageTextBox.Enabled = false;
            this.messageTextBox.Location = new System.Drawing.Point(188, 441);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(658, 21);
            this.messageTextBox.TabIndex = 28;
            // 
            // Tickey
            // 
            this.Tickey.AutoSize = true;
            this.Tickey.Location = new System.Drawing.Point(303, 146);
            this.Tickey.Name = "Tickey";
            this.Tickey.Size = new System.Drawing.Size(39, 12);
            this.Tickey.TabIndex = 29;
            this.Tickey.Text = "Ticket";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(428, 104);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(340, 21);
            this.textBox1.TabIndex = 30;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "RSA Service"});
            this.comboBox1.Location = new System.Drawing.Point(110, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(203, 20);
            this.comboBox1.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 12);
            this.label8.TabIndex = 31;
            this.label8.Text = "Service Server";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 321);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 12);
            this.label9.TabIndex = 33;
            this.label9.Text = "Key TGS";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(188, 321);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(658, 21);
            this.textBox2.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(303, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 12);
            this.label10.TabIndex = 35;
            this.label10.Text = "Message";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(428, 168);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(451, 21);
            this.textBox3.TabIndex = 36;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(774, 102);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 23);
            this.button3.TabIndex = 37;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(24, 518);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 23);
            this.button4.TabIndex = 38;
            this.button4.Text = "Send Request";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // authServerPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Tickey);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.label);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.timeStamp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.decKeyBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pwBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.encKeyBox);
            this.Controls.Add(this.ticketBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.getTGSkey);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.label5);
            this.Name = "authServerPage";
            this.Size = new System.Drawing.Size(882, 611);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox encKeyBox;
        private System.Windows.Forms.TextBox ticketBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button getTGSkey;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox pwBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox decKeyBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox timeStamp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Label Tickey;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;

    }
}
