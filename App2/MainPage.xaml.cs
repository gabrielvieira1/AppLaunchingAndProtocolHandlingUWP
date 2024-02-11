using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
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

    public void SetArgs(string Uri, ValueSet data)
    {
      uri.Text = Uri;
      object itemvalue = null;
      if (data.TryGetValue("item", out itemvalue))
        this.item.Text = (string)itemvalue;
    }

    public void SetArgsAndGetResults(string args, ValueSet data, ProtocolForResultsOperation op)
    {
      _op = op;
      SetArgs(args, data);
    }

    ProtocolForResultsOperation _op;

    private void sendResult_Click(object sender, RoutedEventArgs e)
    {
      var ResultSet = new ValueSet();
      ResultSet.Add("price", "2.99");
      _op.ReportCompleted(ResultSet);
    }
  }
}
