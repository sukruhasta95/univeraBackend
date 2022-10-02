using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
       IDataResult<List<User>>  GetAll();
        User GetById(int id);   
        IResult Add(User user);    
        void Update(User user); 
        void Delete(int id);
    }
}
