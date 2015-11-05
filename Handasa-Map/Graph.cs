using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handasa_Map
{
    class Graph<T>
    {
        private Dictionary<T, List<T>> Data = new Dictionary<T, List<T>>();
        private bool Directed;
        public Graph(bool Directed){
            this.Directed = Directed;
        }
        public void AddNode (T Node){
            Data.Add(Node, new List<T>());
        }
        public void AddEdge(T From, T To){
            Data[From].Add(To);
            if (!Directed)
                Data[To].Add(From);
        }
        public List<T> DFS(T Source, T Destination)
        {
            Stack<T> OrderOfVisit = new Stack<T>();
            Dictionary<T, T> ParentChildTable = new Dictionary<T, T>();
            List<T> Visited = new List<T>();
            T P = Source;
            T S = Source;
            ParentChildTable[S] = P;
            //ordinary traversal
            while (!(S as IEquatable<T>).Equals(Destination))
            {
                if (!Visited.Contains(S))
                {
                    Visited.Add(S);
                    foreach (T child in Data[S])//add adding parent here
                    {
                        if(!Visited.Contains(child))
                        {
                            ParentChildTable[child] = S;//problem parent override
                            OrderOfVisit.Push(child);
                        }
                    }    
                }
                P = S;
                if (OrderOfVisit.Count > 0)
                    S = OrderOfVisit.Pop();
                else
                    return null;
            }
            //traverse back parents
            List<T> Route = new List<T>();
            do
            {
                Route.Add(S);
                S = ParentChildTable[S];
            } while (!(S as IEquatable<T>).Equals(Source));
            Route.Add(S);
            return Route;
        }
    }
}
