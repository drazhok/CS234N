using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsCSharp;

using EventPropsClasses;
using CustomerDB = EventDBClasses.CustomerSQLDB;
using System.Data;

namespace EventClasses
{
    public class Customer : BaseBusiness
    {
        #region Instance Variables
        string name;
        string address;
        string city;
        string state;
        string zip;
        #endregion

        #region Setup
        public override object GetList()
        {
            List<Customer> customers = new List<Customer>();
            List<CustomerProps> props = new List<CustomerProps>();


            props = (List<CustomerProps>)mdbReadable.RetrieveAll(props.GetType());
            foreach (CustomerProps prop in props)
            {
                Customer e = new Customer(prop, this.mConnectionString);
                customers.Add(e);
            }

            return customers;
        }

        protected override void SetDefaultProperties()
        {
            throw new NotImplementedException();
        }

        protected override void SetRequiredRules()
        {
            mRules.RuleBroken("name", true);
            mRules.RuleBroken("address", true);
            mRules.RuleBroken("city", true);
            mRules.RuleBroken("state", true);
            mRules.RuleBroken("zipcode", true);
        }

        protected override void SetUp()
        {
            mProps = new CustomerProps();
            mOldProps = new CustomerProps();

            if (this.mConnectionString == "")
            {
                mdbReadable = new CustomerDB();
                mdbWriteable = new CustomerDB();
            }

            else
            {
                mdbReadable = new CustomerDB(this.mConnectionString);
                mdbWriteable = new CustomerDB(this.mConnectionString);
            }
        }
        #endregion

        #region Constructors
        public Customer() : base(){}

        public Customer(string cnString) : base(cnString){}

        public Customer(int key, string cnString) : base(key, cnString){}

        public Customer(int key) : base(key){}

        public Customer(CustomerProps props) : base(props){}

        public Customer(CustomerProps props, string cnString) : base(props, cnString){}
        #endregion

        #region Properties
        public int ID => ((CustomerProps)mProps).ID;

        public string Name
        {
            get => (((CustomerProps)mProps).name);

            set
            {
                if (!(value == ((CustomerProps)mProps).name))
                {
                    if(value.Length >= 1 && value.Length <= 100)
                    {
                        mRules.RuleBroken("name", false);
                        ((CustomerProps)mProps).name = value;
                        mIsDirty = true;
                    }




                    else
                        throw new ArgumentException("Name must be between 1 and 100 characters.");
                }
            }
        }

        public string Address
        {
            get => (((CustomerProps)mProps).address);

            set
            {
                if (!(value == ((CustomerProps)mProps).address))
                {
                    if (value.Length >= 1 && value.Length <= 50)
                    {
                        mRules.RuleBroken("address", false);
                        ((CustomerProps)mProps).address = value;
                        mIsDirty = true;
                    }

                    else
                        throw new ArgumentException("Address must be between 1 and 50 characters.");
                }
            }
        }

        public string City
        {
            get => (((CustomerProps)mProps).city);

            set
            {
                if (!(value == ((CustomerProps)mProps).city))
                {
                    if (value.Length >= 1 && value.Length <= 20)
                    {
                        mRules.RuleBroken("city", false);
                        ((CustomerProps)mProps).city = value;
                        mIsDirty = true;
                    }

                    else
                        throw new ArgumentException("City must be between 1 and 20 characters.");
                }
            }
        }

        public string State
        {
            get => (((CustomerProps)mProps).state);

            set
            {
                if (!(value == ((CustomerProps)mProps).state))
                {
                    if (value.Length == 2)
                    {
                        mRules.RuleBroken("state", false);
                        ((CustomerProps)mProps).state = value.ToUpper();
                        mIsDirty = true;
                    }

                    else
                        throw new ArgumentException("State must be exactly 2 characters.");
                }
            }
        }

        public string ZipCode
        {
            get => (((CustomerProps)mProps).zip);

            set
            {
                if (!(value == ((CustomerProps)mProps).zip))
                {
                    if (value.Length >= 1 && value.Length <= 15)
                    {
                        mRules.RuleBroken("zip", false);
                        ((CustomerProps)mProps).zip = value;
                        mIsDirty = true;
                    }

                    else
                        throw new ArgumentException("Zip code must be between 1 and 15 characters.");
                }
            }
        }
        #endregion
    }
}
