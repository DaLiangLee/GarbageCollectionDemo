﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Tv.Database;

namespace GarbageCollection.Migrations
{
    [DbContext(typeof(TvContext))]
    [Migration("20180911130722_AddConstraints")]
    partial class AddConstraints
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
