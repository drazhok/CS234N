namespace ProductMaintenance
{
    partial class frmProductMaintenance
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
            this.OnHandQuantityTextBox = new System.Windows.Forms.TextBox();
            this.UnitPriceTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.ProductCodeTextBox = new System.Windows.Forms.TextBox();
            this.UnitPriceLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.ProductCodeLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.GetProductButton = new System.Windows.Forms.Button();
            this.ModifyButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.OnHandQuantityLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OnHandQuantityTextBox
            // 
            this.OnHandQuantityTextBox.Location = new System.Drawing.Point(355, 66);
            this.OnHandQuantityTextBox.Name = "OnHandQuantityTextBox";
            this.OnHandQuantityTextBox.ReadOnly = true;
            this.OnHandQuantityTextBox.Size = new System.Drawing.Size(75, 20);
            this.OnHandQuantityTextBox.TabIndex = 18;
            // 
            // UnitPriceTextBox
            // 
            this.UnitPriceTextBox.Location = new System.Drawing.Point(76, 64);
            this.UnitPriceTextBox.Name = "UnitPriceTextBox";
            this.UnitPriceTextBox.ReadOnly = true;
            this.UnitPriceTextBox.Size = new System.Drawing.Size(54, 20);
            this.UnitPriceTextBox.TabIndex = 17;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(76, 38);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.ReadOnly = true;
            this.DescriptionTextBox.Size = new System.Drawing.Size(354, 20);
            this.DescriptionTextBox.TabIndex = 16;
            // 
            // ProductCodeTextBox
            // 
            this.ProductCodeTextBox.Location = new System.Drawing.Point(76, 12);
            this.ProductCodeTextBox.Name = "ProductCodeTextBox";
            this.ProductCodeTextBox.Size = new System.Drawing.Size(54, 20);
            this.ProductCodeTextBox.TabIndex = 15;
            // 
            // UnitPriceLabel
            // 
            this.UnitPriceLabel.AutoSize = true;
            this.UnitPriceLabel.Location = new System.Drawing.Point(15, 69);
            this.UnitPriceLabel.Name = "UnitPriceLabel";
            this.UnitPriceLabel.Size = new System.Drawing.Size(56, 13);
            this.UnitPriceLabel.TabIndex = 14;
            this.UnitPriceLabel.Text = "Unit Price:";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(8, 41);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.DescriptionLabel.TabIndex = 13;
            this.DescriptionLabel.Text = "Description:";
            // 
            // ProductCodeLabel
            // 
            this.ProductCodeLabel.AutoSize = true;
            this.ProductCodeLabel.Location = new System.Drawing.Point(35, 15);
            this.ProductCodeLabel.Name = "ProductCodeLabel";
            this.ProductCodeLabel.Size = new System.Drawing.Size(35, 13);
            this.ProductCodeLabel.TabIndex = 12;
            this.ProductCodeLabel.Text = "Code:";
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(355, 98);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 11;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(11, 98);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 10;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // GetProductButton
            // 
            this.GetProductButton.Location = new System.Drawing.Point(136, 10);
            this.GetProductButton.Name = "GetProductButton";
            this.GetProductButton.Size = new System.Drawing.Size(111, 23);
            this.GetProductButton.TabIndex = 19;
            this.GetProductButton.Text = "Get Product";
            this.GetProductButton.UseVisualStyleBackColor = true;
            this.GetProductButton.Click += new System.EventHandler(this.GetProductButton_Click);
            // 
            // ModifyButton
            // 
            this.ModifyButton.Location = new System.Drawing.Point(92, 98);
            this.ModifyButton.Name = "ModifyButton";
            this.ModifyButton.Size = new System.Drawing.Size(75, 23);
            this.ModifyButton.TabIndex = 20;
            this.ModifyButton.Text = "Modify";
            this.ModifyButton.UseVisualStyleBackColor = true;
            this.ModifyButton.Click += new System.EventHandler(this.ModifyButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(172, 98);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 21;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // OnHandQuantityLabel
            // 
            this.OnHandQuantityLabel.AutoSize = true;
            this.OnHandQuantityLabel.Location = new System.Drawing.Point(300, 69);
            this.OnHandQuantityLabel.Name = "OnHandQuantityLabel";
            this.OnHandQuantityLabel.Size = new System.Drawing.Size(49, 13);
            this.OnHandQuantityLabel.TabIndex = 22;
            this.OnHandQuantityLabel.Text = "Quantity:";
            // 
            // frmProductMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 131);
            this.Controls.Add(this.OnHandQuantityLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.ModifyButton);
            this.Controls.Add(this.GetProductButton);
            this.Controls.Add(this.OnHandQuantityTextBox);
            this.Controls.Add(this.UnitPriceTextBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.ProductCodeTextBox);
            this.Controls.Add(this.UnitPriceLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.ProductCodeLabel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.AddButton);
            this.Name = "frmProductMaintenance";
            this.Text = "Product Maintenance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OnHandQuantityTextBox;
        private System.Windows.Forms.TextBox UnitPriceTextBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.TextBox ProductCodeTextBox;
        private System.Windows.Forms.Label UnitPriceLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label ProductCodeLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button GetProductButton;
        private System.Windows.Forms.Button ModifyButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label OnHandQuantityLabel;
    }
}