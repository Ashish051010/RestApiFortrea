using Api.Automation.Fortrea.Auth;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Automation.Fortrea
{
    public  class APIClient : IAPIClient, IDisposable
    {

        readonly RestClient client;
        const string BASE_URL = "https://reqres.in/";

        public APIClient()
        {
            var options = new RestClientOptions(BASE_URL);
            client = new RestClient(options)
            {
               Authenticator = new APIAuthenticator()
            };
        }
        public async Task<RestResponse> createUser<T>(T payload) where T : class
        {
            var request = new RestRequest(EndPoints.CREATE_USER, Method.Post);
            request.AddBody(payload);
            return await client.ExecuteAsync<T>(request);
        }

        public async Task<RestResponse> deleteUser<T>(string id)
        {
            var request = new RestRequest(EndPoints.DELETE_USER, Method.Delete);
            request.AddUrlSegment(id, id);
            return await client.ExecuteAsync(request);
        }

        public void Dispose()
        {
            client?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<RestResponse> getListofUser<T>(int pageNumber)
        {
            var request = new RestRequest(EndPoints.GET_LIST_OF_USER, Method.Get);
            request.AddQueryParameter("page", pageNumber);
            return await client.ExecuteAsync<T>(request);
        }

        public async Task<RestResponse> getUser<T>(string id)
        {
            var request = new RestRequest(EndPoints.GET_SINGLE_USER, Method.Get);
            request.AddUrlSegment(id, id);
            return await client.ExecuteAsync<T>(request);
        }

        public async Task<RestResponse> updateUser<T>(T payload, string id) where T : class
        {
            var request = new RestRequest(EndPoints.UPDATE_USER, Method.Put);
            request.AddUrlSegment(id, id);
            request.AddBody(payload);
            return await client.ExecuteAsync<T>(request);
        }
    }
}
