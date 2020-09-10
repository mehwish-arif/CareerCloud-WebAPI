using CareerCloud.ADODataAccessLayer;
using CareerCloud.Pocos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CareerCloud.EntityFrameworkDataAccess
{
    class CareerCloudContext : DbContext
    {

        public static readonly ILoggerFactory MyLoggerFactory
                  = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public DbSet<ApplicantEducationPoco> ApplicantEducation { get; set; }
        public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplication { get; set; }
        public DbSet<ApplicantProfilePoco> ApplicantProfile { get; set; }
        public DbSet<ApplicantResumePoco> ApplicantResume { get; set; }
        public DbSet<ApplicantSkillPoco> ApplicantSkill { get; set; }
        public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistory { get; set; }
        public DbSet<CompanyDescriptionPoco> CompanyDescription { get; set; }
        public DbSet<CompanyJobDescriptionPoco> CompanyJobDescription { get; set; }
        public DbSet<CompanyJobEducationPoco> CompanyJobEducation { get; set; }
        public DbSet<CompanyJobPoco> CompanyJob { get; set; }
        public DbSet<CompanyJobSkillPoco> CompanyJobSkill { get; set; }
        public DbSet<CompanyLocationPoco> CompanyLocation { get; set; }
        public DbSet<CompanyProfilePoco> CompanyProfile { get; set; }
        public DbSet<SecurityLoginPoco> SecurityLogin { get; set; }
        public DbSet<SecurityLoginsLogPoco> SecurityLoginsLog { get; set; }
        public DbSet<SecurityLoginsRolePoco> SecurityLoginsRole { get; set; }
        public DbSet<SecurityRolePoco> SecurityRole { get; set; }
        public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        public DbSet<SystemLanguageCodePoco> SystemLanguageCode { get; set; }
        public CareerCloudContext()
            
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
             {
                optionBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer(@"Data Source=IDEA-PC\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True;");
             }
             protected override void OnModelCreating(ModelBuilder modelbuilder)
            {
            #region ApplicantEducationPoco
            modelbuilder.Entity<ApplicantEducationPoco>(entity =>
                                                       {
                                                           entity.ToTable("Applicant_Educations");
                                                           entity.HasKey(i => i.Id);
                                                           entity.HasOne(i => i.ApplicantProfiles).WithMany(p => p.ApplicantEducations).HasForeignKey(e => e.Applicant);
                                                           entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
                                                        });
            #endregion

            #region ApplicantJobApplicationPoco

            modelbuilder.Entity<ApplicantJobApplicationPoco>(entity =>
                                                             {
                                                                 entity.ToTable("Applicant_Job_Applications");
                                                                 entity.HasKey(i => i.Id);
                                                                 entity.HasOne(i => i.ApplicantProfiles).WithMany(p => p.ApplicantJobApplications).HasForeignKey(i => i.Applicant);
                                                                 entity.HasOne(i => i.CompanyJobs).WithMany(p => p.ApplicantJobApplications).HasForeignKey(e => e.Job);
                                                                 entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
                                                             });
            #endregion

            #region ApplicantProfilePoco

            modelbuilder.Entity<ApplicantProfilePoco>(entity =>
                                                    {
                                                        entity.ToTable("Applicant_Profiles");
                                                        entity.HasKey(i => i.Id);
                                                        entity.HasOne(n => n.SecurityLogins).WithMany(p => p.ApplicantProfiles).HasForeignKey(e => e.Login);
                                                        entity.HasOne(n => n.SystemCountryCodes).WithMany(p => p.ApplicantProfiles).HasForeignKey(e => e.Country);
                                                        entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
                                                    });


            #endregion

            #region ApplicantResumePoco

            modelbuilder.Entity<ApplicantResumePoco>(entity =>
                                                    {
                                                        entity.ToTable("Applicant_Resumes");
                                                        entity.HasKey(i => i.Id);
                                                        entity.HasOne(n => n.ApplicantProfiles).WithMany(e => e.ApplicantResumes).HasForeignKey(e => e.Applicant);
                                                    });

            #endregion

            #region ApplicantSkillPoco

            modelbuilder.Entity<ApplicantSkillPoco>(entity =>

                                                   {
                                                       entity.ToTable("Applicant_Skills");
                                                       entity.HasKey(e => e.Id);
                                                       entity.HasOne(n => n.ApplicantProfiles).WithMany(e => e.ApplicantSkills).HasForeignKey(e => e.Applicant);
                                                       entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();

                                                   });
            #endregion

            #region ApplicantWorkHistoryPoco
            modelbuilder.Entity<ApplicantWorkHistoryPoco>(entity =>
                                                       {
                                                           entity.ToTable("Applicant_Work_History");
                                                           entity.HasKey(e => e.Id);
                                                           entity.HasOne(n => n.ApplicantProfiles).WithMany(e => e.ApplicantWorkHistories).HasForeignKey(e => e.Applicant);
                                                           entity.HasOne(n => n.SystemCountryCodes).WithMany(e => e.ApplicantWorkHistories).HasForeignKey(o => o.CountryCode);
                                                           entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
                                                       });
            #endregion

            #region CompanyDescriptionPoco
            modelbuilder.Entity<CompanyDescriptionPoco>(entity =>

                                                       {
                                                           entity.ToTable("Company_Descriptions");
                                                           entity.HasKey(e => e.Id);
                                                           entity.HasOne(n => n.CompanyProfiles).WithMany(e => e.CompanyDescriptions).HasForeignKey(t => t.Company);
                                                           entity.HasOne(i => i.SystemLanguageCodes).WithMany(h => h.CompanyDescriptions).HasForeignKey(t => t.LanguageId);
                                                           entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
                                                       });

            #endregion
            #region CompanyJobDescriptionPoco

            modelbuilder.Entity<CompanyJobDescriptionPoco>(entity =>
                                                            {
                                                                entity.ToTable("Company_Jobs_Descriptions");
                                                                entity.HasKey(e => e.Id);
                                                                entity.HasOne(n => n.CompanyJobs).WithMany(i => i.CompanyJobDescriptions).HasForeignKey(t => t.Job);
                                                                entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
                                                            });
            #endregion

            #region CompanyJobEducationPoco
            modelbuilder.Entity<CompanyJobEducationPoco>(entity =>

                                                          {
                                                              entity.ToTable("Company_Job_Educations");
                                                              entity.HasKey(e => e.Id);
                                                              entity.HasOne(i => i.CompanyJobs).WithMany(t => t.CompanyJobEducations).HasForeignKey(e => e.Job);
                                                              entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();

                                                          });

            #endregion

            #region CompanyJobPoco
            modelbuilder.Entity<CompanyJobPoco>(entity =>
                                                {
                                                    entity.ToTable("Company_Jobs");
                                                    entity.HasKey(e => e.Id);
                                                    entity.HasOne(n => n.CompanyProfiles).WithMany(t => t.CompanyJobs).HasForeignKey(e => e.Company);
                                                    entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
                                                });
            #endregion

            #region CompanyJobSkillPoco
            modelbuilder.Entity<CompanyJobSkillPoco>(entity =>
                                                    {
                                                        entity.ToTable("Company_Job_Skills");
                                                        entity.HasKey(e => e.Id);
                                                        entity.HasOne(n => n.CompanyJobs).WithMany(m => m.CompanyJobSkills).HasForeignKey(t => t.Job);
                                                        entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();

                                                    });
            #endregion

            #region CompanyLocationPoco

            modelbuilder.Entity<CompanyLocationPoco>(entity =>
                                                     {
                                                         entity.ToTable("Company_Locations");
                                                         entity.HasKey(e => e.Id);
                                                         entity.HasOne(t => t.CompanyProfiles).WithMany(e => e.CompanyLocations).HasForeignKey(t => t.Company);
                                                         entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();

                                                     });
            #endregion

            #region CompanyProfilePoco
            modelbuilder.Entity<CompanyProfilePoco>(entity =>

                                                    {
                                                        entity.ToTable("Company_Profiles");
                                                        entity.HasKey(e => e.Id);
                                                        entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
                                                    });

            #endregion

            #region SecurityLoginPoco
            modelbuilder.Entity<SecurityLoginPoco>(entity =>

                                                   {
                                                       entity.ToTable("Security_Logins");
                                                       entity.HasKey(i => i.Id);
                                                       entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
                                                   });

            #endregion

            #region SecurityLoginsLogPoco
            modelbuilder.Entity<SecurityLoginsLogPoco>(entity =>
                                                       {
                                                           entity.ToTable("Security_Logins_Log");
                                                           entity.HasKey(e=>e.Id);
                                                           entity.HasOne(t => t.SecurityLogins).WithMany(t => t.SecurityLoginsLogs).HasForeignKey(e => e.Login);
                                                         
                                                       });

            #endregion

            #region SecurityLoginsRolePoco
            modelbuilder.Entity<SecurityLoginsRolePoco>(entity =>
                                                       {
                                                           entity.ToTable("Security_Logins_Roles");
                                                           entity.HasKey(t => t.Id);
                                                           entity.HasOne(m => m.SecurityLogins).WithMany(y => y.SecurityLoginsRoles).HasForeignKey(e => e.Login);
                                                           entity.HasOne(m => m.SecurityRoles).WithMany(y => y.SecurityLoginsRoles).HasForeignKey(e => e.Role);
                                                           entity.Property(n => n.TimeStamp).IsRowVersion().IsConcurrencyToken();
                                                       });

            #endregion

            #region SecurityRolePoco

            modelbuilder.Entity<SecurityRolePoco>(entity =>

                                                   {
                                                       entity.ToTable("Security_Roles");
                                                       entity.HasKey(e => e.Id);
                                                   });
            #endregion

            #region SystemCountryCodePoco

               modelbuilder.Entity<SystemCountryCodePoco> (entity =>

                                                          {
                                                              entity.ToTable("System_Country_Codes");
                                                              entity.HasKey(e => e.Code);
                                                              entity.HasMany(e => e.ApplicantProfiles).WithOne(i => i.SystemCountryCodes);
                                                              entity.HasMany(e => e.ApplicantWorkHistories).WithOne(t => t.SystemCountryCodes);
                                                          });
              #endregion
            
          //  #region SystemLanguageCodePoco

            /*modelbuilder.Entity<SystemLanguageCodePoco>(entity =>
                                                           {
                                                               entity.ToTable("System_Language_Codes");
                                                               entity.HasKey(e => e.LanguageID);


                                                           });
            */
            //#endregion
            base.OnModelCreating(modelbuilder);
            }





    }
}
