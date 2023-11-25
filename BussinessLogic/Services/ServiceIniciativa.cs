using System;
using System.Security.Cryptography.X509Certificates;
using BussinessLogic.DTO;
using DataAccess.IRepository;
using DataAccess.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogic.Services
{
    public class ServiceIniciativa
    {
        //Instancio el UnitOfWork que vamos a usar
        private readonly IUnitOfWork _unitOfWork;

        //Inyecto el UnitOfWork por el constructor, esto se hace para que se cree un nuevo contexto por cada vez que se llame a la clase
        public ServiceIniciativa(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<int> CargarIniciativa(INICIATIVADTO ini)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                IniciativaInvestigacion nuevaIniciativa = new IniciativaInvestigacion();
                nuevaIniciativa.Denominacion = ini.Denominacion;
                nuevaIniciativa.Director = ini.Director;
                nuevaIniciativa.IdUniversidad = ini.IdUniversidad;
                nuevaIniciativa.IdTipoPid = ini.IdTipoPid;
                nuevaIniciativa.FechaDesde = ini.FechaDesde.Value;
                nuevaIniciativa.FechaHasta = ini.FechaHasta.Value;
                nuevaIniciativa.FechaAlta = DateTime.Now;
                nuevaIniciativa.FechaActualizacion = DateTime.Now;
                nuevaIniciativa.Programa = ini.Programa;

                IniciativaInvestigacion iniciativaCargada = await _unitOfWork.GenericRepository<IniciativaInvestigacion>().Insert(nuevaIniciativa);

                UctIniciativainvestigacion nuevoUctIniciativa = new UctIniciativainvestigacion();
                nuevoUctIniciativa.IdIniciativainvestigacion = iniciativaCargada.IdIniciativaInvestigacion;
                nuevoUctIniciativa.IdUct = ini.IdUCT; // esto esta bien??????????
                nuevoUctIniciativa.FechaAlta = DateTime.Now;
                nuevoUctIniciativa.FechaActualizacion = DateTime.Now;
                UctIniciativainvestigacion uctIniciativaCargado = await _unitOfWork.GenericRepository<UctIniciativainvestigacion>().Insert(nuevoUctIniciativa);
                await _unitOfWork.CommitAsync();

            }

            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw ex;

            }

            return 0;

        }

        public async Task<bool> EliminarIniciativa(int id)
        {
            IniciativaInvestigacion ini = await _unitOfWork.GenericRepository<IniciativaInvestigacion>().GetById(id);

            if (ini != null)
            {
                ini.FechaBaja = DateTime.Now;
                ini.FechaActualizacion = DateTime.Now;
                IniciativaInvestigacion iniActualizada = await _unitOfWork.GenericRepository<IniciativaInvestigacion>().Update(ini);
            }

            return true;

        }

        public async Task<int> EditarIniciativa(INICIATIVADTO ini)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                IniciativaInvestigacion inibase = await _unitOfWork.GenericRepository<IniciativaInvestigacion>().GetById(ini.IdIniciativaInvestigacion.Value);

                if (inibase != null)
                {
                    inibase.Denominacion = ini.Denominacion;
                    inibase.Director = ini.Director;
                    inibase.IdUniversidad = ini.IdUniversidad;
                    inibase.IdTipoPid = ini.IdTipoPid;
                    inibase.FechaDesde = ini.FechaDesde.Value;
                    inibase.FechaHasta = ini.FechaHasta.Value;
                    inibase.FechaActualizacion = DateTime.Now;
                    inibase.Programa = ini.Programa;

                    IniciativaInvestigacion iniciativaCargado = await _unitOfWork.GenericRepository<IniciativaInvestigacion>().Update(inibase);

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


        public async Task<IList<INICIATIVADTO>> GetAllIniciativa()
        {

            IList<IniciativaInvestigacion> inis = (await _unitOfWork.GenericRepository<IniciativaInvestigacion>().GetByCriteria(x => x.FechaBaja == null)).OrderByDescending(x => x.FechaAlta).ToList();
            IList<INICIATIVADTO> inisDTO = inis.Adapt<IList<INICIATIVADTO>>();

            return inisDTO;

        }

        public async Task<INICIATIVADTO> GetById(int id)
        {
            IniciativaInvestigacion ini = await _unitOfWork.GenericRepository<IniciativaInvestigacion>().GetById(id);
            int idUct = (await _unitOfWork.GenericRepository<UctIniciativainvestigacion>().GetByCriteria(x => x.IdIniciativainvestigacion == ini.IdIniciativaInvestigacion)).FirstOrDefault().IdUct.Value;
            Uct uct = await _unitOfWork.GenericRepository<Uct>().GetById(idUct);
            UCTDTO uctDTO = uct.Adapt<UCTDTO>();
            INICIATIVADTO iniDTO = ini.Adapt<INICIATIVADTO>();
            iniDTO.Uct = uctDTO;

            return iniDTO;
        }




    }




}