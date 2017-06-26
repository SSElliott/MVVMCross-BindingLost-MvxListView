using System;
//using Amobile.Android.Barcodesdk.Api;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;


using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;

using DrawerSample;
using Shared.ViewModels;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Core.ViewModels;

namespace Pirana.Droid.Views
{



    [Activity(ConfigurationChanges = ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize, LaunchMode = LaunchMode.SingleTop, ClearTaskOnLaunch = true)]
  
    public class HomeView : MvxFragmentActivity
   
    {
        private DrawerLayout _drawer;
        private MyActionBarDrawerToggle _drawerToggle;
        private MvxListView _drawerList;


        private string _drawerTitle;
        private string _title;


        protected override void OnStop()
        {
            base.OnStop();
        }



        //Adapter for Menu List
        public class CustomAdapter : MvxAdapter
        {
            public CustomAdapter(Context context, IMvxAndroidBindingContext bindingContext)
                : base(context, bindingContext)
            {
            }



            public void RefreshDataSource()
            {
                NotifyDataSetChanged();


            }


            public override int GetItemViewType(int position)
            {
                //  var item = GetRawItem(position);
                //  if (item is Kitten)
                return 0;
                //  return 1;
            }

            public override int ViewTypeCount
            {
                get { return 4; }
            }
            System.Collections.Generic.Dictionary<string, View> existing = new System.Collections.Generic.Dictionary<string, View>();


            private static bool loading = true;

            
            protected override View GetBindableView(View convertView, object source, ViewGroup parent, int templateId)
            {
                lock (this)
                {


                    templateId = Resource.Layout.drawerlistitem;

                    MenuViewModel item = (MenuViewModel)source;




                    if (item.IsVisible != null && !item.IsVisible())
                    {
                        templateId = Resource.Layout.drawerlistemptyitem;


                    }
                    else
                    {
                        if (item.Indentation == null || item.Indentation < 1)
                        {
                            if ((item.Backcolour) == "CurrentUser")
                            {
                                templateId = Resource.Layout.drawerlistheaderitemwithimage;
                            }
                            else
                            {
                                if (!String.IsNullOrEmpty(item.Backcolour))
                                {
                                    templateId = Resource.Layout.drawerlistheaderitem;
                                }
                                else
                                {
                                    templateId = Resource.Layout.drawerlistitem;
                                }

                            }
                        }
                        else
                        {
                            templateId = Resource.Layout.drawlistsubitem;

                        }
                    }




                    MenuViewModel vm = (MenuViewModel)source;

                    View r = base.GetBindableView(convertView, source, parent,templateId);


                    return r;
                }
            }



        }




        protected override void OnResume()
        {
            base.OnResume();

        }

      


        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                base.OnCreate(bundle);
            }
            catch (Exception ex)
            {
                var f = ex;

            }
            SetContentView(Resource.Layout.FirstView);

            _title = _drawerTitle = Title;

            _drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            _drawerList = FindViewById<MvxListView>(Resource.Id.left_drawer);


            _drawer.SetDrawerShadow(Resource.Drawable.drawer_shadow_dark, (int)GravityFlags.Start);

            _drawerList.Adapter = new CustomAdapter(this, (IMvxAndroidBindingContext)BindingContext);




    


            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);


            _drawerToggle = new MyActionBarDrawerToggle(this, _drawer,
                                                      Resource.Drawable.ic_drawer_light,
                                                      Resource.String.drawer_open,
                                                      Resource.String.drawer_close);

            //You can alternatively use _drawer.DrawerClosed here



            _drawerToggle.DrawerClosed += delegate
            {
                

                
            };

            _drawerList.SetSelector(Android.Resource.Color.Transparent);


            _drawerToggle.DrawerSlide += delegate
            {
                


            };


            _drawerToggle.DrawerOpened += delegate
            {
            };

            _drawer.SetDrawerListener(_drawerToggle);


        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            _drawerToggle.SyncState();
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            _drawerToggle.OnConfigurationChanged(newConfig);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
      
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
       
            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            if (_drawerToggle.OnOptionsItemSelected(item))
                return true;

            switch (item.ItemId)
            {
                
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

     
        public void Show(MvxViewModelRequest request)
        {



            this._drawer.CloseDrawer(this._drawerList);

        }

  
    }
}
