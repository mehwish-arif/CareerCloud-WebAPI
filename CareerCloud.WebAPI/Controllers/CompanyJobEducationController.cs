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
    public class CompanyJobEducationController : ControllerBase
    {
        private CompanyJobEducationLogic _logic;

        public CompanyJobEducationController()
        {
            EFGenericRepository<CompanyJobEducationPoco> repo = new EFGenericRepository<CompanyJobEducationPoco>();
            _logic = new CompanyJobEducationLogic(repo);
        }

        [HttpGet]
        [Route("companyeducation/{id}")]
        [ProducesResponseType(typeof(CompanyJobEducationPoco), 200)]
        public ActionResult GetCompanyJobEducation(Guid id)
        {
            CompanyJobEducationPoco poco = _logic.Get(id);

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
        [Route("companyeducation")]
        public ActionResult PostCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("companyeducation")]
        public ActionResult PutCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)

        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("companyeducation")]
        public ActionResult DeleteCompanyJobEducation([FromBody] CompanyJobEducationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("companyeducation")]
        [ProducesResponseType(typeof(List<CompanyJobEducationPoco>), 200)]
        public ActionResult GetAllCompanyJobEducation()
        {
            return Ok(_logic.GetAll());
        }

    }
}
