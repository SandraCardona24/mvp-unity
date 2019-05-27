using MvpPractica.Presenters.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvpPractica.Presenters.US
{
    public class PresenterTablaUS : PresenterTabla

    {     

        public override void CargarTablaEmpleados()
        {
            using (BDEEUUEntities bd = new BDEEUUEntities())
            {
                this._view.LabelTabla = "Empleados de EEUU";
                this._view.UserGridView.DataSource = bd.Empleadoes.ToList();
                this._view.UserGridView.DataBind();
            }
        }

        public override void CargarTablaEmpresas()
        {
            using (BDEEUUEntities bd = new BDEEUUEntities())
            {
                this._view.LabelTabla = "Empresas de EEUU";
                this._view.UserGridView.DataSource = bd.Empresas.ToList();
                this._view.UserGridView.DataBind();
            }
        }
    }
}
