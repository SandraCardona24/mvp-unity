using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MvpPractica.Interfaces
{
    public interface IMainView
    {
       

        GridView UserGridView { set; get; }
        string LabelTabla { set; get; }

    }
}
