﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210624203751_RemoveTlsClientAuth")]
    partial class RemoveTlsClientAuth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Models.HttpHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Header", "Value")
                        .IsUnique();

                    b.ToTable("HttpHeaders");
                });

            modelBuilder.Entity("Data.Models.HttpRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("BodyUsed")
                        .HasColumnType("bit");

                    b.Property<int>("ContentLength")
                        .HasColumnType("int");

                    b.Property<string>("Fetchers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Redirect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UrlId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UrlId");

                    b.ToTable("HttpRequests");
                });

            modelBuilder.Entity("Data.Models.HttpRequestLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<int?>("RequestId")
                        .HasColumnType("int");

                    b.Property<int>("RequestSize")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("HttpRequestLog");
                });

            modelBuilder.Entity("Data.Models.RequestUrl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Url")
                        .IsUnique();

                    b.ToTable("RequestUrls");
                });

            modelBuilder.Entity("Data.Models.TlsExportedAuthenticator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientFinished")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientHandshake")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServerFinished")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServerHandshake")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TlsExportedAuthenticators");
                });

            modelBuilder.Entity("HttpHeaderHttpRequest", b =>
                {
                    b.Property<int>("HeadersId")
                        .HasColumnType("int");

                    b.Property<int>("HttpRequestsId")
                        .HasColumnType("int");

                    b.HasKey("HeadersId", "HttpRequestsId");

                    b.HasIndex("HttpRequestsId");

                    b.ToTable("HttpHeaderHttpRequest");
                });

            modelBuilder.Entity("Data.Models.HttpRequest", b =>
                {
                    b.HasOne("Data.Models.RequestUrl", "Url")
                        .WithMany("Requests")
                        .HasForeignKey("UrlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Url");
                });

            modelBuilder.Entity("Data.Models.HttpRequestLog", b =>
                {
                    b.HasOne("Data.Models.HttpRequest", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("HttpHeaderHttpRequest", b =>
                {
                    b.HasOne("Data.Models.HttpHeader", null)
                        .WithMany()
                        .HasForeignKey("HeadersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.HttpRequest", null)
                        .WithMany()
                        .HasForeignKey("HttpRequestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Models.RequestUrl", b =>
                {
                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
