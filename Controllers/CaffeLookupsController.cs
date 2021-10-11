using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using caffeServer.Models;
using Microsoft.AspNetCore.Mvc;
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
            using (CaffeDataContext db = new CaffeDataContext())
            {
                return db.Positions.ToList();
            }
        }        
        [HttpGet]
        [Route("/DailyResidues")]
        public IEnumerable<DailyResidues> GetDailyResidues()
        {
            using (CaffeDataContext db = new CaffeDataContext())
            {
                return db.DailyResidues.ToList();
            }
        }
        [HttpGet]
        [Route("/DailySales")]
        public IEnumerable<DailySales> GetDailySales()
        {
            using (CaffeDataContext db = new CaffeDataContext())
            {
                return db.DailySales.ToList();
            }
        }        
        [HttpGet]
        [Route("/Residues")]
        public IEnumerable<Residues> GetResidues()
        {
            using (CaffeDataContext db = new CaffeDataContext())
            {
                return db.Residues.ToList();
            }
        }
    }
}