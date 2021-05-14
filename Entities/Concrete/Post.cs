using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Post:IEntity
    {
        public int Id { get; set; }
        public string PostHeader { get; set; }
        public string PostSummary { get; set; }
        public string PostBody { get; set; }
        public DateTime PostDate { get; set; }
    }
}
