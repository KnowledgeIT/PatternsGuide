using Sales.Service.ViewModels.Internal.Base.Interfaces;
using Sales.Test.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Sales.Test.Modules.Base;

namespace Sales.Test.Modules.Base
{
    [TestClass]
    public abstract class TestModuleBase<TViewModel>: RequestModuleBase<TViewModel>
        where TViewModel: class, IBaseViewModel
    {
        private IList<TViewModel> viewModels;

        #region Constructor

        public TestModuleBase(){

        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Returns a list
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public virtual async Task Must_Return_List_Async()
        {
            var result = await base.GetAsync();
            if (result == null)
                Assert.Fail(TestMessages.NullResult);

            Assert.IsTrue(result.ToList().Count() > 0, TestMessages.NoRows);
        }

        /// <summary>
        /// Returns one
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [TestMethod]
        public virtual async Task Must_Return_One_Async()
        {
            var resultList = await base.GetAsync();

            if (resultList == null)
                Assert.Fail(TestMessages.NullResult);
            else
            {
                var result = await base.GetAsync(resultList.FirstOrDefault().Id);
                if (result == null)
                    Assert.Fail(TestMessages.NullResult);

                Assert.IsTrue(result.Id == resultList.FirstOrDefault().Id, TestMessages.NoRows);
            }
        }

        /// <summary>
        /// Returns a paged list
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [TestMethod]
        public virtual async Task Must_Return_Many_Pages_Async()
        {
            var result = await base.GetPagedList(2, 1);

            if (result == null)
                Assert.Fail(TestMessages.NullResult);

            Assert.IsTrue(result.Results.ToList().Count() > 0, TestMessages.NoRows);
        }

        #endregion

        #region Update Methods

        /// <summary>
        /// Calls the delete request
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[TestMethod]
        //public virtual async Task Should_Delete_Async()
        //{
        //    var result = await base.DeleteAsync();
        //    Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.NoContent);
        //}

        ///// <summary>
        ///// Calls a Post request
        ///// </summary>
        ///// <param name="viewModel"></param>
        ///// <returns></returns>
        //[TestMethod]
        //public virtual async Task Must_Add_Async()
        //{
        //    var result =
        //        await _httpClient.PostAsync(_uri,
        //            new StringContent(
        //                JsonConvert.SerializeObject(viewModel,
        //                    new JsonSerializerSettings()
        //                    {
        //                        ContractResolver = new CamelCasePropertyNamesContractResolver()
        //                    }), Encoding.UTF8, "application/json"));

        //    Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Created);
        //}

        ///// <summary>
        ///// Calls a Put request
        ///// </summary>
        ///// <param name="viewModel"></param>
        ///// <returns></returns>
        //[TestMethod]
        //public virtual async Task Must_Update_Async()
        //{
        //    var result =
        //        await _httpClient.PutAsync(_uri,
        //            new StringContent(
        //                JsonConvert.SerializeObject(viewModel,
        //                    new JsonSerializerSettings()
        //                    {
        //                        ContractResolver = new CamelCasePropertyNamesContractResolver()
        //                    }), Encoding.UTF8, "application/json"));

        //    Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.NoContent);
        //}

        #endregion
    }
}
