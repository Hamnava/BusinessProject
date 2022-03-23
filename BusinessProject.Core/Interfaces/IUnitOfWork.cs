using BusinessProject.Core.Services;
using BusinessProject.DataModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessProject.Core.Interfaces
{
   public interface IUnitOfWork
    {
        GenericClasses<SystemRoles> roleManagerUW { get; }
        GenericClasses<SystemUsers> userManagerUW { get; }
        GenericClasses<SystemJobs> JobanagerUW { get; }
        GenericClasses<UserJob> userJobUW { get; }
        GenericClasses<Payment> paymentUW { get; }
        GenericClasses<RolePattern> rolePatternUW { get; }
        GenericClasses<RolePatternDetails> rolePatternDetailsUW { get; }
        GenericClasses<Contract> contractUW { get; }
        GenericClasses<Letter> letterUW { get; }
        GenericClasses<AdminstrativeForm> adminstrativeFormUW { get; }
        IEntityDatabaseTransaction BeginTrasaction();
        void save();
    }
}
