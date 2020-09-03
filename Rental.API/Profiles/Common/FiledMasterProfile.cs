using AutoMapper;
using Rental.API.Data.Models;
using Rental.API.Model;

namespace Rental.API.Profiles.Common
{
    public class FiledMasterProfile:Profile
    {
        public FiledMasterProfile()
        {
            CreateMap<FieldMaster, FieldMasterDto>();
            CreateMap<FieldMasterForUpdateDto, FieldMaster>()
                .ReverseMap();
        }
    }
}
