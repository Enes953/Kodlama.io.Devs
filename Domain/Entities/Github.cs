using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Github : Entity
    {
        public int UserId { get; set; }
        public string Url { get; set; }
        public virtual User? User { get; set; }
        public Github()
        {

        }
        public Github(int id,int userId, string url):this()
        {
            Id = id;
            UserId = userId;
            Url = url;
        }
      
    }
}
