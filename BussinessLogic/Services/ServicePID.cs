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

        public async Task<int> EditarPID(PIDDTO pid)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                Pid pidbase = await _unitOfWork.GenericRepository<Pid>().GetById(pid.IdPid.Value);

                if (pidbase != null)
                {
                    pidbase.Denominacion = pid.Denominacion;
                    pidbase.Director = pid.Director;
                    pidbase.IdUniversidad = pid.IdUniversidad;
                    pidbase.IdTipoPid = pid.IdTipoPid;
                    pidbase.FechaDesde = pid.FechaDesde.Value;
                    pidbase.FechaHasta = pid.FechaHasta.Value;
                    pidbase.FechaActualizacion = DateTime.Now;

                    Pid pidCargado = await _unitOfWork.GenericRepository<Pid>().Update(pidbase);

                }

                await _unitOfWork.CommitAsync();

            }

            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw ex;

            }

            return 0;
        }

        public async Task<IList<PIDDTO>> GetAllPID()
        {

            IList<Pid> pids = (await _unitOfWork.GenericRepository<Pid>().GetAllIncludingRelations()).Where(x => x.FechaBaja == null).ToList().OrderByDescending(x => x.FechaDesde).ToList();
            IList<PIDDTO> pidDTO = pids.Adapt<IList<PIDDTO>>();

            return pidDTO;

        }

        public async Task<PIDDTO> GetById(int id)
        {
            Pid pid = await _unitOfWork.GenericRepository<Pid>().GetById(id);
            int idUct = (await _unitOfWork.GenericRepository<PidUct>().GetByCriteria(x => x.IdPid == pid.IdPid)).FirstOrDefault().IdUct.Value;
            Uct uct = await _unitOfWork.GenericRepository<Uct>().GetById(idUct);
            UCTDTO uctDTO = uct.Adapt<UCTDTO>();
            PIDDTO pidDTO = pid.Adapt<PIDDTO>();
            pidDTO.Uct = uctDTO;

            return pidDTO;
        }
    }




}