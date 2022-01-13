using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Helpers.HttpHelper;
using Models.NasaRes;
using Newtonsoft.Json;

namespace nasa_api
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            HttpHelperExtensions client = new HttpHelperExtensions("https://api.nasa.gov/planetary/apod?api_key=IXwf5Eqe3gITfAbAVmSloz0xghbzC9cdsFVFfdwv");

            var res = await client.Get();

            if(res != null)
            {
                NasaRes resJson = JsonConvert.DeserializeObject<NasaRes>(res.Content.ToString());

                SettingNasaImage(resJson.Url);

                NasaTitle.Text = resJson.Title;
                NasaContent.Text = resJson.Explanation;
                NasaCopyrightDate.Text = String.Format("© {0}  ·  {1}", resJson.Copyright, resJson.Date);
            }

        }

        private void SettingNasaImage(string source)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(source);
            image.EndInit();

            NasaImage.Source = image;
            NasaImageSP.Background = Brushes.White;
        }
    }
}
