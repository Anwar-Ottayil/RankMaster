using Application.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ServiceInterface
{
    public interface IQuestionService
    {

        Task<string> UploadQuestionsFromCsvAsync(QuestionCsvUploadDto dto);

    }
}
