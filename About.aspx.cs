using MvpPractica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;

namespace MvpPractica
{
    public partial class About : BasePage<About>, IMainView
    {
        [Dependency]
       
        public IPresenterEmpleados _presenterEmpleados { get; set; }       
       public GridView UserGridView{ get => GridView1; set => GridView1 = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            _presenterEmpleados.SetView(this);            
            _presenterEmpleados.CargarTabla();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            _presenterEmpleados.ToggleTabla();
        }
    }
}