using MvpPractica.Presenters.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvpPractica.Presenters.AR
{
    public class PresenterTablaAR : PresenterTabla
    {
      

        public override void CargarTablaEmpleados()
        {
            using (BDArgentinaEntities bd = new BDArgentinaEntities())
            {
                this._view.UserGridView.DataSource = bd.Empleadoes.ToList();
                this._view.UserGridView.DataBind();
            }
        }

        public override void CargarTablaEmpresas()
        {
            using (BDArgentinaEntities bd = new BDArgentinaEntities())
            {
                this._view.UserGridView.DataSource = bd.Empresas.ToList();
                this._view.UserGridView.DataBind();
            }
        }
    }
}