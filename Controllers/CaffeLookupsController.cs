using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using caffeServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace caffeServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaffeLookupsController : ControllerBase
    {
        private readonly ILogger<CaffeLookupsController> _logger;

        public CaffeLookupsController(ILogger<CaffeLookupsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/Positions")]
        public IEnumerable<Positions> GetPositions()
        {
            var repo = new CaffeRepository<Positions>(new CaffeDataContext());
            return repo.SelectDataList();
        } 
        
        [HttpPost]
        [Route("/Positions/set")]
        public void SetPositions(Positions[] positionsArray)
        {
            var repo = new CaffeRepository<Positions>(new CaffeDataContext());
            repo.UpsertDataList(positionsArray);
        }
        [HttpDelete]
        [Route("/Positions/remove")]
        public void RemovePositions(Positions[] positionsArray)
        {
            var repo = new CaffeRepository<Positions>(new CaffeDataContext());
            repo.RemoveDataList(positionsArray);
        } 
        
        [HttpGet]
        [Route("/Residues")]
        public IEnumerable<Residues> GetResidues()
        {
            var  repo = new CaffeRepository<Residues>(new CaffeDataContext());
            return repo.SelectDataList();
        }
        
        [HttpPost]
        [Route("/Residues/set")]
        public void SetResidues(Residues[] residuesArray)
        {
            var repo = new CaffeRepository<Residues>(new CaffeDataContext());
            repo.UpsertDataList(residuesArray);
        }
        [HttpDelete]
        [Route("/Residues/remove")]
        public void RemoveResidues(Residues[] residuesArray)
        {
            var repo = new CaffeRepository<Residues>(new CaffeDataContext());
            repo.RemoveDataList(residuesArray);
        } 

        [HttpGet]
        [Route("/DailyResidues")]
        public IEnumerable<DailyResidues> GetDailyResidues()
        {
            var repo = new CaffeRepository<DailyResidues>(new CaffeDataContext());
            return repo.SelectDataList();
        }
        
        [HttpGet]
        [Route("/DailySales")]
        public IEnumerable<DailySales> GetDailySales()
        {
            var repo = new CaffeRepository<DailySales>(new CaffeDataContext());
            return repo.SelectDataList();
        }
    }
}