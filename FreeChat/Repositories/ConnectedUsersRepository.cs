﻿using FreeChat.Models;
using System.Collections.Generic;
using System.Linq;
using FreeChat.Repositories.Interfaces;

namespace FreeChat.Repositories
{
    public class ConnectedUsersRepository : IConnectedUsers
    {
        private readonly ApplicationDbContext _context;

        public ConnectedUsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public long CountConnectedUsers()
        {
            return _context.ConnectedUsers.Count();
        }

        public IEnumerable<ApplicationUser> GetConnectedUsers()
        {
            return _context.Users;
        }
    }
}