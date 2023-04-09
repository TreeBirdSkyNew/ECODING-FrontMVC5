using AutoMapper;
using ECODING_DAL;
using ECODING_FrontMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECODING_WebApiProject
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<TemplateProject, TemplateProjectVM>();
            CreateMap<TemplateProjectVM, TemplateProject>();
        }
    }
}