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
        Shape s = null;
        Plane p = new Plane();
        public Faculty()
        {
            this.InitializeComponent();
#if DEBUG
            foreach (Shape s in G.Children)
            {
                s.Stroke = new SolidColorBrush(Colors.Black);
            }
#endif
            foreach(Shape s in G.Children)
            {
                s.Tapped += S_Tapped;
                s.Holding += S_Holding; ;
                p.AddSegment(s);
            }
            p.AddRelation(elecdoor2, fdoor1);
            p.AddRelation(fdoor1, cross1);
            p.AddRelation(cross1, addoor1);
            p.AddRelation(addoor1, cross2);
            p.AddRelation(cross2, prepdoor1);
            p.AddRelation(prepdoor1, cross3);
            p.AddRelation(cross3, prepdoor2);
            p.AddRelation(prepdoor2, cross4);
            p.AddRelation(cross4, prepdoor3);
            p.AddRelation(cross4, fdoor2);
            p.AddRelation(electdoor1, cross5);
            p.AddRelation(cross5, addoor1);
        }

        private void S_Holding(object sender, HoldingRoutedEventArgs e)
        {
            if(s != null)
            (s.DataContext as Segment).Color.Color = Colors.DarkCyan;
            s = null;
        }

        private void S_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (s == null)
            {
                s = sender as Shape;
                (s.DataContext as Segment).Color.Color = Colors.BlanchedAlmond;
                p.UndoNavigation();
            }
                
            else
            {
                //Debug.WriteLine("p.AddRelation({0}, {1});",s.Name,(sender as Shape).Name);
                //(s.DataContext as Segment).Color.Color = Colors.DarkCyan;
                //s = sender as Shape;
                //(s.DataContext as Segment).Color.Color = Colors.BlanchedAlmond;
                p.Navigate(s, sender as Shape);
                s = null;
            }

        }

    }
}
