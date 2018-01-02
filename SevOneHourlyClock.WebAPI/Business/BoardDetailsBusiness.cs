using SevOneHourlyClock.WebAPI.Commmon;
using SevOneHourlyClock.WebAPI.Models;
using SevOneHourlyClock.WebAPI.Persistense;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Web;

namespace SevOneHourlyClock.WebAPI.Bussiness
{
    public class BoardDetailsBusiness
    {
        private readonly BoardDetailsPersistense _boardDetailsPersistense;

        public BoardDetailsBusiness()
        {
            this._boardDetailsPersistense = new BoardDetailsPersistense();
        }

        public IReadOnlyCollection<BoardDetails> GetBoardList(int mngrNum = 0, int skipRow = 0, int takerow = 999)
        {
            var dtClockList = this._boardDetailsPersistense.GetBoardList(mngrNum, skipRow, takerow);
            if (dtClockList.Rows.Count > 0)
            {

                return (from DataRow dr in dtClockList.Rows
                        select new BoardDetails()
                        {
                            Title = dr["Title"].ToString(),
                            IncidentNumber = dr["IncidentNumber"].ToString(),
                            Severity = dr["Severity"].ToString(),
                            TechBridgeName = dr["TechBridgeName"]?.ToString(),
                            TechLead = dr["TechLead"]?.ToString(),
                            AssignedAccount = dr["AssignedAccount"].ToString(),
                            AssignedAccountId = dr["AssignedAccountId"].ToString(),
                            AssignedAccountName = dr["AssignedAccountName"].ToString(),
                            SkypeLink = dr["SkypeLink"]?.ToString(),
                            Summary = dr["Description"].ToString(),
                            StartDate = ((DateTime)dr["StartDate"]).ToEST(),
                            RemainingSeconds = ((DateTime)dr["StartDate"]).ToRemainSeconds(),
                            ConferenceNumber = dr["ConferenceNumber"]?.ToString(),
                            TotalRows = int.Parse(dr["TotalRows"].ToString())

                        }).ToList().AsReadOnly();
            }

            return new ReadOnlyCollection<BoardDetails>(new List<BoardDetails>());

        }   

        

    }
}