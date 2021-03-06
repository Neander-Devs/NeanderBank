// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NeanderBank.Data.Context;

#nullable disable

namespace NeanderBank.Data.Migrations
{
    [DbContext(typeof(NeanderBankContext))]
    [Migration("20220424172452_BaseMigration")]
    partial class BaseMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NeanderBank.Business.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Agency")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MaxOverdraft")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MaxWithDraw")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<decimal>("UsingOverdraft")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("NeanderBank.Business.Models.Costumer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Neighboorhood")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Costumers");
                });

            modelBuilder.Entity("NeanderBank.Business.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ReceiverAccountId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderAccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransferDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverAccountId");

                    b.HasIndex("SenderAccountId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("NeanderBank.Business.Models.Account", b =>
                {
                    b.HasOne("NeanderBank.Business.Models.Costumer", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("NeanderBank.Business.Models.Transaction", b =>
                {
                    b.HasOne("NeanderBank.Business.Models.Account", "ReceiverAccount")
                        .WithMany()
                        .HasForeignKey("ReceiverAccountId");

                    b.HasOne("NeanderBank.Business.Models.Account", "SenderAccount")
                        .WithMany("Transactions")
                        .HasForeignKey("SenderAccountId");

                    b.Navigation("ReceiverAccount");

                    b.Navigation("SenderAccount");
                });

            modelBuilder.Entity("NeanderBank.Business.Models.Account", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("NeanderBank.Business.Models.Costumer", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
