using Microsoft.EntityFrameworkCore;
using PruebaMicroservice.CRUD.Data;
using PruebaMicroservice.CRUD.Interface;
using PruebaMicroservice.CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMicroservice.CRUD.Repository
{
    public class RopositoryCargaBipRetail : IRepository<CargaBipRetail>
    {
        pruebaMicroserviceContext _context;

        public RopositoryCargaBipRetail(pruebaMicroserviceContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CargaBipRetail>> GetAll()
        {
            return await _context.CargaBipRetails.ToListAsync();
        }

        public async Task<CargaBipRetail> GetById(int Id)
        {
            var cargaBipRetail = await _context.CargaBipRetails.FindAsync(Id);

            if (cargaBipRetail == null)
            {
                return null;
            }

            return cargaBipRetail;
        }
        public async Task<CargaBipRetail> Add(CargaBipRetail _object)
        {
            try
            {
                _context.CargaBipRetails.Add(_object);
                await _context.SaveChangesAsync();

                return _object;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        public async Task<bool> Delete(int Id)
        {
            var cargaBipRetail = await _context.CargaBipRetails.FindAsync(Id);
            if (cargaBipRetail == null)
            {
                return false;
            }

            _context.CargaBipRetails.Remove(cargaBipRetail);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(CargaBipRetail _object)
        {
            try
            {
                _context.CargaBipRetails.Update(_object);
                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }

        }
    }
}
