

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam7.Views;
using Xamarin.Forms;

namespace Xam7.ViewModels
{
    public class RootViewModel :ViewModelBase
    {
        public ObservableCollection<ContentView> TabItems { get; set; }
        public ContentView Tab { get; set; }
        //Test implementation for possibility to create custom tabs.         
        //The idea is taken from Sharpnado Tabs. But quality is definitely worst than original :D
        public RootViewModel()
        {
            TabItems = new ObservableCollection<ContentView>();
            Tab = new ContentView();
            TabItems.Add(new SLazyView<FirstTabView>() { });
            TabItems.Add(new SLazyView<SecondTabView>() { });
            
             GotoFirstTab();
        }
        public Command SecondCommand
            => new Command(async () => await GotoSecond());
        public Command FirstCommand
            => new Command(async () => await GotoFirstTab());

        async Task GotoFirstTab()
        {

            var lazyView = TabItems[0] as ILazyView;
            if (!lazyView.IsLoaded)
            {
                //for loading view
                //...
                await FirstTab();
            }
            else
            {
                await FirstTab();
            }



        }
        async Task GotoSecond()
        {

            var lazyView = TabItems[1] as ILazyView;
            if (!lazyView.IsLoaded)
            {
                //for loading view
                //...
                await SecondTab();
            }
            else
            {
                await SecondTab();
            }

        }

        async Task FirstTab()
        {
            await Device.InvokeOnMainThreadAsync(() =>
            {
                
                var lazyView = TabItems[0] as ILazyView;
                
                if (lazyView != null)
                {
                    if (!lazyView.IsLoaded)
                    {
                        lazyView.LoadView();
                        
                    }
                }

                Tab.Content = lazyView.Content;
                
            });
        }

        async Task SecondTab()
        {


            await Device.InvokeOnMainThreadAsync(() =>
            {
               
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                

                var lazyView = TabItems[1] as ILazyView;
                if (lazyView != null)
                {
                    if (!lazyView.IsLoaded)
                    {
                        lazyView.LoadView();
                        
                    }
                }
                
                Tab.Content = lazyView.Content;

                
                stopWatch.Stop();

                 Application.Current.MainPage.DisplayAlert("", $"--> Go to second tab took: " + stopWatch.ElapsedMilliseconds + " ms", "ok");

                Debug.WriteLine($"-->  Go to second tab took: " + stopWatch.ElapsedMilliseconds + " ms");
            });

        }
    }
}
