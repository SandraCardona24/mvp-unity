
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvpPractica.Interfaces
{
    public interface IMainPresenter
    {

        void Saludar();
        void SetView(IMainView view);
    }
}