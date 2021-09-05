using CRUD.Server.Model;
using CRUD.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
        private readonly IModel _model;

        public CRUDController(IModel model)
        {
            _model = model;
        }

        [HttpGet]
        [Route("HaalOpEigenaren")]
        public async Task<ActionResult<IEnumerable<EIGENAAR>>> HaalOpEigenaren()
        {
            try
            {
                IEnumerable<EIGENAAR> resultaat = await _model.HaalOpEigenaren();
                return Ok(resultaat);
            }
            catch (Exception e)
            {
                return Problem(
                   statusCode: (int)HttpStatusCode.InternalServerError,
                   detail: "Er is iets fout gegaan met action method " +
                           "HaalOpEigenaren van CRUDController: " + e.Message);
            }

        }

        [HttpGet]
        [Route("HaalOpEigenaar/{ID}")]
        public async Task<ActionResult<EIGENAAR>> HaalopEigenaar(int ID)
        {
            try
            {
                var resultaat = await _model.HaalopEigenaar(ID);
                if (resultaat == null)
                {
                    // return NotFound();
                    return Problem(
                       statusCode: (int)HttpStatusCode.NotFound,
                       detail: "Er is iets fout gegaan met action method " +
                               "HaalOpEigenaar van CRUDController: Niks gevonden");
                }
                return Ok(resultaat);
            }
            catch (Exception e)
            {
                return Problem(
                   statusCode: (int)HttpStatusCode.InternalServerError,
                   detail: "Er is iets fout gegaan met action method " +
                   "HaalOpEigenaar van CRUDController: " + e.Message);
            }
        }

        [HttpPost]
        [Route("VoegToe")]
        public async Task<ActionResult<EIGENAAR>> VoegToe([FromBody] EIGENAAR eigenaar)
        {
            try
            {
                var resultaat = await _model.VoegToe(eigenaar);
                return Ok(resultaat);
            }
            catch (Exception e)
            {
                return Problem(
                    statusCode: (int)HttpStatusCode.InternalServerError,
                    detail: "Er is iets fout gegaan met action method " +
                             "VoegToe van CRUDController: " + e.Message);
            }
        }

        [HttpPut]
        [Route("Muteer")]
        public async Task<ActionResult<EIGENAAR>> Muteer([FromBody] EIGENAAR eigenaar)
        {
            try
            {
                var resultaat = await _model.Muteer(eigenaar);

                if (resultaat == null)
                    return Problem(
                        statusCode: (int)HttpStatusCode.NotFound,
                        detail: "Er is iets fout gegaan met action method " +
                                 "Muteer van CRUDController: de eigenaar kan niet gevonden worden. ");

                return Ok(resultaat);
            }
            catch (Exception e)
            {
                return Problem(
                    statusCode: (int)HttpStatusCode.InternalServerError,
                    detail: "Er is iets fout gegaan met action method " +
                            "Muteer van CRUDController: " + e.Message);
            }
        }

        [HttpDelete]
        [Route("Verwijder/{ID}")]
        public async Task<ActionResult<bool>> Verwijder(int ID)
        {
            try
            {
                var resultaat = await _model.Verwijder(ID);

                if (resultaat == false)
                    return Problem(
                        statusCode: (int)HttpStatusCode.NotFound,
                        detail: "Er is iets fout gegaan met action method Verwijder " +
                                "van CRUDController: de eigenaar kan niet gevonden worden. ");

                return Ok(resultaat);
            }
            catch (Exception e)
            {
                return Problem(
                    statusCode: (int)HttpStatusCode.InternalServerError,
                    detail: "Er is iets fout gegaan met action method Verwijder " +
                            "van CRUDController: " + e.Message);
            }
        }
    }
}

