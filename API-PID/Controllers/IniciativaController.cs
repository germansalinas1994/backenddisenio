using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessLogic.DTO;
using BussinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using AutoWrapper.Wrappers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_PID.Controllers
{
    [Route("api/[controller]")]
    public class IniciativaController : Controller
    {

        //Instancio el service que vamos a usar
        private ServiceIniciativa _service;

        //Inyecto el service por el constructor
        public IniciativaController(ServiceIniciativa service)
        {
            _service = service;
        }
        // GET: api/values




        [HttpPost]
        [Route("/iniciativa")]
        public async Task<ApiResponse> CrearIniciativa([FromBody] INICIATIVADTO ini)
        {
            await _service.CargarIniciativa(ini);
            ApiResponse response = new ApiResponse("La Iniciativa de Investigación se cargó exitosamente");
            return response;

        }

        [HttpPut]
        [Route("/iniciativa/{id}")]

        public async Task<ApiResponse> EliminarIniciativa(int id)
        {
            await _service.EliminarIniciativa(id);
            ApiResponse response = new ApiResponse("La Iniciativa se eliminó exitosamente");
            return response;
        }


        [HttpPut]
        [Route("/iniciativa")]
        public async Task<ApiResponse> EditarIniciativa([FromBody] INICIATIVADTO ini)
        {
            await _service.EditarIniciativa(ini);
            ApiResponse response = new ApiResponse("La iniciativa se modificó exitosamente");
            return response;
        }

        [HttpGet]
        [Route("/iniciativa")]

        public async Task<ApiResponse> ListarIniciativa()
        {
            IList<INICIATIVADTO> inis = await _service.GetAllIniciativa();
            ApiResponse response = new ApiResponse(new { data = inis });
            return response;
        }

        [HttpGet]
        [Route("/iniciativa/{id}")]
        public async Task<ApiResponse> GetIniciativa(int id)
        {
            INICIATIVADTO ini = await _service.GetById(id);
            ApiResponse response = new ApiResponse(new { data = ini });
            return response;
        }








    }
}

