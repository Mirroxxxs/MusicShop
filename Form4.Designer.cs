namespace MusicShop
{
    partial class Form4
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
            this.buttonReport = new System.Windows.Forms.Button();
            this.buttonSales = new System.Windows.Forms.Button();
            this.buttonCategories = new System.Windows.Forms.Button();
            this.buttonProducts = new System.Windows.Forms.Button();
            this.End = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(1014, 137);
            this.buttonReport.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(150, 40);
            this.buttonReport.TabIndex = 6;
            this.buttonReport.Text = "Отчет";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // buttonSales
            // 
            this.buttonSales.Location = new System.Drawing.Point(808, 137);
            this.buttonSales.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSales.Name = "buttonSales";
            this.buttonSales.Size = new System.Drawing.Size(150, 40);
            this.buttonSales.TabIndex = 5;
            this.buttonSales.Text = "Продажи";
            this.buttonSales.UseVisualStyleBackColor = true;
            this.buttonSales.Click += new System.EventHandler(this.buttonSales_Click);
            // 
            // buttonCategories
            // 
            this.buttonCategories.Location = new System.Drawing.Point(597, 137);
            this.buttonCategories.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCategories.Name = "buttonCategories";
            this.buttonCategories.Size = new System.Drawing.Size(150, 40);
            this.buttonCategories.TabIndex = 3;
            this.buttonCategories.Text = "Категории";
            this.buttonCategories.UseVisualStyleBackColor = true;
            this.buttonCategories.Click += new System.EventHandler(this.buttonCategories_Click);
            // 
            // buttonProducts
            // 
            this.buttonProducts.Location = new System.Drawing.Point(387, 137);
            this.buttonProducts.Margin = new System.Windows.Forms.Padding(2);
            this.buttonProducts.Name = "buttonProducts";
            this.buttonProducts.Size = new System.Drawing.Size(150, 40);
            this.buttonProducts.TabIndex = 2;
            this.buttonProducts.Text = "Товары";
            this.buttonProducts.UseVisualStyleBackColor = true;
            this.buttonProducts.Click += new System.EventHandler(this.buttonProducts_Click);
            // 
            // End
            // 
            this.End.Location = new System.Drawing.Point(674, 355);
            this.End.Margin = new System.Windows.Forms.Padding(2);
            this.End.Name = "End";
            this.End.Size = new System.Drawing.Size(150, 40);
            this.End.TabIndex = 7;
            this.End.Text = "Выйти";
            this.End.UseVisualStyleBackColor = true;
            this.End.Click += new System.EventHandler(this.End_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1484, 611);
            this.Controls.Add(this.End);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.buttonSales);
            this.Controls.Add(this.buttonProducts);
            this.Controls.Add(this.buttonCategories);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Button buttonSales;
        private System.Windows.Forms.Button buttonCategories;
        private System.Windows.Forms.Button buttonProducts;
        private System.Windows.Forms.Button End;
    }
}