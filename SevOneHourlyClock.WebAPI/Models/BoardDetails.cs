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

        [JsonProperty("Severity")]
        public string Severity { get; set; }

        [JsonProperty("TechOp_Bridge")]
        public string TechOpBridge { get; set; }

        [JsonProperty("IMTech_Lead")]
        public string IMTechLead { get; set; }

        [JsonProperty("Summary")]
        public string Summary { get; set; }

        [JsonProperty("Start_Date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("Total_Rows")]
        public int TotalRows { get; set; }

    }
}