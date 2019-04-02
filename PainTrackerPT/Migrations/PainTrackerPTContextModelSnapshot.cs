﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PainTrackerPT.Models;

namespace PainTrackerPT.Migrations
{
    [DbContext(typeof(PainTrackerPTContext))]
    partial class PainTrackerPTContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PainTrackerPT.Models.Analytics.AnalyticsLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("timeStamp");

                    b.HasKey("Id");

                    b.ToTable("AnalyticsLog");
                });

            modelBuilder.Entity("PainTrackerPT.Models.Doctors.DoctorsLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("timeStamp");

                    b.HasKey("Id");

                    b.ToTable("DoctorsLog");
                });

            modelBuilder.Entity("PainTrackerPT.Models.Events.EventsLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("timeStamp");

                    b.HasKey("Id");

                    b.ToTable("EventsLog");
                });

            modelBuilder.Entity("PainTrackerPT.Models.Followups.Advice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AnswerId");

                    b.Property<DateTime>("DateGenerated");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Advice");
                });

            modelBuilder.Entity("PainTrackerPT.Models.Followups.Answer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateGenerated");

                    b.Property<string>("Description");

                    b.Property<long>("QuestionId");

                    b.HasKey("Id");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("PainTrackerPT.Models.Followups.FollowUp", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateGenerated");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<long>("DoctorId");

                    b.Property<long>("PatientId");

                    b.Property<int>("State");

                    b.HasKey("Id");

                    b.ToTable("FollowUp");
                });

            modelBuilder.Entity("PainTrackerPT.Models.Followups.FollowupsLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateGenerated");

                    b.Property<string>("Description");

                    b.Property<Guid>("FollowUpId");

                    b.Property<DateTime>("timeStamp");

                    b.HasKey("Id");

                    b.ToTable("FollowupsLog");
                });

            modelBuilder.Entity("PainTrackerPT.Models.Followups.Media", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AnswerId");

                    b.Property<string>("MediaUrl")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("PainTrackerPT.Models.Followups.Question", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateGenerated");

                    b.Property<string>("Description");

                    b.Property<long>("FollowUpId");

                    b.HasKey("Id");

                    b.HasIndex("FollowUpId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("PainTrackerPT.Models.Followups.Recommendation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AnswerId");

                    b.Property<DateTime>("DateGenerated");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Recommendation");
                });

            modelBuilder.Entity("PainTrackerPT.Models.Medicine.MedicineLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("timeStamp");

                    b.HasKey("Id");

                    b.ToTable("MedicineLog");
                });

            modelBuilder.Entity("PainTrackerPT.Models.PainDiary.PainDiaryLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("timeStamp");

                    b.HasKey("Id");

                    b.ToTable("PainDiaryLog");
                });

            modelBuilder.Entity("PainTrackerPT.Models.Followups.Question", b =>
                {
                    b.HasOne("PainTrackerPT.Models.Followups.FollowUp", "FollowUp")
                        .WithMany("Questions")
                        .HasForeignKey("FollowUpId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
