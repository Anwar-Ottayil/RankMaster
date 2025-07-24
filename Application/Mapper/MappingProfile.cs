using Application.Dto;
using AutoMapper;
using Domain.Model;
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

            CreateMap<Question, ReadQuestionDto>()
            .ForMember(dest => dest.Source, opt => opt.MapFrom(src => "New"));

            CreateMap<RemovedQuestion, ReadQuestionDto>()
            .ForMember(dest => dest.Source, opt => opt.MapFrom(src => "Rejected"));


            CreateMap<CreateAnnouncementDto, Announcement>();
            CreateMap<UpdateAnnouncementDto, Announcement>();
            CreateMap<Announcement, AnnouncementDto>();


            CreateMap<CreateCurrentAffairDto, CurrentAffair>();
            CreateMap<CurrentAffair, CurrentAffairDto>();


            CreateMap<ExamAttempt, ExamAttemptResultDto>();
            CreateMap<ExamAnswer, ExamAnswerDto>();
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<WalletTransaction, WalletTransactionResponseDto>();


        }
    }
}
