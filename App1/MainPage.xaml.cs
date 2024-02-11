using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
      //var uri = new Uri(@"https://www.bing.com/?cc=br");
      var uri = new Uri(@"foodtruck:burgers");

      var launchOptions = new LauncherOptions()
      {
        TargetApplicationPackageFamilyName = "75b5be6a-3249-46b5-b0e8-25ec0224b92c_03w1eqkrn0fpt", // App 2
        //TargetApplicationPackageFamilyName = "b9968d3a-1d0e-4d41-ac1f-5e922d694357_03w1eqkrn0fpt", // App 3
      };

      //var success = await Launcher.LaunchUriAsync(uri, launchOptions);

      var set = new ValueSet();
      set.Add("item", "cheeseburguer");
      var launchResult = await Launcher.LaunchUriForResultsAsync(uri, launchOptions, set);
      if (launchResult.Status == LaunchUriStatus.Success)
      {
        object resultItem = null;
        if (launchResult.Result?.TryGetValue("price", out resultItem) ?? false)
        {
          var dialog = new MessageDialog((string)resultItem);
          await dialog.ShowAsync();
        }
      }
    }

    private async void Button_Click1(object sender, RoutedEventArgs e)
    {
      var handlers = await Launcher.FindUriSchemeHandlersAsync("foodtruck");
      foreach (var handler in handlers)
      {
        System.Diagnostics.Debug.WriteLine($"PackageFamilyName: {handler.PackageFamilyName}");
      }
    }
  }
}
