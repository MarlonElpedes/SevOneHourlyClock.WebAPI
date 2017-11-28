using SevOneHourlyClock.WebAPI.Bussiness;
using SevOneHourlyClock.WebAPI.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace SevOneHourlyClock.WebAPI.Controllers
{
    public class WallBoardValuesController : ApiController
    {

        private readonly BoardDetailsBusiness _boardDetailsBusiness;

        private WallBoardValuesController()
        {
            this._boardDetailsBusiness = new BoardDetailsBusiness();
        }
        
        // GET api/<controller>
        public IEnumerable<BoardDetails> Get(int skipNum = 0, int TakeNum = 999)
        {
            return this._boardDetailsBusiness.GetBoardList(skipRow: skipNum, takerow: TakeNum);
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