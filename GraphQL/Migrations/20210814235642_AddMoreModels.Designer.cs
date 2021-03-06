// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using GraphQL;

namespace GraphQL.Migrations
{
    [DbContext(typeof(GraphQLDbContext))]
    [Migration("20210814235642_AddMoreModels")]
    partial class AddMoreModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Server.Entities.Locality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Localities");
                });

            modelBuilder.Entity("Server.Entities.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LocalityId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MemberTypeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Website")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LocalityId");

                    b.HasIndex("MemberTypeId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Server.Entities.MemberType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MemberTypes");
                });

            modelBuilder.Entity("Server.Entities.Notice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("NoticeTypeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("NoticeTypeId");

                    b.ToTable("Notices");
                });

            modelBuilder.Entity("Server.Entities.NoticeType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("NoticeTypes");
                });

            modelBuilder.Entity("Server.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BuyerId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SellerId")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("TransactionDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TransactionTypeId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("SellerId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Server.Entities.TransactionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TransactionTypes");
                });

            modelBuilder.Entity("Server.Entities.Member", b =>
                {
                    b.HasOne("Server.Entities.Locality", "Locality")
                        .WithMany("Members")
                        .HasForeignKey("LocalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Entities.MemberType", "MemberType")
                        .WithMany("Members")
                        .HasForeignKey("MemberTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locality");

                    b.Navigation("MemberType");
                });

            modelBuilder.Entity("Server.Entities.Notice", b =>
                {
                    b.HasOne("Server.Entities.Member", "Member")
                        .WithMany("Notices")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Entities.NoticeType", "NoticeType")
                        .WithMany("Notices")
                        .HasForeignKey("NoticeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("NoticeType");
                });

            modelBuilder.Entity("Server.Entities.Transaction", b =>
                {
                    b.HasOne("Server.Entities.Member", "Buyer")
                        .WithMany("Purchases")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Entities.Member", "Seller")
                        .WithMany("Sales")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Entities.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");

                    b.Navigation("Seller");

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("Server.Entities.Locality", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("Server.Entities.Member", b =>
                {
                    b.Navigation("Notices");

                    b.Navigation("Purchases");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Server.Entities.MemberType", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("Server.Entities.NoticeType", b =>
                {
                    b.Navigation("Notices");
                });
#pragma warning restore 612, 618
        }
    }
}
