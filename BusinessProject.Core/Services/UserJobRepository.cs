using BusinessProject.DataModelLayer.DbContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BusinessProject.Core.ViewModels;
using BusinessProject.Core.Interfaces;
using BusinessProject.DataModelLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessProject.Core.Services
{
   public class UserJobRepository : IUserJobRepository
    {
        private readonly ApplicationContext _context;
        public UserJobRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void DeleteJobFromUser(int UserJobId)
        {
            var result = (from uj in _context.UserJobs where uj.UserJobId == UserJobId select uj);
            var currentUser = result.FirstOrDefault();
            if (result.Count() > 0)
            {
                currentUser.EndJobDate = DateTime.Now;
                currentUser.IsHaveJob = false;
                _context.UserJobs.Attach(currentUser);
                _context.Entry(currentUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public List<UserFullNameWithJobName> GetUserFullNameWithJobNames()
        {
            var query = (from userjob in _context.UserJobs
                         join user in _context.Users on userjob.UserId equals user.Id
                         join jobchart in _context.SystemJobs_tbl on userjob.JobId equals jobchart.JobsID
                         where userjob.IsHaveJob == true
                         select new UserFullNameWithJobName()
                         {
                             UserId = user.Id,
                             UserFullNameWithJob = jobchart.JobsName + "(" + user.FirstName + " " + user.Family + ")"
                         }).ToList();
            return query;
        }
        public List<Contract> GetContracts()
        {
            return _context.Contracts.Include(u => u.User).ToList();
        }
        public string GetJobNameFromUserID(string userId)
        {
            var JobName = (from uj in _context.UserJobs
                          where uj.UserId == userId
                          where uj.IsHaveJob == true
                          select uj.Jobs.JobsName).Single();
            return JobName;
        }
        public int GetJobIdFromUserID(string userId)
        {
            var JobId = (from uj in _context.UserJobs
                           where uj.UserId == userId
                           where uj.IsHaveJob == true
                           select uj.Jobs.JobsID).Single();
            return JobId;
        }

      
        public UserJob SeletTopOneUserJob(string userId)
        {
            return _context.UserJobs.FromSqlRaw<UserJob>("Sp_SelectTopOneUserJob {0}", userId).ToList().FirstOrDefault();
        }

        public Payment GetPaymentDateFromUserID(string userId)
        {
            return _context.Payments.FromSqlRaw<Payment>("Sp_GetTopOnePayment {0}", userId).ToList().FirstOrDefault();
        }
    }
}
