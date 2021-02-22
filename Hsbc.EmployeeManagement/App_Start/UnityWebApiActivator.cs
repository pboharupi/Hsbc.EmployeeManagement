using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity.AspNet.WebApi;
[assembly:WebActivatorEx.PostApplicationStartMethod(typeof(Hsbc.EmployeeManagement.UnityWebApiActivator),nameof(Hsbc.EmployeeManagement.UnityWebApiActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Hsbc.EmployeeManagement.UnityWebApiActivator), nameof(Hsbc.EmployeeManagement.UnityWebApiActivator.Stutdown))]
namespace Hsbc.EmployeeManagement
{
    public static class UnityWebApiActivator
    {
        public static void Start()
        {
            var resolver = new UnityDependencyResolver(UnityConfig.Container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
        public static void Stutdown()
        {
            UnityConfig.Container.Dispose();
        }
    }
}