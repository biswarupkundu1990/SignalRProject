using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SignalRProject.Components
{
    public static class XMLWatchComponents
    {
        private static FileSystemWatcher fWatcher;
        private static string xmlFilePath = HttpContext.Current.Server.MapPath("~/Random.xml");

        public static void init()
        {
            Initialize();            
        }

        private static void Initialize()
        {
            fWatcher = new FileSystemWatcher();
            fWatcher.Path = Path.GetDirectoryName(xmlFilePath);
            fWatcher.Filter = Path.GetFileName(xmlFilePath);
            fWatcher.Changed += watcher_Changed;
            
            fWatcher.EnableRaisingEvents = true;
            fWatcher.Error += OnError;
        }        

        private static void OnError(object sender, ErrorEventArgs e)
        {
            fWatcher.Dispose();
            Initialize();
        }


        private static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                fWatcher.EnableRaisingEvents = false;
                
                //Pass new points to client
                var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                context.Clients.All.Logoutall();
            }
            finally
            {
                fWatcher.EnableRaisingEvents = true;
            }
        }

    }
}