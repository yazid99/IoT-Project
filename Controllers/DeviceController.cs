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
using System.Dynamic;

namespace sirmoto.Controllers
{
    public class DeviceController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public DeviceController(UserManager<ApplicationUser> userManager)
        {
           _userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        
        public async Task<IActionResult> TestInternet()
        {
            return new ObjectResult("ok");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> GetDevices()
        {   
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var usrId = usr.Id;
            var devices = await dbContext.SirmotoDevices.Where(z => z.UserId == usrId ).ToListAsync();
            foreach (var item in devices)
            {
                var a =item.SirmotoDeviceSchedule;
            }
            if  (devices.Count == 0) 
            {
                return new ObjectResult(JsonConvert.SerializeObject(devices));
            } 
            else 
                return new ObjectResult(JsonConvert.SerializeObject(devices));
            
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> GetDeviceNo(string id)
        {   
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var usrId = usr.Id;
            var device = await dbContext.SirmotoDevices.Where(z => z.UserId == usrId ).ToListAsync();
            
            if  (device[Int32.Parse(id)] == null) 
            {
                return NotFound("[WARN] Device not found");
            } 
            else 
                return new ObjectResult(JsonConvert.SerializeObject(device[Int32.Parse(id)]));
            
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> SendSiramCommand(string id)
        {
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var usrId = usr.Id;
            var device = await dbContext.SirmotoDevices.Where(z => z.Id == Int32.Parse(id) ).ToListAsync();
            
            if  (device[0] == null) 
            {
                return NotFound("[WARN] Device not found");
            } 
            else 
            {
                device[0].DeviceInfo = "STATE_WATERING_ONDEMAND";
                dbContext.Update(device[0]);
                await dbContext.SaveChangesAsync();
            }
            return new ObjectResult("done");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> SendUpdateCommand(string id)
        {
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var usrId = usr.Id;
            var device = await dbContext.SirmotoDevices.Where(z => z.Id == Int32.Parse(id)).ToListAsync();

            if (device[0] == null)
            {
                return NotFound("[WARN] Device not found");
            }
            else
            {
                device[0].DeviceInfo = "STATE_UPDATE_FIRMWARE";
                dbContext.Update(device[0]);
                await dbContext.SaveChangesAsync();
            }
            return new ObjectResult("done");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> SendRebootCommand(string id)
        {
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var usrId = usr.Id;
            var device = await dbContext.SirmotoDevices.Where(z => z.Id == Int32.Parse(id) ).ToListAsync();
            
            if  (device[0] == null) 
            {
                return NotFound("[WARN] Device not found");
            } 
            else 
            {
                device[0].DeviceInfo = "STATE_REBOOT_NOW";
                dbContext.Update(device[0]);
                await dbContext.SaveChangesAsync();
            }
            return new ObjectResult("done");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> SendDefaultCommand(string id)
        {
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var usrId = usr.Id;
            var device = await dbContext.SirmotoDevices.Where(z => z.Id == Int32.Parse(id) ).ToListAsync();
            
            if  (device[0] == null) 
            {
                return NotFound("[WARN] Device not found");
            } 
            else 
            {
                device[0].DeviceInfo = "READY";
                device[0].LastUpdated = DateTime.UtcNow;
                dbContext.Update(device[0]);
                await dbContext.SaveChangesAsync();
            }
            return new ObjectResult("done");
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> GetDeviceById(string id)
        {   
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var usrId = usr.Id;
            var device = await dbContext.SirmotoDevices.Where(z => z.Id == Int32.Parse(id) ).ToListAsync();
            if  (device == null) 
            {
                System.Diagnostics.Debug.WriteLine("LOLL" + id);
                return NotFound("[WARN] Device not found");
            } 
            else 
            {
                device[0].LastUpdated = DateTime.UtcNow;
                dbContext.Update(device[0]);
                dbContext.SaveChanges();
                return new ObjectResult(JsonConvert.SerializeObject(device[0]));
            }
                
            
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> GetDetailedScheduleById(string id)
        {
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var usrId = usr.Id;
            var device = await dbContext.SirmotoDeviceSchedule.Where(z => z.Id == Int32.Parse(id) ).ToListAsync();
            if  (device == null) 
            {
                System.Diagnostics.Debug.WriteLine("LOLL" + id);
                return NotFound("[WARN] Device not found");
            } 
            else 
                return new ObjectResult(JsonConvert.SerializeObject(device[0]));

        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> RegisterDevice([FromBody] SirmotoDevices data)
        {   
            var random = new Random();
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var user = await dbContext.AspNetUsers.Where(z => z.Email == usr.Email ).ToListAsync();
            data.Description = "None";
            data.Id = random.Next();
            data.UserId = usr.Id;
            data.DeviceInfo = "READY";
            data.LastUpdated = DateTime.Now;
            dbContext.SirmotoDevices.Add(data);
            await dbContext.SaveChangesAsync();
            dynamic result = new ExpandoObject();

            result.Sirmoto = data;
            result.Resource = "Device/GetDeviceById/" + data.Id; 
            return new ObjectResult(JsonConvert.SerializeObject(result));
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]        
        [HttpPost]
        public async Task<IActionResult> AddNewSchedule(string id,string data)
        {
            var dbContext = new sirmotoContext();
            SirmotoDeviceSchedule schedule;
            try{
                schedule = JsonConvert.DeserializeObject<SirmotoDeviceSchedule>(data);
            }
            catch(Exception e)
            {
                return BadRequest("Bad json data: "+data);
            }
            if(dbContext.SirmotoDevices.Where(z=> z.Id == Int32.Parse(id)).Count()==0)
                return NotFound("Device not found");
            schedule.Id = GenerateRandomInt();
            schedule.DeviceId = Int32.Parse(id);
            dbContext.SirmotoDeviceSchedule.Add(schedule);
            await dbContext.SaveChangesAsync();
            dynamic result = new ExpandoObject();
            result.Schedule = schedule;
            result.Location = "Device/GetScheduleById/" + id;
            return new ObjectResult(result);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> GetSchedulesByIdSimple(string id)
        {
            var dbContext = new sirmotoContext();
            var schedule = await dbContext.SirmotoDeviceSchedule.Where(z=> z.DeviceId == Int32.Parse(id)).ToListAsync();
            var results = new List<int>();
            if(schedule.Count==0)
                return NotFound("Device not found");
            else 
            {
                foreach (var s in schedule)
                {   
                    results.Add(s.Id);
                }
                
            }
            return new ObjectResult(JsonConvert.SerializeObject(results));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> GetScheduleDetailsById(string id)
        {
            var dbContext = new sirmotoContext();
            var schedule = await dbContext.SirmotoDeviceSchedule.Where(z=> z.Id == Int32.Parse(id)).ToListAsync();
            if(schedule.Count==0)
                return NotFound("Device not found");

            return new ObjectResult(JsonConvert.SerializeObject(schedule[0]));
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete]
        public async Task<IActionResult> RemoveSchedule(string id)
        {
            var dbContext = new sirmotoContext();
            var schedule = await dbContext.SirmotoDeviceSchedule.Where(z=> z.Id == Int32.Parse(id)).ToListAsync();
            if(schedule.Count==0)
                return NotFound("Device not found");
            else 
            {
                dbContext.SirmotoDeviceSchedule.Remove(schedule[0]);
                await dbContext.SaveChangesAsync();
            }
            return new ObjectResult("[INFO] Unregistered schedule no "+id);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch]
        public async Task<IActionResult> UpdateDeviceStatus(string id,[FromBody] SirmotoDevices sirmoto)
        {   
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var usrId = usr.Id;
            var device = await dbContext.SirmotoDevices.Where(z => z.Id == Int32.Parse(id) ).ToListAsync();
            if(device[0].UserId!=usr.Id)
            {
                return Forbid("[ERRO] Access denied");
            }
            device[0].Description = (String.IsNullOrEmpty(sirmoto.Description)) ? device[0].Description : sirmoto.Description;
            device[0].DeviceInfo = (String.IsNullOrEmpty(sirmoto.DeviceName)) ? device[0].DeviceInfo : sirmoto.DeviceName;
            device[0].DeviceName = (String.IsNullOrEmpty(sirmoto.DeviceName)) ? device[0].DeviceName : sirmoto.DeviceName;
            device[0].DeviceState = (String.IsNullOrEmpty(sirmoto.DeviceState)) ? device[0].DeviceState : sirmoto.DeviceState;            
            if  (device[0] == null) 
            {
                return NotFound("[WARN] Device not found");
            } 
            else 
                dbContext.Update(sirmoto);
            return new ObjectResult(JsonConvert.SerializeObject(device[0]));
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete]
        public async Task<IActionResult> Unregister(string id)
        {   
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var usrId = usr.Id;
            var device = await dbContext.SirmotoDevices.Where(z => z.Id == Int32.Parse(id) ).ToListAsync();
            
            if  (device.Count == 0) 
            {
                return NotFound("[WARN] Device not found");
            } 
            else if(device[0].UserId!=usr.Id)
            {
                return Forbid("[ERRO] Access denied");
            }
            else
            {
                dbContext.Remove(device[0]);
                await dbContext.SaveChangesAsync();
            }
            return new ObjectResult("[INFO] Unregistered devie no "+id);
            
        }

        private int GenerateRandomInt() => new Random().Next();
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.FindByEmailAsync(User.Identity.Name);
    }
}