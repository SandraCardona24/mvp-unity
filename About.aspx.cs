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
        public IMainPresenter _presenter { get; set; }
        public string LabelSaludo { get => LabelMensaje.Text; set => LabelMensaje.Text = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.SetView(this);
            _presenter.Saludar();

        }
    }
}