

using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.Plugins;


using Shared.ViewModels;


using System;

namespace Shared
{
    public class App : MvxApplication
    {

      
        
        public override async void Initialize()
        {

            

            



        }


        public App()
        {

            //MvvmCross.Plugins.Sqlite.PluginLoader.Instance.EnsureLoaded();
            //  Mvx.ConstructAndRegisterSingleton<ISyncService, SyncService>();
    

       


            RegisterAppStart<ViewModels.HomeViewModel>();



            //b.DBName = "PiranaDB.sql";











        }

       

   
      


        
     
    }



    






}