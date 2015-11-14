using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;
using Windows.UI.Xaml.Shapes;
using System.Diagnostics;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Handasa_Map
{
    public sealed partial class Faculty : UserControl
    {
        public Faculty()
        {
            this.InitializeComponent();
            //Debug.WriteLine((this.Content as Grid).Name);
            //#if DEBUG
            //foreach (var s in (this.Content as Grid).Children)
            //{
            //    if (s is Rectangle)
            //        (s as Rectangle).Stroke = new SolidColorBrush(Colors.Black);
            //}
            //#endif
            //Graph<Segment> Segments = new Graph<Segment>(false);
            //Segment _electdoor2 = new Segment("electdoor2");
            //elecdoor2.DataContext = _electdoor2;
            //Segment _fdoor1 = new Segment("fdoor1");
            //fdoor1.DataContext = _fdoor1;
            //Segments.AddNode(_fdoor1);
            //Segments.AddNode(_electdoor2);
            //Segments.AddEdge(_fdoor1, _electdoor2);
            //Segment _cross1 = new Segment("cross1");
            //cross1.DataContext = _cross1;
            //Segments.AddNode(_cross1);
            //Segments.AddEdge(_cross1, _fdoor1);
            //Segment _addoor1 = new Segment("addoor1");
            //addoor1.DataContext = _addoor1;
            //Segments.AddNode(_addoor1);
            //Segments.AddEdge(_addoor1, _cross1);
            //List<Segment> result = Segments.DFS(_electdoor2, _addoor1);
            //for (int i = 0; i < result.Count; i++)
            //{
            //    result[i].Color = new SolidColorBrush(Colors.Azure);
            //}
            Plane p = new Plane();
            foreach(Shape s in G.Children)
            {
                //TODO add event handlers here
                p.AddSegment(s);
            }
        }
    }
}
