using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IHomePagePostDateService
    {
        IResult Add(HomePagePostDate postDate);
        IResult Update(HomePagePostDate postDate);
        IDataResult<HomePagePostDate> Get();
    }
}
