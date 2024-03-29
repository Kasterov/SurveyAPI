﻿using Application.DTOs.Profiles;
using Application.DTOs.Users;
using Domain.Entities;

namespace Application.Mapper.Users;

public class UserProfile : AutoMapper.Profile
{
    public UserProfile() 
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<User, ProfileToUpdateDTO>().ReverseMap();
    }
}
