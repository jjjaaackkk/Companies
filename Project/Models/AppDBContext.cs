using Microsoft.EntityFrameworkCore;

namespace Companies.Models
{
    public class AppDBContext : DbContext
    {
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Companies");
        }
        */

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            // Make sure db loaded
            Database.EnsureCreated();
        }

        public DbSet<Title> Titles { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Note> Notes { get; set; }

        // Sample Data for db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Title>().HasData(
                    new Title { Id = 1, Name = "Sir" },
                    new Title { Id = 2, Name = "Ma'am" },
                    new Title { Id = 3, Name = "Madam" },
                    new Title { Id = 4, Name = "Mr." },
                    new Title { Id = 5, Name = "Mrs." },
                    new Title { Id = 6, Name = "Miss" },
                    new Title { Id = 7, Name = "Dr." },
                    new Title { Id = 8, Name = "Professor" },
                    new Title { Id = 9, Name = ""}
            );

            modelBuilder.Entity<Position>().HasData(
                    new Position { Id = 1, Name = "CEO" },
                    new Position { Id = 2, Name = "COO" },
                    new Position { Id = 3, Name = "CFO" },
                    new Position { Id = 4, Name = "CMO" },
                    new Position { Id = 5, Name = "CTO" },
                    new Position { Id = 6, Name = "President" },
                    new Position { Id = 7, Name = "Vice president" },
                    new Position { Id = 8, Name = "Executive assistant" },
                    new Position { Id = 9, Name = "Marketing manager" },
                    new Position { Id = 10, Name = "Product manager" },
                    new Position { Id = 11, Name = "Project manager" },
                    new Position { Id = 12, Name = "Finance manager" },
                    new Position { Id = 13, Name = "Vice president" },
                    new Position { Id = 14, Name = "HR" },
                    new Position { Id = 15, Name = "Marketing specialist" },
                    new Position { Id = 16, Name = "Business analyst" },
                    new Position { Id = 17, Name = "Accountant" },
                    new Position { Id = 18, Name = "Sales representative" },
                    new Position { Id = 19, Name = "Administrative assistant" },
                    new Position { Id = 20, Name = "Team leader" },
                    new Position { Id = 21, Name = "Web developer" },
                    new Position { Id = 22, Name = "Computer systems engineer" },
                    new Position { Id = 23, Name = "Systems analyst" },
                    new Position { Id = 25, Name = "Programmer analyst" },
                    new Position { Id = 26, Name = "Database administrator" },
                    new Position { Id = 27, Name = "Front-end developer" },
                    new Position { Id = 28, Name = "Software developer" },
                    new Position { Id = 29, Name = "Data scientist" }
            );

            modelBuilder.Entity<Company>().HasData(
                    new Company { 
                        Id = 1,
                        Address = "702 SW 8th Street",
                        City = "Bentonville",
                        State = "AR",
                        Name = "Super Mart of the West",
                        Tel = "8005552797"
                    },
                    new Company { 
                        Id = 2, 
                        Address = "1606 Oakridge Farm Lane", 
                        City = "Atlanta", 
                        State = "GA", 
                        Name = "Electronic Depot",
                        Tel = "8005953232"
                    },
                    new Company { 
                        Id = 3,
                        Address = "",
                        City = "Minneapolis",
                        State = "MN",
                        Name = "K&S Music",
                        Tel = "6123046073"
                    },
                    new Company { 
                        Id = 4,
                        Address = "1590 Confederate Drive",
                        City = "Issaquah",
                        State = "WA",
                        Name = "Tom's Club",
                        Tel = "8009552292"
                    },
                    new Company { 
                        Id = 5,
                        Address = "2115 Brannon Street",
                        City = "Hoffman Estates",
                        State = "IL",
                        Name = "E-Mart",
                        Tel = "8472862500"
                    },
                    new Company {
                        Id = 6,
                        Address = "3371 Columbia Boulevard",
                        City = "Deerfield",
                        State = "IL",
                        Name = "Walters",
                        Tel = "8479402500"
                    },
                    new Company { 
                        Id = 7,
                        Address = "4090 Goldcliff Circle",
                        City = "Fort Worth",
                        State = "TX",
                        Name = "StereoShack",
                        Tel = "8178200741"
                    },
                    new Company { 
                        Id = 8,
                        Address = "179 Pick Street",
                        City = "Oak Brook",
                        State = "IL",
                        Name = "Circuit Town",
                        Tel = "8009552929"
                    },
                    new Company { 
                        Id = 9,
                        Address = "3230 Orchard Street",
                        City = "Richfield",
                        State = "MN",
                        Name = "Perimer Buy",
                        Tel = "6122911000"
                    },
                    new Company { 
                        Id = 10,
                        Address = "3242 Rainbow Drive",
                        City = "Naperville",
                        State = "IL",
                        Name = "ElectrixMax",
                        Tel = "6304387800"
                    },
                    new Company { 
                        Id = 11,
                        Address = "343 Pointe Lane",
                        City = "Dallas",
                        State = "TX",
                        Name = "Video Emporium",
                        Tel = "2148543000"
                    },
                    new Company { 
                        Id = 12,
                        Address = "711 Pinnickinick Street",
                        City = "Mooresville",
                        State = "NC",
                        Name = "Screen Shop",
                        Tel = "8004456937"
                    }
            );

            modelBuilder.Entity<Employee>().HasData(

                    new Employee
                    {
                        Id = 1,
                        CompanyId = 1,
                        First = "John",
                        Last = "Hear",
                        TitleId = 4,
                        PositionId = 18,
                        DOB = new DateTime(1966, 11, 10)
                    },
                    new Employee
                    {
                        Id = 2,
                        CompanyId = 1,
                        First = "Olivia",
                        Last = "Peyton",
                        TitleId = 5,
                        PositionId = 1,
                        DOB = new DateTime(1984, 3, 16)
                    },
                    new Employee
                    {
                        Id = 3,
                        CompanyId = 1,
                        First = "Robert",
                        Last = "Reagan",
                        TitleId = 4,
                        PositionId = 1,
                        DOB = new DateTime(1994, 3, 16)
                    },
                    new Employee
                    {
                        Id = 4,
                        CompanyId = 1,
                        First = "Cynthia",
                        Last = "Stanwick",
                        TitleId = 3,
                        PositionId = 1,
                        DOB = new DateTime(2004, 3, 16)
                    },
                    new Employee
                    {
                        Id = 5,
                        CompanyId = 1,
                        First = "Harv",
                        Last = "Mudd",
                        TitleId = 4,
                        PositionId = 18,
                        DOB = new DateTime(1996, 1, 22)
                    },
                    new Employee
                    {
                        Id = 6,
                        CompanyId = 1,
                        First = "Jim",
                        Last = "Packard",
                        TitleId = 4,
                        PositionId = 18,
                        DOB = new DateTime(1999, 1, 12)
                    },
                    new Employee
                    {
                        Id = 7,
                        CompanyId = 1,
                        First = "Todd",
                        Last = "Hoffman",
                        TitleId = 9,
                        PositionId = 18,
                        DOB = new DateTime(1999, 1, 12)
                    },
                    new Employee
                    {
                        Id = 8,
                        CompanyId = 1,
                        First = "Clark",
                        Last = "Morgan",
                        TitleId = 4,
                        PositionId = 18,
                        DOB = new DateTime(2003, 11, 28)
                    },
                    new Employee
                    {
                        Id = 9,
                        CompanyId = 2,
                        First = "Terry",
                        Last = "Whitehead",
                        TitleId = 7,
                        PositionId = 1,
                        DOB = new DateTime(1994, 3, 16)
                    },
                    new Employee
                    {
                        Id = 10,
                        CompanyId = 2,
                        First = "Cecil",
                        Last = "Fletcher",
                        TitleId = 4,
                        PositionId = 18,
                        DOB = new DateTime(1984, 3, 16)
                    },
                    new Employee
                    {
                        Id = 11,
                        CompanyId = 2,
                        First = "Lorelei",
                        Last = "Glover",
                        TitleId = 4,
                        PositionId = 17,
                        DOB = new DateTime(1974, 3, 16)
                    },

                    new Employee
                    {
                        Id = 12,
                        CompanyId = 3,
                        First = "Curtis",
                        Last = "Garza",
                        TitleId = 4,
                        PositionId = 18,
                        DOB = new DateTime(1980, 3, 16)
                    },
                    new Employee
                    {
                        Id = 13,
                        CompanyId = 3,
                        First = "Pansy",
                        Last = "Jenning",
                        TitleId = 1,
                        PositionId = 10,
                        DOB = new DateTime(1989, 3, 16)
                    },

                    new Employee
                    {
                        Id = 14,
                        CompanyId = 4,
                        First = "Curtis",
                        Last = "Garza",
                        TitleId = 6,
                        PositionId = 1,
                        DOB = new DateTime(1980, 3, 16)
                    },
                    new Employee
                    {
                        Id = 15,
                        CompanyId = 4,
                        First = "Pansy",
                        Last = "Jenning",
                        TitleId = 4,
                        PositionId = 10,
                        DOB = new DateTime(1989, 3, 16)
                    },
                    new Employee
                    {
                        Id = 16,
                        CompanyId = 4,
                        First = "Sienna",
                        Last = "Little",
                        TitleId = 15,
                        PositionId = 18,
                        DOB = new DateTime(2005, 3, 16)
                    },
                    new Employee
                    {
                        Id = 17,
                        CompanyId = 4,
                        First = "Terence",
                        Last = "Middleton",
                        TitleId = 5,
                        PositionId = 23,
                        DOB = new DateTime(1989, 3, 16)
                    },
                    new Employee
                    {
                        Id = 18,
                        CompanyId = 5,
                        First = "Piers",
                        Last = "Hines",
                        TitleId = 4,
                        PositionId = 7,
                        DOB = new DateTime(1950, 3, 16)
                    },
                    new Employee
                    {
                        Id = 19,
                        CompanyId = 5,
                        First = "Regina",
                        Last = "Manwaring",
                        TitleId = 5,
                        PositionId = 10,
                        DOB = new DateTime(2001, 3, 16)
                    },
                    new Employee
                    {
                        Id = 20,
                        CompanyId = 5,
                        First = "Melissa",
                        Last = "Cooke",
                        TitleId = 5,
                        PositionId = 10,
                        DOB = new DateTime(2003, 3, 16)
                    },

                    new Employee
                    {
                        Id = 21,
                        CompanyId = 6,
                        First = "Alexander",
                        Last = "Vasquez",
                        TitleId = 4,
                        PositionId = 8,
                        DOB = new DateTime(1999, 3, 16)
                    },
                    new Employee
                    {
                        Id = 22,
                        CompanyId = 6,
                        First = "Hunter",
                        Last = "Moore",
                        TitleId = 4,
                        PositionId = 14,
                        DOB = new DateTime(1988, 3, 16)
                    },

                    new Employee
                    {
                        Id = 23,
                        CompanyId = 7,
                        First = "Hadden",
                        Last = "Ryan",
                        TitleId = 4,
                        PositionId = 20,
                        DOB = new DateTime(1995, 3, 16)
                    },
                    new Employee
                    {
                        Id = 24,
                        CompanyId = 7,
                        First = "Ellery",
                        Last = "Garza",
                        TitleId = 4,
                        PositionId = 28,
                        DOB = new DateTime(1999, 3, 16)
                    },

                    new Employee
                    {
                        Id = 25,
                        CompanyId = 8,
                        First = "Carly",
                        Last = "Munoz",
                        TitleId = 7,
                        PositionId = 1,
                        DOB = new DateTime(1957, 3, 16)
                    },
                    new Employee
                    {
                        Id = 26,
                        CompanyId = 8,
                        First = "Rowena",
                        Last = "Strickland",
                        TitleId = 5,
                        PositionId = 7,
                        DOB = new DateTime(1959, 3, 16)
                    },
                    new Employee
                    {
                        Id = 27,
                        CompanyId = 8,
                        First = "Willa",
                        Last = "Shaw",
                        TitleId = 5,
                        PositionId = 8,
                        DOB = new DateTime(1961, 3, 16)
                    },

                    new Employee
                    {
                        Id = 28,
                        CompanyId = 9,
                        First = "Opal",
                        Last = "Hawkins",
                        TitleId = 4,
                        PositionId = 9,
                        DOB = new DateTime(1957, 3, 16)
                    },
                    new Employee
                    {
                        Id = 29,
                        CompanyId = 9,
                        First = "Jasmine",
                        Last = "Schmidt",
                        TitleId = 5,
                        PositionId = 11,
                        DOB = new DateTime(1959, 3, 16)
                    },
                    new Employee
                    {
                        Id = 30,
                        CompanyId = 9,
                        First = "Ingram",
                        Last = "Schepherd",
                        TitleId = 5,
                        PositionId = 19,
                        DOB = new DateTime(1961, 3, 16)
                    },

                    new Employee
                    {
                        Id = 31,
                        CompanyId = 10,
                        First = "John",
                        Last = "Connor",
                        TitleId = 4,
                        PositionId = 1,
                        DOB = new DateTime(1975, 12, 12)
                    },

                    new Employee
                    {
                        Id = 32,
                        CompanyId = 11,
                        First = "Herbert",
                        Last = "Stokes",
                        TitleId = 1,
                        PositionId = 1,
                        DOB = new DateTime(1952, 2, 4)
                    },
                    new Employee
                    {
                        Id = 33,
                        CompanyId = 11,
                        First = "Joe",
                        Last = "Perry",
                        TitleId = 1,
                        PositionId = 5,
                        DOB = new DateTime(1962, 4, 7)
                    },
                    new Employee
                    {
                        Id = 34,
                        CompanyId = 11,
                        First = "Hanley",
                        Last = "Higgins",
                        TitleId = 4,
                        PositionId = 16,
                        DOB = new DateTime(1970, 11, 10)
                    },
                    new Employee
                    {
                        Id = 35,
                        CompanyId = 11,
                        First = "Reynard",
                        Last = "Schneider",
                        TitleId = 1,
                        PositionId = 26,
                        DOB = new DateTime(1990, 1, 2)
                    },

                    new Employee
                    {
                        Id = 36,
                        CompanyId = 12,
                        First = "Brooke",
                        Last = "Harris",
                        TitleId = 4,
                        PositionId = 1,
                        DOB = new DateTime(1970, 11, 10)
                    },
                    new Employee
                    {
                        Id = 37,
                        CompanyId = 12,
                        First = "Vere",
                        Last = "Apple",
                        TitleId = 9,
                        PositionId = 15,
                        DOB = new DateTime(1990, 12, 31)
                    }

            );

            modelBuilder.Entity<Note>().HasData(
                    new Note
                    {
                        Id = 1,
                        CompanyId = 1,
                        InvoiceId = 35703,
                        EmployeeId = 5, // Harv
                        StoreCity = "Las Vegas",
                        OrderDate = new DateTime(2013, 11, 12),
                    },
                    new Note
                    {
                        Id = 2,
                        CompanyId = 1,
                        InvoiceId = 35711,
                        EmployeeId = 2, // Jim
                        StoreCity = "Las Vegas",
                        OrderDate = new DateTime(2013, 11, 14),
                    },
                    new Note
                    {
                        Id = 3,
                        CompanyId = 1,
                        InvoiceId = 35714,
                        EmployeeId = 5, // Harv
                        StoreCity = "San Jose",
                        OrderDate = new DateTime(2013, 11, 18),
                    },
                    new Note
                    {
                        Id = 4,
                        CompanyId = 1,
                        InvoiceId = 35983,
                        EmployeeId = 7, // Todd
                        StoreCity = "Denver",
                        OrderDate = new DateTime(2013, 11, 22),
                    },
                    new Note
                    {
                        Id = 5,
                        CompanyId = 1,
                        InvoiceId = 36987,
                        EmployeeId = 8, // Clark
                        StoreCity = "Seattle",
                        OrderDate = new DateTime(2013, 11, 30),
                    },
                    new Note
                    {
                        Id = 6,
                        CompanyId = 1,
                        InvoiceId = 38466,
                        EmployeeId = 5, // Harv
                        StoreCity = "San Jose",
                        OrderDate = new DateTime(2013, 12, 1),
                    }
            );
        }
    }
}
