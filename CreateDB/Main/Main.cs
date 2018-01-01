namespace CreateDB.Main
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Configuration;

    public partial class Main : DbContext
    {
        public Main()
            : base("name=EXON_DbContext")
        {
            //Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["Main"].ConnectionString;
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<ANSWER> ANSWERS { get; set; }
        public virtual DbSet<ANSWERSHEET_DETAILS> ANSWERSHEET_DETAILS { get; set; }
        public virtual DbSet<ANSWERSHEET> ANSWERSHEETS { get; set; }
        public virtual DbSet<BAGOFTEST> BAGOFTESTS { get; set; }
        public virtual DbSet<CONTEST_FEES> CONTEST_FEES { get; set; }
        public virtual DbSet<CONTEST_TYPES> CONTEST_TYPES { get; set; }
        public virtual DbSet<CONTESTANT_TYPES> CONTESTANT_TYPES { get; set; }
        public virtual DbSet<CONTESTANT> CONTESTANTS { get; set; }
        public virtual DbSet<CONTESTANTS_SHIFTS> CONTESTANTS_SHIFTS { get; set; }
        public virtual DbSet<CONTESTANTS_SUBJECTS> CONTESTANTS_SUBJECTS { get; set; }
        public virtual DbSet<CONTESTANTS_TESTS> CONTESTANTS_TESTS { get; set; }
        public virtual DbSet<CONTEST> CONTESTS { get; set; }
        public virtual DbSet<DEMO_FINGERPRINTS> DEMO_FINGERPRINTS { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENTS { get; set; }
        public virtual DbSet<DIVISION_SHIFTS> DIVISION_SHIFTS { get; set; }
        public virtual DbSet<EXAMINATIONCOUNCIL_POSITIONS> EXAMINATIONCOUNCIL_POSITIONS { get; set; }
        public virtual DbSet<EXAMINATIONCOUNCIL_STAFFS> EXAMINATIONCOUNCIL_STAFFS { get; set; }
        public virtual DbSet<FINGERPRINT> FINGERPRINTS { get; set; }
        public virtual DbSet<LOCATION> LOCATIONS { get; set; }
        public virtual DbSet<MODULE> MODULES { get; set; }
        public virtual DbSet<ORIGINAL_TEST_DETAILS> ORIGINAL_TEST_DETAILS { get; set; }
        public virtual DbSet<ORIGINAL_TESTS> ORIGINAL_TESTS { get; set; }
        public virtual DbSet<POSITION> POSITIONS { get; set; }
        public virtual DbSet<QUESTION_TYPES> QUESTION_TYPES { get; set; }
        public virtual DbSet<QUESTION> QUESTIONS { get; set; }
        public virtual DbSet<RECEIPT> RECEIPTS { get; set; }
        public virtual DbSet<REGISTER> REGISTERS { get; set; }
        public virtual DbSet<REGISTERS_SUBJECTS> REGISTERS_SUBJECTS { get; set; }
        public virtual DbSet<REMINDER> REMINDERS { get; set; }
        public virtual DbSet<ROOMDIAGRAM> ROOMDIAGRAMS { get; set; }
        public virtual DbSet<ROOMTEST> ROOMTESTS { get; set; }
        public virtual DbSet<SCHEDULE> SCHEDULES { get; set; }
        public virtual DbSet<SHIFT> SHIFTS { get; set; }
        public virtual DbSet<STAFF> STAFFS { get; set; }
        public virtual DbSet<STAFFS_POSITIONS> STAFFS_POSITIONS { get; set; }
        public virtual DbSet<STRUCTURE_DETAILS> STRUCTURE_DETAILS { get; set; }
        public virtual DbSet<STRUCTURE> STRUCTURES { get; set; }
        public virtual DbSet<SUBJECT> SUBJECTS { get; set; }
        public virtual DbSet<SUBQUESTION> SUBQUESTIONS { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TEST_DETAILS> TEST_DETAILS { get; set; }
        public virtual DbSet<TEST> TESTS { get; set; }
        public virtual DbSet<TOPIC> TOPICS { get; set; }
        public virtual DbSet<TOPICS_STAFFS> TOPICS_STAFFS { get; set; }
        public virtual DbSet<VIOLATION> VIOLATIONS { get; set; }
        public virtual DbSet<VIOLATIONS_CONTESTANTS> VIOLATIONS_CONTESTANTS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ANSWERSHEET>()
                .HasMany(e => e.ANSWERSHEET_DETAILS)
                .WithRequired(e => e.ANSWERSHEET)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BAGOFTEST>()
                .HasMany(e => e.TESTS)
                .WithRequired(e => e.BAGOFTEST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONTESTANT>()
                .Property(e => e.ContestantCode)
                .IsUnicode(false);

            modelBuilder.Entity<CONTESTANT>()
                .HasMany(e => e.CONTESTANTS_SHIFTS)
                .WithRequired(e => e.CONTESTANT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONTESTANT>()
                .HasMany(e => e.FINGERPRINTS)
                .WithRequired(e => e.CONTESTANT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONTESTANTS_SHIFTS>()
                .HasMany(e => e.CONTESTANTS_TESTS)
                .WithRequired(e => e.CONTESTANTS_SHIFTS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONTESTANTS_SHIFTS>()
                .HasMany(e => e.VIOLATIONS_CONTESTANTS)
                .WithRequired(e => e.CONTESTANTS_SHIFTS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONTESTANTS_TESTS>()
                .HasMany(e => e.ANSWERSHEETS)
                .WithRequired(e => e.CONTESTANTS_TESTS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONTEST>()
                .Property(e => e.SchoolYear)
                .IsUnicode(false);

            modelBuilder.Entity<CONTEST>()
                .HasMany(e => e.EXAMINATIONCOUNCIL_STAFFS)
                .WithRequired(e => e.CONTEST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONTEST>()
                .HasMany(e => e.LOCATIONS)
                .WithRequired(e => e.CONTEST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONTEST>()
                .HasMany(e => e.REGISTERS)
                .WithRequired(e => e.CONTEST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONTEST>()
                .HasMany(e => e.SCHEDULES)
                .WithRequired(e => e.CONTEST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CONTEST>()
                .HasMany(e => e.ORIGINAL_TESTS)
                .WithRequired(e => e.CONTEST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.DEPARTMENTS1)
                .WithOptional(e => e.DEPARTMENT1)
                .HasForeignKey(e => e.DepartmentIDParent);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.STAFFS)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.SUBJECTS)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DIVISION_SHIFTS>()
                .HasMany(e => e.BAGOFTESTS)
                .WithRequired(e => e.DIVISION_SHIFTS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DIVISION_SHIFTS>()
                .HasMany(e => e.CONTESTANTS_SHIFTS)
                .WithRequired(e => e.DIVISION_SHIFTS)
                .HasForeignKey(e => e.ShiftID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EXAMINATIONCOUNCIL_POSITIONS>()
                .Property(e => e.ExaminationCouncil_PositionCode)
                .IsUnicode(false);

            modelBuilder.Entity<EXAMINATIONCOUNCIL_POSITIONS>()
                .HasMany(e => e.EXAMINATIONCOUNCIL_STAFFS)
                .WithRequired(e => e.EXAMINATIONCOUNCIL_POSITIONS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOCATION>()
                .HasMany(e => e.EXAMINATIONCOUNCIL_STAFFS)
                .WithRequired(e => e.LOCATION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MODULE>()
                .Property(e => e.ModuleCode)
                .IsUnicode(false);

            modelBuilder.Entity<ORIGINAL_TESTS>()
                .HasMany(e => e.ORIGINAL_TEST_DETAILS)
                .WithRequired(e => e.ORIGINAL_TESTS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<POSITION>()
                .Property(e => e.PositionCode)
                .IsUnicode(false);

            modelBuilder.Entity<POSITION>()
                .HasMany(e => e.STAFFS_POSITIONS)
                .WithRequired(e => e.POSITION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QUESTION_TYPES>()
                .HasMany(e => e.QUESTIONS)
                .WithRequired(e => e.QUESTION_TYPES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QUESTION>()
                .HasMany(e => e.ORIGINAL_TEST_DETAILS)
                .WithRequired(e => e.QUESTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QUESTION>()
                .HasMany(e => e.TEST_DETAILS)
                .WithRequired(e => e.QUESTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REGISTER>()
                .Property(e => e.StudentCode)
                .IsUnicode(false);

            modelBuilder.Entity<REGISTER>()
                .Property(e => e.IdentityCardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<REGISTER>()
                .HasMany(e => e.CONTESTANTS)
                .WithRequired(e => e.REGISTER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REGISTER>()
                .HasMany(e => e.RECEIPTS)
                .WithRequired(e => e.REGISTER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REGISTER>()
                .HasMany(e => e.REGISTERS_SUBJECTS)
                .WithRequired(e => e.REGISTER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REMINDER>()
                .Property(e => e.ReminderContent)
                .IsUnicode(false);

            modelBuilder.Entity<ROOMDIAGRAM>()
                .Property(e => e.ComputerCode)
                .IsUnicode(false);

            modelBuilder.Entity<ROOMDIAGRAM>()
                .Property(e => e.ComputerName)
                .IsUnicode(false);

            modelBuilder.Entity<ROOMTEST>()
                .HasMany(e => e.DIVISION_SHIFTS)
                .WithRequired(e => e.ROOMTEST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROOMTEST>()
                .HasMany(e => e.ROOMDIAGRAMS)
                .WithRequired(e => e.ROOMTEST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SCHEDULE>()
                .HasMany(e => e.CONTESTANTS_SHIFTS)
                .WithRequired(e => e.SCHEDULE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SCHEDULE>()
                .HasMany(e => e.STRUCTURES)
                .WithRequired(e => e.SCHEDULE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SHIFT>()
                .HasMany(e => e.DIVISION_SHIFTS)
                .WithRequired(e => e.SHIFT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.IdentityCardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.MailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.CONTESTS)
                .WithOptional(e => e.STAFF)
                .HasForeignKey(e => e.AcceptedStaffID);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.CONTESTS1)
                .WithOptional(e => e.STAFF1)
                .HasForeignKey(e => e.CreatedStaffID);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.DIVISION_SHIFTS)
                .WithOptional(e => e.STAFF)
                .HasForeignKey(e => e.SupervisorID);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.EXAMINATIONCOUNCIL_STAFFS)
                .WithRequired(e => e.STAFF)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.QUESTIONS)
                .WithOptional(e => e.STAFF)
                .HasForeignKey(e => e.AcceptedStaffID);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.QUESTIONS1)
                .WithRequired(e => e.STAFF1)
                .HasForeignKey(e => e.CreatedStaffID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.RECEIPTS)
                .WithRequired(e => e.STAFF)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.REMINDERS)
                .WithRequired(e => e.STAFF)
                .HasForeignKey(e => e.ReceiveStaffID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.REMINDERS1)
                .WithRequired(e => e.STAFF1)
                .HasForeignKey(e => e.SendStaffID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.STRUCTURES)
                .WithRequired(e => e.STAFF)
                .HasForeignKey(e => e.CreatedStaffID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.TOPICS_STAFFS)
                .WithRequired(e => e.STAFF)
                .HasForeignKey(e => e.AssignedStaffID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.TOPICS_STAFFS1)
                .WithRequired(e => e.STAFF1)
                .HasForeignKey(e => e.TaskmasterStaffID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.STAFFS_POSITIONS)
                .WithRequired(e => e.STAFF)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STRUCTURE>()
                .HasMany(e => e.STRUCTURE_DETAILS)
                .WithRequired(e => e.STRUCTURE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUBJECT>()
                .Property(e => e.SubjectCode)
                .IsUnicode(false);

            modelBuilder.Entity<SUBJECT>()
                .HasMany(e => e.MODULES)
                .WithRequired(e => e.SUBJECT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUBJECT>()
                .HasMany(e => e.ORIGINAL_TESTS)
                .WithRequired(e => e.SUBJECT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUBJECT>()
                .HasMany(e => e.REGISTERS_SUBJECTS)
                .WithRequired(e => e.SUBJECT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUBJECT>()
                .HasMany(e => e.SCHEDULES)
                .WithRequired(e => e.SUBJECT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUBJECT>()
                .HasMany(e => e.TESTS)
                .WithRequired(e => e.SUBJECT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUBJECT>()
                .HasMany(e => e.TOPICS)
                .WithRequired(e => e.SUBJECT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TEST_DETAILS>()
                .Property(e => e.RandomAnswer)
                .IsUnicode(false);

            modelBuilder.Entity<TEST_DETAILS>()
                .HasMany(e => e.ANSWERSHEET_DETAILS)
                .WithRequired(e => e.TEST_DETAILS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TEST>()
                .HasMany(e => e.CONTESTANTS_TESTS)
                .WithRequired(e => e.TEST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TEST>()
                .HasMany(e => e.TEST_DETAILS)
                .WithRequired(e => e.TEST)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TOPIC>()
                .HasMany(e => e.QUESTIONS)
                .WithRequired(e => e.TOPIC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TOPIC>()
                .HasMany(e => e.STRUCTURE_DETAILS)
                .WithRequired(e => e.TOPIC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TOPIC>()
                .HasMany(e => e.TOPICS_STAFFS)
                .WithRequired(e => e.TOPIC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VIOLATION>()
                .HasMany(e => e.VIOLATIONS_CONTESTANTS)
                .WithRequired(e => e.VIOLATION)
                .WillCascadeOnDelete(false);
        }
    }
}
