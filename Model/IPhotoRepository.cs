using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Model
{
    public interface IPhotoRepository
    {
        Photo GetPhoto(int employeeId);
        IEnumerable<Photo> GetAllPhoto();
        Photo Add(Photo p);

        Photo UpdatePhoto(Photo p);

        void DeletePhoto(Photo p);

    }
}
