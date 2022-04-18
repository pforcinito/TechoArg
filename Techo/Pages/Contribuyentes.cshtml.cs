using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Caching.Memory;
using Techo.Contracts;
using Techo.Models;
using Techo.ViewModels;

namespace Techo.Pages
{
    public class ContribuyentesView : ModelBase
    {
        private const string _modal = "Modals/ContribuyenteModal";

        private readonly IContribuyenteService _service;
        private readonly IEntidadParticipativaService _serviceTD;
        private readonly IMapper _mapper;

        //[TempData]
        //public string Message { get; set; }

        public ContribuyentesView(IContribuyenteService service, IMapper mapper, IEntidadParticipativaService serviceTD)
        {
            _service = service;
            _mapper = mapper;
            _serviceTD = serviceTD;
        }

        public void OnGet()
        {
            CheckLogin();
        }

        public IActionResult OnGetContribuyentes()
        {
            var res = _mapper.Map<List<ContribuyenteViewModel>>(_service.GetAll());
            return new JsonResult(res);
        }

        //public PartialViewResult OnGetClienteModal(short? id)
        //{
        //    var clienteViewModel = new ClienteViewModel();

        //    if (id.HasValue)
        //        clienteViewModel = _mapper.Map<ClienteViewModel>(_service.GetById(id.Value));

        //    return new PartialViewResult
        //    {
        //        ViewName = _modal,
        //        ViewData = new ViewDataDictionary<ClienteViewModel>(ViewData, clienteViewModel)
        //    };
        //}

        public PartialViewResult OnGetContribuyenteModal(short? id)
        {
            var clienteModalViewModel = new ContribuyenteModalViewModel();

            if (id.HasValue)
            {
                var contribuyente = _service.GetById(id.Value);
                clienteModalViewModel = _mapper.Map<ContribuyenteModalViewModel>(contribuyente);
            }

            clienteModalViewModel.EntidadParticipativa = _serviceTD.GetAll();

            return new PartialViewResult
            {
                ViewName = _modal,
                ViewData = new ViewDataDictionary<ContribuyenteModalViewModel>(ViewData, clienteModalViewModel)
            };
        }

        public PartialViewResult OnPostSaveContribuyente(ContribuyenteModalViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cliente = _mapper.Map<Contribuyente>(model);
                var res = _service.Save(cliente);

                if(res != 0)
                    TempData["success"] = "registro grabado";
            }

            return new PartialViewResult
            {
                ViewName = _modal,
                ViewData = new ViewDataDictionary<ContribuyenteModalViewModel>(ViewData, model)
            };
        }

        public IActionResult OnPostEditContribuyente(ContribuyenteModalViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cliente = _mapper.Map<Contribuyente>(model);
                var res = _service.Update(cliente);
            }

            return new PartialViewResult
            {
                ViewName = _modal,
                ViewData = new ViewDataDictionary<ContribuyenteModalViewModel>(ViewData, model)
            };
        }
    }
}
