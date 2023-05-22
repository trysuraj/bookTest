using BookApplication.Core.Models.Dtos;
using BookApplication.Core.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApplication.Service.Interfaces
{
    public interface IBookService
    {
        
       // Task<string> DeleteProfileById(string Id);
        Task<string> UpdateProfileById(string Id, UserDto appUser);
        Task<UserDto> GetProfileById(string Id);
        Task<PaginatedList<UserDto>> GetAllProfiles(int page, int perPage);
    }
}
