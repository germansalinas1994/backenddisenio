﻿using System;
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


        [HttpGet]
        [Route("/pid")]
        public async Task<ApiResponse> GetPID()
        {

            try
            {
                ApiResponse response = new ApiResponse();
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

        [HttpPost]
        [Route("/pid")]
        public async Task<ApiResponse> CrearPID([FromBody] PIDDTO pid)
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








    }
}

