using System;
using System.Security.Cryptography.X509Certificates;
using BussinessLogic.DTO;
using DataAccess.IRepository;
using DataAccess.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BussinessLogic.Services
{
    public class ServiceIniciativaInvestigacion
    {
        //Instancio el UnitOfWork que vamos a usar
        private readonly IUnitOfWork _unitOfWork;

        //Inyecto el UnitOfWork por el constructor, esto se hace para que se cree un nuevo contexto por cada vez que se llame a la clase
        public ServiceIniciativaInvestigacion(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<int> CargarIniciativa(RequestIniciativaDTO pid)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                IniciativaInvestigacion nuevoPid = new IniciativaInvestigacion();
                nuevoPid.Denominacion = pid.denominacion;
                nuevoPid.Director = pid.director;
                nuevoPid.Programa = pid.programa;
                nuevoPid.IdUniversidad = pid.universidad;
                nuevoPid.IdTipoPid = pid.tipoPid;

                //logica de las fechas

                pid.fechaDesde = DateTime.Parse(pid.fechaDesde, null, DateTimeStyles.RoundtripKind).ToString("dd/MM/yyyy");
                pid.fechaHasta = DateTime.Parse(pid.fechaHasta, null, DateTimeStyles.RoundtripKind).ToString("dd/MM/yyyy");


                nuevoPid.FechaDesde = DateTime.ParseExact(pid.fechaDesde, "dd/MM/yyyy", null);
                nuevoPid.FechaHasta = DateTime.ParseExact(pid.fechaHasta, "dd/MM/yyyy", null);

                nuevoPid.FechaAlta = DateTime.Now;
                nuevoPid.FechaActualizacion = DateTime.Now;

                IniciativaInvestigacion pidCargado = await _unitOfWork.GenericRepository<IniciativaInvestigacion>().Insert(nuevoPid);

                UctIniciativainvestigacion nuevoPidUct = new UctIniciativainvestigacion();
                nuevoPidUct.IdIniciativainvestigacion = pidCargado.IdIniciativaInvestigacion;
                nuevoPidUct.IdUct = pid.uct;
                nuevoPidUct.FechaAlta = DateTime.Now;
                nuevoPidUct.FechaActualizacion = DateTime.Now;

                UctIniciativainvestigacion pidUctCargado = await _unitOfWork.GenericRepository<UctIniciativainvestigacion>().Insert(nuevoPidUct);

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
            IniciativaInvestigacion pid = await _unitOfWork.GenericRepository<IniciativaInvestigacion>().GetById(id);

            if (pid != null)
            {
                pid.FechaBaja = DateTime.Now;
                pid.FechaActualizacion = DateTime.Now;
                IniciativaInvestigacion pidActualizado = await _unitOfWork.GenericRepository<IniciativaInvestigacion>().Update(pid);
            }


            return true;

        }

        public async Task<int> EditarPID(RequestIniciativaDTO pid)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                IniciativaInvestigacion pidbase = await _unitOfWork.GenericRepository<IniciativaInvestigacion>().GetById(pid.idIniciativaInvestigacion);

                if (pidbase != null)
                {
                    pidbase.Denominacion = pid.denominacion;
                    pidbase.Director = pid.director;
                    pidbase.Programa = pid.programa;
                    pidbase.IdUniversidad = pid.universidad;
                    pidbase.IdTipoPid = pid.tipoPid;


                    pid.fechaDesde = DateTime.Parse(pid.fechaDesde, null, DateTimeStyles.RoundtripKind).ToString("dd/MM/yyyy");
                    pid.fechaHasta = DateTime.Parse(pid.fechaHasta, null, DateTimeStyles.RoundtripKind).ToString("dd/MM/yyyy");

                    pidbase.FechaDesde = DateTime.ParseExact(pid.fechaDesde, "dd/MM/yyyy", null);
                    pidbase.FechaHasta = DateTime.ParseExact(pid.fechaHasta, "dd/MM/yyyy", null);

                    // pidbase.FechaDesde = pid.FechaDesde.Value;
                    // pidbase.FechaHasta = pid.FechaHasta.Value;
                    pidbase.FechaActualizacion = DateTime.Now;

                    IniciativaInvestigacion pidCargado = await _unitOfWork.GenericRepository<IniciativaInvestigacion>().Update(pidbase);

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

        public async Task<IList<IniciativaDTO>> GetAllPID()
        {

            IList<IniciativaInvestigacion> pids = (await _unitOfWork.GenericRepository<IniciativaInvestigacion>().GetAllIncludingRelations()).Where(x => x.FechaBaja == null).ToList().OrderByDescending(x => x.FechaAlta).ToList();
            IList<IniciativaDTO> pidsDTO = new List<IniciativaDTO>();
            foreach (IniciativaInvestigacion pid in pids)
            {
                int idUct = (await _unitOfWork.GenericRepository<UctIniciativainvestigacion>().GetByCriteria(x => x.IdIniciativainvestigacion == pid.IdIniciativaInvestigacion)).FirstOrDefault().IdUct.Value;
                Uct uct = await _unitOfWork.GenericRepository<Uct>().GetById(idUct);
                UCTDTO uctDTO = uct.Adapt<UCTDTO>();
                IniciativaDTO pidDTO = pid.Adapt<IniciativaDTO>();
                pidDTO.Uct = uctDTO;
                pidsDTO.Add(pidDTO);
            }

            return pidsDTO;



        }

        public async Task<IniciativaDTO> GetById(int id)
        {
            IniciativaInvestigacion pid = await _unitOfWork.GenericRepository<IniciativaInvestigacion>().GetByIdIncludingRelations(id);
            int idUct = (await _unitOfWork.GenericRepository<UctIniciativainvestigacion>().GetByCriteriaIncludingRelations(x => x.IdUctIniciativaInvestigacion == pid.IdIniciativaInvestigacion)).FirstOrDefault().IdUct.Value;
            Uct uct = await _unitOfWork.GenericRepository<Uct>().GetById(idUct);
            UCTDTO uctDTO = uct.Adapt<UCTDTO>();
            IniciativaDTO pidDTO = pid.Adapt<IniciativaDTO>();
            pidDTO.Uct = uctDTO;

            return pidDTO;
        }

        public async Task<IList<UCTDTO>> GetAllUcts()
        {
            IList<Uct> ucts = await _unitOfWork.GenericRepository<Uct>().GetAll();
            IList<UCTDTO> uctsDTO = ucts.Adapt<IList<UCTDTO>>();
            return uctsDTO;
        }

        public async Task<IList<TipoPidDTO>> GetAllTipoPids()
        {
            IList<Tipopid> tipoPids = await _unitOfWork.GenericRepository<Tipopid>().GetAll();
            IList<TipoPidDTO> tipoPidsDTO = tipoPids.Adapt<IList<TipoPidDTO>>();
            return tipoPidsDTO;
        }

        public async Task<IList<UniversidadDTO>> GetAllUniversidades()
        {
            IList<Universidad> universidades = await _unitOfWork.GenericRepository<Universidad>().GetAll();
            IList<UniversidadDTO> universidadesDTO = universidades.Adapt<IList<UniversidadDTO>>();
            return universidadesDTO;
        }

        public async Task<IList<IniciativaDTO>> BuscarPIDFilter(int? idTipoPid, int? idUctFiltro)
        {
            List<IniciativaInvestigacion> pids = new List<IniciativaInvestigacion>();
            IList<IniciativaDTO> pidsDTO = new List<IniciativaDTO>();

            //Si vienen ambos filtros, filtro por ambos
            if (idTipoPid.HasValue && idTipoPid.Value != 0 && idUctFiltro.HasValue && idUctFiltro.Value != 0)
            {
                // Combinar ambos filtros.
                pids = (await _unitOfWork.GenericRepository<IniciativaInvestigacion>().GetByCriteriaIncludingRelations(
                           x => x.IdTipoPid == idTipoPid && x.UctIniciativainvestigacion.Any(y => y.IdUct == idUctFiltro) && x.FechaBaja == null))
                       .OrderByDescending(x => x.FechaAlta).ToList();
            }
            else
            {
                // Filtra solo por idTipoPid.
                if (idTipoPid.HasValue && idTipoPid.Value != 0)
                {
                    pids = (await _unitOfWork.GenericRepository<IniciativaInvestigacion>().GetByCriteriaIncludingRelations(
                               x => x.IdTipoPid == idTipoPid && x.FechaBaja == null))
                           .OrderByDescending(x => x.FechaAlta).ToList();
                }
                // Filtra solo por idUctFiltro.
                else if (idUctFiltro.HasValue && idUctFiltro.Value != 0)
                {
                    pids = (await _unitOfWork.GenericRepository<IniciativaInvestigacion>().GetByCriteriaIncludingRelations(
                               x => x.UctIniciativainvestigacion.Any(y => y.IdUct == idUctFiltro) && x.FechaBaja == null))
                           .OrderByDescending(x => x.FechaAlta).ToList();
                }
                // Si no viene ningun filtro entonces traigo todos los pids.
                else
                {
                    pids = (await _unitOfWork.GenericRepository<IniciativaInvestigacion>().GetAllIncludingRelations())
                           .Where(x => x.FechaBaja == null).OrderByDescending(x => x.FechaAlta).ToList();
                }
            }

            // Proceso para mapear Pid a PIDDTO.
            foreach (IniciativaInvestigacion pid in pids)
            {
                int idUct = (await _unitOfWork.GenericRepository<PidUct>().GetByCriteria(x => x.IdPid == pid.IdIniciativaInvestigacion)).FirstOrDefault().IdUct.Value;
                Uct uct = await _unitOfWork.GenericRepository<Uct>().GetById(idUct);
                UCTDTO uctDTO = uct.Adapt<UCTDTO>();
                IniciativaDTO pidDTO = pid.Adapt<IniciativaDTO>();
                pidDTO.Uct = uctDTO;
                pidsDTO.Add(pidDTO);
            }

            return pidsDTO;
        }

        public async Task<IList<PIDDTO>> GetUltimosPids()
        {
            IList<Pid> pids = (await _unitOfWork.GenericRepository<Pid>().GetAllIncludingRelations()).Where(x => x.FechaBaja == null).ToList().OrderByDescending(x => x.FechaAlta).Take(3).ToList();
            IList<PIDDTO> pidsDTO = new List<PIDDTO>();
            foreach (Pid pid in pids)
            {
                int idUct = (await _unitOfWork.GenericRepository<PidUct>().GetByCriteria(x => x.IdPid == pid.IdPid)).FirstOrDefault().IdUct.Value;
                Uct uct = await _unitOfWork.GenericRepository<Uct>().GetById(idUct);
                UCTDTO uctDTO = uct.Adapt<UCTDTO>();
                PIDDTO pidDTO = pid.Adapt<PIDDTO>();
                pidDTO.Uct = uctDTO;
                pidsDTO.Add(pidDTO);
            }

            return pidsDTO;
        }
    }




}