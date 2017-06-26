

using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;

namespace Shared.ViewModels
{

    public class Settings
    {  
        public Guid? License1 { get; set; }
        public Guid? License2 { get; set; }
        public Guid? License3 { get; set; }
      
    }

    public class MenuViewModel : BaseViewModel
    {
        private HomeViewModel.Section section;
        public HomeViewModel.Section Section
        {
            get { return this.section; }
            set
            {
                this.section = value;
                this.Id = (int)this.section; this.RaisePropertyChanged(() => this.Section);
            }
        }

        public int Indentation { get; set; }

        public Type ViewModelType;


        public string Forecolour { get; set; }
        public string Backcolour { get; set; }


        public Func<bool> IsVisible { get;
            set; }

    }
    
    
    public class HomeViewModel 
		: MvxViewModel
    {


        private List<MenuViewModel> menuItems;
        public List<MenuViewModel> MenuItems
        {
            get { return this.menuItems; }
            set { this.menuItems = value; this.RaisePropertyChanged(() => this.MenuItems); }
        }


        public enum Section
        {
            Unknown,
            Menu_Item1,
            
        }

     

 
        public void Init(bool noCheck = false, string licenses = null)
        {
  
    

            

        }

      
        public HomeViewModel()
        {

            Settings _settings = new ViewModels.Settings()
            {
                License2 = Guid.NewGuid(),
                License3 = Guid.NewGuid(),
                License1 = Guid.NewGuid()

            };
       









            this.menuItems = new List<MenuViewModel>
                              {

                          new MenuViewModel
                                      {
                                          Section = Section.Menu_Item1,

                                          Title = "User",
                                          Backcolour = "CurrentUser",
                                          Forecolour = "Back",
                                          IsVisible = () => { return (_settings.License2 != null && _settings.License2 != Guid.Empty)
                                             || (_settings.License1 != null && _settings.License1 != Guid.Empty)
                                             || (_settings.License3 != null && _settings.License3 != Guid.Empty)
                                             ; }

                                      },

                                         new MenuViewModel
                                      {
                                           Section = Section.Menu_Item1,
                                           Title = "Change User",
                                           Backcolour = "Teal",
                                           Forecolour = "Back",
                                           IsVisible = () => { return (_settings.License2 != null && _settings.License2 != Guid.Empty)
                                             || (_settings.License1 != null && _settings.License1 != Guid.Empty)
                                             || (_settings.License3 != null && _settings.License3 != Guid.Empty)
                                             ; }

                                      },
                                                new MenuViewModel
                                      {
                                           Section = Section.Menu_Item1,
                                           Title = "Logout",
                                              Backcolour = "Teal",
                                          Forecolour = "Back",
                                           IsVisible = () => { return (_settings.License2 != null && _settings.License2 != Guid.Empty)
                                             || (_settings.License1 != null && _settings.License1 != Guid.Empty)
                                             || (_settings.License3 != null && _settings.License3 != Guid.Empty)
                                             ; }

                                      }
            };
            for(int i = 0; i < 50; i++)
            {
                if (i % 2 == 0)
                {
                    this.menuItems.Add(new MenuViewModel() { Indentation = 0, Backcolour = "Red", Title = "Item ABCDEGF - " + i.ToString(), Forecolour = "Pink" });
                }
                else {
                    this.menuItems.Add(new MenuViewModel() { Indentation = 1, Backcolour = "Pink", Title = "Item HIJKLMNOP - " + i.ToString(), Forecolour = "Red" });
                }
                        


            }
            


                       



        }








        private MvxCommand<MenuViewModel> m_SelectMenuItemCommand;
        public ICommand SelectMenuItemCommand
        {
            get
            {
                return this.m_SelectMenuItemCommand ?? (this.m_SelectMenuItemCommand = new MvxCommand<MenuViewModel>(
                    async (p) => await this.ExecuteSelectMenuItemCommand(p)
                    ));
            }
        }




       

        public IMvxViewModel  LastSection { get; set; }

        public async System.Threading.Tasks.Task ExecuteSelectMenuItemCommand(MenuViewModel item)
        {
            Debug.WriteLine(item.Title);

        }


      

     

    


        

    }

}
                

