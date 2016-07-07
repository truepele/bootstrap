using bootstrap.Models;
using bootstrap.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace bootstrap.Controllers
{
    public class TableDataController : Controller
    {
        private ITableDataRepo _repo;

        public TableDataController(ITableDataRepo repo)
        {
            _repo = repo;
        }

        // GET: TableData
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetData(TableOptionsModel options)
        {
            int totalrecords;
            var dataList = _repo.GetData(options.start, options.length, options.SearchOptions?.Value ?? "", options.SearchOptions?.IsRegex ?? false, out totalrecords);

            return Json(
                        new
                        {
                            draw = options.draw,
                            recordsTotal = totalrecords,
                            recordsFiltered = totalrecords,
                            data = dataList
                        }
                        , JsonRequestBehavior.AllowGet
                );
        }

        [HttpGet]
        public ActionResult GetDataAll()
        {            
            var dataList = _repo.GetData();

            return Json(
                        new
                        {
                            data = dataList
                        }
                        , JsonRequestBehavior.AllowGet
                );
        }
    }
}