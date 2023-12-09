using AutoMapper;
using Lms_ID3_BE.Dtos;
using Lms_ID3_BE.Infrastructure.Entities.Student;

namespace Lms_ID3_BE.Extensions
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<StudentEntity, StudentDto>();
    }
  }
}
