using AutoMapper;
using TaskManager.Core;
using TaskManager.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Web
{
    public class EmployeeTaskProfile : Profile
    {
        public EmployeeTaskProfile()
        {
            CreateMap<EmployeeTask, EmployeeTaskDTO>().ForMember(dest => dest.Projects, opt => opt.Ignore())
                                                        .ForMember(dest => dest.TaskStatuses, opt => opt.Ignore())
                                                        .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(a => a.Project.Name))
                                                        .ForMember(dest => dest.TaskStatusName, opt => opt.MapFrom(a => a.TaskStatus.Name));
        }
    }
}
