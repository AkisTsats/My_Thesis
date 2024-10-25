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
            //TODO what the ... is going on here
            //var announcementCategoriesIds = await _context.Categories
            //    .Where(a => a.Id == announcement.AnnID)
            //    .Select(b => b.Id)
            //    .ToListAsync();

            //var usersWithSelectedCategories = await _context.Subjects
            //    .Where(a => announcementCategoriesIds.Contains(a.Id))
            //    .Select(b => b.Id)
            //    .ToListAsync();

            //var emailsFromCategories = await _context.Users
            //    .Where(a => usersWithSelectedCategories.Contains(a.Id))
            //    .Select(b => b.PrimaryEmail)
            //    .ToListAsync();

            //Console.WriteLine($"fetched mail categories{emailsFromCategories}");

            throw new NotImplementedException();
            //return emailsFromCategories;
        }


        //public async Task<List<string>> SendToWordpress
        //{

        //}

        //public async Task<List<string>> SendToMqtt
        //{

        //}

    }
}
