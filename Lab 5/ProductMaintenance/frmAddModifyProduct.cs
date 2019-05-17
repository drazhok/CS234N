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
    public partial class frmAddModifyProduct : Form
    {
        public bool addProduct;
        public Product product;
        public frmAddModifyProduct()
        {
            InitializeComponent();

            if (addProduct)
                this.Text = "Add Product";

            else
                this.Text = "Modify Product";
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (addProduct)
                {
                    product = new Product();

                    PutProductData(product);

                    if (ProductDB.AddProduct(product))
                        this.DialogResult = DialogResult.OK;

                    else
                        this.DialogResult = DialogResult.Abort;
                }

                else
                {
                    Product newProduct = new Product();
                    newProduct.ProductCode = product.ProductCode;
                    this.PutProductData(newProduct);

                    try
                    {
                        if(!ProductDB.UpdateProduct(product, newProduct))
                        {
                            MessageBox.Show("Another user has updated or deleted that customer.", "Database Error");
                            this.DialogResult = DialogResult.Retry;
                        }

                        else
                        {
                            product = newProduct;
                            this.DialogResult = DialogResult.OK;
                        }
                    }

                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private bool IsValidData()
        {
            return
                Validator.IsPresent(ProductCodeTextBox) &&
                Validator.IsPresent(DescriptionTextBox) &&
                Validator.IsPresent(UnitPriceTextBox) &&
                Validator.IsPresent(OnHandQuantityTextBox);
        }

        private void PutProductData(Product newProduct)
        {
            product.ProductCode = ProductCodeTextBox.Text;
            product.Description = DescriptionTextBox.Text;

            try
            {
                product.UnitPrice = Decimal.Parse(UnitPriceTextBox.Text);
            }

            catch
            {
                MessageBox.Show("Invalid input for UnitPrice.", "Input Error");
            }

            try
            {
                product.OnHandQuantity = int.Parse(OnHandQuantityTextBox.Text);
            }

            catch
            {
                MessageBox.Show("Invalid input for on hand quantity.", "Input Error");
            }
        }
    }
}
