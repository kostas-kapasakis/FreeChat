using System.Collections.Generic;

namespace FreeChat.Core.Models.Domain
{
    public class MainCategory
    {
        public MainCategory()
        {
            Topics = new List<Topic>();
        }

        public byte Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public string CategoryImage { get; set; }

        public string CategoryDescription { get; set; }

        public IList<Topic> Topics { get; set; }


    }
}