using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using ToolsCSharp;

using DBDataReader = System.Data.SqlClient.SqlDataReader;

namespace EventPropsClasses
{
    [Serializable()]
    public class CustomerProps : IBaseProps
    {

        #region instance variables
        public int ID = Int32.MinValue;
        public string name = "";
        public string address = "";
        public string city = "";
        public string state = "";
        public string zip = "";

        /// <summary>
        /// ConcurrencyID. See main docs, don't manipulate directly
        /// </summary>
        public int ConcurrencyID = 0;
        #endregion

        #region constructor
        /// <summary>
        /// Constructor. This object should only be instantiated by Customer, not used directly.
        /// </summary>
        public CustomerProps()
        {
        }

        #endregion

        #region BaseProps Members
        /// <summary>
        /// Serializes this props object to XML, and writes the key-value pairs to a string.
        /// </summary>
        /// <returns>String containing key-value pairs</returns>	
        public string GetState()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, this);
            return writer.GetStringBuilder().ToString();
        }

        // I don't always want to generate xml in the db class so the 
        // props class can read in from xml
        public void SetState(DBDataReader dr)
        {
            this.ID = (Int32)dr["CustomerID"];
            this.name = (string)dr["name"];
            this.address = (string)dr["address"];
            this.city = (string)dr["city"];
            this.state = (string)dr["state"];
            this.zip = (string)dr["zipcode"];
            this.ConcurrencyID = (Int32)dr["ConcurrencyID"];
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetState(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            StringReader reader = new StringReader(xml);
            CustomerProps p = (CustomerProps)serializer.Deserialize(reader);
            this.ID = p.ID;
            this.name = p.name;
            this.address = p.address;
            this.city = p.city;
            this.state = p.state;
            this.zip = p.zip;
            this.ConcurrencyID = p.ConcurrencyID;
        }
        #endregion

        #region ICloneable Members
        /// <summary>
        /// Clones this object.
        /// </summary>
        /// <returns>A clone of this object.</returns>
        public Object Clone()
        {
            CustomerProps p = new CustomerProps();
            p.ID = this.ID;
            p.name = this.name;
            p.address = this.address;
            p.city = this.city;
            p.state = this.state;
            p.zip = this.zip;
            p.ConcurrencyID = this.ConcurrencyID;
            return p;
        }
        #endregion

    }
}
