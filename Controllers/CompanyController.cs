using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using sirmoto.Models;
using sirmoto.Data;
using sirmoto.Models.ManageViewModels;
using sirmoto.Services;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt ;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace sirmoto.Controllers
{    
    [Authorize]
    [Route("[controller]/[action]")]
    public class CompanyController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CompanyController(UserManager<ApplicationUser> userManager)
        {
           _userManager = userManager;
        }

        
        public async Task<IActionResult> Index()
        {   

            return View();    
        }
        [HttpGet]
        public async Task<IActionResult> NewCompany()
        {
            
                        var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var usrId = usr.Id;
            var company = await dbContext.Companies.Where(z => z.UserId == usrId ).ToListAsync();
            
            if  (company.Count == 0) 
            {
                return NotFound("User is not company");
            } 
            else 
                return new ObjectResult(JsonConvert.SerializeObject(company[0]));
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.FindByEmailAsync(User.Identity.Name);
    }
    
}