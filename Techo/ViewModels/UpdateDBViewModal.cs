using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Techo.ViewModels
{
    public class UpdateDBViewModal
    {
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}
