﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace MvpPractica.Interfaces
{
    interface IContainerAccessor
    {

        IUnityContainer Container { get; }
    }
}
