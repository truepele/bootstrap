using System.Web.Mvc;

namespace bootstrap.Models.Binders
{
    public class TableOptionsModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProvider = bindingContext.ValueProvider;
            int draw, start, length;
            bool isSearchRegex;

            int.TryParse(valueProvider.GetValue("draw")?.AttemptedValue, out draw);
            int.TryParse(valueProvider.GetValue("start")?.AttemptedValue, out start);
            int.TryParse(valueProvider.GetValue("length")?.AttemptedValue, out length);
            var searchtext = valueProvider.GetValue("search[value]")?.AttemptedValue;
            bool.TryParse(valueProvider.GetValue("search[regex]")?.AttemptedValue, out isSearchRegex);

            return new TableOptionsModel { draw = draw, length = length, start = start, SearchOptions = new SearchOptions { IsRegex = isSearchRegex, Value = searchtext} };
        }     
    }
}