using Mapsui.Providers;
using Mapsui.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MapsuiFormsSample
{
    public partial class MainPage : ContentPage
    {
        MapsUIView _mapView;

        public MainPage()
        {
            InitializeComponent();

            _mapView = new MapsUIView
            {
                NativeMap = InfoLayersSample.CreateMap(),
                BackgroundColor = Color.Black
            };
            _mapView.NativeMap.Info += MapOnInfo;

            ContentGrid.Children.Add(_mapView);
        }

        private void MapOnInfo(object sender, MapInfoEventArgs e)
        {
            var message = ToString(e.MapInfo.Feature);
            Debug.WriteLine(message);
            detail.Text = message;
        }

        private string ToString(IFeature feature)
        {
            var result = new StringBuilder();
            if (feature == null || feature.Fields == null)
                return result.ToString();

            foreach (var field in feature.Fields)
            {
                result.Append($"{field}={feature[field]}, ");
            }

            result.Append($"Geometry={feature.Geometry}");
            return result.ToString();
        }

        private void GenerateData_Clicked(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            InfoLayersSample.ChangeMap(_mapView.NativeMap);
            watch.Stop();
            detail.Text = $"Date generated and map updated in {watch.ElapsedMilliseconds}ms";
        }
    }
}
