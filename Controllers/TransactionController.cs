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
    
    
    public class TransactionController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public TransactionController(UserManager<ApplicationUser> userManager)
        {
           _userManager = userManager;
        }
        [Authorize]    
        public async Task<IActionResult> Index(string transId)
        {
            return View();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DetailDevice()
        {
            return View();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {   
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var usrId = usr.Id;
            var company = await dbContext.Transactions.Where(z => z.UserId == usrId ).ToListAsync();
            company.FirstOrDefault().PickedUpEmployees.ToList();
            company.FirstOrDefault().PickedUpProducts.ToList();

            if  (company.Count == 0) 
            {
                return NotFound("[WARN] User has no Transaction");
            } 
            else 
                return new ObjectResult(JsonConvert.SerializeObject(company[0]));
            
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> GetTransactionNo(string id)
        {   
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var usrId = usr.Id;
            var device = await dbContext.Transactions.Where(z => z.UserId == usrId ).ToListAsync();
                        device.FirstOrDefault().PickedUpEmployees.ToList();
            device.FirstOrDefault().PickedUpProducts.ToList();
            if  (device[Int32.Parse(id)] == null) 
            {
                return NotFound("[WARN] Device not found");
            } 
            else 
                return new ObjectResult(JsonConvert.SerializeObject(device[Int32.Parse(id)]));
            
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> GetTransactionById(string id)
        {   
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var usrId = usr.Id;
            var transactions = await dbContext.Transactions.Where(z => z.Id == Int32.Parse(id) ).ToListAsync();
            
            if  (transactions.Count == 0) 
            {
                return NotFound("[WARN] Transaction not found");
            } 
            else 
                return new ObjectResult(JsonConvert.SerializeObject(transactions[0]));
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> BeginTransaction([FromBody]Transactions input)
        {
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var user = await dbContext.AspNetUsers.Where(z=>z.Id == usr.Id).ToListAsync();
            if(user[0]==null)
            {
                return NotFound("User not found");
            }
            var transaction = new Transactions(){Id = GenerateRandomInt(),State = "BEGIN", UserId=user[0].Id};
            
            transaction.Location = input.Location;
            transaction.TimeStamp = DateTime.Now;
            transaction.Discount = 0;
            transaction.CompanyId = 0;
            transaction.PaymentMethod = "Nothing";
            dbContext.Transactions.Add(transaction);
            await dbContext.SaveChangesAsync();
            dynamic result = new ExpandoObject();

            result.Transaction = transaction;
            result.Resource = "Transaction/GetTransactionById/" + transaction.Id; 
            return new ObjectResult(JsonConvert.SerializeObject(result));
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch]
        public async Task<IActionResult> AddProduct(string id, [FromBody]PickedUpProducts[] products)
        {
            var randomnum = new Random().Next();
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var user = await dbContext.AspNetUsers.Where(z=>z.Id == usr.Id).ToListAsync();
            var transaction = await dbContext.Transactions.Where(z=> z.Id == Int32.Parse(id)).ToListAsync();
            
            if(transaction.Count == 0)
            {
                return NotFound("Transaction not found");
            }
            else if (transaction[0].UserId != user[0].Id)
            {
                return Forbid();
            }
            else if(transaction[0].State!="BEGIN")
            {
                return Forbid();
            }
            else
            {
                foreach (var item in products)
                {
                    item.Id = GenerateRandomInt();
                    item.TransactionId = Int32.Parse(id);
                    var product = await dbContext.Products.Where(z=>z.Id == item.ProductId).ToListAsync();
                    if(product[0] == null)
                        return BadRequest("Product item not found: "+ item.ProductId);
                    var getproductType = await dbContext.Products.Where(z=> z.Id == item.ProductId).ToListAsync();
                    var productType = getproductType[0].Type;
                    if(productType == "LAYANAN")
                    {
                        item.Quantity = 1;
                        //item.HitCount++;
                        //dbContext.Update(layanan[0]);
                    }    
                    transaction[0].PickedUpProducts.Add(item);
                }
                transaction[0].State = "PRODUCT_ADDED";
                dbContext.Update(transaction[0]);
                await dbContext.SaveChangesAsync();
                dynamic result = new ExpandoObject();

                result.Transaction = transaction;
                result.Resource = "Transaction/GetTransactionById/" + transaction[0].Id; 
                return new ObjectResult(JsonConvert.SerializeObject(result));
            }
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch]
        public async Task<IActionResult> FindCompanyForTransaction(string id)
        {   
            var random = new Random();
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var user = await dbContext.AspNetUsers.Where(z => z.Id == usr.Id ).ToListAsync();
            if(user[0]==null)
            {
                return NotFound("User not found");
            }
            var transaction = await dbContext.Transactions.Where(z=> z.Id == Int32.Parse(id)).ToListAsync();
            if(transaction[0].State=="PRODUCT_ADDED")
            {        
                transaction[0].State = "FIND_COMPANY";
                transaction[0].TimeStamp = DateTime.Now;
                //transaction[0].Company = FindCompany();
                dbContext.Transactions.Update(transaction[0]);
                await dbContext.SaveChangesAsync();
                dynamic result = new ExpandoObject();

                result.Transaction = transaction[0];
                result.Resource = "Transaction/GetTransactionById/" + transaction[0].Id; 
                return new ObjectResult(JsonConvert.SerializeObject(result));
            }
            return Forbid();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> CompanyCheckForTransactionRequest()
        {
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var user = await dbContext.AspNetUsers.Where(z => z.Id == usr.Id ).ToListAsync();
            var company = await dbContext.Companies.Where(z=>z.UserId == user[0].Id).ToListAsync();
            if(company.Count == 0)
            {
                return NotFound("User is a not company");
            }
            var transaction = await dbContext.Transactions.Where(z=> z.State == "COMPANY_ADDED" && z.CompanyId == user[0].Companies.Id).ToListAsync();
            return new ObjectResult(transaction);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch]
        public async Task<IActionResult> GetCompanyForTransaction(string id)
        {   
            var random = new Random();
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var user = await dbContext.AspNetUsers.Where(z => z.Id == usr.Id ).ToListAsync();
            if(user[0]==null)
            {
                return NotFound("User not found");
            }
            var transaction = await dbContext.Transactions.Where(z=> z.Id == Int32.Parse(id)).ToListAsync();
            var transactionToProcess = transaction[0];
            if(transaction[0].State=="FIND_COMPANY")
            {
                var company = await FindCompany(transaction[0]);
                if(company == null)
                {
                    return BadRequest("No company is available");
                }
                transaction[0].State = "COMPANY_ADDED";
                transaction[0].TimeStamp = DateTime.Now;
                transaction[0].CompanyId = company.Id;
                dbContext.Transactions.Update(transaction[0]);
                await dbContext.SaveChangesAsync();
                dynamic result = new ExpandoObject();

                result.Transaction = transaction[0];
                result.Resource = "Transaction/GetTransactionById/" + transaction[0].Id; 
                return new ObjectResult(JsonConvert.SerializeObject(result));
            }
            return NotFound("Not assigned to a company yet");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch]
        public async Task<IActionResult> CompanyAcceptForTransaction(string id)
        {   
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var user = await dbContext.AspNetUsers.Where(z => z.Id == usr.Id ).ToListAsync();
            var company = await dbContext.Companies.Where(z=>z.UserId == user[0].Id).ToListAsync();
            if(company.Count == 0)
            {
                return NotFound("User is a not company");
            }
            var transaction = await dbContext.Transactions.Where(z=> z.Id == Int32.Parse(id)).ToListAsync();
            if(transaction[0].State=="COMPANY_ADDED")
            {
                transaction[0].TimeStamp = DateTime.Now;
                if(company[0].Employees.Count == 0)
                {
                    return BadRequest();    
                }
                transaction[0].State = "FINAL" ;
                //var company1 = dbContext.Companies.Where(z => z.UserId == user[0].Id ).ToArray();
                var employess = await AssembleEmployees(transaction[0],company[0]);
                foreach (var item in employess)
                {
                    transaction[0].PickedUpEmployees.Add(new PickedUpEmployees{ 
                        Id = GenerateRandomInt(),
                        EmployeeId = item.Id,
                        TransactionId = transaction[0].Id});
                }
                //transaction[0].PickedUpEmployees = ;
                dbContext.Transactions.Update(transaction[0]);
                await dbContext.SaveChangesAsync();
                dynamic result = new ExpandoObject();

                result.Transaction = transaction[0];
                result.Resource = "Transaction/GetTransactionById/" + transaction[0].Id; 
                return new ObjectResult(JsonConvert.SerializeObject(result));
            }
            return NotFound("Not assigned to a company yet");
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch]
        public async Task<IActionResult> CompanyRejectForTransaction(string id)
        {   
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var user = await dbContext.AspNetUsers.Where(z => z.Id == usr.Id ).ToListAsync();
            if(user[0].Companies==null)
            {
                return NotFound("User is a not company");
            }
            var transaction = await dbContext.Transactions.Where(z=> z.Id == Int32.Parse(id)).ToListAsync();
            if(transaction[0].State=="FIND_COMPANY")
            {
                transaction[0].TimeStamp = DateTime.Now;
                transaction[0].State = "FIND_COMPANY" ;
                transaction[0].Company = await FindCompany(transaction[0], user[0].Companies);
                dbContext.Transactions.Update(transaction[0]);
                await dbContext.SaveChangesAsync();
                dynamic result = new ExpandoObject();

                result.Transaction = transaction[0];
                result.Resource = "Transaction/GetTransactionById/" + transaction[0].Id; 
                return new ObjectResult(JsonConvert.SerializeObject(result));
            }
            return NotFound("Not yet added a product");
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> CompanyCheckForTransaction()
        {   
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var company = await dbContext.Companies.Where(z => z.UserId == usr.Id).ToListAsync();
            if(company.Count==0)
            {
                return NotFound("User is a not company");
            }
            var transaction = await dbContext.Transactions.
                    Where(z=> z.CompanyId == company[0].Id &&
                              z.State == "FIND_COMPANY"  ).ToListAsync();
            if(transaction.Count == 0)
            {
                return NotFound("No transaction is available yet");
            }
            return new ObjectResult(transaction[0]);
        }
        
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch]
        public async Task<IActionResult> TransactionFinalise(string id, [FromBody]Transactions transactionUpdate)
        {   
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var user = await dbContext.AspNetUsers.Where(z => z.Id == usr.Id ).ToListAsync();
            var transaction = await dbContext.Transactions.Where(z=> z.Id == Int32.Parse(id)).ToListAsync();
            
            if(transaction[0] == null)
            {
                return NotFound("Transaction is not found");
            }
            if(transaction[0].UserId != user[0].Id)
            {
                return Forbid("Access Denied");
            }
            if(transaction[0].State == "FINAL")
            {
                transaction[0].State = "DONE";
                transaction[0].PaymentMethod =  transactionUpdate.PaymentMethod;
                transaction[0].TimeStamp = DateTime.Now;
                dbContext.Update(transaction[0]);
                await dbContext.SaveChangesAsync();
                ResetEmployees(transaction[0]);
                return new ObjectResult(transaction[0]);
            }
            return NotFound("Transaction is not ready");
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete]
        public async Task<IActionResult> DeleteTrans(string id)
        {   
            var dbContext = new sirmotoContext();
            var usr = await GetCurrentUserAsync();
            var usrId = usr.Id;
            var transactions = await dbContext.Transactions.Where(z => z.Id == Int32.Parse(id) ).ToListAsync();
            
            if  (transactions[0] == null) 
            {
                return NotFound("Transaction not found");
            } 
            else if(transactions[0].State != "DONE" || transactions[0].State != "FINAL")
            {
                dbContext.Remove(transactions[0]);
                await dbContext.SaveChangesAsync();
                return new ObjectResult("Cancelled transaction id " + id);
            }
            else
            {
                return Forbid("Transaction cannot be cancelled, id " + id);
            }   
        }

        
        private async Task<Companies> FindCompany(Transactions transactionsToProcess)
        {
            var dbContext = new sirmotoContext();
            var companies = await dbContext.Companies.ToArrayAsync();
            Companies selectedCompanyWithLowestAndNearestLocation =null;
            float distance = (float) Double.MaxValue;
            int smallestTotalTransaction = Int32.MaxValue;
            foreach (var company in companies)
            {
                var totalTransactionOfThisCompanyToday = company.Transactions.Count(z=>isThisStillInToday(z.TimeStamp) 
                                                                        && z.State == "FIND_COMPANY");

                
            /*  transaction.Location
                {
                    x: Number,
                    y: Number,
                }
                company.Address
                {
                    x: Number,
                    y: Number,
                    Address: string 
                }
                employee.Address
                {
                    x: Number,
                    y: Number,
                    Address: string                     
                }
                
                */
                if(company.Id == 0) continue;
                var transactionLocationCoordinate = JsonConvert.DeserializeObject<Location>(transactionsToProcess.Location);
                var companyLocationCoordinate = JsonConvert.DeserializeObject<Location>(company.Address);
                if(distance > Distance(companyLocationCoordinate.x, companyLocationCoordinate.y , transactionLocationCoordinate.x, transactionLocationCoordinate.y) &&
                    smallestTotalTransaction > totalTransactionOfThisCompanyToday)
                {
                    selectedCompanyWithLowestAndNearestLocation = company;
                    distance =  Distance(companyLocationCoordinate.x, companyLocationCoordinate.y , transactionLocationCoordinate.x, transactionLocationCoordinate.y);
                    smallestTotalTransaction = totalTransactionOfThisCompanyToday;
                }
            }
            return selectedCompanyWithLowestAndNearestLocation;
        }

        private async Task<Companies> FindCompany(Transactions transactionsToProcess, Companies companyReject)
        {
            var dbContext = new sirmotoContext();
            var companies = await dbContext.Companies.ToArrayAsync();
            companies.FirstOrDefault().Employees.ToList();
            companies.FirstOrDefault().Transactions.ToList();
            Companies selectedCompanyWithLowestAndNearestLocation =null;
            float distance = (float) Double.MaxValue;
            int smallestTotalTransaction = Int32.MaxValue;
            foreach (var company in companies)
            {
                if(company == companyReject)
                    continue;
                if(company.Employees.Count == 0)
                    continue;
                var totalTransactionOfThisCompanyToday = company.Transactions.Count(z=>isThisStillInToday(z.TimeStamp) 
                                                                        && z.State == "FIND_COMPANY");
                dynamic transactionLocationCoordinate = JsonConvert.DeserializeObject(transactionsToProcess.Location);
                dynamic companyLocationCoordinate = JsonConvert.DeserializeObject(company.Address);
                if(distance > Distance(companyLocationCoordinate.x, companyLocationCoordinate.y , transactionLocationCoordinate.x, transactionLocationCoordinate.y) &&
                    smallestTotalTransaction > totalTransactionOfThisCompanyToday)
                {
                    selectedCompanyWithLowestAndNearestLocation = company;
                    distance =  Distance(companyLocationCoordinate.x, companyLocationCoordinate.y , transactionLocationCoordinate.x, transactionLocationCoordinate.y);
                    smallestTotalTransaction = totalTransactionOfThisCompanyToday;
                }
            }
            return selectedCompanyWithLowestAndNearestLocation;
        }

        private async Task<Employees[]> AssembleEmployees(Transactions transaction, Companies company)
        {
            var dbContext = new sirmotoContext();
            var transactions = dbContext.Transactions
                                        .Include(t => t.PickedUpProducts);
            var count = 1;
            var previousItemQuery = await dbContext.PickedUpProducts.Where(w=>w.TransactionId == transaction.Id).ToListAsync();
            var previousItem = previousItemQuery[0];
            foreach (var item in previousItemQuery)
            {
                var product = dbContext.Products.Where(z=> z.Id == item.ProductId).ToArray()[0];
                if(product.RequiredWorker == 1 && transaction.PickedUpProducts.Count < 4)
                    continue;
                else if(product.RequiredWorker < 3 && transaction.PickedUpProducts.Count <4)
                    count += 1;
                else if(product.RequiredWorker < 5 && transaction.PickedUpProducts.Count <5)
                    count += 2;
                previousItem = item;
            }
            var employess = dbContext.Employees.Where(z=>z.State=="IDLE" && z.CompanyId == company.Id);
            var employeeslist = await employess.ToArrayAsync();
            count = (employess.Count()<count) ? employess.Count() : count;
            for (int i = 0; i < count ; i++)
            {
                employeeslist[i].State = "WORKING";
                dbContext.Update(employeeslist[i]);
            }
            
            await dbContext.SaveChangesAsync();
            return employess.Take(count).ToArray();
        }
        
        private async void ResetEmployees(Transactions transactions)
        {
            var dbContext = new sirmotoContext();
            var list = await dbContext.Employees.Where(w=> w.CompanyId == transactions.CompanyId).ToListAsync();
            foreach (var item in list)
            {
                item.State = "IDLE";
                dbContext.Update(item);
            }
            await dbContext.SaveChangesAsync();
        }

        private int GenerateRandomInt() => new Random().Next();
        private bool isThisStillInToday (DateTime time) => (time.Date == DateTime.Now.Date);
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.FindByEmailAsync(User.Identity.Name);
        private float Distance(double p1, double p2, double q1, double q2) => MathF.Sqrt( (float) (Math.Pow((q1 - p1),2) + Math.Pow((q2 - p2),2)));
    }
}