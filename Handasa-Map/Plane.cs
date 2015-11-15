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
        List<Segment> Result;
        Graph<Segment> Relation = new Graph<Segment>(false);
        public void AddSegment(Shape Segment)
        {
            Segment.DataContext = new Segment(Segment.Name);
            Relation.AddNode(Segment.DataContext as Segment);
            Segment.SetBinding(Shape.FillProperty, new Binding() { Path = new PropertyPath("Color") });
        }

        public void AddRelation(Shape From, Shape To)
        {
            Relation.AddEdge(From.DataContext as Segment, To.DataContext as Segment);
        }
        public void Navigate(Shape From, Shape To)
        {
            Result = Relation.DFS(From.DataContext as Segment, To.DataContext as Segment);
            if(Result != null)
                foreach (Segment item in Result)
                {
                    item.Color = new SolidColorBrush(Colors.CadetBlue);
                }
        }
        public void UndoNavigation()
        {
            if(Result != null)
                foreach (Segment item in Result)
                {
                    item.Color = new SolidColorBrush(Colors.DarkCyan);
                }
        }
        public void Navigate(string From, string To)
        {

        }

    }
}
