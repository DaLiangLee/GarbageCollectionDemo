﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Tv.Database;

namespace Tv.Migrations
{
    [DbContext(typeof(TvContext))]
    [Migration("20180914135336_Garbage_Collection_Tables")]
    partial class Garbage_Collection_Tables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Garbage.Models.GarbageModel", b =>
                {
                    b.Property<int>("GCId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<int>("RecyclingQty");

                    b.Property<int>("SubId");

                    b.HasKey("GCId");

                    b.ToTable("Garbages");
                });

            modelBuilder.Entity("Garbage.Models.GCCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("GCSubCategorySubId");

                    b.HasKey("CategoryId");

                    b.HasIndex("GCSubCategorySubId");

                    b.ToTable("GCCategories");
                });

            modelBuilder.Entity("Garbage.Models.GCSubCategory", b =>
                {
                    b.Property<int>("SubId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<int?>("GarbageModelGCId");

                    b.Property<string>("SubCategoryName");

                    b.HasKey("SubId");

                    b.HasIndex("GarbageModelGCId");

                    b.ToTable("GCSubCategories");
                });

            modelBuilder.Entity("Tv.Models.TvNetwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("TvNetworks");
                });

            modelBuilder.Entity("Tv.Models.TvShow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("TvNetworkId");

                    b.HasKey("Id");

                    b.HasIndex("TvNetworkId");

                    b.ToTable("TvShows");
                });

            modelBuilder.Entity("Garbage.Models.GCCategory", b =>
                {
                    b.HasOne("Garbage.Models.GCSubCategory")
                        .WithMany("GCCategories")
                        .HasForeignKey("GCSubCategorySubId");
                });

            modelBuilder.Entity("Garbage.Models.GCSubCategory", b =>
                {
                    b.HasOne("Garbage.Models.GarbageModel")
                        .WithMany("GCSubCategories")
                        .HasForeignKey("GarbageModelGCId");
                });

            modelBuilder.Entity("Tv.Models.TvShow", b =>
                {
                    b.HasOne("Tv.Models.TvNetwork", "TvNetwork")
                        .WithMany("TvShows")
                        .HasForeignKey("TvNetworkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
