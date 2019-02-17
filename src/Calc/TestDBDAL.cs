using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Calc
{
    public class TestDBDAL
    {
        private SqlConnection connection = null;
        
        public void OpenConnection(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public void InsertLogs(DateTime dateLog, string message, string messageType)
        {
            string sql = "Insert Into Logs (DateLog, Message, MessageType) Values (@DateLog, @Message, @MessageType)";

            using (SqlCommand cmd = new SqlCommand(sql, this.connection))
            {
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@DateLog";
                parameter.Value = dateLog;
                parameter.SqlDbType = SqlDbType.DateTime;
                cmd.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@Message";
                parameter.Value = message;
                parameter.SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@MessageType";
                parameter.Value = messageType;
                parameter.SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.Add(parameter);

                cmd.ExecuteNonQuery();
            }
        }

        public void InsertResults(CalcModel calcModel)
        {
            string sql = "Insert Into Results" +
                "(FirstOperand, SecondOperand, Operation, Result) Values (@FirstOperand, @SecondOperand, @Operation, @Result)";

            using (SqlCommand cmd = new SqlCommand(sql, this.connection))
            {
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@FirstOperand";
                parameter.Value = calcModel.FirstOperand;
                parameter.SqlDbType = SqlDbType.Float;
                cmd.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@SecondOperand";
                parameter.Value = calcModel.SecondOperand;
                parameter.SqlDbType = SqlDbType.Float;
                cmd.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@Operation";
                parameter.Value = Enum.GetName(typeof(Operation), calcModel.Operation);
                parameter.SqlDbType = SqlDbType.Text;
                cmd.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@Result";
                parameter.Value = calcModel.Result;
                parameter.SqlDbType = SqlDbType.Float;
                cmd.Parameters.Add(parameter);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
