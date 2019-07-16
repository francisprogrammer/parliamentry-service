using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                    var result = await httpClient.GetAsync(
                        $"{request.Url}?startdate={request.StartDate:yyyy-MM-dd}&enddate={request.EndDate:yyyy-MM-dd}");
                    var response = await result.Content.ReadAsStringAsync();
                    
                    var events = XmlConvert.Deserialize<Events>(response);

                    events.Event = 
                        events
                            .Event
                            .Where(
                                x =>
                                    x.Type.Equals("Main Chamber", StringComparison.OrdinalIgnoreCase) &&
                                    x.House.Equals("Commons", StringComparison.OrdinalIgnoreCase))
                            .ToList();
                    
                    return GetParliamentEventResponse.Success(events);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public async Task<GetParliamentEventDetailsResponse> GetParliamentEventDetails(
            GetParliamentEventDetailsRequest request)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var result = await httpClient.GetAsync(
                        $"{request.Url}?startdate={request.StartDate:yyyy-MM-dd}&enddate={request.EndDate:yyyy-MM-dd}");
                    var response = await result.Content.ReadAsStringAsync();

                    var events = XmlConvert.Deserialize<Events>(response);

                    if (events.Event.All(x => x.Id != request.Id))
                        return GetParliamentEventDetailsResponse.Failed();

                    var eventDetails = events.Event.Single(x => x.Id == request.Id);
                    return GetParliamentEventDetailsResponse.Success(new BusinessItemDetails(eventDetails.Id,
                        eventDetails.StartDate, eventDetails.StartTime, eventDetails.EndDate, eventDetails.EndTime,
                        eventDetails.Description, eventDetails.Category,
                        eventDetails.Members.Select(x => new MemberItem(x.Id, x.Name))));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public async Task<GetParliamentMemberDetailsResponse> GetGetParliamentMemberDetails(
            GetParliamentMemberDetailsRequest request)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var result = await httpClient.GetAsync($"{request.Url}id={request.Id}");
                    var response = await result.Content.ReadAsStringAsync();

                    var membersCollection = XmlConvert.Deserialize<MembersCollection>(response);

                    return GetParliamentMemberDetailsResponse.Success(membersCollection.MemberDetails);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}