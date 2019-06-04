using System;
using System.IO;
using System.Xml.Serialization;
using ToolsCSharp;
using DBDataReader = System.Data.SqlClient.SqlDataReader;

namespace EventPropsClasses
{
    [Serializable()]
    public class ProductProps : IBaseProps
    {
        #region Instance Variables
        public int ID = Int32.MinValue;
        public string code = "";
        public string description = "";
        public decimal unitPrice = 0;
        public int quantity = 0;

        public int ConID = 0;
        #endregion

        #region Constructor(s)
        public ProductProps(){}
        #endregion

        #region BaseProps Members
        public string GetState()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, this);
            return writer.GetStringBuilder().ToString();
        }

        public void SetState(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            StringReader reader = new StringReader(xml);
            ProductProps p = (ProductProps)serializer.Deserialize(reader);

            this.ID = p.ID;
            this.code = p.code;
            this.description = p.description;
            this.unitPrice = p.unitPrice;
            this.quantity = p.quantity;
            this.ConID = p.ConID;
        }

        public void SetState(DBDataReader dr)
        {
            this.ID = (Int32)dr["ProductID"];
            this.code = (string)dr["ProductCode"];
            this.description = (string)dr["Description"];
            this.unitPrice = (decimal)dr["UnitPrice"];
            this.quantity = (int)dr["OnHandQuantity"];
            this.ConID = (Int32)dr["ConcurrencyID"];
        }
        #endregion

        #region ICloneable Members
        public object Clone()
        {
            ProductProps p = new ProductProps();

            p.ID = this.ID;
            p.code = this.code;
            p.description = this.description;
            p.unitPrice = this.unitPrice;
            p.quantity = this.quantity;

            return p;
        }
        #endregion
    }
}
