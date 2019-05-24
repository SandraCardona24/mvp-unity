using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvpPractica.Interfaces
{
    public interface IPresenterEmpleados
    {
        void SetView(IMainView view);
        void CargarTabla();

    }
}