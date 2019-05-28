# Configurar MVP con Unity .NET ![badge](https://img.shields.io/badge/unity-.net-green.svg)[![HitCount](http://hits.dwyl.io/diaznicolasandres1/mvp-unity.svg)](http://hits.dwyl.io/diaznicolasandres1/mvp-unity)
### Model view presenter pattern with Unity framework (Independency Injection)

[Unity Framework](https://www.c-sharpcorner.com/UploadFile/dhananjaycoder/unity-framework/)

[Inyeccion de dependencias](https://thatcsharpguy.com/posts/la-inyeccion-de-dependencias/)

[What are MVP and MVC and what is the difference?](https://stackoverflow.com/questions/2056/what-are-mvp-and-mvc-and-what-is-the-difference)


## **Indice**

- [Estructura del proyecto](#estructura)
- [Diagramas](#diagramas)
- [Instalacion de packages](#instalar)
- [Configuraciones](#configuraciones)
- [Route Mapper y BasePage](#route)
- [Ejemplo basico](#ejemplo)



### Estructura del proyecto <a name="estructura"></a>

Crear un proyecto WebForms y agregar los folders Configuration, Presenter e Interfaces.


### Diagramas. <a name="diagramas"></a>
#### Diagrama de clases
![clases](https://github.com/diaznicolasandres1/mvp-unity/blob/master/fotos-readme/uml.png?raw=true)
#### Diagrama de secuencia
![secuencia](https://github.com/diaznicolasandres1/mvp-unity/blob/master/fotos-readme/image_thumb%5B2%5D.png?raw=true)
  

![imagen1](https://github.com/diaznicolasandres1/mvp-unity/blob/master/fotos-readme/1.png?raw=true)

### Instalar con Nugget Manager<a name="instalar"></a>

| Package       | version           
| ------------- |:-------------:|
|  Unity.Abastractions | 4.1.3.0 |
| Unity.Configuration      | 5.10.0.0      | 
| Unity.Container | 5.10.3.0      |   
| DotNetNuke.Web | 7.4.2      |


![imagen1](https://github.com/diaznicolasandres1/mvp-unity/blob/master/fotos-readme/3.png?raw=true)

![imagen1](https://github.com/diaznicolasandres1/mvp-unity/blob/master/fotos-readme/4.png?raw=true)

![imagen1](https://github.com/diaznicolasandres1/mvp-unity/blob/master/fotos-readme/5.png?raw=true)


* ### Configuration xmls <a name="configuraciones"></a>
Crear **unity.config** en folder Configuration y agregar
estructura del tipo
```c#
 <register type="UBICACION DE LA INTERFAZ, NOMBRE PROYECTO " mapTo="UBICACION CLASE CONCRETA, NOMBRE PROYECTO/>
 ```
 
```c#
<?xml version="1.0" encoding="utf-8"?>
<unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
  <container>    
    <register type="MvpPractica.Interfaces.IPresenterTabla, MvpPractica" mapTo="MvpPractica.Presenters.AR.PresenterTablaAR, MvpPractica"/>
    <!-- <register type="MvpPractica.Interfaces.IPresenterTabla, MvpPractica" mapTo="MvpPractica.Presenters.US.PresenterTablaUS, MvpPractica"/> -->
  </container>
</unity>
```

En **Web.config** agregar

```c#
  <configSections>
    	<section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Unity.Configuration" />    
  </configSections>
  <unity configSource="Configuration\unity.config" />
  ```
  
 * ### Clases RouteMapper y BasePage <a name="route"></a>
  
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
  
  ## Ejemplo básico <a name="ejemplo"></a>
  Crear dos bases de datos una para AR y otra para US con las tablas Empleado y Empresa. 
  Cargar las bases de datos con EntityFramework.
  
  - [Que es EntityFramework?](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ef/overview)   
  - [Crear o updatear  edmx  con EntityFramework datamodel](https://www.c-sharpcorner.com/article/create-and-update-an-edmx-file-using-entity-framework-data-model-in-visual-stud/)
  
  ![imagen](https://github.com/diaznicolasandres1/mvp-unity/blob/master/fotos-readme/bd.png)
  

  
  ### Interfaces.
  ```c#
public interface IMainView
{   
	string LabelTabla { set; get; }
	GridView UserGridView { set; get; }
}

```

```c#
    public interface IPresenterTabla
    {
        void SetView(IMainView view);
        void CargarTablaEmpleados();
        void CargarTablaEmpresas();    
    }
```

### Presenters.

```c#
//Clase abstracta
    public abstract class PresenterTabla : IPresenterTabla
    {
        public IMainView _view;

        public abstract void CargarTablaEmpleados();

        public abstract void CargarTablaEmpresas();      

        public void SetView(IMainView view)
        {
            this._view = view;
        }      
    }

```

```c#
   

public class PresenterTablaAR : PresenterTabla    {

	public override void CargarTablaEmpleados()
	{
	   //En PresenterTablaUS cambia por 
	   // using (BDEEUUEntities bd = new BDEEUUEntities())
	    using (BDArgentinaEntities bd = new BDArgentinaEntities())
	    {
	   	this._view.LabelTabla = "Empleados de Argentina";
		this._view.UserGridView.DataSource = bd.Empleadoes.ToList();
		this._view.UserGridView.DataBind();
	    }
	}

	public override void CargarTablaEmpresas()
	{
	    using (BDArgentinaEntities bd = new BDArgentinaEntities())
	    {
	   	this._view.LabelTabla = "Empresas de Argentina";
		this._view.UserGridView.DataSource = bd.Empresas.ToList();
		this._view.UserGridView.DataBind();
	    }
	}
} 
```

### Vista.
Agregamos un DataGridView en About.aspx

```c#
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
```




  
