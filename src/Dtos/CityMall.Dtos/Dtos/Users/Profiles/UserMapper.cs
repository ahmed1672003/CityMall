using CityMall.Domain.Entities.Identity;

namespace CityMall.Dtos.Dtos.Users.Profiles;
public static class UserMapper
{
    public static IEnumerable<GetUserDto> Mapp(this IQueryable<User> query)
    {
        return query.Select(user => new GetUserDto
        {
            Id = user.Id,
            Email = user.Email,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Gander = user.Gander,
            FileName = user.FileName,
            FilePath = user.FilePath,
            PhoneNumber = user.PhoneNumber,
            WhatsAppNumber = user.WhatsAppNumber,
            CreatedAt = user.CreatedAt,
            IsDeleted = user.IsDeleted,
            DeletedAt = user.DeletedAt,
            UpdatedAt = user.UpdatedAt,
        })
        .AsEnumerable();
    }

    public static GetUserDto Mapp(this User user)
    {
        return new GetUserDto
        {
            Id = user.Id,
            Email = user.Email,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Gander = user.Gander,
            FileName = user.FileName,
            FilePath = user.FilePath,
            PhoneNumber = user.PhoneNumber,
            WhatsAppNumber = user.WhatsAppNumber,
            CreatedAt = user.CreatedAt,
            IsDeleted = user.IsDeleted,
            DeletedAt = user.DeletedAt,
            UpdatedAt = user.UpdatedAt,
        };
    }

    //public static User Mapp(AddUserDto dto)
    //{

    //    return new()
    //    {
    //        FirstName = dto.FirstName,
    //        LastName = dto.LastName,
    //        Email = dto.Email,
    //        UserName = dto.UserName,
    //        Gander = dto.Gander,
    //        PhoneNumber = dto.PhoneNumber,
    //        WhatsAppNumber = dto.WhatsAppNumber,

    //    };
    //}
}
