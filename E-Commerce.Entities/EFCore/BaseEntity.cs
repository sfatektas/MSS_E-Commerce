﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.EFCore
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }
    }
}
