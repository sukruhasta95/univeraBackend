using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountDal;
        public AccountManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }
        public IResult Add(Account account)
        {
            _accountDal.Add(account);
            return new SuccessResult(Messages.AccountAdded);
        }

        public IResult WithdrawMoney(Transactions account)
        {

            var existAccount = _accountDal.GetList().Where(x => x.Id == account.Id && x.Active == true).FirstOrDefault();
            if (existAccount != null)
            {
                var totalBalance = existAccount.TotalBalance;
                var currentBalance = totalBalance - account.Quantity;
                if (account.Quantity < 0)
                {
                    return new ErrorResult(Messages.QuantityIsNotLessThenZero);
                }
                if (account.Quantity < totalBalance)
                {

                    existAccount.Id = account.Id;
                    existAccount.TotalBalance = currentBalance;

                    _accountDal.Update(existAccount);
                    return new SuccessResult(Messages.AccountUpdated);
                }
                else
                {
                    return new ErrorResult(Messages.InsufficientBalance);
                }
            }
            else
            {
                return new ErrorResult(Messages.AccountNotFound);

            }

        }

        public IDataResult<List<Account>> GetAll()
        {

            var accounts = _accountDal.GetList(x => x.Active == true && x.UserId == 1).ToList();
            return new SuccessDataResult<List<Account>>(accounts);

        }

        public Account GetById(int id)
        {
            return _accountDal.Get(x => x.Id == id && x.Active == true);
        }

        /// </summary>
        public IResult Deposit(Transactions account)
        {
            var existAccount = _accountDal.GetList().Where(x => x.Id == account.Id && x.Active == true).FirstOrDefault();
            var totalBalance = existAccount.TotalBalance;
            if (account.Quantity < 0)
                return new ErrorResult(Messages.QuantityIsNotLessThenZero);
            var currentBalance = totalBalance + account.Quantity;

            if (existAccount != null)
            {
                existAccount.Id = account.Id;
                existAccount.TotalBalance = currentBalance;

                _accountDal.Update(existAccount);
                return new SuccessResult(Messages.AccountUpdated);

            }
            else
            {
                return new ErrorResult(Messages.AccountNotFound);
            }

        }
    }
}
