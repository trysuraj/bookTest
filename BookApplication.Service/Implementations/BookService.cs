using AutoMapper;
using BookApplication.Core.Models;
using BookApplication.Core.Models.Dtos;
using BookApplication.Core.Models.Pagination;
using BookApplication.Infrastructure.Context;
using BookApplication.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookApplication.Core.Models.Pagination.PageImplement;

namespace BookApplication.Service.Implementations
{
    public class BookService : IBookService
    {
        private readonly BookDbContext _context;
        private readonly IMapper _mapper;

        public BookService(BookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; ;
        }


        public async Task<string> UpdateProfileById(string Id, UserDto appUser)
        {
            var searchForUser = await _context.AppUsers.FindAsync(Id);
            if (searchForUser == null) return null;

            searchForUser.UserName = appUser.UserName;
            searchForUser.Email = appUser.Email;
            searchForUser.Password = appUser.Password;


            _context.AppUsers.Update(searchForUser);
            _context.SaveChanges();
            return "Successfully updated user's profile";
        }
       
        public async Task<UserDto> GetProfileById(string Id)
        {
            var searchForUser = await _context.AppUsers.FindAsync(Id);
            if (searchForUser == null) return null;
            var userToReturn = _mapper.Map<UserDto>(searchForUser);
            return userToReturn;
        }
        public async Task<PaginatedList<UserDto>> GetAllProfiles(int page, int perPage)
        {
            var searchForUser = await _context.AppUsers.ToListAsync();
            if (searchForUser == null) return null;
            var userToReturn = _mapper.Map<List<UserDto>>(searchForUser);
            var user = PagImplement<UserDto>.Paginate(userToReturn, page, perPage);
            return user;
        }

    }
}
