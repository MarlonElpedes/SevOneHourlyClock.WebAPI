using SevOneHourlyClock.WebAPI.Bussiness;
using SevOneHourlyClock.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SevOneHourlyClock.WebAPI.Controllers
{
    public class DashBoardValuesController : ApiController
    {
        private readonly BoardDetailsBusiness _boardDetailsBusiness;

        private DashBoardValuesController()
        {
            this._boardDetailsBusiness = new BoardDetailsBusiness();
        }

        // GET api/<controller>
        public IEnumerable<BoardDetails> Get(int managerId, int skipNum, int TakeNum)
        {
            return this._boardDetailsBusiness.GetBoardList(managerId, skipNum, TakeNum);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}