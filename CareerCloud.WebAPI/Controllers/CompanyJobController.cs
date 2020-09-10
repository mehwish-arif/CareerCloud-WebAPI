using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    [ApiController]
    public class CompanyJobController : ControllerBase
    {
        private CompanyJobLogic _logic;

        public CompanyJobController()
        {
            EFGenericRepository<CompanyJobPoco> repo = new EFGenericRepository<CompanyJobPoco>();
            _logic = new CompanyJobLogic(repo);
        }
        [HttpGet]
        [Route("companyjob/{id}")]
        [ProducesResponseType(typeof(CompanyJobPoco), 200)]
        public ActionResult GetCompanyJob(Guid id)
        {
            CompanyJobPoco poco = _logic.Get(id);

            if (poco != null)
            {
                return Ok(poco);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("companyjob")]
        public ActionResult PostCompanyJob([FromBody] CompanyJobPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("companyjob")]
        public ActionResult PutCompanyJob([FromBody] CompanyJobPoco[] pocos)

        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("companyjob")]
        public ActionResult DeleteCompanyJob([FromBody] CompanyJobPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("companyjob")]
        [ProducesResponseType(typeof(List<CompanyJobPoco>), 200)]
        public ActionResult GetAllCompanyJob()
        {
            return Ok(_logic.GetAll());
        }
    }
}
