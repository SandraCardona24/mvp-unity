
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
