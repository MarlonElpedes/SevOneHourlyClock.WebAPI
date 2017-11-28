//dev added below
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace SevOneHourlyClock.WebAPI.Commmon
{
    public static class clsException
    {
        /// <summary>
        /// Global variable storing important stuff.
        /// </summary>
        static string _strException;
        public static string strUserFullName;
        public static string strMngrNum;
        public static string tabOpen;
        public static string strIncNum;

        /// <summary>
        /// Get or set the static important data.
        /// </summary>
        public static string strException
        {
            get
            {
                return _strException;
            }
            set
            {
                _strException = value;
            }
        }

        public static SqlConnection exConnBackEnd
        {
            get; set;
        }

        public static void Init()
        {
            ConnectionStringSettings connConnString = WebConfigurationManager.OpenWebConfiguration("~/Web.config").ConnectionStrings.ConnectionStrings["connBackEnd"];
            exConnBackEnd = new SqlConnection(connConnString.ToString());
        }


    }
}