using Application.Dto;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDto, User>().ReverseMap();
            CreateMap<LoginDto,User>().ReverseMap();
            CreateMap<ExamDto, Exam>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<Exam, SearchDto>().ReverseMap();
            CreateMap<Question, ReadQuestionDto>();




        }
    }
}
