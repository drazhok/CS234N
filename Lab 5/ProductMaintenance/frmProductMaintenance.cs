using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerMaintenance;

namespace ProductMaintenance
{
    public partial class frmProductMaintenance : Form
    {
        private Product product;

        public frmProductMaintenance()
        {
            InitializeComponent();
        }

        // Unfortunately, I can't make the existing code any better,
        // so everything here is basically just the code from
        // frmCustomerMaintenance.
        private void GetProductButton_Click(object sender, EventArgs e)
        {
            if(Validator.IsPresent(ProductCodeTextBox))
            {
                string productCode = ProductCodeTextBox.Text;

                GetProduct(productCode);

                if (product == null)
                {
                    MessageBox.Show(@"
                        No product was found with this product code.
                        Try again, please.
                    ", "Product not found");

                    ClearControls();
                }

                else DisplayProduct();
            }
        }

        private void GetProduct(string productCode)
        {
            try
            {
                product = ProductDB.GetProduct(productCode);
            }
            
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearControls()
        {
            ProductCodeTextBox.Text = "";
            DescriptionTextBox.Text = "";
            UnitPriceTextBox.Text = "";
            OnHandQuantityTextBox.Text = "";
            ModifyButton.Enabled = false;
            DeleteButton.Enabled = false;
            ProductCodeTextBox.Select();
        }

        private void DisplayProduct()
        {
            DescriptionTextBox.Text = product.Description;
            UnitPriceTextBox.Text = product.UnitPrice.ToString("c");
            OnHandQuantityTextBox.Text = product.OnHandQuantity.ToString();
            ModifyButton.Enabled = true;
            DeleteButton.Enabled = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            frmAddModifyProduct addProductForm = new frmAddModifyProduct();

            addProductForm.addProduct = true;

            DialogResult result = addProductForm.ShowDialog();

            if(result == DialogResult.OK)
            {
                product = addProductForm.product;

                ProductCodeTextBox.Text = product.ProductCode.ToString();
                DisplayProduct();
            }
        }

        private void ModifyButton_Click(object sender, EventArgs e)
        {
            frmAddModifyProduct modifyProductForm = new frmAddModifyProduct();

            modifyProductForm.addProduct = false;
            modifyProductForm.product = product;

            DialogResult result = modifyProductForm.ShowDialog();

            if(result == DialogResult.OK)
            {
                product = modifyProductForm.product;
                DisplayProduct();
            }
            else if(result == DialogResult.Retry)
            {
                GetProduct(product.ProductCode);

                if (product != null)
                    DisplayProduct();

                else
                    ClearControls();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete Product " + product.ProductCode + "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                try
                {
                    if (!ProductDB.DeleteProduct(product))
                    {
                        MessageBox.Show("Another user has updated or deleted that product.", "Database Error");

                        GetProduct(product.ProductCode);

                        if (product != null)
                            DisplayProduct();

                        else
                            ClearControls();
                    }

                    else ClearControls();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
