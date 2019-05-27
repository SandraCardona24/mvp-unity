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
       
        public IPresenterTabla _presenterTabla { get; set; }       
       public GridView UserGridView{ get => GridView1; set => GridView1 = value; }
        public string LabelTabla { get => LabelMensaje.Text; set => LabelMensaje.Text = value; }

        protected void Page_Load(object sender, EventArgs e)
        {

            _presenterTabla.SetView(this);           
          
        }

        protected void ButtonEmpleados_Click(object sender, EventArgs e)
        {
            _presenterTabla.CargarTablaEmpleados();
        }

        protected void ButtonEmpresas_Click(object sender, EventArgs e)
        {
            _presenterTabla.CargarTablaEmpresas();
        }
    }
}