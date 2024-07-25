using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomArrays
{
    internal class TravelEvent
    {
        public string clientName {  get; set; }
        public string location {  get; set; }
        public string[] itineraries { get; set; }

        public TravelEvent(string clientName, string location, string[] itineraries)
        {
            this.clientName = clientName;
            this.location = location;
            this.itineraries = itineraries;
        }
        public string listItineraries(string[] itineraries)
        {
            string list = "";
            foreach (var itinerary in itineraries)
            {
                list += itinerary + ", ";
            }
            return list;
        }
        public override string ToString()
        {
            return $"{clientName} is going to {location} and is planning to do: {listItineraries(itineraries)}";
        }
    }
}
