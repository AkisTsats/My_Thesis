﻿using AnnouncementAPI.Helpers;
using EFDataAccessLibrary.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnnouncementAPI.Controllers
{
#if DEBUG

    [Route("api/[controller]")]
    [ApiController]
    public class Admin : ControllerBase
    {
        private readonly MyDbContext _context;

        public Admin(MyDbContext? context)
        {
            _context = context;
        }

        [HttpPost("PopulateDatabase")]
        public async Task<ActionResult<bool>> PopulateDatabase()
        {
            var toAdd = new List<object>();

            var admin = new User
            {
                FirstName = "Admin",
                LastName = "Admin",
                FullName = "Admin Admin",
                Email = "admin@admin.admin",
            };
            toAdd.Add(admin);

            var tsixlas = new User
            {
                FirstName = "Κωσταντίνος",
                LastName = "Τσίχλας",
                FullName = "Κωσταντίνος Τσίχλας",
                Email = "kt@ceid.com",
            };
            toAdd.Add(tsixlas);

            var zaroliagis = new User
            {
                FirstName = "Χρήστος",
                LastName = "Ζαρολιάγκης",
                FullName = "Χρήστος Ζαρολιάγκης",
                Email = "xz@ceid.com",
            };
            toAdd.Add(zaroliagis);

            var sioutas = new User
            {
                FirstName = "Σπυρίδον",
                LastName = "Σιούτας",
                FullName = "Σπυρίδον Σιούτας",
                Email = "ss@ceid.com",
            };
            toAdd.Add(sioutas);

            var vergos = new User
            {
                FirstName = "Χαρίδημος",
                LastName = "Βέργος",
                FullName = "Χαρίδημος Βέργος",
                Email = "xv@ceid.com",
            };
            toAdd.Add(sioutas);

            var simpleUser = new User
            {
                FirstName = "Simple",
                LastName = "User",
                FullName = "Simple User",
                Email = "simple@user.user",
            };
            toAdd.Add(simpleUser);

            var category1 = new Category
            {
                Name = "Undergraduate",
            };
            toAdd.Add(category1);

            var category2 = new Category
            {
                Name = "Postgraduate",
            };
            toAdd.Add(category2);

            var subject1 = new Subject
            {
                Name = "Σχεδιασμός Συστημάτων Ειδικού Σκοπού",
            };
            toAdd.Add(subject1);

            var subject2 = new Subject
            {
                Name = "Βασικά Ηλεκτρονικά",
            };
            toAdd.Add(subject2);

            var announcement13 = new Announcement
            {
                Title = "Σχεδιασμός Συστημάτων Ειδικού Σκοπού: Έναρξη διαλέξεων",
                Body = "O κ. Βέργος είναι Διπλωματούχος και Διδάκτορας του Τμήματος Μηχανικών Η/Υ & Πληροφορικής του Πανεπιστημίου Πατρών. Στη διδακτορική του διατριβή πρότεινε τρεις εναλλακτικές τεχνικές αντιμετώπισης ελαττωμάτων στις ενσωματωμένες κρυφές μνήμες, κάποιες εκ των οποίων βρίσκουν εμπορική εφαρμογή στα ολοκληρωμένα μικροεπεξεργαστών έως και σήμερα. Ακολούθως εργάστηκε ως σχεδιαστής υλικού για την εταιρεία Atmel. Ήταν μέλος της σχεδιαστικής μονάδας του πρώτου παγκοσμίως επεξεργαστή που υλοποιούσε πλήρως το MAC επίπεδο ασύρματων δικτύων κατά το πρότυπο 802.11, ενώ εργάστηκε και στην ανάπτυξη άλλων ολοκληρωμένων για δικτυακές εφαρμογές. Τα ερευνητικά του ενδιαφέροντα περιλαμβάνουν τις αρχιτεκτονικές αριθμητικών κυκλωμάτων, τη σχεδίαση και έλεγχο ορθής λειτουργίας ολοκληρωμένων κυκλωμάτων, τη γρήγορη πρωτοτυποποίηση με χρήση ολοκληρωμένων προγραμματιζόμενης λογικής και τη σταδιακή υποβάθμιση της απόδοσης για την αντιμετώπιση σφαλμάτων. Σε αυτά τα αντικείμενα έχει δημοσιεύσει πάνω από 95 εργασίες, με τουλάχιστον 10 εξ αυτών στα απολύτως κορυφαία περιοδικά του χώρου, ενώ είναι συνεφευρέτης μιας ιδέας κατοχυρωμένης για εμπορική χρήση με πατέντα παγκοσμίου εμβέλειας. Είναι επίσης κριτής σε σχεδόν όλα τα φημισμένα περιοδικά και συνέδρια του χώρου και υψηλού κύρους μέλος της IEEE. Κατά το τρέχων ακαδημαϊκό έτος διδάσκει τα μαθήματα \"Βασικές αρχές οργάνωσης και λειτουργίας υπολογιστικών συστημάτων\" και \"Σχεδίαση συστημάτων με χρήση υπολογιστών\" του προπτυχιακού προγράμματος. Επίσης διδάσκει το μάθημα \"Υπολογιστικά συστήματα υψηλής αξιοπιστίας\" τόσο για προπτυχιακούς όσο και μεταπτυχιακούς φοιτητές. Στο παρελθόν έχει διδάξει μαθήματα Ψηφιακής Σχεδίασης, Ηλεκτρονικών και Αρχιτεκτονικής, ενώ ήταν ο επιβλέπων της ανάπτυξης του ΑΤ91, ενός συστήματος βασισμένου σε αρχιτεκτονική ARM που χρησιμοποιείται έως και σήμερα στα εργαστήρια συμβολικής γλώσσας και μικροϋπολογιστών. Είναι Δντής του εργαστηρίου Μικροηλεκτρονικής. Έχει διατελέσει επίσης Δντής του τομέα Υλικού και Αρχιτεκτονικής των Υπολογιστών και του Υπολογιστικού Κέντρου του Τμήματος.",
                CreationDate = DateTime.Parse("2024-02-19 02:50:12.119000"),
                RelatedToCategories = new List<Category> { category1 },
                RelatedToSubjects = new List<Subject> { subject1 },
                Abstract = "Οι διαλέξεις του κατ’ επιλογήν μαθήματος “Σχεδιασμός Συστημάτων Ειδικού Σκοπού”, θα ξεκινήσουν την Πέμπτη 3/10.",
                Creator = vergos,
            };

            var announcement15 = new Announcement
            {
                Title = "Παρουσίαση Διπλωματικής Εργασίας",
                Body = "Την Παρασκευή 27/9/2024 στις 5:30, θα πραγματοποιηθεί η παρουσίαση της προπτυχιακής διπλωματικής εργασίας του φοιτητή κ. Γουρνιεζάκη Γεώργιου με τίτλο: «Ανάπτυξη πλατφόρμας χαρτογράφησης αιολικών πάρκων με μηχανισμό διαβούλευσης για τον εντοπισμό απειλών για τη βιοποικιλότητα» Η παρουσίαση θα γίνει με εξ’ αποστάσεως σύνδεση στο Zoom link: https://upatras-gr.zoom.us/j/91719033873?pwd=1G3HWtuzG6ylIA6HQYXTkPnngkYfd4.1 Meeting ID: 917 1903 3873 Passcode: 972395 Τριμελής εξεταστική επιτροπή: Σταύρος Καμπούρης (Επιβλέπων), Κώστας Χατζόπουλος, Χρήστος Σπανός.",
                CreationDate = DateTime.Parse("2023-08-02 00:05:11.143000"),
                RelatedToCategories = new List<Category> { category1 },
                RelatedToSubjects = new List<Subject> { subject1 },
                Abstract = "Την Παρασκευή 27/9/2024 στις 5:30, θα πραγματοποιηθεί η παρουσίαση της προπτυχιακής διπλωματικής εργασίας του φοιτητή κ. Γουρνιεζάκη Γεώργιου με τίτλο: «Ανάπτυξη πλατφόρμας χαρτογράφησης αιολικών πάρκων με μηχανισμό διαβούλευσης για τον εντοπισμό απειλών για τη βιοποικιλότητα».",
                Creator = admin,
            };

            var announcement17 = new Announcement
            {
                Title = "Παρουσίαση Διπλωματικής Εργασίας, Γουρνιεζάκης Γιώργος",
                Body = "Την Παρασκευή 27/9/2024 στις 5:30, θα πραγματοποιηθεί η παρουσίαση της προπτυχιακής διπλωματικής εργασίας του φοιτητή κ. Γουρνιεζάκη Γεώργιου με τίτλο: «Ανάπτυξη πλατφόρμας χαρτογράφησης αιολικών πάρκων με μηχανισμό διαβούλευσης για τον εντοπισμό απειλών για τη βιοποικιλότητα».",
                CreationDate = DateTime.Parse("2023-08-02 00:14:03.669000"),
                RelatedToCategories = new List<Category> { category1 },
                RelatedToSubjects = new List<Subject> { subject1 },
                Abstract = "Την Παρασκευή 27/9/2024 στις 5:30, θα πραγματοποιηθεί η παρουσίαση της προπτυχιακής διπλωματικής εργασίας του φοιτητή κ. Γουρνιεζάκη Γεώργιου με τίτλο: «Ανάπτυξη πλατφόρμας χαρτογράφησης αιολικών πάρκων με μηχανισμό διαβούλευσης για τον εντοπισμό απειλών για τη βιοποικιλότητα».",
                Creator = admin,
            };

            var announcement18 = new Announcement
            {
                Title = "Διπλωματικές 24-25 – Τσίχλας Κωνσταντίνος",
                Body = "Αγαπητές/οί φοιτήτριες/τητές, Σε λίγες ημέρες θα ανακοινωθεί στον ιστό-τοπο του Τμήματος: Υποχρεωτικά Μαθήματα το Ωρολόγιο Πρόγραμμα και θα αρχίσουν οι εγγραφές στο μάθημα “Βασικά Ηλεκτρονικά (Εργαστήριο)” (Β’ Έτος). Προκειμένου να μπορέσετε να επιλέξετε Τμήμα Εξάσκησης, θα πρέπει, πρώτα, να εγγραφείτε στον ιστό-τοπο του μαθήματος: ΒΑΣΙΚΑ ΗΛΕΚΤΡΟΝΙΚΑ-ΕΡΓΑΣΤΗΡΙΟ (23165NY) (CEID1119). Στον ιστό-τοπο αυτόν θα βρείτε τις Σημειώσεις, τις οδηγίες σχετικά με τη διενέργεια των πειραμάτων. Επισημαίνεται ότι το πρώτο πείραμα θα διεξαχθεί την Δευτέρα 12/9/2024.",
                CreationDate = DateTime.Parse("2023-08-05 07:48:22.378000"),
                RelatedToCategories = new List<Category> { category1 },
                RelatedToSubjects = new List<Subject> { subject1 },
                Abstract = "Aγαπητές/οί φοιτήτριες/τητές, Σε λίγες ημέρες θα ανακοινωθεί στον ιστό-τοπο του Τμήματος: Υποχρεωτικά Μαθήματα το Ωρολόγιο Πρόγραμμα και θα αρχίσουν οι εγγραφές στο μάθημα “Βασικά Ηλεκτρονικά (Εργαστήριο)” (Β’ Έτος).",
                Creator = tsixlas,
            };

            var announcement19 = new Announcement
            {
                Title = "Παρουσίαση Διπλωματικής Εργασίας, Ντάτσος Στέλιος",
                Body = "Την Παρασκευή 30/8/2024 στις 5:30, θα πραγματοποιηθεί η παρουσίαση της προπτυχιακής διπλωματικής εργασίας του φοιτητή κ. Ντάτσου Στέλιου με τίτλο: «Ανάλυση και σχεδίαση συστημάτων επικοινωνίας μέσω του Διαδικτύου».",
                CreationDate = DateTime.Parse("2023-08-02 00:08:03.579000"),
                RelatedToCategories = new List<Category> { category1 },
                RelatedToSubjects = new List<Subject> { subject1 },
                Abstract = "Την Παρασκευή 30/8/2024 στις 5:30, θα πραγματοποιηθεί η παρουσίαση της προπτυχιακής διπλωματικής εργασίας του φοιτητή κ. Ντάτσου Στέλιου με τίτλο: «Ανάλυση και σχεδίαση συστημάτων επικοινωνίας μέσω του Διαδικτύου».",
                Creator = admin,
            };

            var announcement20 = new Announcement
            {
                Title = "Προκήρυξη εκλογών, 2024",
                Body = "Αγαπητοί/ές φοιτητές/φοιτήτριες, σας ενημερώνουμε ότι οι εκλογές για την ανάδειξη εκπροσώπων των φοιτητών στο τμήμα θα διεξαχθούν την Τετάρτη 22/11/2024. Όσοι επιθυμούν να υποβάλουν υποψηφιότητα, παρακαλούνται να το δηλώσουν μέχρι την Δευτέρα 6/11/2024.",
                CreationDate = DateTime.Parse("2023-08-02 00:14:03.669000"),
                RelatedToCategories = new List<Category> { category1 },
                RelatedToSubjects = new List<Subject> { subject1 },
                Abstract = "Οι εκλογές για την ανάδειξη εκπροσώπων των φοιτητών στο τμήμα θα διεξαχθούν την Τετάρτη 22/11/2024.",
                Creator = admin,
            };

            var announcement21 = new Announcement
            {
                Title = "Διαδικασία Υποβολής Διπλωματικών Εργασιών",
                Body = "Αγαπητοί/ές φοιτητές/φοιτήτριες, σας ενημερώνουμε ότι η διαδικασία υποβολής διπλωματικών εργασιών θα ξεκινήσει από την 1η Ιανουαρίου 2025. Οι φοιτητές καλούνται να υποβάλουν τα έργα τους σύμφωνα με τις οδηγίες που θα ανακοινωθούν σύντομα στον ιστότοπο του τμήματος.",
                CreationDate = DateTime.Parse("2023-08-02 00:05:11.143000"),
                RelatedToCategories = new List<Category> { category1 },
                RelatedToSubjects = new List<Subject> { subject1 },
                Abstract = "Η διαδικασία υποβολής διπλωματικών εργασιών θα ξεκινήσει από την 1η Ιανουαρίου 2025.",
                Creator = admin,
            };
            var announcement22 = new Announcement
            {
                Title = "Ενημέρωση για τις εξετάσεις του εξαμήνου",
                Body = "Αγαπητές/οί φοιτήτριες/τητές, σας ενημερώνουμε ότι οι εξετάσεις του εξαμήνου θα διεξαχθούν από τις 15 έως τις 29 Ιουνίου 2025. Η ακριβής ημερομηνία και ώρα των εξετάσεων κάθε μαθήματος θα ανακοινωθεί στον ιστότοπο του τμήματος μία εβδομάδα πριν από την έναρξή τους. Είναι υποχρεωτική η προσκόμιση της φοιτητικής ταυτότητας κατά τη διάρκεια των εξετάσεων.",
                CreationDate = DateTime.Parse("2024-01-05 10:00:00.000000"),
                RelatedToCategories = new List<Category> { category1 },
                RelatedToSubjects = new List<Subject> { subject1 },
                Abstract = "Οι εξετάσεις του εξαμήνου θα διεξαχθούν από τις 15 έως τις 29 Ιουνίου 2025.",
                Creator = admin,
            };

            var announcement23 = new Announcement
            {
                Title = "Καλοκαιρινά μαθήματα και εργαστήρια",
                Body = "Αγαπητοί φοιτητές/φοιτήτριες, σας ενημερώνουμε ότι τα καλοκαιρινά μαθήματα και εργαστήρια θα ξεκινήσουν την 1η Ιουλίου 2025 και θα διαρκέσουν έως τις 30 Αυγούστου 2025. Οι εγγραφές θα ανοίξουν στις 15 Μαΐου 2025, και παρακαλούμε να ελέγχετε τον ιστότοπο του τμήματος για περισσότερες λεπτομέρειες.",
                CreationDate = DateTime.Parse("2024-01-10 14:30:00.000000"),
                RelatedToCategories = new List<Category> { category1 },
                RelatedToSubjects = new List<Subject> { subject1 },
                Abstract = "Τα καλοκαιρινά μαθήματα και εργαστήρια θα ξεκινήσουν την 1η Ιουλίου 2025.",
                Creator = admin,
            };

            var announcement24 = new Announcement
            {
                Title = "Ημερίδα για την Έρευνα στην Πληροφορική",
                Body = "Αγαπητοί φοιτητές/φοιτήτριες, σας προσκαλούμε να συμμετάσχετε στην ημερίδα για την Έρευνα στην Πληροφορική, η οποία θα διεξαχθεί στις 5 Απριλίου 2025 στην αίθουσα συνεδρίων του τμήματος. Η ημερίδα θα περιλαμβάνει παρουσιάσεις ερευνητικών έργων, καθώς και εργαστήρια σε νέες τεχνολογίες. Η συμμετοχή είναι ελεύθερη και οι δηλώσεις συμμετοχής γίνονται μέσω του ιστότοπου του τμήματος.",
                CreationDate = DateTime.Parse("2024-02-01 09:00:00.000000"),
                RelatedToCategories = new List<Category> { category1 },
                RelatedToSubjects = new List<Subject> { subject1 },
                Abstract = "Η ημερίδα για την Έρευνα στην Πληροφορική θα διεξαχθεί στις 5 Απριλίου 2025.",
                Creator = admin,
            };

            var announcement25 = new Announcement
            {
                Title = "Δηλώσεις μαθημάτων εξαμήνου",
                Body = "Αγαπητοί/ές φοιτητές/φοιτήτριες, οι δηλώσεις μαθημάτων για το επόμενο εξάμηνο θα γίνουν από 1 έως 15 Σεπτεμβρίου 2025. Είναι υποχρεωτικό να ολοκληρώσετε τη διαδικασία δήλωσης εντός της προθεσμίας, καθώς μετά την παρέλευση της προθεσμίας δεν θα μπορείτε να δηλώσετε μαθήματα. Για οποιαδήποτε απορία μπορείτε να απευθυνθείτε στην γραμματεία του τμήματος.",
                CreationDate = DateTime.Parse("2024-02-05 11:00:00.000000"),
                RelatedToCategories = new List<Category> { category1 },
                RelatedToSubjects = new List<Subject> { subject1 },
                Abstract = "Οι δηλώσεις μαθημάτων για το επόμενο εξάμηνο θα γίνουν από 1 έως 15 Σεπτεμβρίου 2025.",
                Creator = admin,
            };

            var announcement26 = new Announcement
            {
                Title = "Προκήρυξη υποτροφιών",
                Body = "Αγαπητοί φοιτητές/φοιτήτριες, ανακοινώνεται ότι οι αιτήσεις για τις υποτροφίες του τμήματος θα είναι ανοιχτές από 1 Μαΐου έως 30 Ιουνίου 2025. Οι υποτροφίες αφορούν προπτυχιακούς και μεταπτυχιακούς φοιτητές και θα απονεμηθούν με βάση ακαδημαϊκά κριτήρια. Περισσότερες λεπτομέρειες θα βρείτε στον ιστότοπο του τμήματος.",
                CreationDate = DateTime.Parse("2024-03-01 15:00:00.000000"),
                RelatedToCategories = new List<Category> { category1 },
                RelatedToSubjects = new List<Subject> { subject1 },
                Abstract = "Οι αιτήσεις για τις υποτροφίες του τμήματος θα είναι ανοιχτές από 1 Μαΐου έως 30 Ιουνίου 2025.",
                Creator = admin,
            };

            var announcement27 = new Announcement
            {
                Title = "Προγραμματισμός εργαστηρίων για το Χειμερινό εξάμηνο",
                Body = "Αγαπητοί φοιτητές/φοιτήτριες, σας ενημερώνουμε ότι ο προγραμματισμός των εργαστηρίων για το Χειμερινό εξάμηνο του 2025-2026 θα ολοκληρωθεί έως τις 15 Αυγούστου 2025. Για τυχόν προτάσεις ή αλλαγές μπορείτε να επικοινωνήσετε με την γραμματεία του τμήματος.",
                CreationDate = DateTime.Parse("2024-03-05 12:00:00.000000"),
                RelatedToCategories = new List<Category> { category1 },
                RelatedToSubjects = new List<Subject> { subject1 },
                Abstract = "Ο προγραμματισμός των εργαστηρίων για το Χειμερινό εξάμηνο του 2025-2026 θα ολοκληρωθεί έως τις 15 Αυγούστου 2025.",
                Creator = admin,
            };

            toAdd.Add(announcement13);
            toAdd.Add(announcement15);
            toAdd.Add(announcement17);
            toAdd.Add(announcement18);
            toAdd.Add(announcement19);
            toAdd.Add(announcement20);
            toAdd.Add(announcement21);
            toAdd.Add(announcement22);
            toAdd.Add(announcement23);
            toAdd.Add(announcement24);
            toAdd.Add(announcement25);
            toAdd.Add(announcement26);
            toAdd.Add(announcement27);
                



            foreach (var item in toAdd)
            {
                _context.Add(item);
            }

            await _context.SaveChangesAsync();

            return true;
        }
    }

#endif
}
