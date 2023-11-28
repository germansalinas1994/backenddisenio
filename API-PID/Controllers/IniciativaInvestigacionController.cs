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
    public class IniciativaInvestigacionController : Controller
    {

        //Instancio el service que vamos a usar
        private ServiceIniciativaInvestigacion _service;

        //Inyecto el service por el constructor
        public IniciativaInvestigacionController(ServiceIniciativaInvestigacion service)
        {
            _service = service;
        }
        // GET: api/values




        [HttpPost]
        [Route("/iniciativa")]
        public async Task<ApiResponse> CrearIniciativa([FromBody] RequestIniciativaDTO iniciativa)
        {
            await _service.CargarIniciativa(iniciativa);
            ApiResponse response = new ApiResponse("La Iniciativa de Investigación se cargó exitosamente");
            return response;
        }

        [HttpPut]
        [Route("/iniciativa/{id}")]

        public async Task<ApiResponse> EliminarPID(int id)
        {
            await _service.EliminarPID(id);
            ApiResponse response = new ApiResponse("La Iniciativa de Investigación se eliminó exitosamente");
            return response;
        }

        [HttpPut]
        [Route("/iniciativa")]
        public async Task<ApiResponse> EditarPID([FromBody] RequestIniciativaDTO pid)
        {
            try
            {
                if (pid.idIniciativaInvestigacion == 0 || pid.idIniciativaInvestigacion == null)
                {
                    throw new Exception("No se ha encontrado la Iniciativa de Investigación");
                }
                await _service.EditarPID(pid);
                ApiResponse response = new ApiResponse("La Iniciativa de Investigación se modificó exitosamente");
                return response;
            }
            catch (Exception e)
            {
                ApiResponse response = new ApiResponse(e.Message);
                return response;
            }


        }

        [HttpGet]
        [Route("/iniciativa")]

        public async Task<ApiResponse> ListarPID()
        {
            IList<IniciativaDTO> pids = await _service.GetAllPID();
            ApiResponse response = new ApiResponse(new { data = pids });
            return response;
        }

        [HttpPost]
        [Route("/buscarIniciativa")]
        public async Task<ApiResponse> BuscarPIDFilter([FromBody] FilterIniciativa filtro)
        {
            IList<IniciativaDTO> pids = await _service.BuscarPIDFilter(filtro.tipoPid, filtro.uct);
            ApiResponse response = new ApiResponse(new { data = pids });
            return response;
        }

        [HttpGet]
        [Route("/iniciativa/{id}")]
        public async Task<ApiResponse> GetPID(int id)
        {
            IniciativaDTO pid = await _service.GetById(id);
            ApiResponse response = new ApiResponse(new { data = pid });
            return response;
        }

    }
}

public class FilterIniciativa
{
    public int? tipoPid { get; set; }
    public int? uct { get; set; }
}