using BusinessProject.Core.ViewModels;
using BusinessProject.DataModelLayer.DbContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BusinessProject.Core.Interfaces;

namespace BusinessProject.Core.Services
{
    public class LetterRepository : ILetterRepository
    {
        private readonly ApplicationContext _context;
        public LetterRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<LettersListViewModel> LetterList(string userId)
        {
            var LetterQueryList = (from L in _context.Letters
                                   where L.UserId == userId
                                   select new LettersListViewModel()
                                   {
                                       LetterId = L.LetterId,
                                       LetterContent = L.LetterContent,
                                       LetterSubject = L.LetterSubject,
                                       LetterCreatDate = L.LetterCreatDate,
                                       ReplyDate = L.ReplyDate,
                                       UserId = L.UserId,
                                       AttachmentFile = L.AttachmentFile,

                                       Classification = L.Classification,
                                       ClassificationText =
                                   (L.Classification == 1) ? "Normal" :
                                   (L.Classification == 2) ? "Private" :
                                   (L.Classification == 3) ? "Secret" : null,

                                       ImmediatellyStatus = L.ImmediatellyStatus,
                                       ImmediatellyStatusText =
                                   (L.ImmediatellyStatus == 1) ? "Normal" :
                                   (L.ImmediatellyStatus == 2) ? "Urgent" :
                                   (L.ImmediatellyStatus == 3) ? "Momentary" : null,

                                       replayDateStatus = L.replayDateStatus,
                                       replayDateStatusText =
                                   (L.replayDateStatus == true) ? "Has" :
                                   (L.replayDateStatus == false) ? "Doesn't have" : null,

                                       AttachmentStatus = L.AttachmentStatus,
                                       AttachmentStatusText =
                                   (L.AttachmentStatus == true) ? "Has" :
                                   (L.AttachmentStatus == false) ? "Doesn't have" : null,

                                   }).ToList();
            return LetterQueryList;
        }

        public List<JobsChartWithUserInfoViewModel> JobsChartWithUserInfo()
        {
            var jobwithuser = (from jobsChart in _context.SystemJobs_tbl
                                   join userjob in _context.UserJobs on jobsChart.JobsID equals userjob.JobId
                                   join user in _context.Users on userjob.UserId equals user.Id
                                   where jobsChart.JobsLevel != 0
                                   where userjob.IsHaveJob == true
                                   select new JobsChartWithUserInfoViewModel()
                                   {
                                      JobsID = jobsChart.JobsID,
                                      JobsName = jobsChart.JobsName,
                                      JobsLevel = jobsChart.JobsLevel,
                                      FirstName = user.FirstName,
                                      Family = user.Family

                                   }).ToList();
            return jobwithuser;
        }
    }
}
