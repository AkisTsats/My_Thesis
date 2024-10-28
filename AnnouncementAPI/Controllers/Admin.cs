//using AnnouncementAPI.Helpers;
//using EFDataAccessLibrary.Data;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace AnnouncementAPI.Controllers
//{
//#if DEBUG

//    [Route("api/[controller]")]
//    [ApiController]
//    public class Admin : ControllerBase
//    {
//        private readonly MyDbContext _context;

//        public Admin(MyDbContext? context)
//        {
//            _context = context;
//        }

//        [HttpPost("PopulateDatabase")]
//        public async Task<ActionResult<bool>> PopulateDatabase()
//        {
//            var toAdd = new List<object>();

//            var admin = new User
//            {
//                FirstName = "Admin",
//                LastName = "Admin",
//                FullName = "Admin Admin",
//                Email = "admin@admin.admin",
//            };
//            toAdd.Add(admin);

//            var tsixlas = new User
//            {
//                FirstName = "Κωσταντίνος",
//                LastName = "Τσίχλας",
//                FullName = "Κωσταντίνος Τσίχλας",
//                Email = "kt@ceid.com",
//            };
//            toAdd.Add(tsixlas);

//            var zaroliagis = new User
//            {
//                FirstName = "Χρήστος",
//                LastName = "Ζαρολιάγκης",
//                FullName = "Χρήστος Ζαρολιάγκης",
//                Email = "xz@ceid.com",
//            };
//            toAdd.Add(zaroliagis);

//            var sioutas = new User
//            {
//                FirstName = "Σπυρίδον",
//                LastName = "Σιούτας",
//                FullName = "Σπυρίδον Σιούτας",
//                Email = "ss@ceid.com",
//            };
//            toAdd.Add(sioutas);

//            var vergos = new User
//            {
//                FirstName = "Χαρίδημος",
//                LastName = "Βέργος",
//                FullName = "Χαρίδημος Βέργος",
//                Email = "xv@ceid.com",
//            };
//            toAdd.Add(sioutas);

//            var simpleUser = new User
//            {
//                FirstName = "Simple",
//                LastName = "User",
//                FullName = "Simple User",
//                Email = "simple@user.user",
//            };
//            toAdd.Add(simpleUser);

//            var category1 = new Category
//            {
//                Name = "Undergraduate",
//            };
//            toAdd.Add(category1);

//            var category2 = new Category
//            {
//                Name = "Postgraduate",
//            };
//            toAdd.Add(category2);

//            var subject1 = new Subject
//            {
//                Name = "Σχεδιασμός Συστημάτων Ειδικού Σκοπού",
//            };
//            toAdd.Add(subject1);

//            var subject2 = new Subject
//            {
//                Name = "Βασικά Ηλεκτρονικά",
//            };
//            toAdd.Add(subject2);

//            var announcement13 = new Announcement
//            {
//                Title = "Σχεδιασμός Συστημάτων Ειδικού Σκοπού: Έναρξη διαλέξεων",
//                Body = "O κ. Βέργος είναι Διπλωματούχος και Διδάκτορας του Τμήματος Μηχανικών Η/Υ & Πληροφορικής του Πανεπιστημίου Πατρών. Στη διδακτορική του διατριβή πρότεινε τρεις εναλλακτικές τεχνικές αντιμετώπισης ελαττωμάτων στις ενσωματωμένες κρυφές μνήμες, κάποιες εκ των οποίων βρίσκουν εμπορική εφαρμογή στα ολοκληρωμένα μικροεπεξεργαστών έως και σήμερα. Ακολούθως εργάστηκε ως σχεδιαστής υλικού για την εταιρεία Atmel. Ήταν μέλος της σχεδιαστικής μονάδας του πρώτου παγκοσμίως επεξεργαστή που υλοποιούσε πλήρως το MAC επίπεδο ασύρματων δικτύων κατά το πρότυπο 802.11, ενώ εργάστηκε και στην ανάπτυξη άλλων ολοκληρωμένων για δικτυακές εφαρμογές. Τα ερευνητικά του ενδιαφέροντα περιλαμβάνουν τις αρχιτεκτονικές αριθμητικών κυκλωμάτων, τη σχεδίαση και έλεγχο ορθής λειτουργίας ολοκληρωμένων κυκλωμάτων, τη γρήγορη πρωτοτυποποίηση με χρήση ολοκληρωμένων προγραμματιζόμενης λογικής και τη σταδιακή υποβάθμιση της απόδοσης για την αντιμετώπιση σφαλμάτων. Σε αυτά τα αντικείμενα έχει δημοσιεύσει πάνω από 95 εργασίες, με τουλάχιστον 10 εξ αυτών στα απολύτως κορυφαία περιοδικά του χώρου, ενώ είναι συνεφευρέτης μιας ιδέας κατοχυρωμένης για εμπορική χρήση με πατέντα παγκοσμίου εμβέλειας. Είναι επίσης κριτής σε σχεδόν όλα τα φημισμένα περιοδικά και συνέδρια του χώρου και υψηλού κύρους μέλος της IEEE. Κατά το τρέχων ακαδημαϊκό έτος διδάσκει τα μαθήματα \"Βασικές αρχές οργάνωσης και λειτουργίας υπολογιστικών συστημάτων\" και \"Σχεδίαση συστημάτων με χρήση υπολογιστών\" του προπτυχιακού προγράμματος. Επίσης διδάσκει το μάθημα \"Υπολογιστικά συστήματα υψηλής αξιοπιστίας\" τόσο για προπτυχιακούς όσο και μεταπτυχιακούς φοιτητές. Στο παρελθόν έχει διδάξει μαθήματα Ψηφιακής Σχεδίασης, Ηλεκτρονικών και Αρχιτεκτονικής, ενώ ήταν ο επιβλέπων της ανάπτυξης του ΑΤ91, ενός συστήματος βασισμένου σε αρχιτεκτονική ARM που χρησιμοποιείται έως και σήμερα στα εργαστήρια συμβολικής γλώσσας και μικροϋπολογιστών. Είναι Δντής του εργαστηρίου Μικροηλεκτρονικής. Έχει διατελέσει επίσης Δντής του τομέα Υλικού και Αρχιτεκτονικής των Υπολογιστών και του Υπολογιστικού Κέντρου του Τμήματος.",
//                CreationDate = DateTime.Parse("2024-02-19 02:50:12.119000"),
//                RelatedToCategories = new List<Category> { category1 },
//                RelatedToSubjects = new List<Subject> { subject1 },
//                Abstract = "Οι διαλέξεις του κατ’ επιλογήν μαθήματος “Σχεδιασμός Συστημάτων Ειδικού Σκοπού”, θα ξεκινήσουν την Πέμπτη 3/10.",
//                Creator = vergos,
//            };

