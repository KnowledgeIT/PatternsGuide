using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sales.CrossCutting.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sales.Test.Modules.Base
{
    public abstract class RequestModuleBase<TViewModel>
    {
        #region Fields

        protected HttpClient _httpClient;
        protected Uri _uri;

        #endregion

        #region Constructor

        public RequestModuleBase()
        {
            CreateHttpClient();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calls the delete request
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected virtual async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            return await _httpClient.DeleteAsync(_uri + $"/{id}");
        }

        /// <summary>
        /// Returns a list
        /// </summary>
        /// <returns></returns>
        protected virtual async Task<List<TViewModel>> GetAsync()
        {
            var streamTask = await _httpClient.GetStringAsync(_uri);
            return JsonConvert.DeserializeObject<List<TViewModel>>(streamTask);
        }

        /// <summary>
        /// Returns one
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected virtual async Task<TViewModel> GetAsync(int id)
        {
            var streamTask = await _httpClient.GetStringAsync(_uri + $"/{id}");
            return JsonConvert.DeserializeObject<TViewModel>(streamTask);
        }

        /// <summary>
        /// Returns a paged list
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        protected virtual async Task<PagedList<TViewModel>> GetPagedList(int page, int pageSize)
        {
            var streamTask = await _httpClient.GetStringAsync(_uri + $"/{page}/{pageSize}");
            return JsonConvert.DeserializeObject<PagedList<TViewModel>>(streamTask);
        }

        /// <summary>
        /// Returns a paged list
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        protected virtual async Task<PagedList<TViewModel>> GetPagedList(int page)
        {
            var streamTask = await _httpClient.GetStringAsync(_uri + $"/{page}");
            return JsonConvert.DeserializeObject<PagedList<TViewModel>>(streamTask);
        }

        /// <summary>
        /// Calls a Post request
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        protected virtual async Task<HttpResponseMessage> PostAsync(TViewModel viewModel)
        {
            return
                await _httpClient.PostAsync(
                    _uri,
                    new StringContent(
                        JsonConvert.SerializeObject(viewModel,
                            new JsonSerializerSettings()
                            {
                                ContractResolver = new CamelCasePropertyNamesContractResolver()
                            }), Encoding.UTF8, "application/json"));
        }

        /// <summary>
        /// Calls a Post request
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        protected virtual async Task<HttpResponseMessage> PostAsync<T>(T viewModel)
        {
            return
                await _httpClient.PostAsync(
                    _uri,
                    new StringContent(
                        JsonConvert.SerializeObject(viewModel,
                            new JsonSerializerSettings()
                            {
                                ContractResolver = new CamelCasePropertyNamesContractResolver()
                            }), Encoding.UTF8, "application/json"));
        }

        /// <summary>
        /// Calls a Put request
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        protected virtual async Task<HttpResponseMessage> PutAsync(TViewModel viewModel)
        {
            return
                await _httpClient.PutAsync(
                    _uri,
                    new StringContent(
                        JsonConvert.SerializeObject(viewModel,
                            new JsonSerializerSettings()
                            {
                                ContractResolver = new CamelCasePropertyNamesContractResolver()
                            }), Encoding.UTF8, "application/json"));
        }

        /// <summary>
        /// Calls a Put request
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        protected virtual async Task<HttpResponseMessage> PutAsync<T>(T viewModel)
        {
            return
                await _httpClient.PutAsync(
                    _uri,
                    new StringContent(
                        JsonConvert.SerializeObject(viewModel,
                            new JsonSerializerSettings()
                            {
                                ContractResolver = new CamelCasePropertyNamesContractResolver()
                            }), Encoding.UTF8, "application/json"));
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Instantiates or updates the HttpClient object (Useful for paged requests)
        /// </summary>
        protected virtual void CreateHttpClient()
        {
            if (_httpClient == null)
                _httpClient = new HttpClient();

            _httpClient.BaseAddress = _uri;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #endregion
    }
}
