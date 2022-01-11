using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Model
{
    public class Photo
    {
        public int Id { get; set; }
        [Required]
        public Location? Location { get; set; }
        [Required]
        public string Story { get; set; }
        [Required]
        public string PhotoLead { get; set; }

        public string UniquePhotoName { get; set; }

        public string AZ_Photo_Uri { get; set; }
    }
}
