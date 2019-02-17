using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Calc
{
    public enum Operation
    {
        Add = '+',
        Subtract = '-',
        Multipy = '*',
        Divide = '/',
        Pow = '^',
        ErrorOperation
    }

    class Calc
    {
        static void Main(string[] args)
        {
            var exit = "";

            var connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = @"pcp-000463";
            connectionStringBuilder.InitialCatalog = "TestDB";
            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.Pooling = true;

            var dal = new TestDBDAL();
            CalcModel calcModel = new CalcModel();
            CalcView calcView = new CalcView();
            CalcController calcController = new CalcController(calcModel, calcView);
            while (exit != "exit")
            {
                dal.OpenConnection(connectionStringBuilder.ConnectionString);
                if (calcController.Update())
                {
                    dal.InsertResults(calcModel);
                    dal.InsertLogs(DateTime.Now, "Calculation successful", "S");
                }
                else
                {
                    dal.InsertLogs(DateTime.Now, "Calculation error", "Error");
                }
                calcController.ClearModel(calcModel);
                dal.CloseConnection();
                Console.WriteLine("Enter \"exit\" to exit program or anykey for continue");
                exit = Console.ReadLine();
            }
        }
    }
}
