using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvpPractica.Interfaces
{
    public interface IPresenterTabla
    {
        void SetView(IMainView view);
        void CargarTablaEmpleados();
        void CargarTablaEmpresas();
        

    }
}