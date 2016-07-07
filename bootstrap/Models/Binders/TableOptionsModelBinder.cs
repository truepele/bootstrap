using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
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

            int.TryParse(valueProvider.GetValue("draw")?.AttemptedValue.ToString(), out draw);
            int.TryParse(valueProvider.GetValue("start")?.AttemptedValue.ToString(), out start);
            int.TryParse(valueProvider.GetValue("length")?.AttemptedValue.ToString(), out length);
            var searchtext = valueProvider.GetValue("search[value]")?.AttemptedValue.ToString();
            bool.TryParse(valueProvider.GetValue("search[regex]")?.AttemptedValue.ToString(), out isSearchRegex);

            return new TableOptionsModel() { draw = draw, length = length, start = start, SearchOptions = new SearchOptions() { IsRegex = isSearchRegex, Value = searchtext} };
        }     
    }
}