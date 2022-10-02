﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User: BaseEntity,IEntity
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int AccountId { get;  set; }
    }
}
