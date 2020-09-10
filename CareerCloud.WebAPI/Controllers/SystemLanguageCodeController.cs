﻿using System;
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
    [Route("api/careercloud/system/v1")]
    [ApiController]
    public class SystemLanguageCodeController : ControllerBase
    {
        private SystemLanguageCodeLogic _logic;

        public SystemLanguageCodeController()
        {
            EFGenericRepository<SystemLanguageCodePoco> repo = new EFGenericRepository<SystemLanguageCodePoco>();
            _logic = new SystemLanguageCodeLogic(repo);
        }

        [HttpGet]
        [Route("SystemLanguageCode/{id}")]
        [ProducesResponseType(typeof(SystemLanguageCodePoco), 200)]
        public ActionResult GetSystemLanguageCode(string id)
        {
            SystemLanguageCodePoco poco = _logic.Get(id);

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
        [Route("SystemLanguageCode")]
        public ActionResult PostSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("SystemLanguageCode")]
        public ActionResult PutSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)

        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("SystemLanguageCode")]
        public ActionResult DeleteSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }

        [HttpGet]
        [Route("SystemLanguageCode")]
        [ProducesResponseType(typeof(List<SystemLanguageCodePoco>), 200)]
        public ActionResult GetAllSystemLanguageCode()
        {
            return Ok(_logic.GetAll());
        }
    }
}
