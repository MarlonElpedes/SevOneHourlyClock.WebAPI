using SevOneHourlyClock.WebAPI.Commmon;
using SevOneHourlyClock.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SevOneHourlyClock.WebAPI.Persistense
{
    public class BoardDetailsPersistense
    {
        csBackend qryExecQuery;
        SqlDataReader rdrSQLRecords;

        public BoardDetailsPersistense()
        {
            qryExecQuery = new csBackend();
            qryExecQuery.clsConnClose();
            qryExecQuery.clsConnOpen();
        }
        
        public DataTable GetBoardList(int mngrNum = 0, int skipRow = 0, int takerow = 999)
        {
            SqlCommand commFetchClockList = new SqlCommand();
            DataTable dtClockList = new DataTable();
            commFetchClockList.CommandText = "procFetchActiveBoardList";
            commFetchClockList.Parameters.AddWithValue("@MngrNUm", mngrNum);
            commFetchClockList.Parameters.AddWithValue("@SkipRows", skipRow);
            commFetchClockList.Parameters.AddWithValue("@TakeRows", takerow);
            commFetchClockList.CommandType = CommandType.StoredProcedure;

            try
            {
                rdrSQLRecords = qryExecQuery.clsExecQuery(commFetchClockList);            
                dtClockList.Load(rdrSQLRecords);
            }
            catch (Exception strEx)
            {
                clsException.strException = "Query error. " + strEx.Message;
            }
            finally
            {
                rdrSQLRecords.Close();
            }
                    
            return dtClockList;

        }
    }
}