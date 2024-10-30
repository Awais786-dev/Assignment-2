using AutoMapper;
using FirstAssignment.Models; // Adjust the namespace as necessary

public class UserProfile : Profile
{
    public UserProfile()
    {       
        // CreateMap<User, UserDto>(); // Map User to UserDto
        CreateMap<User, UserDto>()
           .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name));

        //CreateMap<UserDto, User>(); // Map UserDto back to User
        CreateMap<UserDto, User>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName));


    }
}
