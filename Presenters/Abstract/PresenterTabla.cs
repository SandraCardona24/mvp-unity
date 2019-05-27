using MvpPractica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvpPractica.Presenters.Abstract
{
    public abstract class PresenterTabla : IPresenterTabla
    {
        public IMainView _view;

        public abstract void CargarTablaEmpleados();


        public abstract void CargarTablaEmpresas();
      

        public void SetView(IMainView view)
        {
            this._view = view;
        }

        
       
    }
}