using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handasa_Map
{
    class Graph<T>
    {
        private Dictionary<T, LinkedList<T>> Data = new Dictionary<T, LinkedList<T>>();
        private bool Directed;
        public Graph(bool Directed){
            this.Directed = Directed;
        }
        public void AddNode (T Node){
            Data.Add(Node, new LinkedList<T>());
        }
        public void AddEdge(T From, T To){
            Data[From].AddLast(To);
            if (!Directed)
                Data[To].AddLast(From);
        }
        public LinkedList<T> DFS(T Source, T Destination,T Parent)
        {
            Stack<T> OrderOfVisit = new Stack<T>();
            Dictionary<T, T> ParentChildTable = new Dictionary<T, T>();
            List<T> Visited = new List<T>();
            T P = Parent;
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
                S = OrderOfVisit.Pop();
            }
            //traverse back parents
            LinkedList<T> Route = new LinkedList<T>();
            do
            {
                Route.AddLast(S);
                S = ParentChildTable[S];
            } while (!(S as IEquatable<T>).Equals(Source));
            Route.AddLast(S);
            return Route;
        }
    }
}
