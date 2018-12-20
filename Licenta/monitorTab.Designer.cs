using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Licenta
{
    partial class monitorTab
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
        void monitorList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index != -5)
            {
                Graphics g = e.Graphics;
                Dictionary<string, object> props = (this.monitorList.Items[e.Index] as Dictionary<string, object>);
                SolidBrush backgroundBrush = new SolidBrush(props.ContainsKey("BackColor") ? (Color)props["BackColor"] : e.BackColor);
                SolidBrush foregroundBrush = new SolidBrush(props.ContainsKey("ForeColor") ? (Color)props["ForeColor"] : e.ForeColor);
                Font textFont = props.ContainsKey("Font") ? (Font)props["Font"] : e.Font;
                string text = props.ContainsKey("Text") ? (string)props["Text"] : string.Empty;
                RectangleF rectangle = new RectangleF(new PointF(e.Bounds.X, e.Bounds.Y), new SizeF(e.Bounds.Width, g.MeasureString(text, textFont).Height));

                g.FillRectangle(backgroundBrush, rectangle);
                g.DrawString(text, textFont, foregroundBrush, rectangle);

                backgroundBrush.Dispose();
                foregroundBrush.Dispose();
                g.Dispose();
            }
        }
        private void InitializeComponent()
        {
            this.monitorList = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monitorList
            // 
            this.monitorList.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monitorList.FormattingEnabled = true;
            this.monitorList.ItemHeight = 16;
            this.monitorList.Location = new System.Drawing.Point(15, 41);
            this.monitorList.Name = "monitorList";
            this.monitorList.Size = new System.Drawing.Size(541, 308);
            this.monitorList.TabIndex = 0;
            this.monitorList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            //this.monitorList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            //this.monitorList.DrawItem += new DrawItemEventHandler(monitorList_DrawItem);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(205, 354);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "*right-click detection to delete";
            // 
            // monitorTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(221)))), ((int)(((byte)(223)))));
            this.Controls.Add(this.label8);
            this.Controls.Add(this.monitorList);
            this.Name = "monitorTab";
            this.Size = new System.Drawing.Size(570, 380);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox monitorList;
        private System.Windows.Forms.Label label8;
    }
}
