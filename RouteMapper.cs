
using DotNetNuke.Web.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using MvpPractica.Interfaces;
using Microsoft.Practices.Unity.Configuration;

namespace MvpPractica
{
  
    
        public class RouteMapper : IServiceRouteMapper, IContainerAccessor
        {
            public static IUnityContainer Container { get; private set; }

            IUnityContainer IContainerAccessor.Container
            {
                get
                {
                    return Container;
                }
            }

            public void RegisterRoutes(IMapRoute mapRouteManager)
            {
                //seteo ioC
                CreateContainer();

                //mapRouteManager.MapHttpRoute("Dnn.Solicitudes", "default", "{controller}/{action}", new[] { "DirecTV.SDSNET.Dnn.Solicitudes" });
            }

            public static void CreateContainer()
            {
                IUnityContainer container = new UnityContainer();

                container.LoadConfiguration();

                Container = container;
            }
        }
    }






