using System.Collections.Generic;

namespace WebCrawler
{
    public class LinkQueue
    {
        private List<string> _visited = new List<string>();
        private Queue<string> _unvisted = new Queue<string>();

        public List<string> Visited
        {
            get => _visited;
        }
        public Queue<string> UnVisited
        {
            get => _unvisted;
        }
        public int VisitedCount 
        {
            get => _visited.Count;
        }
        public int UnVisitedCount
        {
            get => _unvisted.Count;
        }
        public bool VisitedEmpty
        {
            get => _visited.Count == 0;
        }
        public bool UnVisitedEmpty
        {
            get => _unvisted.Count == 0;
        }
        public LinkQueue(string seedUrl)
        {
            this.AddUnVisitedUrl(seedUrl);

        }

        public void AddVisitedUrl(string url)
        {
            Visited.Add(url);
        }
        public void RemoveVisited(string url)
        {
            Visited.Remove(url);
        }

        public string UnVisitedDequece()
        {
            if (UnVisited.Count != 0)
                return UnVisited.Dequeue();
            else
                return "null";
        }
        public void AddUnVisitedUrl(string url)
        {
            if (!UnVisited.Contains(url) && !Visited.Contains(url))
                UnVisited.Enqueue(url);
        }



    }
}