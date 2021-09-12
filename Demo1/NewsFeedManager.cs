using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Demo1.IO;
using Demo1.Models;
using Publisher = Demo1.Models.Publisher;

namespace Demo1
{
    public class NewsFeedManager
    {
        private readonly INewsRepository _newsRepository;
        private List<Publisher> _publishers;
        private INewRepository repository;

        public NewsFeedManager(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public NewsFeedManager(INewRepository repository)
        {
            this.repository = repository;
        }

        public List<Publisher> GetNewsFeed()
        {
            if (_publishers == null)
            {
                _publishers = _newsRepository.GetNews();
            }
            return _publishers;
        }

        public List<Publisher> Get_publishers()
        {
            return _publishers;
        }

        public void SaveChandes(List<Publisher> _publishers)
        {
            _newsRepository.Save(_publishers);
        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void RemovePublisher(string publisherName)
        {
            _publishers.RemoveAll(x => x.Name == publisherName);
            SaveChandes(Get_publishers());
        }
        public void RemoveCategory(string publisherName, string categoryName)
        {
            var publisher = _publishers.Find(x => x.Name == publisherName);
            if (publisher == null) return;

            publisher.RemoveCategory(categoryName);
            SaveChandes(Get_publishers());
        }
        public bool AddCategory(string publisherName, string categoryName, string rssLink, bool updateIfExisted)
        {
            var publisher = _publishers.Find(x => x.Name == publisherName);
            if (publisher == null)
            {
                publisher = new Publisher()
                {
                    Name = publisherName
                };
                _publishers.Add(publisher);
            }
            return publisher.AddCategory(categoryName, rssLink, updateIfExisted);
        }
    }
}
