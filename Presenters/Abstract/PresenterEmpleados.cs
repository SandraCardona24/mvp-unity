using MvpPractica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvpPractica.Presenters.Abstract
{
    public abstract class PresenterEmpleados : IPresenterEmpleados
    {
        public IMainView _view;

        public abstract void CargarTabla();
        

        public void SetView(IMainView view)
        {
            this._view = view;
        }
    }
}