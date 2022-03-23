using BusinessProject.Core.ViewModels;
using BusinessProject.DataModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessProject.Core.Interfaces
{
   public interface IUserJobRepository
    {
        void DeleteJobFromUser(int UserJobId);
        List<UserFullNameWithJobName> GetUserFullNameWithJobNames();
        string GetJobNameFromUserID(string userId);
        List<Contract> GetContracts();
        int GetJobIdFromUserID(string userId);
        Payment GetPaymentDateFromUserID(string userId);
        UserJob SeletTopOneUserJob(string userId);
    }
}
