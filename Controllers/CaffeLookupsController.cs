using System.Collections;
using System.Net;
using caffeServer.Controllers.Exceptions;
using caffeServer.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace caffeServer.Controllers
{
    [ApiController]
    [Route("lookups")]
    public class CaffeLookupsController : ControllerBase
    {
        private readonly ILogger<CaffeLookupsController> _logger;

        public CaffeLookupsController(ILogger<CaffeLookupsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/{model}")]
        public IEnumerable GetModelData(string model)
        {
            object repo;
            switch (model.ToLower())
            {
                case "positions":
                    repo = new CaffeRepository<Positions>(new CaffeDataContext());
                    return ((CaffeRepository<Positions>)repo).Select(); 
                case "residues":
                    repo = new CaffeRepository<Residues>(new CaffeDataContext());
                    return ((CaffeRepository<Residues>)repo).Select();
                case "positiontypes":
                    repo = new CaffeRepository<PositionTypes>(new CaffeDataContext());
                    return ((CaffeRepository<PositionTypes>)repo).Select();
                default:
                    var exception =  new StatusCodeException(HttpStatusCode.BadRequest, "invalid model in uri");
                    throw exception;
            }

        } 
        
        [HttpPut]
        [Route("/{model}/set")]
        public void SetModelData(ArrayList inputData, string model)
        {
            if (inputData.Count == 0) return;
            object repo;
            switch (model.ToLower())
            {
                case "positions":
                    repo = new CaffeRepository<Positions>(new CaffeDataContext());
                    ((CaffeRepository<Positions>)repo).Upsert(inputData);
                    break;
                case "residues":
                    repo = new CaffeRepository<Residues>(new CaffeDataContext());
                    ((CaffeRepository<Residues>)repo).Upsert(inputData);
                    break;
                case "positiontypes":
                    repo = new CaffeRepository<PositionTypes>(new CaffeDataContext());
                    ((CaffeRepository<PositionTypes>)repo).Upsert(inputData);
                    break;
                default:
                    var exception = new StatusCodeException(HttpStatusCode.BadRequest, "invalid model in uri");
                    throw exception;
            }
        }
        
        [HttpDelete]
        [Route("/{model}/remove")]
        public void RemoveModelData(ArrayList inputData, string model)
        {
            if (inputData.Count == 0) return;
            object repo;
            switch (model.ToLower())
            {
                case "positions":
                    repo = new CaffeRepository<Positions>(new CaffeDataContext());
                    ((CaffeRepository<Positions>)repo).Delete(inputData);
                    break;
                case "residues":
                    repo = new CaffeRepository<Residues>(new CaffeDataContext());
                    ((CaffeRepository<Residues>)repo).Delete(inputData);
                    break;
                case "positiontypes":
                    repo = new CaffeRepository<PositionTypes>(new CaffeDataContext());
                    ((CaffeRepository<PositionTypes>)repo).Delete(inputData);
                    break;
                default:
                    var exception = new StatusCodeException(HttpStatusCode.BadRequest, "invalid model in uri");
                    throw exception;
            }
        }
    }
}