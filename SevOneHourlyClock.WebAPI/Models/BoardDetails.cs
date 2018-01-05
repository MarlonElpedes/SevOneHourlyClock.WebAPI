using Newtonsoft.Json;
using System;

namespace SevOneHourlyClock.WebAPI.Models
{
    public class BoardDetails
    {

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Incident_Number")]
        public string IncidentNumber { get; set; }

        [JsonProperty("Assigned_Account_Id")]
        public string AssignedAccountId { get; set; }

        [JsonProperty("Assigned_Account")]
        public string AssignedAccount { get; set; }

        [JsonProperty("Assigned_Account_Name")]
        public string AssignedAccountName { get; set; }

        [JsonProperty("Severity")]
        public string Severity { get; set; }

        [JsonProperty("Tech_Bridge_Name")]
        public string TechBridgeName { get; set; }

        [JsonProperty("Tech_Lead")]
        public string TechLead { get; set; }
        
        [JsonProperty("Skype_Link")]
        public string SkypeLink { get; set; }

        [JsonProperty("Conference_Number")]
        public string ConferenceNumber { get; set; }

        [JsonProperty("Summary")]
        public string Summary { get; set; }

        [JsonProperty("Start_Date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("Total_Rows")]
        public int TotalRows { get; set; }

        [JsonProperty("Remaining_Seconds")]
        public double RemainingSeconds { get; set; }

    }
}