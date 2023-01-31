using AutoMapper;
using TestApp.Core.DTOs.Test;
using TestApp.Core.Enteties.Test;

namespace TestApp.TestApp.Core.Profiles
{
    public class AppMapingProfile : Profile
    {
        public AppMapingProfile()
        {
            CreateMap<TestQuestion, TestQuestionDTO>().ForMember(dst =>
            dst.Options, opt => 
            opt.MapFrom((src, dest, destMember, context) => 
            context.Mapper.Map<List<TestQuestionOptionDTO>>(src.Options)));
            CreateMap<TestQuestionOption, TestQuestionOptionDTO>();
        }
    }
}
