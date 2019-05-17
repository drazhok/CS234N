namespace ProductMaintenance
{
    partial class frmAddModifyProduct
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
            this.AcceptButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ProductCodeLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.UnitPriceLabel = new System.Windows.Forms.Label();
            this.OnHandQuantityLabel = new System.Windows.Forms.Label();
            this.ProductCodeTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.UnitPriceTextBox = new System.Windows.Forms.TextBox();
            this.OnHandQuantityTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(12, 92);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptButton.TabIndex = 0;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(262, 92);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // ProductCodeLabel
            // 
            this.ProductCodeLabel.AutoSize = true;
            this.ProductCodeLabel.Location = new System.Drawing.Point(36, 9);
            this.ProductCodeLabel.Name = "ProductCodeLabel";
            this.ProductCodeLabel.Size = new System.Drawing.Size(35, 13);
            this.ProductCodeLabel.TabIndex = 2;
            this.ProductCodeLabel.Text = "Code:";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(9, 35);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.DescriptionLabel.TabIndex = 3;
            this.DescriptionLabel.Text = "Description:";
            // 
            // UnitPriceLabel
            // 
            this.UnitPriceLabel.AutoSize = true;
            this.UnitPriceLabel.Location = new System.Drawing.Point(16, 63);
            this.UnitPriceLabel.Name = "UnitPriceLabel";
            this.UnitPriceLabel.Size = new System.Drawing.Size(56, 13);
            this.UnitPriceLabel.TabIndex = 4;
            this.UnitPriceLabel.Text = "Unit Price:";
            // 
            // OnHandQuantityLabel
            // 
            this.OnHandQuantityLabel.AutoSize = true;
            this.OnHandQuantityLabel.Location = new System.Drawing.Point(207, 63);
            this.OnHandQuantityLabel.Name = "OnHandQuantityLabel";
            this.OnHandQuantityLabel.Size = new System.Drawing.Size(49, 13);
            this.OnHandQuantityLabel.TabIndex = 5;
            this.OnHandQuantityLabel.Text = "Quantity:";
            // 
            // ProductCodeTextBox
            // 
            this.ProductCodeTextBox.Location = new System.Drawing.Point(77, 6);
            this.ProductCodeTextBox.Name = "ProductCodeTextBox";
            this.ProductCodeTextBox.Size = new System.Drawing.Size(54, 20);
            this.ProductCodeTextBox.TabIndex = 6;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(77, 32);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(260, 20);
            this.DescriptionTextBox.TabIndex = 7;
            // 
            // UnitPriceTextBox
            // 
            this.UnitPriceTextBox.Location = new System.Drawing.Point(77, 58);
            this.UnitPriceTextBox.Name = "UnitPriceTextBox";
            this.UnitPriceTextBox.Size = new System.Drawing.Size(54, 20);
            this.UnitPriceTextBox.TabIndex = 8;
            // 
            // OnHandQuantityTextBox
            // 
            this.OnHandQuantityTextBox.Location = new System.Drawing.Point(262, 60);
            this.OnHandQuantityTextBox.Name = "OnHandQuantityTextBox";
            this.OnHandQuantityTextBox.Size = new System.Drawing.Size(75, 20);
            this.OnHandQuantityTextBox.TabIndex = 9;
            // 
            // frmAddModifyProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 124);
            this.Controls.Add(this.OnHandQuantityTextBox);
            this.Controls.Add(this.UnitPriceTextBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.ProductCodeTextBox);
            this.Controls.Add(this.OnHandQuantityLabel);
            this.Controls.Add(this.UnitPriceLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.ProductCodeLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AcceptButton);
            this.Name = "frmAddModifyProduct";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label ProductCodeLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label UnitPriceLabel;
        private System.Windows.Forms.Label OnHandQuantityLabel;
        private System.Windows.Forms.TextBox ProductCodeTextBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.TextBox UnitPriceTextBox;
        private System.Windows.Forms.TextBox OnHandQuantityTextBox;
    }
}

