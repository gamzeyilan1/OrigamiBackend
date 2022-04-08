using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.Helpers;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OrigamiBackend.Helper
{
    [ModelBinder(BinderType = typeof(DataSourceLoadOptionsBinder))]
    public class DataSourceLoadOptions : DataSourceLoadOptionsBase
    {
    }

    public class DataSourceLoadOptionsBinder : IModelBinder
    {
        public System.Threading.Tasks.Task BindModelAsync(ModelBindingContext bindingContext)
        {
            CultureInfo.CurrentCulture = new CultureInfo("tr-TR", false);
            var loadOptions = new DataSourceLoadOptions();
            DataSourceLoadOptionsParser.Parse(loadOptions,
                key => bindingContext.ValueProvider.GetValue(key).FirstOrDefault());
            bindingContext.Result = ModelBindingResult.Success(loadOptions);
            return System.Threading.Tasks.Task.CompletedTask;
        }

    }
}