//            var announcement1 = new Announcement
//            {
//                Id = 1,
//                Title = "Σχεδιασμός Συστημάτων Ειδικού Σκοπού: Έναρξη διαλέξεων",
//                Abstract = "Οι διαλέξεις του κατ’ επιλογήν μαθήματος “Σχεδιασμός Συστημάτων Ειδικού Σκοπού”, θα ξεκινήσουν την Πέμπτη 3/10.",
//                Body = "O κ. Βέργος είναι Διπλωματούχος και Διδάκτορας του Τμήματος Μηχανικών Η/Υ & Πληροφορικής του Πανεπιστημίου Πατρών...",
//                CreationDate = DateTime.Parse("2024-02-19 02:50:12.119000"),
//                IsPublished = false,
//                Creator = vergos,
//                RelatedToCategories = new List<Category> { category1 },
//                RelatedToSubjects = new List<Subject> { subject1 }
//            };

//            var announcement2 = new Announcement
//            {
//                Id = 2,
//                Title = "Παρουσίαση Διπλωματικής Εργασίας",
//                Abstract = "Την Παρασκευή 27/9/2024 στις 5:30,  θα πραγματοποιηθεί η παρουσίαση της προπτυχιακής διπλωματικής εργασίας του φοιτητή...",
//                Body = "Την Παρασκευή 27/9/2024 στις 5:30,  θα πραγματοποιηθεί η παρουσίαση της προπτυχιακής διπλωματικής εργασίας του φοιτητή...",
//                CreationDate = DateTime.Parse("2023-08-02 00:05:11.143000"),
//                IsPublished = false,
//                Creator = "Admin"
//            };

//            var announcement3 = new Announcement
//            {
//                Id = 3,
//                Title = "Παρουσίαση Διπλωματικής Εργασίας, Γουρνιεζάκης Γιώργος",
//                Abstract = "Την Παρασκευή 27/9/2024 στις 5:30,  θα πραγματοποιηθεί η παρουσίαση της προπτυχιακής διπλωματικής εργασίας...",
//                Body = "Την Παρασκευή 27/9/2024 στις 5:30,  θα πραγματοποιηθεί η παρουσίαση της προπτυχιακής διπλωματικής εργασίας...",
//                CreationDate = DateTime.Parse("2023-08-02 00:14:03.669000"),
//                IsPublished = false,
//                Creator = "Admin"
//            };

//            var announcement4 = new Announcement
//            {
//                Id = 4,
//                Title = "Διπλωματικές 24-25 – Τσίχλας Κωνσταντίνος",
//                Abstract = "Aγαπητές/οί φοιτήτριες/τητές, Σε λίγες ημέρες θα ανακοινωθεί στον ιστό-τοπο του Τμήματος...",
//                Body = "Αγαπητές-οί φοιτήτριες-ές, Σε λίγες ημέρες θα ανακοινωθεί στον ιστό-τοπο του Τμήματος...",
//                CreationDate = DateTime.Parse("2023-08-05 07:48:22.378000"),
//                IsPublished = false,
//                Creator = "string"
//            };

//            toAdd.Add(announcement13);
//            toAdd.Add(announcement15);
//            toAdd.Add(announcement17);
//            toAdd.Add(announcement18);
//            toAdd.Add(announcement19);
//            toAdd.Add(announcement20);
//            toAdd.Add(announcement21);
//            toAdd.Add(announcement22);
//            toAdd.Add(announcement23);
//            toAdd.Add(announcement24);
//            toAdd.Add(announcement25);
//            toAdd.Add(announcement26);
//            toAdd.Add(announcement27);
                
//            foreach (var item in toAdd)
//            {
//                _context.Add(item);
//            }

//            await _context.SaveChangesAsync();

//            return true;
//        }
//    }

//#endif
//}
