﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using PD.Services.Tasks.GetBusinessItemDetails;
using PD.Services.Tasks.GetBusinessItems;
using PD.Services.Tasks.GetWeeks;

namespace PD.Tests.IngregationTests
{
    class IntegrationTests
    {
        private MockApiClientFactory _factory;
        private HttpClient _client;

        [OneTimeSetUp]
        public void One_time_set_up()
        {
            _factory = new MockApiClientFactory();
            _client = _factory.CreateClient();
        }

        [Test]
        public async Task Get_events()
        {
            // act
            var result = await _client.GetAsync("/events?StartDate=2015-11-16&EndDate=2015-11-20");

            // assert
            var model = JsonConvert.DeserializeObject<IEnumerable<BusinessItemModel>>(await result.Content.ReadAsStringAsync());

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(model.First().Id, Is.EqualTo(3564));
            Assert.That(model.Last().Id, Is.EqualTo(5692));
        }

        [Test]
        public async Task Get_weeks()
        {
            // act
            var result = await _client.GetAsync("/weeks");

            // assert
            var model = JsonConvert.DeserializeObject<GetWeeksViewModel>(await result.Content.ReadAsStringAsync());

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(model.Weeks.Count(), Is.EqualTo(54), "expected 54 weeks based on get weeks app settings");
        }

        [Test]
        public async Task Get_event_details()
        {
            // act
            var result = await _client.GetAsync("/events/3564?StartDate=2015-11-16&EndDate=2015-11-20");

            // assert
            var model = JsonConvert.DeserializeObject<BusinessItemDetailsModel>(await result.Content.ReadAsStringAsync());

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(model.First().Id, Is.EqualTo(3564));
        }
    }
}
