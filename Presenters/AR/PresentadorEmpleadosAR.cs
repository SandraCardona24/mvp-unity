using MvpPractica.Presenters.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvpPractica.Presenters.AR
{
    public class PresentadorEmpleadosAR : PresenterEmpleados
    {
        public override void CargarTabla()
        {
            using(EmpleadosAREntities1 db = new EmpleadosAREntities1())
            {

                this._view.UserGridView.DataSource = db.Empleadoes.ToList();
                this._view.UserGridView.DataBind();
            }
            
        }
    }
}