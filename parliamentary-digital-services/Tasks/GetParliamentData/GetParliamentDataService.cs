using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using PD.Domain;
using PD.Services.Tasks.GetBusinessItemDetails;
using PD.Services.Tasks.GetBusinessItems;
using PD.Services.Tasks.GetMemberDetails;

namespace PD.Services.Tasks.GetParliamentData
{
    class GetParliamentDataService : IGetParliamentEvents, IGetParliamentEventDetails, IGetParliamentMemberDetails
    {
        public async Task<GetParliamentEventResponse> GetEvents(GetParliamentEventsRequest request)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var result = await httpClient.GetAsync($"{request.Url}?startdate={request.StartDate:yyyy-MM-dd}&enddate={request.EndDate:yyyy-MM-dd}");
                    var response = await result.Content.ReadAsStringAsync();
                    var xmlSerialize = new XmlSerializer(typeof(Events));
                    return GetParliamentEventResponse.Success((Events)xmlSerialize.Deserialize(new StringReader(response)));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public async Task<GetParliamentEventDetailsResponse> GetParliamentEventDetails(GetParliamentEventDetailsRequest request)
        {
            //using (var httpClient = new HttpClient())
            //{
            //    var result = await httpClient.GetAsync($"{request.Url}?startdate={request.StartDate:yyyy-MM-dd}6&enddate={request.EndDate:yyyy-MM-dd}");
            //    var response = await result.Content.ReadAsStringAsync();

            //    try
            //    {
            //        var xmlSerialize = new XmlSerializer(typeof(Events));
            //        var model = (Events)xmlSerialize.Deserialize(new StringReader(response));
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e);
            //        throw;
            //    }
            //}

            return null;
        }

        public async Task<GetParliamentMemberDetailsResponse> GetGetParliamentMemberDetails(GetParliamentMemberDetailsRequest request)
        {
            //using (var httpClient = new HttpClient())
            //{
            //    var result = await httpClient.GetAsync($"{request.Url}id={request.Id}");
            //    var response = await result.Content.ReadAsStringAsync();

            //    try
            //    {
            //        var xmlSerialize = new XmlSerializer(typeof(Events));
            //        return (Events)xmlSerialize.Deserialize(new StringReader(response));
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e);
            //        throw;
            //    }
            //}

            return null;
        }
    }
}