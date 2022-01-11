using Microsoft.AspNetCore.Http;
using Practice.Model;
using System.ComponentModel.DataAnnotations;

namespace PhotoManager
{
    public class PhotoViewModel
    {


        [Required]
        public Location? Location { get; set; }
        [Required]
        public string Story { get; set; }
        [Required]
        public string PhotoLead { get; set; }

        public IFormFile Photo { get; set; }


    }
}
