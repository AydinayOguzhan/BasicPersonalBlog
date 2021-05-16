using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class HomePagePostDate:IEntity
    {
        public int Id { get; set; }
        public byte PostDate { get; set; }
    }
}
