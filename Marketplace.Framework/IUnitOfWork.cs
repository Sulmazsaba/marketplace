﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Framework
{
   public interface IUnitOfWork
   {
       Task Commit();
   }
}
