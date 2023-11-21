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
    public class CategoriaController : Controller
    {

        //Instancio el service que vamos a usar
        private ServiceCategoria _service;

        //Inyecto el service por el constructor
        public CategoriaController(ServiceCategoria service)
        {
            _service = service;
        }
        // GET: api/values


        [HttpGet]
        [Route("/categoria/{id}")]
        public async Task<ApiResponse> GetCategoriaById(int id)
        {
            if (id == 0)
            {
                throw new ApiException("Debe ingresar un id de categoria valido");
            }

            try
            {
                CategoriaDTO categoria = await _service.GetCategoriaById(id);
                ApiResponse response = new ApiResponse(new { data = categoria });
                return response;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                throw new ApiException(ex);
            }


        }


       

    }
}

