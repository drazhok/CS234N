using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMaintenance
{
    public class Product
    {
        private string productCode;
        private string description;
        private decimal unitPrice;
        private int onHandQuantity;

        public string ProductCode
        {
            get => productCode;
            set => productCode = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public decimal UnitPrice
        {
            get => unitPrice;
            set => unitPrice = value;
        }

        public int OnHandQuantity
        {
            get => onHandQuantity;
            set => onHandQuantity = value;
        }
    }
}
