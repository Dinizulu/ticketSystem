﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ticketSystem.Data;
using ticketSystem.DTOs.User;
using ticketSystem.Interfaces;
using ticketSystem.Models;

namespace ticketSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        //Dependancy injection
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        //Geting all users from the database
        public async Task<List<User>> GetAllAsync()
        {
            return await _appDbContext.User.ToListAsync();
        }
        //Getting a single user by ID
        public async Task<User> GetByIdAsync(int id)
        {
            return await _appDbContext.User.FindAsync(id);
        }
        //Inserting a user to the Database
        public async Task<User> InsertUserAsync(User user)
        {
            await _appDbContext.User.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
            return user;
        }
        //Updating database/saving changes to the update
        public async Task UpdateDbAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
        //Deleting a user
        public async Task DeleteUserAsync(User user)
        {
            _appDbContext.User.Remove(user);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
