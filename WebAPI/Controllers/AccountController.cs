using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost ("addAccount")]
        public IActionResult Add(Account account)
        {
           var result =  _accountService.Add(account);
            return Ok(result);
        }
        [HttpPost("Deposit")]
        public IActionResult Deposit(Transactions account)
        {
            var result = _accountService.Deposit(account);
            return Ok(result);
        }

        [HttpPost("WithdrawMoney")]
        public IActionResult WithdrawMoney(Transactions account)
        {
            var result = _accountService.WithdrawMoney(account);
            return Ok(result);
        }

        [HttpGet ("GetAllAccount")]
        public IActionResult GetAll()
        {
            var result = _accountService.GetAll();
          
                return Ok(result);

        }
        [HttpGet("GetByAccountId")]
        public IActionResult GetById(int id)
        {
            var result = _accountService.GetById(id);
            return Ok(result);
        }

    }
}
