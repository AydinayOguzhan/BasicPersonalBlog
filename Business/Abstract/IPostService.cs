using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPostService
    {
        IDataResult<List<Post>> GetAll();
        IDataResult<Post> GetById(int id);
        IResult Add(Post post);
        IResult Update(Post post);
        IResult Delete(Post post);
    }
}
