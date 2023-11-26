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
    public class PIDController : Controller
    {

        //Instancio el service que vamos a usar
        private ServicePID _service;

        //Inyecto el service por el constructor
        public PIDController(ServicePID service)
        {
            _service = service;
        }
        // GET: api/values




        [HttpPost]
        [Route("/pid")]
        public async Task<ApiResponse> CrearPID([FromBody] RequestPIDDTO pid)
        {
            await _service.CargarPID(pid);
            ApiResponse response = new ApiResponse("El PID se cargó exitosamente");
            return response;
        }

        [HttpPut]
        [Route("/pid/{id}")]

        public async Task<ApiResponse> EliminarPID(int id)
        {
            await _service.EliminarPID(id);
            ApiResponse response = new ApiResponse("El PID se eliminó exitosamente");
            return response;
        }

        [HttpPut]
        [Route("/pid")]
        public async Task<ApiResponse> EditarPID([FromBody] RequestPIDDTO pid)
        {
            await _service.EditarPID(pid);
            ApiResponse response = new ApiResponse("El PID se modificó exitosamente");
            return response;
        }

        [HttpGet]
        [Route("/pid")]

        public async Task<ApiResponse> ListarPID()
        {
            IList<PIDDTO> pids = await _service.GetAllPID();
            ApiResponse response = new ApiResponse(new { data = pids });
            return response;
        }

        [HttpGet]
        [Route("/pid/{id}")]
        public async Task<ApiResponse> GetPID(int id)
        {
            PIDDTO pid = await _service.GetById(id);
            ApiResponse response = new ApiResponse(new { data = pid });
            return response;
        }


        [HttpGet]
        [Route("/uct")]

        public async Task<ApiResponse> GetUcts()
        {
            IList<UCTDTO> ucts = await _service.GetAllUcts();
            ApiResponse response = new ApiResponse(new { data = ucts });
            return response;
        }

        [HttpGet]
        [Route("/tipoPid")]

        public async Task<ApiResponse> GetTipoPids()
        {
            IList<TipoPidDTO> tipoPids = await _service.GetAllTipoPids();
            ApiResponse response = new ApiResponse(new { data = tipoPids });
            return response;
        }


        [HttpGet]
        [Route("/universidad")]

        public async Task<ApiResponse> GetUniversidades()
        {
            IList<UniversidadDTO> universidades = await _service.GetAllUniversidades();
            ApiResponse response = new ApiResponse(new { data = universidades });
            return response;
        }



    }
}

