using DimensionTrip.Controllers.Base.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DimensionTrip.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerBase<TViewModel> : ControllerBase, IControllerBase<TViewModel> where TViewModel : class
    {
        #region Fields

        protected HttpClient _httpClient;
        protected readonly ILogger _logger;
        
        #endregion

        #region Constructor

        public ControllerBase(
            HttpClient httpClient,
            ILogger<ControllerBase<TViewModel>> logger
        )
        {
            _httpClient = httpClient;
            CreateHttpClient();
            _logger = logger;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executa a request de exclusão
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<HttpResponseMessage> DeleteAsync(string id)
        {
            return
                await _httpClient.DeleteAsync(
                    _uri + MountUri(
                        GetEndpoint(_integrationScope, EndPointActionType.DELETE)) + $"/{id}");
        }

        /// <summary>
        /// Executa request de retorno de apenas um registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TViewModel> GetAsync(string id)
        {
            var streamTask =
                await _httpClient.GetStringAsync(
                    _uri + MountUri(
                        GetEndpoint(_integrationScope, EndPointActionType.GET)) + $"/{id}");
            return JsonConvert.DeserializeObject<TViewModel>(streamTask);
        }

        /// <summary>
        /// Utilizado para executar requests paginadas e retornar uma ViewModel diferente do padrão passado para a classe
        /// </summary>
        /// <typeparam name="TPagedViewModel"></typeparam>
        /// <param name="page"></param>
        /// <returns></returns>
        public virtual async Task<TPagedViewModel> GetPagedListAsync<TPagedViewModel>(int page) where TPagedViewModel : class
        {
            var streamTask =
                await _httpClient.GetStringAsync(
                    _uri + MountUri(
                        GetEndpoint(_integrationScope, EndPointActionType.GETLIST, true), page));

            return JsonConvert.DeserializeObject<TPagedViewModel>(streamTask);
        }

        /// <summary>
        /// Utilizado para executar requests paginadas e retornar uma ViewModel diferente do padrão passado para a classe
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public virtual async Task<TViewModel> GetPagedListAsync(int page)
        {
            var streamTask =
                await _httpClient.GetStringAsync(
                    _uri + MountUri(
                        GetEndpoint(_integrationScope, EndPointActionType.GETLIST, true), page));

            return JsonConvert.DeserializeObject<TViewModel>(streamTask);
        }

        /// <summary>
        /// Executa a request retornando uma lista
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public virtual async Task<List<TViewModel>> GetListAsync()
        {
            var streamTask =
                await _httpClient.GetStringAsync(
                    _uri + MountUri(
                        GetEndpoint(_integrationScope, EndPointActionType.GET)));

            return JsonConvert.DeserializeObject<List<TViewModel>>(streamTask);
        }

        /// <summary>
        /// Executa a request de inclusão
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public virtual async Task<HttpResponseMessage> PostAsync(TViewModel viewModel)
        {
            return
                await _httpClient.PostAsync(
                    _uri + MountUri(
                        GetEndpoint(_integrationScope, EndPointActionType.POST)),
                    new StringContent(
                        JsonConvert.SerializeObject(viewModel,
                            new JsonSerializerSettings()
                            {
                                ContractResolver = new CamelCasePropertyNamesContractResolver()
                            }), Encoding.UTF8, "application/json"));
        }

        /// <summary>
        /// Executa a request de inclusão, recebendo um novo objeto como parâmetro
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public virtual async Task<HttpResponseMessage> PostAsync<T>(T viewModel)
        {
            return
                await _httpClient.PostAsync(
                    _uri + MountUri(
                        GetEndpoint(_integrationScope, EndPointActionType.POST)),
                    new StringContent(
                        JsonConvert.SerializeObject(viewModel,
                            new JsonSerializerSettings()
                            {
                                ContractResolver = new CamelCasePropertyNamesContractResolver()
                            }), Encoding.UTF8, "application/json"));
        }

        /// <summary>
        /// Executa a request de atualização
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public virtual async Task<HttpResponseMessage> PutAsync(TViewModel viewModel)
        {
            return
                await _httpClient.PutAsync(
                    _uri + MountUri(
                        GetEndpoint(_integrationScope, EndPointActionType.PUT)),
                    new StringContent(
                        JsonConvert.SerializeObject(viewModel,
                            new JsonSerializerSettings()
                            {
                                ContractResolver = new CamelCasePropertyNamesContractResolver()
                            }), Encoding.UTF8, "application/json"));
        }

        /// <summary>
        /// Executa a request de atualização, recebendo um novo objeto como parâmetro
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public virtual async Task<HttpResponseMessage> PutAsync<T>(T viewModel)
        {
            return
                await _httpClient.PutAsync(
                    _uri + MountUri(
                        GetEndpoint(_integrationScope, EndPointActionType.PUT)),
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
        /// Instacia ou atualiza o objeto HttpClient (Útil para requests paginadas)
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
