﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestProject.Data;

#nullable disable

namespace TestProject.Migrations
{
    [DbContext(typeof(TestProjectContext))]
    [Migration("20220316123147_AddUserEditorPropertyToJournal")]
    partial class AddUserEditorPropertyToJournal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TestProject.Models.Comment", b =>
                {
                    b.Property<int>("CommentNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentNumber"), 1L, 1);

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JournalNumber")
                        .HasColumnType("int");

                    b.Property<int?>("UserNumber")
                        .HasColumnType("int");

                    b.HasKey("CommentNumber");

                    b.HasIndex("JournalNumber");

                    b.HasIndex("UserNumber");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("TestProject.Models.Journal", b =>
                {
                    b.Property<int>("JournalNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JournalNumber"), 1L, 1);

                    b.Property<DateTime>("DateWritten")
                        .HasColumnType("datetime2");

                    b.Property<int>("EditorUserNumber")
                        .HasColumnType("int");

                    b.Property<string>("Entry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerUserNumber")
                        .HasColumnType("int");

                    b.HasKey("JournalNumber");

                    b.HasIndex("EditorUserNumber");

                    b.HasIndex("OwnerUserNumber");

                    b.ToTable("Journal");
                });

            modelBuilder.Entity("TestProject.Models.User", b =>
                {
                    b.Property<int>("UserNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserNumber"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserNumber");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TestProject.Models.Comment", b =>
                {
                    b.HasOne("TestProject.Models.Journal", "Journal")
                        .WithMany("Comments")
                        .HasForeignKey("JournalNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestProject.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserNumber");

                    b.Navigation("Journal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TestProject.Models.Journal", b =>
                {
                    b.HasOne("TestProject.Models.User", "Editor")
                        .WithMany("EditedJournals")
                        .HasForeignKey("EditorUserNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestProject.Models.User", "Owner")
                        .WithMany("Journals")
                        .HasForeignKey("OwnerUserNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Editor");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("TestProject.Models.Journal", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("TestProject.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("EditedJournals");

                    b.Navigation("Journals");
                });
#pragma warning restore 612, 618
        }
    }
}
