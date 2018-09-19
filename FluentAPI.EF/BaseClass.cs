﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.EF
{
    public abstract class BaseClass
    {
        private int? id;

        public int? Id
        {
            get
            {
                return id;
            }
            set
            {                
                id = value;
            }
        }        
    }
}
