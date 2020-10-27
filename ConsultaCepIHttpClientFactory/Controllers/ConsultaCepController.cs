using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaCepIHttpClientFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaCepController : ControllerBase
    {
        private readonly IHttpInstance httpInstance;
        public ConsultaCepController(IHttpInstance httpInstance)
        {
            this.httpInstance = httpInstance;
        }
        /// <summary>
        /// Metodo para consultar cep
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        [HttpGet("consulta-cep")]
        public async Task<ActionResult> ConsultarCep(string cep)
        {

            try
            {
                var retorno = await httpInstance.Get("34585210/json/", "ViaCep");


                return Ok("");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
