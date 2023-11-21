﻿using System;
using System.Security.Cryptography.X509Certificates;
using BussinessLogic.DTO;
using DataAccess.IRepository;
using DataAccess.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogic.Services
{
    public class ServiceCategoria
    {
        //Instancio el UnitOfWork que vamos a usar
        private readonly IUnitOfWork _unitOfWork;

        //Inyecto el UnitOfWork por el constructor, esto se hace para que se cree un nuevo contexto por cada vez que se llame a la clase
        public ServiceCategoria(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

     
        public async Task<CategoriaDTO> GetCategoriaById(int id)
        {
            return (await _unitOfWork.CategoriaRepository.GetById(id)).Adapt<CategoriaDTO>();

        }

      
     

    }
}