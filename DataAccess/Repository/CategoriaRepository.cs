using System;
using DataAccess.IRepository;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace DataAccess.Repository
{
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
    {


        //que hace esta linea
        public CategoriaRepository(DbveterinariaContext _context) : base(_context)
        {
        }


        public async Task<Categoria?> GetByIdCategoria(int id)
        {
            //esto tambien lo implementa haciendo la consulta sql
            return await _context.Categoria.FirstOrDefaultAsync(x => x.IdCategoria == id);


        }


    }
}

