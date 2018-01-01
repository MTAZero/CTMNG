namespace ContestManagementVer2.CSDL_Luu_Tru
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MTA_Quiz_Main : DbContext
    {
        public MTA_Quiz_Main()
            : base("name=MTA_Quiz_Main")
        {
        }

        public virtual DbSet<ANSWER> ANSWERS { get; set; }
        public virtual DbSet<ANSWERS_TEMP> ANSWERS_TEMP { get; set; }
        public virtual DbSet<ANSWERSHEET_DETAILS> ANSWERSHEET_DETAILS { get; set; }
        public virtual DbSet<ANSWERSHEET> ANSWERSHEETS { get; set; }
        public virtual DbSet<BAGOFTEST> BAGOFTESTS { get; set; }
        public virtual DbSet<CONTESTANT> CONTESTANTS { get; set; }
        public virtual DbSet<CONTESTANTS_SHIFTS> CONTESTANTS_SHIFTS { get; set; }
        public virtual DbSet<CONTESTANTS_TESTS> CONTESTANTS_TESTS { get; set; }
        public virtual DbSet<CONTEST> CONTESTS { get; set; }
        public virtual DbSet<DIVISION_SHIFTS> DIVISION_SHIFTS { get; set; }
        public virtual DbSet<DIVISIONSHIFT_SUPERVISOR> DIVISIONSHIFT_SUPERVISOR { get; set; }
        public virtual DbSet<EXAMINATIONCOUNCIL_POSITIONS> EXAMINATIONCOUNCIL_POSITIONS { get; set; }
        public virtual DbSet<EXAMINATIONCOUNCIL_STAFFS> EXAMINATIONCOUNCIL_STAFFS { get; set; }
        public virtual DbSet<FINGERPRINT> FINGERPRINTS { get; set; }
        public virtual DbSet<LOCATION> LOCATIONS { get; set; }
        public virtual DbSet<POSITION> POSITIONS { get; set; }
        public virtual DbSet<QUESTION> QUESTIONS { get; set; }
        public virtual DbSet<QUESTIONS_TEMP> QUESTIONS_TEMP { get; set; }
        public virtual DbSet<ROOMDIAGRAM> ROOMDIAGRAMS { get; set; }
        public virtual DbSet<ROOMTEST> ROOMTESTS { get; set; }
        public virtual DbSet<SCHEDULE> SCHEDULES { get; set; }
        public virtual DbSet<SHIFT> SHIFTS { get; set; }
        public virtual DbSet<STAFF> STAFFS { get; set; }
        public virtual DbSet<STAFFS_POSITIONS> STAFFS_POSITIONS { get; set; }
        public virtual DbSet<SUBJECT> SUBJECTS { get; set; }
        public virtual DbSet<SUBQUESTION> SUBQUESTIONS { get; set; }
        public virtual DbSet<SUBQUESTIONS_TEMP> SUBQUESTIONS_TEMP { get; set; }
        public virtual DbSet<TEST_DETAILS> TEST_DETAILS { get; set; }
        public virtual DbSet<TEST> TESTS { get; set; }
        public virtual DbSet<VIOLATION> VIOLATIONS { get; set; }
        public virtual DbSet<VIOLATIONS_CONTESTANTS> VIOLATIONS_CONTESTANTS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CONTESTANT>()
                .Property(e => e.ContestantCode)
                .IsUnicode(false);

            modelBuilder.Entity<CONTESTANT>()
                .Property(e => e.IdentityCardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<CONTESTANT>()
                .Property(e => e.StudentCode)
                .IsUnicode(false);

            modelBuilder.Entity<CONTEST>()
                .Property(e => e.SchoolYear)
                .IsUnicode(false);

            modelBuilder.Entity<EXAMINATIONCOUNCIL_POSITIONS>()
                .Property(e => e.ExaminationCouncil_PositionCode)
                .IsUnicode(false);

            modelBuilder.Entity<POSITION>()
                .Property(e => e.PositionCode)
                .IsUnicode(false);

            modelBuilder.Entity<ROOMDIAGRAM>()
                .Property(e => e.ComputerCode)
                .IsUnicode(false);

            modelBuilder.Entity<ROOMDIAGRAM>()
                .Property(e => e.ClientIP)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.IdentityCardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<SUBJECT>()
                .Property(e => e.SubjectCode)
                .IsUnicode(false);

            modelBuilder.Entity<TEST_DETAILS>()
                .Property(e => e.RandomAnswer)
                .IsUnicode(false);
        }
    }
}
