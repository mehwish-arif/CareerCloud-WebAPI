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
    public class CompanyProfileController : ControllerBase
    {
        private CompanyProfileLogic _logic;

        public CompanyProfileController()
        {
            EFGenericRepository<CompanyProfilePoco> repo = new EFGenericRepository<CompanyProfilePoco>();
            _logic = new CompanyProfileLogic(repo);
        }
        [HttpGet]
        [Route("companyprofile/{id}")]
        [ProducesResponseType(typeof(CompanyProfilePoco), 200)]
        public ActionResult GetCompanyProfile(Guid id)
        {
            CompanyProfilePoco poco = _logic.Get(id);

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
        [Route("companyprofile")]
        public ActionResult PostCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("companyprofile")]
        public ActionResult PutCompanyProfile([FromBody] CompanyProfilePoco[] pocos)

        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("companyprofile")]
        public ActionResult DeleteCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("companyprofile")]
        [ProducesResponseType(typeof(List<CompanyProfilePoco>), 200)]
        public ActionResult GetAllCompanyProfile()
        {
            return Ok(_logic.GetAll());
        }

    }
}
