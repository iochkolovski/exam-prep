using System.Text.Json;
using RestSharp;
using System.Net;
using RestSharpAPITests.Models;

namespace RestSharpAPITests
{
    public class RestSharpAPI_Tests
    {
        private RestClient _client;
        private const string baseUrl = "http://localhost:8080/api";
        private int id;

        [SetUp]
        public void Setup()
        {
            this._client = new RestClient(baseUrl);
        }

        [Test]
        public void Test_GetDoneTasks_Check_Title()
        {
            var request = new RestRequest("/tasks/board/done", Method.Get);
            var response = this._client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var task = JsonSerializer.Deserialize<List<Models.TaskResponse>>(response.Content);
            Assert.That(task[0].title, Is.EqualTo("Project skeleton"));
        }

        [Test]
        public void Test_GetTask_ByKeyword_Valid()
        {
            var request = new RestRequest("/tasks/search/home", Method.Get);
            var response = this._client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var task = JsonSerializer.Deserialize<List<Models.TaskResponse>>(response.Content);
            Assert.That(task[0].title, Is.EqualTo("Home page"));
        }

        [Test]
        public void Test_GetTask_ByKeyword_Invalid()
        {
            var request = new RestRequest("/tasks/search/missing{randnum}", Method.Get);
            var response = this._client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Is.EqualTo("[]"));
        }

        [Test]
        public void Test_PostTask_InvalidBody()
        {
            var request = new RestRequest("/tasks", Method.Post);
            var body = new
            {
                description = "desc",
                board = "open"
            };
            request.AddBody(body);
            var response = this._client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.Content, Is.EqualTo("{\"errMsg\":\"Title cannot be empty!\"}"));
        }

        [Test]
        public void Test_PostTask_ValidBody()
        {
            var request = new RestRequest("/tasks", Method.Post);
            var body = new
            {
                title = "bobiboi",
                description = "desc",
                board = "open"
            };
            request.AddBody(body);
            var response = this._client.Execute(request);
            var createdObject = JsonSerializer.Deserialize<Models.CreateTaskResponse>(response.Content);
            id = createdObject.task.id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(createdObject.task.description, Is.EqualTo("desc"));
            Assert.That(createdObject.task.title, Is.EqualTo("bobiboi"));
        }

        [TearDown]
        public void TearDown()
        {
            // Execute only after Test2
            if (TestContext.CurrentContext.Test.Name.Equals(nameof(this.Test_PostTask_ValidBody)))
            {
                var request = new RestRequest($"/tasks/{id}", Method.Delete);
                var response = _client.Execute(request);
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("Successfully teardown");
                }
                else Console.WriteLine("Error! Check test log");
            }
        }


    }
}