using System;
using System.Security.Cryptography.X509Certificates;
using BussinessLogic.DTO;
using DataAccess.IRepository;
using DataAccess.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogic.Services
{
    public class ServicePID
    {
        //Instancio el UnitOfWork que vamos a usar
        private readonly IUnitOfWork _unitOfWork;

        //Inyecto el UnitOfWork por el constructor, esto se hace para que se cree un nuevo contexto por cada vez que se llame a la clase
        public ServicePID(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<int> CargarPID(PIDDTO pid)
        {

            Pid nuevoPid = new Pid();
            nuevoPid.Denominacion = pid.Denominacion;
            nuevoPid.Director = pid.Director;
            nuevoPid.IdUniversidad = pid.IdUniversidad;
            nuevoPid.IdTipoPid = pid.IdTipoPid;
            nuevoPid.FechaDesde = pid.FechaDesde.Value;
            nuevoPid.FechaHasta = pid.FechaHasta.Value;
            Pid pidCargado = await _unitOfWork.GenericRepository<Pid>().Insert(nuevoPid);
            return 0;

        }


    }




}