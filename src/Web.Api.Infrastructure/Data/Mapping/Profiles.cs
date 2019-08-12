using AutoMapper;
using Web.Api.Core.Domain.Entities;
using Web.Api.Infrastructure.Identity;


namespace Web.Api.Infrastructure.Data.Mapping
{
    /// <summary></summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class DataProfile : Profile
    {
        /// <summary>Initializes a new instance of the <see cref="DataProfile"/> class.</summary>
        public DataProfile()
        {
            CreateMap<User, AppUser>().ConstructUsing(u => new AppUser {UserName = u.UserName, Email = u.Email}).ForMember(au=>au.Id,opt=>opt.Ignore());
            CreateMap<AppUser, User>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)).
                                       ForMember(dest=> dest.PasswordHash, opt=> opt.MapFrom(src=>src.PasswordHash)).
                                       ForAllOtherMembers(opt=>opt.Ignore());
        }
    }
}
