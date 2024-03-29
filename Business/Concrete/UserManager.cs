using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);

        }

        public void Delete(int id)
        {

            var existUser = _userDal.GetList(x => x.Id == id).FirstOrDefault();

            existUser.Id = id;
            existUser.Active = false;
            existUser.Name = "sukruhasta";

            _userDal.Update(existUser);
        }

        public IDataResult<List<User>> GetAll()
        {
            var userList = _userDal.GetList(x => x.Active == true).ToList();

            return new SuccessDataResult<List<User>>(userList);
        }

        public User GetById(int id)
        {
            return _userDal.Get(x => x.Id == id && x.Active == true);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
