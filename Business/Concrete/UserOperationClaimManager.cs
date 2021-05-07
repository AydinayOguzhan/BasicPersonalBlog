using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.Successful);
        }

        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult(Messages.Successful);
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetList());
        }

        public IDataResult<UserOperationClaim> GetById(int id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(u=>u.Id == id));
        }

        public IDataResult<List<UserOperationClaim>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetList(u => u.UserId == userId));
        }

        public IResult Update(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(Messages.Successful);
        }

        public IResult CheckIfItsAdmin(int userId)
        {
            var result = BusinessRules.Run(CheckAdminClaim(userId));
            if (result == null)
            {
                int adminClaimId = 1;
                var claims = _userOperationClaimDal.GetList(u => u.UserId == userId);
                var adminClaim = claims.SingleOrDefault(c => c.OperationClaimId == adminClaimId);
                if (adminClaim == null)
                {
                    return new ErrorResult();
                }
                return new SuccessResult();
            }
            return new ErrorResult(Messages.UserNotFound);
        }

        private IResult CheckAdminClaim(int userId)
        {
            var claims = _userOperationClaimDal.GetList(u => u.UserId == userId);
            if (claims == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
