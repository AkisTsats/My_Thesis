using DTOs.Data;
using EFDataAccessLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnouncementAPI.Helpers
{
    //public class SendAnnouncement
    //{
    //    private readonly MyDbContext _context;

    //    public SendAnnouncement(MyDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<List<string>> GetUsersToInform(AnnouncementDTO announcement)
    //    {
    //        var announcementCategoriesIds = await _context.Categories
    //            .Where(a => announcement.Categories.Select(b => b.Id)
    //            .Contains(a.Id))
    //            .ToListAsync();

    //        var announcementSubjectsIds = await _context.Subjects
    //            .Where(a => announcement.Subjects.Select(b => b.Id)
    //            .Contains(a.Id))
    //            .ToListAsync();

    //        var announcementAcademicYearsIds = await _context.AcademicYears
    //            .Where(a => announcement.AcademicYears.Select(b => b.Id)
    //            .Contains(a.Id))
    //            .ToListAsync();

    //        var usersWithSelectedCategories = await _context.Users
    //            .Where(a => announcementCategoriesIds.Select(b => b.Id)
    //            .Contains(a.Id))
    //            .ToListAsync();

    //        var usersWithSelectedSubjects = await _context.Users
    //            .Where(a => announcementSubjectsIds.Select(b => b.Id)
    //            .Contains(a.Id))
    //            .ToListAsync();

    //        var usersWithSelectedAcademicYears = await _context.Users
    //            .Where(a => announcementAcademicYearsIds.Select(b => b.Id)
    //            .Contains(a.Id))
    //            .ToListAsync();

    //        var commonUserIds = usersWithSelectedCategories.Select(u => u.Id)
    //            .Intersect(usersWithSelectedSubjects.Select(u => u.Id))
    //            .Intersect(usersWithSelectedAcademicYears.Select(u => u.Id));

    //        var userEmailsToInform = await _context.Users
    //            .Where(a => commonUserIds.Contains(a.Id))
    //            .Select(a => a.Email)
    //            .ToListAsync();

    //        Console.WriteLine($"fetched mail categories{userEmailsToInform}");

    //        return userEmailsToInform;
    //    }
    //}
}
