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
    public class ServicePID
    {
        //Instancio el UnitOfWork que vamos a usar
        private readonly IUnitOfWork _unitOfWork;

        //Inyecto el UnitOfWork por el constructor, esto se hace para que se cree un nuevo contexto por cada vez que se llame a la clase
        public ServicePID(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<int> CargarPID(RequestPIDDTO pid)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                Pid nuevoPid = new Pid();
                nuevoPid.Denominacion = pid.denominacion;
                nuevoPid.Director = pid.director;
                nuevoPid.IdUniversidad = pid.universidad;
                nuevoPid.IdTipoPid = pid.tipoPid;

                //logica de las fechas

                pid.fechaDesde = DateTime.Parse(pid.fechaDesde, null, DateTimeStyles.RoundtripKind).ToString("dd/MM/yyyy");
                pid.fechaHasta = DateTime.Parse(pid.fechaHasta, null, DateTimeStyles.RoundtripKind).ToString("dd/MM/yyyy");


                nuevoPid.FechaDesde = DateTime.ParseExact(pid.fechaDesde, "dd/MM/yyyy", null);
                nuevoPid.FechaHasta = DateTime.ParseExact(pid.fechaHasta, "dd/MM/yyyy", null);

                nuevoPid.FechaAlta = DateTime.Now;
                nuevoPid.FechaActualizacion = DateTime.Now;

                Pid pidCargado = await _unitOfWork.GenericRepository<Pid>().Insert(nuevoPid);

                PidUct nuevoPidUct = new PidUct();
                nuevoPidUct.IdPid = pidCargado.IdPid;
                nuevoPidUct.IdUct = pid.uct;
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

        public async Task<int> EditarPID(RequestPIDDTO pid)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                Pid pidbase = await _unitOfWork.GenericRepository<Pid>().GetById(pid.idPid);

                if (pidbase != null)
                {
                    pidbase.Denominacion = pid.denominacion;
                    pidbase.Director = pid.director;
                    pidbase.IdUniversidad = pid.universidad;
                    pidbase.IdTipoPid = pid.tipoPid;


                    pid.fechaDesde = DateTime.Parse(pid.fechaDesde, null, DateTimeStyles.RoundtripKind).ToString("dd/MM/yyyy");
                    pid.fechaHasta = DateTime.Parse(pid.fechaHasta, null, DateTimeStyles.RoundtripKind).ToString("dd/MM/yyyy");

                    pidbase.FechaDesde = DateTime.ParseExact(pid.fechaDesde, "dd/MM/yyyy", null);
                    pidbase.FechaHasta = DateTime.ParseExact(pid.fechaHasta, "dd/MM/yyyy", null);

                    // pidbase.FechaDesde = pid.FechaDesde.Value;
                    // pidbase.FechaHasta = pid.FechaHasta.Value;
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

            IList<Pid> pids = (await _unitOfWork.GenericRepository<Pid>().GetAllIncludingRelations()).Where(x => x.FechaBaja == null).ToList().OrderByDescending(x => x.FechaAlta).ToList();
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

        public async Task<PIDDTO> GetById(int id)
        {
            Pid pid = await _unitOfWork.GenericRepository<Pid>().GetByIdIncludingRelations(id);
            int idUct = (await _unitOfWork.GenericRepository<PidUct>().GetByCriteriaIncludingRelations(x => x.IdPid == pid.IdPid)).FirstOrDefault().IdUct.Value;
            Uct uct = await _unitOfWork.GenericRepository<Uct>().GetById(idUct);
            UCTDTO uctDTO = uct.Adapt<UCTDTO>();
            PIDDTO pidDTO = pid.Adapt<PIDDTO>();
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

        public async Task<IList<PIDDTO>> BuscarPIDFilter(int? idTipoPid, int? idUctFiltro)
        {
            List<Pid> pids = new List<Pid>();
            IList<PIDDTO> pidsDTO = new List<PIDDTO>();

            //Si vienen ambos filtros, filtro por ambos
            if (idTipoPid.HasValue && idTipoPid.Value != 0 && idUctFiltro.HasValue && idUctFiltro.Value != 0)
            {
                // Combinar ambos filtros.
                pids = (await _unitOfWork.GenericRepository<Pid>().GetByCriteriaIncludingRelations(
                           x => x.IdTipoPid == idTipoPid && x.PidUct.Any(y => y.IdUct == idUctFiltro) && x.FechaBaja == null))
                       .OrderByDescending(x => x.FechaAlta).ToList();
            }
            else
            {
                // Filtra solo por idTipoPid.
                if (idTipoPid.HasValue && idTipoPid.Value != 0)
                {
                    pids = (await _unitOfWork.GenericRepository<Pid>().GetByCriteriaIncludingRelations(
                               x => x.IdTipoPid == idTipoPid && x.FechaBaja == null))
                           .OrderByDescending(x => x.FechaAlta).ToList();
                }
                // Filtra solo por idUctFiltro.
                else if (idUctFiltro.HasValue && idUctFiltro.Value != 0)
                {
                    pids = (await _unitOfWork.GenericRepository<Pid>().GetByCriteriaIncludingRelations(
                               x => x.PidUct.Any(y => y.IdUct == idUctFiltro) && x.FechaBaja == null))
                           .OrderByDescending(x => x.FechaAlta).ToList();
                }
                // Si no viene ningun filtro entonces traigo todos los pids.
                else
                {
                    pids = (await _unitOfWork.GenericRepository<Pid>().GetAllIncludingRelations())
                           .Where(x => x.FechaBaja == null).OrderByDescending(x => x.FechaAlta).ToList();
                }
            }

            // Proceso para mapear Pid a PIDDTO.
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