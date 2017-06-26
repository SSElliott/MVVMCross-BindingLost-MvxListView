using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using MvvmCross.Core.ViewModels;
using Shared.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace V.FlyoutTest.Droid.Helpers
{
    public interface IFragmentHost
    {
        System.Threading.Tasks.Task<bool> Show(MvxViewModelRequest request);


      


         
    }

    public interface ICustomPresenter
    {
        void Register(Type viewModelType, IFragmentHost host);

        Type CurrentViewModel { get; set; }

    }

    public class CustomPresenter
        : MvxAndroidViewPresenter
        , ICustomPresenter
    {
        private Dictionary<Type, IFragmentHost> _dictionary = new Dictionary<Type, IFragmentHost>();


        public Type CurrentViewModel { get; set; }

        

        public override void Close(IMvxViewModel viewModel)
        {
            base.Close(viewModel);

            //also close the other one
            


        }

        

        public override async void Show(MvxViewModelRequest request)
        {

            Fragment existing = null;

            this.CurrentViewModel = request.ViewModelType;

            if (request.PresentationValues != null)
            {
                if (request.PresentationValues.ContainsKey("NavigationMode") && request.PresentationValues["NavigationMode"] == "BackOrInPlace")
                {
                    var hasFragmentTypeInStack =
                        Enumerable.Range(0, this.Activity.FragmentManager.BackStackEntryCount - 1)
                                  .Reverse()
                                  .Any(index => this.Activity.FragmentManager.GetBackStackEntryAt(index).Name == request.ViewModelType.Name);

                    if (hasFragmentTypeInStack)
                    {
                        while (this.Activity.GetType() != request.ViewModelType)
                            this.Activity.FragmentManager.PopBackStackImmediate();

                        return;
                    }

            

                    this.Activity.FragmentManager.PopBackStackImmediate();
                    return;
                }
            }

            try
            {
                var ex = Activity.FragmentManager.GetBackStackEntryAt(Activity.FragmentManager.BackStackEntryCount - 1); ;
                var ex2 = Activity.FragmentManager.FindFragmentById(ex.Id);
                if (ex2 != null) ex2.Dispose();
            }catch { }


            IFragmentHost host;
            if (this._dictionary.TryGetValue(request.ViewModelType, out host))
            {
                if (await host.Show(request))
                {
                    return;

                }
            }

            base.Show(request);
            
        }

        public void Register(Type viewModelType, IFragmentHost host)
        {
            this._dictionary[viewModelType] = host;
        }
    }


 

}