using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Model
{
    public class SQLPhotoRepository : IPhotoRepository
    {
        AppDbContext _context;
        public SQLPhotoRepository(AppDbContext context)
        {
            _context = context;
        }
        public Photo Add(Photo p)
        {
            _context.Photos.Add(p);
            _context.SaveChanges();
            return p;
        }

        public void DeletePhoto(Photo p)
        {
            _context.Photos.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<Photo> GetAllPhoto() => _context.Photos;


        public Photo GetPhoto(int photoId) => _context.Photos.FirstOrDefault(c => c.Id == photoId);


        public Photo UpdatePhoto(Photo p)
        {
            var u = _context.Photos.Attach(p);
            u.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return p;
        }
    }
}
