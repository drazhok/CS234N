using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using DBBase = ToolsCSharp.BaseSQLDB;
using DBConnection = System.Data.SqlClient.SqlConnection;
using DBCommand = System.Data.SqlClient.SqlCommand;
using DBParameter = System.Data.SqlClient.SqlParameter;
using DBDataReader = System.Data.SqlClient.SqlDataReader;
using DBDataAdapter = System.Data.SqlClient.SqlDataAdapter;

using ToolsCSharp;
using EventPropsClasses;

namespace EventDBClasses
{
    public class ProductSQLDB : DBBase, IReadDB, IWriteDB
    {
        #region Constructors
        public ProductSQLDB() : base(){}
        public ProductSQLDB(string conString) : base(conString){}
        public ProductSQLDB(DBConnection con) : base(con){}
        #endregion

        public IBaseProps Retrieve(Object key)
        {
            DBDataReader data = null;
            ProductProps props = new ProductProps();
            DBCommand command = new DBCommand();

            command.CommandText = "usp_ProductSelect";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@ProductID", SqlDbType.Int);
            command.Parameters["@ProductID"].Value = (Int32)key;

            try
            {
                data = RunProcedure(command);

                if (!data.IsClosed)
                {
                    if (data.Read())
                        props.SetState(data);

                    else
                        throw new Exception("Record doesn't exist in the database.");
                }

                return props;
            }

            catch(Exception e)
            {
                throw;
            }

            finally
            {
                if(data != null)
                {
                    if (!data.IsClosed)
                        data.Close();
                }
            }
        }

        public object RetrieveAll(Type type)
        {
            throw new NotImplementedException();
        }

        public IBaseProps Create(IBaseProps props)
        {
            throw new NotImplementedException();
        }

        public bool Update(IBaseProps props)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IBaseProps props)
        {
            throw new NotImplementedException();
        }
    }
}
