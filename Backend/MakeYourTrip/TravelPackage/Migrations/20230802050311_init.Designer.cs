﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using TravelPackage.Models.Context;

#nullable disable

namespace TravelPackage.Migrations
{
    [DbContext(typeof(TourContext))]
    [Migration("20230802050311_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Destination", b =>
                {
                    b.Property<int>("DestinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DestinationId"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DestinationId");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("TourDate", b =>
                {
                    b.Property<int>("DateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DateId"), 1L, 1);

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("DateId");

                    b.HasIndex("TourId");

                    b.ToTable("TourDates");
                });

            modelBuilder.Entity("TourDestination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DestinationActivity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<string>("Destinationimage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.HasIndex("TourId");

                    b.ToTable("TourDestinations");
                });

            modelBuilder.Entity("TourExclusion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ExclusionId")
                        .HasColumnType("int");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExclusionId");

                    b.HasIndex("TourId");

                    b.ToTable("TourExclusions");
                });

            modelBuilder.Entity("TourInclusion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("InclusionId")
                        .HasColumnType("int");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InclusionId");

                    b.HasIndex("TourId");

                    b.ToTable("TourInclusions");
                });

            modelBuilder.Entity("TourPackage.Models.Exclusions", b =>
                {
                    b.Property<int>("ExclusionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExclusionId"), 1L, 1);

                    b.Property<string>("ExclusionDescriptionn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExclusionId");

                    b.ToTable("Exclusions");
                });

            modelBuilder.Entity("TourPackage.Models.Inclusions", b =>
                {
                    b.Property<int>("InclusionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InclusionId"), 1L, 1);

                    b.Property<string>("InclusionDescriptionn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InclusionId");

                    b.ToTable("Inclusions");
                });

            modelBuilder.Entity("TourPackage.Models.TourDetails", b =>
                {
                    b.Property<int>("TourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TourId"), 1L, 1);

                    b.Property<bool>("Availability")
                        .HasColumnType("bit");

                    b.Property<int>("BookedCapacity")
                        .HasColumnType("int");

                    b.Property<string>("TourDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TourName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TourPrice")
                        .HasColumnType("int");

                    b.Property<string>("Tourtype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TravelAgentId")
                        .HasColumnType("int");

                    b.Property<int>("maxCapacity")
                        .HasColumnType("int");

                    b.HasKey("TourId");

                    b.ToTable("TourDetails");
                });

            modelBuilder.Entity("TourDate", b =>
                {
                    b.HasOne("TourPackage.Models.TourDetails", "Tour")
                        .WithMany("TourDate")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TourDestination", b =>
                {
                    b.HasOne("Destination", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourPackage.Models.TourDetails", "Tour")
                        .WithMany("TourDestination")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TourExclusion", b =>
                {
                    b.HasOne("TourPackage.Models.Exclusions", "Exclusions")
                        .WithMany()
                        .HasForeignKey("ExclusionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourPackage.Models.TourDetails", "TourDetails")
                        .WithMany("TourExclusion")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exclusions");

                    b.Navigation("TourDetails");
                });

            modelBuilder.Entity("TourInclusion", b =>
                {
                    b.HasOne("TourPackage.Models.Inclusions", "Inclusions")
                        .WithMany()
                        .HasForeignKey("InclusionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TourPackage.Models.TourDetails", "Tour")
                        .WithMany("TourInclusion")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inclusions");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("TourPackage.Models.TourDetails", b =>
                {
                    b.Navigation("TourDate");

                    b.Navigation("TourDestination");

                    b.Navigation("TourExclusion");

                    b.Navigation("TourInclusion");
                });
#pragma warning restore 612, 618
        }
    }
}
