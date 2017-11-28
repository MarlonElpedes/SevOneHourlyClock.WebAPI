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
                            Title = (string)dr["Title"],
                            IncidentNumber = (string)dr["IncidentNumber"],
                            Severity = (string)dr["Severity"],
                            TechOpBridge = (string)dr["TechOpBridge"],
                            IMTechLead = (string)dr["IMTechLead"],
                            Summary = (string)dr["Summary"],
                            StartDate = (DateTime)dr["StartDate"],
                            TotalRows = int.Parse(dr["TotalRows"].ToString())

                        }).ToList().AsReadOnly();
            }

            return new ReadOnlyCollection<BoardDetails>(new List<BoardDetails>());

        }
    }
}