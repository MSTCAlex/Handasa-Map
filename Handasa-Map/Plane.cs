using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI;
namespace Handasa_Map
{
    class Plane
    {
        public enum Mode
        {
            Create,
            Navigate
        }
        public Mode M = Mode.Navigate;
        Graph<Segment> Relation = new Graph<Segment>(false);
        public void AddSegment(Shape Segment)
        {
            Segment.Tag = new Segment(Segment.Name);
            Segment.DataContext = Segment.Tag;
            Relation.AddNode(Segment.Tag as Segment);
            Segment.SetBinding(Shape.FillProperty, new Binding() { Path = new PropertyPath("Color") });
            Segment.Tapped += Segment_Tapped;
        }

        private void Segment_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            
        }

        public void AddRelation(Shape From, Shape To)
        {
            Relation.AddEdge(From.Tag as Segment, To.Tag as Segment);
        }
        public void Navigate(Shape From, Shape To)
        {
            List<Segment> Result = Relation.DFS(From.Tag as Segment, To.Tag as Segment);
            foreach (Segment item in Result)
            {
                item.Color = new SolidColorBrush(Colors.CadetBlue);
            }
        }
        public void Navigate(string From, string To)
        {

        }

    }
}
