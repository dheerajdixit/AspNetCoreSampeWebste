using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Model
{
    public class MockPhotoRespository : IPhotoRepository
    {
        List<Photo> photoList;
        public MockPhotoRespository()
        {
            photoList = new List<Photo>()
            {
                new Photo { Id = 1, Location=Location.Goa, PhotoLead="Dheeraj", Story="Travelling to Goa" },
          new Photo { Id = 2, Location=Location.Goa, PhotoLead="Dheeraj", Story="Travelling to Goa" },
               new Photo { Id = 3, Location=Location.Goa, PhotoLead="Dheeraj", Story="Travelling to Goa" }
        };
        }

        public Photo Add(Photo p)
        {
            p.Id = photoList.Max(a => a.Id) + 1;
            photoList.Add(p);
            return p;
        }

        public void DeletePhoto(Photo p)
        {
            if (photoList.Find(b => b.Id == p.Id) != null)
            {
                photoList.Remove(p);
            }
        }

        public IEnumerable<Photo> GetAllPhoto()
        {
            return photoList;
        }

        public Photo GetPhoto(int employeeId)
        {
            return photoList.Where(e => e.Id == employeeId).FirstOrDefault();
        }

        public Photo UpdatePhoto(Photo p)
        {
            var u = photoList.FirstOrDefault(b => b.Id == p.Id);
            if (photoList.Find(b => b.Id == p.Id) != null)
            {               
                u.Location = p.Location;
                u.PhotoLead = p.PhotoLead;
                u.Story = p.Story;

            }
            return u;
        }
    }
}
