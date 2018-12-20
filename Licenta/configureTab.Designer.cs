using System;
using System.Drawing;
using System.Windows.Forms;

namespace Licenta
{
    public class CustomButton : Button
    {
        public CustomButton()
            : base()
        {
            // Prevent the button from drawing its own border
            FlatAppearance.BorderSize = 0;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackColor = Color.LightGray;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw Border using color specified in Flat Appearance
            Pen pen = new Pen(FlatAppearance.BorderColor, 1);
            Rectangle rectangle = new Rectangle(0, 0, Size.Width - 1, Size.Height - 1);
            e.Graphics.DrawRectangle(pen, rectangle);
        }
    }
    partial class configureTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.serverIPText = new System.Windows.Forms.TextBox();
            this.serverPortText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.serverAddressText = new System.Windows.Forms.TextBox();
            this.listenPortText = new System.Windows.Forms.TextBox();
            this.listenIPText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listenList = new System.Windows.Forms.ListBox();
            this.addIPButtonn = new Licenta.CustomButton();
            this.setPortButton = new Licenta.CustomButton();
            this.saveButton = new Licenta.CustomButton();
            this.start_stopButton = new Licenta.CustomButton();
            this.warningLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Proxy Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(53, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Host of the web server to proxy:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Schoolbook", 8.25F);
            this.label4.Location = new System.Drawing.Point(53, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Port of the web server to proxy:";
            // 
            // serverIPText
            // 
            this.serverIPText.Location = new System.Drawing.Point(231, 44);
            this.serverIPText.Name = "serverIPText";
            this.serverIPText.Size = new System.Drawing.Size(185, 20);
            this.serverIPText.TabIndex = 4;
            // 
            // serverPortText
            // 
            this.serverPortText.Location = new System.Drawing.Point(231, 69);
            this.serverPortText.Name = "serverPortText";
            this.serverPortText.Size = new System.Drawing.Size(185, 20);
            this.serverPortText.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(201, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Server address:";
            // 
            // serverAddressText
            // 
            this.serverAddressText.Location = new System.Drawing.Point(120, 126);
            this.serverAddressText.Name = "serverAddressText";
            this.serverAddressText.ReadOnly = true;
            this.serverAddressText.Size = new System.Drawing.Size(250, 20);
            this.serverAddressText.TabIndex = 8;
            // 
            // listenPortText
            // 
            this.listenPortText.Location = new System.Drawing.Point(194, 220);
            this.listenPortText.Name = "listenPortText";
            this.listenPortText.Size = new System.Drawing.Size(185, 20);
            this.listenPortText.TabIndex = 13;
            // 
            // listenIPText
            // 
            this.listenIPText.Location = new System.Drawing.Point(194, 195);
            this.listenIPText.Name = "listenIPText";
            this.listenIPText.Size = new System.Drawing.Size(185, 20);
            this.listenIPText.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Schoolbook", 8.25F);
            this.label6.Location = new System.Drawing.Point(16, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Port number on which to listen:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "IPv4 address on which to listen:";
            // 
            // listenList
            // 
            this.listenList.FormattingEnabled = true;
            this.listenList.Location = new System.Drawing.Point(56, 254);
            this.listenList.Name = "listenList";
            this.listenList.Size = new System.Drawing.Size(201, 95);
            this.listenList.TabIndex = 17;
            this.listenList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listenList_MouseDown);
            // 
            // addIPButtonn
            // 
            this.addIPButtonn.BackColor = System.Drawing.Color.LightGray;
            this.addIPButtonn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addIPButtonn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addIPButtonn.Location = new System.Drawing.Point(397, 195);
            this.addIPButtonn.Name = "addIPButtonn";
            this.addIPButtonn.Size = new System.Drawing.Size(75, 20);
            this.addIPButtonn.TabIndex = 16;
            this.addIPButtonn.Text = "add";
            this.addIPButtonn.UseVisualStyleBackColor = true;
            this.addIPButtonn.Click += new System.EventHandler(this.addIPButtonn_Click);
            // 
            // setPortButton
            // 
            this.setPortButton.BackColor = System.Drawing.Color.LightGray;
            this.setPortButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setPortButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.setPortButton.Location = new System.Drawing.Point(397, 220);
            this.setPortButton.Name = "setPortButton";
            this.setPortButton.Size = new System.Drawing.Size(75, 20);
            this.setPortButton.TabIndex = 15;
            this.setPortButton.Text = "set";
            this.setPortButton.UseVisualStyleBackColor = true;
            this.setPortButton.Click += new System.EventHandler(this.setPortButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.LightGray;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.saveButton.Location = new System.Drawing.Point(458, 67);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // start_stopButton
            // 
            this.start_stopButton.BackColor = System.Drawing.Color.LightGray;
            this.start_stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_stopButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.start_stopButton.Location = new System.Drawing.Point(458, 326);
            this.start_stopButton.Name = "start_stopButton";
            this.start_stopButton.Size = new System.Drawing.Size(75, 23);
            this.start_stopButton.TabIndex = 18;
            this.start_stopButton.Text = "start";
            this.start_stopButton.UseVisualStyleBackColor = true;
            this.start_stopButton.Click += new System.EventHandler(this.start_stopButton_Click);
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.warningLabel.Location = new System.Drawing.Point(394, 356);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(0, 16);
            this.warningLabel.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(74, 352);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "*right-click address to delete";
            // 
            // configureTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.Controls.Add(this.label8);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.start_stopButton);
            this.Controls.Add(this.listenList);
            this.Controls.Add(this.addIPButtonn);
            this.Controls.Add(this.setPortButton);
            this.Controls.Add(this.listenPortText);
            this.Controls.Add(this.listenIPText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.serverAddressText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.serverPortText);
            this.Controls.Add(this.serverIPText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "configureTab";
            this.Size = new System.Drawing.Size(570, 380);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.configureTab_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox serverIPText;
        private System.Windows.Forms.TextBox serverPortText;
        private CustomButton saveButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox serverAddressText;
        private TextBox listenPortText;
        private TextBox listenIPText;
        private Label label6;
        private Label label7;
        private CustomButton setPortButton;
        private CustomButton addIPButtonn;
        private ListBox listenList;
        private CustomButton start_stopButton;
        private Label warningLabel;
        private Label label8;
    }

}
