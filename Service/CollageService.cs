using Asp.netCoreMVCIntro.Context;
using Asp.netCoreMVCIntro.Models;
using Asp.netCoreMVCIntro.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Asp.netCoreMVCIntro.Service
{
    public class CollageService : ICollageService
    {
        private readonly CollageDbContext _context;
        public CollageService(CollageDbContext context)
        {
            _context = context;
        }

        public void Add(CollageViewModel collage)
        {
            var newCollage = new Collage()
            {
                Collage_Name = collage.Collage_Name,
                Address = collage.Address,
                Grade = collage.Grade,
                Code = collage.Code
            };

            _context.Collages.Add(newCollage);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Collage>> GetAllCollage()
        {
            return await _context.Collages.ToListAsync();
        }

        public async Task<Collage> GetCollage(int Id)
        {
            return await _context.Collages.FindAsync(Id);
        }

        public Collage Update(Collage collageModified)
        {
            _context.Update(collageModified);
            _context.SaveChanges();
            return collageModified;
        }

        public void Delete(int Id)
        {
            Collage collage = _context.Collages.Find(Id);
            if (collage != null)
            {
                _context.Collages.Remove(collage);
                _context.SaveChanges();
            }
        }
    }
}