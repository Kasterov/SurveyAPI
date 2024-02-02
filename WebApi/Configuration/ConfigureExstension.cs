﻿using Application.Abstractions.Assignments;
using Infrastructure.Db;
using Infrastructure.Repositories.Assignments;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Application.Configuration;
using Infrastructure.Configuration;
using MediatR;
using Application.Mapper;
using Infrastructure.Repositories.Tickets;
using Application.Abstractions.Users;
using Infrastructure.Repositories;
using Application.MediatR.Users.Commands;
using Application.Abstractions.Posts;
using Application.Abstractions.Votes;
using Application.Abstractions.Profiles;
using Application.Abstractions.Jobs;
using Application.Abstractions.Educations;
using Application.Abstractions.Countries;
using Application.Abstractions.Hobbies;

namespace WebApi.Configuration;

public static class ConfigureExstension
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(CreateUser))));

        builder.Services.AddScoped<IVoteRepository, VoteRepository>();
        builder.Services.AddScoped<IPostRepository, PostRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
        builder.Services.AddScoped<IJobRepository, JobRepository>();
        builder.Services.AddScoped<IEducationRepository, EducationRepository>();
        builder.Services.AddScoped<ICountryRepository, CountryRepository>();
        builder.Services.AddScoped<IHobbyRepository, HobbyRepository>();

        builder.Services
            .AddApplication()
            .AddInfrastructure(builder.Configuration);

        builder.Services.AddAutoMapper(typeof(MappingProfile));
    }
}
