using Sales.Service.ViewModels.Internal;
using Sales.Test.Modules.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Test.Modules
{
    [TestClass]
    public class TaxTestModule: TestModuleBase<TaxViewModel>
    {
        public TaxTestModule()
        {
            base._uri = new Uri("http://localhost:44353/api/taxes");
        }
    }
}
