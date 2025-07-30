using AutoMapper;
using Health.Domain.Entities;
using Health.Domain.ViewModel;

namespace Health.Application.Mappings
{
    public class PlanMappingProfile : Profile
    {
        public PlanMappingProfile()
        {
            CreateMap<PlanEntity, PlanViewModel>();
        }
    }
}
