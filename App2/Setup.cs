using Android.Content;


using Shared;
using Shared.Converters;

using System.Collections.Generic;
using System.Reflection;
using V.FlyoutTest.Droid.Helpers;


using Android.Widget;
using System;



using MvvmCross.Droid.Views;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Bindings.Target.Construction;
using System.Diagnostics;
using MvvmCross.Platform.Converters;
using Android.App;

namespace Pirana.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
            //testone two
            

        }

        

        protected override IMvxApplication CreateApp()
        {
            
            var x = new Shared.App();
     
            return x;
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }





        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += currentDomain_UnhandledException;


            var customPresenter = new CustomPresenter();



            return customPresenter;
        }

        void currentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            
        }

        protected override void FillBindingNames(IMvxBindingNameRegistry registry)
        {
            

            base.FillBindingNames(registry);
                  }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            
        
            base.FillTargetFactories(registry);

        }
    }

    public class DebugTrace : IMvxTrace
    {
        public void Trace(MvxTraceLevel level, string tag, Func<string> message)
        {
            Debug.WriteLine(tag + ":" + level + ":" + message());
        }

        public void Trace(MvxTraceLevel level, string tag, string message)
        {
            Debug.WriteLine(tag + ":" + level + ":" + message);
        }

        public void Trace(MvxTraceLevel level, string tag, string message, params object[] args)
        {
            try
            {
                Debug.WriteLine(string.Format(tag + ":" + level + ":" + message, args));
            }
            catch (FormatException)
            {
                Trace(MvxTraceLevel.Error, tag, "Exception during trace of {0} {1}", level, message);
            }
        }
    }


}