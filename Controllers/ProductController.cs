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
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        
        public async Task<IActionResult> Items()
        {   
            return View();    
        }

        public async Task<IActionResult> Layanan()
        {   
            return View();    
        }

        public async Task<IActionResult> GetAll()
        {   
            var dbContext = new sirmotoContext();
            var lists = await dbContext.Products.ToArrayAsync();
            return new ObjectResult(lists);
        }

        public async Task<IActionResult> GetLayanans()
        {   
            var dbContext = new sirmotoContext();
            var lists = await dbContext.Products.Where(w=>w.Type == "LAYANAN").ToArrayAsync();
            return new ObjectResult(lists);
        }

        public async Task<IActionResult> GetBarangs()
        {   
            var dbContext = new sirmotoContext();
            var lists = await dbContext.Products.Where(w=>w.Type == "ITEM").ToArrayAsync();
            return new ObjectResult(lists);
        }  
    }  
}