using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToolsCSharp;
using EventPropsClasses;

using ProductDB = EventDBClasses.ProductSQLDB;

namespace EventClasses
{
    public class Product : BaseBusiness
    {
        #region Instance Variables
        string code;
        string description;
        decimal unitPrice;
        int quantity;
        #endregion

        #region Setup
        public override object GetList()
        {
            List<Product> products = new List<Product>();
            List<ProductProps> props = new List<ProductProps>();
        }

        protected override void SetDefaultProperties()
        {
        }

        protected override void SetRequiredRules()
        {
            mRules.RuleBroken("code", true);
            mRules.RuleBroken("description", true);
            mRules.RuleBroken("unitPrice", true);
            mRules.RuleBroken("quantity", true);
        }

        protected override void SetUp()
        {
            mProps = new ProductProps();
            mOldProps = new ProductProps();

            if (this.mConnectionString == "")
            {
                mdbReadable = new ProductDB();
                mdbWriteable = new ProductDB();
            }

            else
            {
                mdbReadable = new ProductDB(this.mConnectionString);
                mdbWriteable = new ProductDB(this.mConnectionString);
            }
        }
        #endregion

        #region Constructors
        public Product() : base() { }
        public Product(string cnString) : base(cnString) { }
        public Product(int key, string cnString) : base(key, cnString){}
        public Product(int key) : base(key){}
        #endregion

        #region Properties
        public string Code
        {
            get => (((ProductProps)mProps).code);

            set
            {
                if (!(value == ((ProductProps)mProps).code))
                {
                    if(value.Length >= 1 && value.Length <= 10)
                    {
                        mRules.RuleBroken("code", false);
                        ((ProductProps)mProps).code = value;
                        mIsDirty = true;
                    }

                    else
                        throw new ArgumentException("ProductCode must be between 1 and 10 characters.");
                }
            }
        }

        public string Description
        {
            get => (((ProductProps)mProps).description);

            set
            {
                if(!(value == ((ProductProps)mProps).description))
                {
                    if (value.Length >= 1 && value.Length <= 50)
                    {
                        mRules.RuleBroken("description", false);
                        ((ProductProps)mProps).description = value;
                        mIsDirty = true;
                    }

                    else
                        throw new ArgumentException("The description must be between 1 and 50 characters.");
                }
            }
        }

        public decimal UnitPrice
        {
            get => (((ProductProps)mProps).unitPrice);

            set
            {
                if(!(value == ((ProductProps)mProps).unitPrice))
                {
                    if (value > 0)
                    {
                        mRules.RuleBroken("unitPrice", false);
                        ((ProductProps)mProps).unitPrice = value;
                        mIsDirty = true;
                    }

                    else
                        throw new ArgumentException("What do you think we are, a charity?");
                }
            }
        }

        public int Quantity
        {
            get => (((ProductProps)mProps).quantity);

            set
            {
                if(!(value == ((ProductProps)mProps).quantity))
                {
                    if (value >= 0)
                    {
                        mRules.RuleBroken("quantity", false);
                        ((ProductProps)mProps).quantity = value;
                        mIsDirty = true;
                    }

                    else
                        throw new ArgumentException("We can't have a negative amount of a product!");
                }
            }
        }
        #endregion
    }
}
