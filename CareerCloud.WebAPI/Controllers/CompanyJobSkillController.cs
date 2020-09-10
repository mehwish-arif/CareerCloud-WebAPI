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
    public class CompanyJobSkillController : ControllerBase
    {
        private CompanyJobSkillLogic _logic;

        public CompanyJobSkillController()
        {
            EFGenericRepository<CompanyJobSkillPoco> repo = new EFGenericRepository<CompanyJobSkillPoco>();
            _logic = new CompanyJobSkillLogic(repo);
        }
        [HttpGet]
        [Route("companyjobskill/{id}")]
        [ProducesResponseType(typeof(CompanyJobSkillPoco), 200)]
        public ActionResult GetCompanyJobSkill(Guid id)
        {
            CompanyJobSkillPoco poco = _logic.Get(id);

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
        [Route("companyjobskill")]
        public ActionResult PostCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("companyjobskill")]
        public ActionResult PutCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)

        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("companyjobskill")]
        public ActionResult DeleteCompanyJobSkill([FromBody] CompanyJobSkillPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("companyjobskill")]
        [ProducesResponseType(typeof(List<CompanyJobSkillPoco>), 200)]
        public ActionResult GetAllCompanyJobSkill()
        {
            return Ok(_logic.GetAll());
        }

    }
}
