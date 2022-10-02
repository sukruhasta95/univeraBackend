using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAccountService
    {
        IDataResult<List<Account>> GetAll();
        Account GetById(int id);
        IResult Add(Account account);
        IResult Deposit(Transactions account);   
        IResult WithdrawMoney(Transactions account);
    }
}
