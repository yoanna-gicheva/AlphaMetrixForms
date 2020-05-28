using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AlphaMetrixForms.Services.Contracts;
using AlphaMetrixForms.Services.DTOs;
using AlphaMetrixForms.Web.Models.Form;
using AlphaMetrixForms.Web.Models.User;
using AlphaMetrixForms.Web.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlphaMetrixForms.Web.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _service;
        private readonly IMapper _mapper;
        private readonly IFormService _formService;
        public UserController(IUserService service, IFormService formService, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _service = service ?? throw new ArgumentNullException(nameof(mapper));
            _formService = formService ?? throw new ArgumentNullException(nameof(mapper));
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Account()
        {
            Guid userId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));

            UserDTO user = await _service.UserDetails(userId, _mapper);
            if (user == null)
                return RedirectToAction("Error");

            UserViewModel toPass = _mapper.Map<UserViewModel>(user);
            return View("AccountView", toPass);
        }
        public async Task<IActionResult> MyForms(int? pageNumber)
        {
            Guid userId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            IEnumerable<FormDTO> forms = await _service.MyForms(userId, _mapper);
            IEnumerable<FormViewModel>  result = _mapper.Map<IEnumerable<FormViewModel>>(forms);


            int pageSize = 9;
            return View("MyFormsView", PaginatedList<FormViewModel>.CreateAsync(result.Reverse(), pageNumber ?? 1, pageSize));
        }
    }
}