using AutoMapper;
using Entities;
using Shared.DTO;

namespace DeviceAndManagement
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DeviceViewModel, Device>().ReverseMap();
            CreateMap<DeviceViewItemModel, DeviceViewModel>().ReverseMap();
            CreateMap<Device, DeviceViewItemModel>().ReverseMap();

            CreateMap<DeviceStatusLogViewModel, DeviceStatusLog>().ReverseMap();
            CreateMap<DeviceStatusLogViewModel, StatusViewItemModel>().ReverseMap().ForMember(dest => dest.DeviceId, opt => opt.MapFrom(src => src.DeviceId));
        }
    }
}
