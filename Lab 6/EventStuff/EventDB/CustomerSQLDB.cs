﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EventPropsClasses;
using ToolsCSharp;

using System.Data;
using System.Data.SqlClient;

// *** I use an "alias" for the ado.net classes throughout my code
// When I switch to an oracle database, I ONLY have to change the actual classes here
using DBBase = ToolsCSharp.BaseSQLDB;
using DBConnection = System.Data.SqlClient.SqlConnection;
using DBCommand = System.Data.SqlClient.SqlCommand;
using DBParameter = System.Data.SqlClient.SqlParameter;
using DBDataReader = System.Data.SqlClient.SqlDataReader;
using DBDataAdapter = System.Data.SqlClient.SqlDataAdapter;

namespace EventDBClasses
{
    public class CustomerSQLDB : DBBase, IReadDB, IWriteDB
    {
        #region Constructors
        public CustomerSQLDB() : base(){}
        public CustomerSQLDB(string conString) : base(conString){}
        public CustomerSQLDB(DBConnection con) : base(con){}
        #endregion

        public IBaseProps Create(IBaseProps props)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IBaseProps props)
        {
            DBCommand command = new DBCommand();

            command.CommandText = "usp_CustomerDelete";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CustomerID", SqlDbType.Int);
            command.Parameters["@CustomerID"].Value = ((CustomerProps)props).ID;

            try
            {
                int deleted = RunNonQueryProcedure(command);

                if (deleted == 1)
                    return true;

                else
                    throw new Exception("Record cannot be deleted. It has been edited by another user or does not exist.");
            }

            catch(Exception e)
            {
                throw;
            }

            finally
            {
                if (mConnection.State == ConnectionState.Open)
                    mConnection.Close();
            }
        }

        public IBaseProps Retrieve(Object key)
        {
            DBDataReader data = null;
            CustomerProps props = new CustomerProps();
            DBCommand command = new DBCommand();

            command.CommandText = "usp_CustomerSelect";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CustomerID", SqlDbType.Int);
            command.Parameters["@CustomerID"].Value = (Int32)key;

            try
            {
                data = RunProcedure(command);
                if (!data.IsClosed)
                {
                    if (data.Read())
                        props.SetState(data);

                    else
                        throw new Exception("Record does not exist in the database.");
                }
                return props;
            }

            catch (Exception e)
            {
                throw;
            }

            finally
            {
                if (data != null)
                {
                    if (!data.IsClosed)
                        data.Close();
                }
            }
        }

        public object RetrieveAll(Type type)
        {
            List<CustomerProps> list = new List<CustomerProps>();
            DBDataReader reader = null;
            CustomerProps props;

            try
            {
                reader = RunProcedure("usp_CustomerSelectAll");

                if (!reader.IsClosed)
                {
                    while (reader.Read())
                    {
                        props = new CustomerProps();
                        props.SetState(reader);
                        list.Add(props);
                    }
                }

                return list;
            }

            catch(Exception e)
            {
                throw;
            }

            finally
            {
                if (!reader.IsClosed)
                    reader.Close();
            }
        }

        public bool Update(IBaseProps p)
        {
            int rowsAffected = 0;
            CustomerProps props = (CustomerProps)p;

            DBCommand command = new DBCommand();

            command.CommandText = "usp_CustomerUpdate";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@CustomerID", SqlDbType.Int);
            command.Parameters.Add("@Name", SqlDbType.VarChar);
            command.Parameters.Add("@Address", SqlDbType.VarChar);
            command.Parameters.Add("@City", SqlDbType.VarChar);
            command.Parameters.Add("@State", SqlDbType.Char);
            command.Parameters.Add("@ZipCode", SqlDbType.Char);
            command.Parameters.Add("@ConcurrencyID", SqlDbType.Int);

            command.Parameters["@CustomerID"].Value = props.ID;
            command.Parameters["@Name"].Value = props.name;
            command.Parameters["@Address"].Value = props.address;
            command.Parameters["@City"].Value = props.city;
            command.Parameters["@State"].Value = props.state;
            command.Parameters["@ZipCode"].Value = props.zip;
            command.Parameters["@ConcurrencyID"].Value = props.ConcurrencyID;

            try
            {
                rowsAffected = RunNonQueryProcedure(command);

                if (rowsAffected == 1)
                {
                    props.ConcurrencyID++;
                    return true;
                }

                else
                {
                    string message = "Record cannot be updated. It has been edited by another user.";
                    throw new Exception(message);
                }
            }

            catch (Exception e)
            {
                throw;
            }

            finally
            {
                if (mConnection.State == ConnectionState.Open)
                    mConnection.Close();
            }
        }
    }
}
