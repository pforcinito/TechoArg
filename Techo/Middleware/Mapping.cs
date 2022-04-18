using AutoMapper;
using Techo.ViewModels;
using Techo.Models;
using System.Linq;

namespace Techo.Middleware
{
    public class Mapping : Profile
    {
        public Mapping()
        {
          

            CreateMap<ContribuyenteViewModel, Contribuyente>().ReverseMap();
            CreateMap<EntidadParticipativaViewModel, EntidadParticipativa>().ReverseMap();
            CreateMap<ContribuyenteModalViewModel, Contribuyente>().ReverseMap();
        }
    }
}