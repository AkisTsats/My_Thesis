using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary
{
    public enum ResourceType
    {
        Undefined,
        Image,
        Document,
    }
    public enum UserType
    {
        Undergraduate,
        Postgraduate,
        Professor,
        Secretary,
        Other
    }

    public enum UserRole
    {
        Student,
        Staff,
        Admin
    }
}
