﻿using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using AutoMapper;

namespace App.InterViews.Report.Service.Mappers;

public class ProcessProfileMapperService : Profile
{
    public ProcessProfileMapperService()
    {
        CreateMap<ProcessDto, Process>()
            .ReverseMap();
    }
}
