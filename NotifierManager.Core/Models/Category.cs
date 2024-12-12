using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifierManager.Core.Models
{
    public class Category
    {
        public Category()
        {
            Notifications = new HashSet<Notification>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ColorHex { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
    }

}
