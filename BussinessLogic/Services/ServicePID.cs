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
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                Pid nuevoPid = new Pid();
                nuevoPid.Denominacion = pid.Denominacion;
                nuevoPid.Director = pid.Director;
                nuevoPid.IdUniversidad = pid.IdUniversidad;
                nuevoPid.IdTipoPid = pid.IdTipoPid;
                nuevoPid.FechaDesde = pid.FechaDesde.Value;
                nuevoPid.FechaHasta = pid.FechaHasta.Value;
                nuevoPid.FechaAlta = DateTime.Now;
                nuevoPid.FechaActualizacion = DateTime.Now;

                Pid pidCargado = await _unitOfWork.GenericRepository<Pid>().Insert(nuevoPid);
                PidUct nuevoPidUct = new PidUct();
                nuevoPidUct.IdPid = pidCargado.IdPid;
                nuevoPidUct.IdUct = pid.IdUCT;
                nuevoPidUct.FechaAlta = DateTime.Now;
                nuevoPidUct.FechaActualizacion = DateTime.Now;
                PidUct pidUctCargado = await _unitOfWork.GenericRepository<PidUct>().Insert(nuevoPidUct);
                await _unitOfWork.CommitAsync();

            }

            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw ex;

            }



            return 0;

        }

        public async Task<bool> EliminarPID(int id)
        {
            Pid pid = await _unitOfWork.GenericRepository<Pid>().GetById(id);

            if (pid != null)
            {
                pid.FechaBaja = DateTime.Now;
                pid.FechaActualizacion = DateTime.Now;
                Pid pidActualizado = await _unitOfWork.GenericRepository<Pid>().Update(pid);
            }


            return true;

        }
    }




}