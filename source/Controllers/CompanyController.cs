using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Misa.SmeNetCore.Data;
using Misa.SmeNetCore.Handlers;
using Misa.SmeNetCore.Models;
using Misa.SmeNetCore.Models.CompanyViewModels;
using Misa.SmeNetCore.Results;

namespace Misa.SmeNetCore.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    
    public class CompanyController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CompanyController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        [AllowAnonymous]
        [AuthorizeJWT]
        public async Task<IActionResult> AddCompany([FromBody] RegisterCompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var company = new Company() { CompanyName = model.CompanyName, Address = model.Address, TaxCode = model.TaxCode };
                _applicationDbContext.Add(company);
                var userCompany = new UserCompany() { CompanyID = company.CompanyID, UserID = model.UserID };
                _applicationDbContext.Add(userCompany);
                await _applicationDbContext.SaveChangesAsync();
                return Ok(new ServiceResult() { Code = 200, Data = "Thêm công ty thành công", Success = true });
            }
            else
            {
                return Ok(new ServiceResult() { Code = 400, Data = ModelState, Success = false });
            }
        }
    }
}