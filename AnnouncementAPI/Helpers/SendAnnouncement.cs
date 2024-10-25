using DTOs.Data;
using EFDataAccessLibrary.Data;
using MailKit;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using DTOs.API.Responses;
using EFDataAccessLibrary.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs.Data;
using Microsoft.AspNetCore.Authorization;
using System.Collections;

namespace AnnouncementAPI.Helpers
{
    public class SendAnnouncement
    {
        private readonly MyDbContext _context;

        public SendAnnouncement(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> SendToMail(AnnouncementDTO announcement)
        {
            var announcementCategoriesIds = await _context.categoriesListannouncement
                .Where(a => a.AnnouncementID == announcement.AnnID)
                .Select(b => b.CategoryId)
                .ToListAsync();

            var usersWithSelectedCategories = await _context.categorieslistuser
                .Where(a => announcementCategoriesIds.Contains(a.CategoryID))
                .Select(b => b.UserID)
                .ToListAsync();

            var emailsFromCategories = await _context.Users
                .Where(a => usersWithSelectedCategories.Contains(a.UserID))
                .Select(b => b.PrimaryEmail)
                .ToListAsync();

            Console.WriteLine($"fetched mail categories{emailsFromCategories}");

            return emailsFromCategories;
        }


        //public async Task<List<string>> SendToWordpress
        //{

        //}

        //public async Task<List<string>> SendToMqtt
        //{

        //}

    }
}
