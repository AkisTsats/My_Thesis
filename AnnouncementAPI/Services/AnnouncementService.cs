using EFDataAccessLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnouncementAPI.Services
{
    public class AnnouncementService
    {
        private readonly MyDbContext _context;

        public AnnouncementService(MyDbContext context)
        {
            _context = context;
        }

        public IQueryable<Announcement> GetAnnouncementsQuery(
            string? textContains,
            IEnumerable<int>? InCategoriesIds,
            IEnumerable<int>? InSubjectIds,
            bool orderByCreationDateAscending,
            bool orderByCreationDateDescending,
            bool includesForMapping = true,
            bool allowUnpublished = false
            )
        {
            var query = _context.Announcements.AsQueryable();

            if (textContains is not null)
            {
                query = query.Where(a => a.Title.Contains(textContains) || a.Body.Contains(textContains));
            }

            if (InCategoriesIds is not null)
            {
                query = query.Where(a => a.RelatedToCategories.Any(b => InCategoriesIds.Contains(b.Id)));
            }

            if (InSubjectIds is not null)
            {
                query = query.Where(a => a.RelatedToSubjects.Any(b => InSubjectIds.Contains(b.Id)));
            }

            if (orderByCreationDateAscending)
            {
                query = query.OrderBy(a => a.CreatedTs);
            }
            else if (orderByCreationDateDescending)
            {
                query = query.OrderByDescending(a => a.CreatedTs);
            }
            else
            {
                query = query.OrderBy(a => a.Id);
            }

            if (!allowUnpublished)
            {
                query = query.Where(a => a.IsPublished);
            }

            if (includesForMapping)
            {
                query = query
                    .Include(e => e.Creator)
                    .Include(e => e.RelatedToSubjects)
                    .Include(e => e.RelatedToCategories)
                    ;
            }

            return query;
        }
    }
}
