using BusinessProject.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessProject.Core.Interfaces
{
   public interface ILetterRepository
    {
        List<LettersListViewModel> LetterList(string userId);
        List<JobsChartWithUserInfoViewModel> JobsChartWithUserInfo();
    }
}
