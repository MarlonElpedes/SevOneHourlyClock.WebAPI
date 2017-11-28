using SevOneHourlyClock.WebAPI.Commmon;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SevOneHourlyClock.WebAPI.Persistense
{
    public class csBackend
    {
        public void clsConnOpen()
        {
            clsException.Init();
            try
            {
                if (clsException.exConnBackEnd.State != ConnectionState.Open)
                    clsException.exConnBackEnd.Open();
            }
            catch (Exception strEx)
            {
                clsException.strException = "DB Connection error. " + strEx.Message;
            }
        }

        public void clsConnClose()
        {
            try
            {
                if (clsException.exConnBackEnd != null && clsException.exConnBackEnd.State == ConnectionState.Open)
                    clsException.exConnBackEnd.Close();
            }
            catch (Exception strEx)
            {
                clsException.strException = "DB Connection error. " + strEx.Message;
            }

        }
        public SqlDataReader clsExecQuery(SqlCommand sqlCommQuery)
        {
            SqlDataReader dataSql;

            try
            {
                sqlCommQuery.Connection = clsException.exConnBackEnd;
                dataSql = sqlCommQuery.ExecuteReader();
                return dataSql;

            }
            catch (Exception strEx)
            {
                clsException.strException = "DB error. " + strEx.Message;
                return null;
            }

        }
    }
}