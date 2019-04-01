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

            modelBuilder.Entity("PainTrackerPT.Models.Followups.FollowUp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("timeStamp");

                    b.HasKey("Id");

                    b.ToTable("FollowupsLog");
                });

            modelBuilder.Entity("PainTrackerPT.Models.Medicine.MedicineEvent", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Dosage");

                    b.Property<int>("Intervals");

                    b.Property<int>("MedId");

                    b.Property<int>("NumOfRecurringTimes");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("EventId");

                    b.ToTable("MedicineEvent");
                });

            modelBuilder.Entity("PainTrackerPT.Models.Medicine.MedicineLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Img");

                    b.Property<string>("Name");

                    b.Property<string>("Type");

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
#pragma warning restore 612, 618
        }
    }
}
