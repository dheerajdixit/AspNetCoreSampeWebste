using Practice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Photo> Photo { get; set; }
        public string PageTitle { get; set; }
    }
}
