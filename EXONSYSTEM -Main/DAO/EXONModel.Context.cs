﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EXON_SYSTEM_TESTEntities : DbContext
    {
        public EXON_SYSTEM_TESTEntities()
            : base("name=EXON_SYSTEM_TESTEntities")
        {
            Database.Connection.ConnectionString = Common.GetConnectString("EXON_SYSTEM_TESTEntities");

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
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
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TEST_DETAILS> TEST_DETAILS { get; set; }
        public virtual DbSet<TEST> TESTS { get; set; }
        public virtual DbSet<VIOLATION> VIOLATIONS { get; set; }
        public virtual DbSet<VIOLATIONS_CONTESTANTS> VIOLATIONS_CONTESTANTS { get; set; }
    }
}
