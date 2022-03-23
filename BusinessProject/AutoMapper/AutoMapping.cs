using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessProject.DataModelLayer.Entities;
using BusinessProject.Core.ViewModels;

namespace BusinessProject.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<SystemUsers, UserViewModel>().ReverseMap();
            CreateMap<SystemJobs, JobsChartViewModel>().ReverseMap();
            CreateMap<Payment, PaymentViewModel>().ReverseMap();
            CreateMap<SystemRoles, RoleViewModel>().ReverseMap();
            CreateMap<RolePattern, RolePatternViewModel>().ReverseMap();
            CreateMap<AdminstrativeForm, AdminstrativeDefaultFormViewModel>().ReverseMap();
            CreateMap<Letter, LettersViewModel>().ReverseMap();
            
        }
    }
}
