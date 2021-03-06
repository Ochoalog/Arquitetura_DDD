using System;
using Api.CrossCutting.Mappings;
using AutoMapper;
using Xunit;

namespace Api.Service.Test;

public abstract class BaseTestService
{
    public IMapper _mapper { get; set; }
    
    public BaseTestService()
    {
        _mapper = new AutoMapperFixture().GetMapper();
    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper() 
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new ModelToEntityProfile());
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
            });

            return config.CreateMapper();
        }

        public void Dispose() 
        {

        }
    }
}