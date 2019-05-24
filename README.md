# Configurar MVP con Unity .NET
Model view presenter pattern with Unity framework(Independency Injection)

[Unity Framework](https://www.c-sharpcorner.com/UploadFile/dhananjaycoder/unity-framework/)

[Inyeccion de dependencias](https://thatcsharpguy.com/posts/la-inyeccion-de-dependencias/)

[What are MVP and MVC and what is the difference?](https://stackoverflow.com/questions/2056/what-are-mvp-and-mvc-and-what-is-the-difference)

### Folders

Crear los folders Configuration, Presenter e Interfaces.

![imagen1](https://github.com/diaznicolasandres1/mvp-unity/blob/master/fotos-readme/folders.png?raw=true)

* ### Instalar con Nugget Manager

| Package       | version           
| ------------- |:-------------:|
|  Unity.Abastractions | 4.1.3.0 |
| Unity.Configuration      | 5.10.0.0      | 
| Unity.Container | 5.10.3.0      |   
| DotNetNuke.Web | 7.4.2      |

![imagen1](https://github.com/diaznicolasandres1/mvp-unity/blob/master/fotos-readme/2.png?raw=true)
![imagen1](https://github.com/diaznicolasandres1/mvp-unity/blob/master/fotos-readme/3.png?raw=true)
![imagen1](https://github.com/diaznicolasandres1/mvp-unity/blob/master/fotos-readme/4.png?raw=true)
![imagen1](https://github.com/diaznicolasandres1/mvp-unity/blob/master/fotos-readme/5.png?raw=true)

* ### Configuration xmls
Crear **unity.config** en folder Configuration y agregar

```c#
<?xml version="1.0" encoding="utf-8"?>
<unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
  <container>
    <register type="MvpPractica.Interfaces.IMainPresenter, MvpPractica" mapTo="MvpPractica.Presenters.AR.MainPresenterAR, MvpPractica"/>
       <!-- <register type="MvpPractica.Interfaces.IMainPresenter, MvpPractica" mapTo="MvpPractica.Presenters.US.MainPresenterUS, MvpPractica"/> -->
    </container>
</unit
```

En **Web.config** agregar

```c#
  <configSections>
    	<section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Unity.Configuration" />
    
  </configSections>
  <unity configSource="Configuration\unity.config" />
  ```
  
 * ### Clases RouteMapper y BasePage
  
 #### Route Mapper
  ```c#
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
  ```
  
   #### Base Page
  ```c#
  using System;  
	using System.Collections.Generic;  
	using System.Linq;  
	using System.Web;  
	using System.Web.UI;  
	using Unity;  
	  
	namespace MvpPractica	{  
	    public class BasePage<T> : Page where T : class  
	    {  
	        public BasePage()
        {  
	            InjectDependencies();  
	        }  
	  
	        protected virtual void InjectDependencies()
	        {  
	            try  
	            {  
	                if (RouteMapper.Container == null)  
	                {  
	                    RouteMapper.CreateContainer();  
	                }  
	  
	                IUnityContainer container = RouteMapper.Container;  
	  
	                container.BuildUp(this as T);  
	            }  
	            catch (Exception ex)  
	            {  
	                throw ex;  
	            }  
	        }  
	  
	    }  
	}  
  ```
