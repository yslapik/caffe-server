using System;
using System.Collections;
using System.Net;
using caffeServer.Controllers.Exceptions;
using caffeServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace caffeServer.Controllers
{
    [ApiController]
    [Route("dailyData")]
    public class CaffeDailyDataController : ControllerBase
    {
        [HttpGet]
        [Route("/{model}/{date}")]
        public IEnumerable GetDailyModelData(string model, string date)
        {
            var filterDate = DateTime.Parse(date);
            object repo;
            switch (model.ToLower())
            {
                case "dailyresidues":
                    repo = new CaffeRepository<DailyResidues>(new CaffeDataContext());
                    return ((CaffeRepository<DailyResidues>)repo).Select((x)=>x.Date.Equals(filterDate));
                case "dailysales":
                    repo = new CaffeRepository<DailySales>(new CaffeDataContext());
                    return ((CaffeRepository<DailySales>)repo).Select((x)=>x.Date.Equals(filterDate));
                default:
                    var exception =  new StatusCodeException(HttpStatusCode.BadRequest, "invalid model in uri");
                    throw exception;
            }
        }
    }
}