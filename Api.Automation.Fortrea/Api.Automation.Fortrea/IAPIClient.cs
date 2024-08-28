using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Automation.Fortrea
{
    public  interface IAPIClient
    {
        Task<RestResponse> createUser<T>(T payload) where T : class;

        Task<RestResponse> updateUser<T>(T payload,string id) where T : class;

        Task<RestResponse> deleteUser<T>(string id);

        Task<RestResponse> getUser<T>(string id);

        Task<RestResponse> getListofUser<T>(int pageNumber);



    }
}
