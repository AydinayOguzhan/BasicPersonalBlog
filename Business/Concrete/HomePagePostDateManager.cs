using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class HomePagePostDateManager : IHomePagePostDateService
    {
        IHomePagePostDateDal _homePagePostDate;

        public HomePagePostDateManager(IHomePagePostDateDal homePagePostDate)
        {
            _homePagePostDate = homePagePostDate;
        }

        public IResult Add(HomePagePostDate postDate)
        {
            _homePagePostDate.Add(postDate);
            return new SuccessResult(Messages.Successful);
        }

        public IDataResult<HomePagePostDate> Get()
        {
            return new SuccessDataResult<HomePagePostDate>(_homePagePostDate.Get(h=>h.Id == 1));
        }

        public IResult Update(HomePagePostDate postDate)
        {
            _homePagePostDate.Update(postDate);
            return new SuccessResult(Messages.Successful);
        }
    }
}
