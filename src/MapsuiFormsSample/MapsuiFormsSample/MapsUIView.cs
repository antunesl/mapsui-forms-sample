using Mapsui.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapsuiFormsSample
{
    public class MapsUIView : Xamarin.Forms.View
    {
        public Mapsui.Map NativeMap { get; set; }

        protected internal MapsUIView()
        {
            NativeMap = new Mapsui.Map
            {
                BackColor = Color.Black
            };
        }
    }
}
