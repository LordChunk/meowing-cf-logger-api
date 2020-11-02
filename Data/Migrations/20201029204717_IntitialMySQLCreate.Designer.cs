﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20201029204717_IntitialMySQLCreate")]
    partial class IntitialMySQLCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Data.Models.CfHttpHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Asn")
                        .HasColumnType("text");

                    b.Property<string>("ClientAcceptEncoding")
                        .HasColumnType("text");

                    b.Property<int>("ClientTcpRtt")
                        .HasColumnType("int");

                    b.Property<string>("Colo")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<int>("EdgeRequestKeepAliveStatus")
                        .HasColumnType("int");

                    b.Property<string>("HttpProtocol")
                        .HasColumnType("text");

                    b.Property<string>("RequestPriority")
                        .HasColumnType("text");

                    b.Property<string>("TlsCipher")
                        .HasColumnType("text");

                    b.Property<int?>("TlsClientAuthId")
                        .HasColumnType("int");

                    b.Property<int?>("TlsExportedAuthenticatorId")
                        .HasColumnType("int");

                    b.Property<string>("TlsVersion")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TlsClientAuthId");

                    b.HasIndex("TlsExportedAuthenticatorId");

                    b.ToTable("CfHttpHeaders");
                });

            modelBuilder.Entity("Data.Models.HttpHeader", b =>
                {
                    b.Property<string>("Header")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("HttpRequestId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Header", "HttpRequestId");

                    b.HasIndex("HttpRequestId");

                    b.ToTable("HttpHeaders");
                });

            modelBuilder.Entity("Data.Models.HttpRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .HasColumnType("text");

                    b.Property<bool>("BodyUsed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("CfId")
                        .HasColumnType("int");

                    b.Property<int>("ContentLength")
                        .HasColumnType("int");

                    b.Property<string>("Fetchers")
                        .HasColumnType("text");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Redirect")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CfId");

                    b.ToTable("HttpRequests");
                });

            modelBuilder.Entity("Data.Models.TlsClientAuth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CertFingerprintSha1")
                        .HasColumnType("text");

                    b.Property<string>("CertIssuerDn")
                        .HasColumnType("text");

                    b.Property<string>("CertIssuerDnLegacy")
                        .HasColumnType("text");

                    b.Property<string>("CertIssuerDnrfc2253")
                        .HasColumnType("text");

                    b.Property<string>("CertNotAfter")
                        .HasColumnType("text");

                    b.Property<string>("CertNotBefore")
                        .HasColumnType("text");

                    b.Property<string>("CertPresented")
                        .HasColumnType("text");

                    b.Property<string>("CertSerial")
                        .HasColumnType("text");

                    b.Property<string>("CertSubjectDn")
                        .HasColumnType("text");

                    b.Property<string>("CertSubjectDnLegacy")
                        .HasColumnType("text");

                    b.Property<string>("CertSubjectDnrfc2253")
                        .HasColumnType("text");

                    b.Property<string>("CertVerified")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TlsClientAuths");
                });

            modelBuilder.Entity("Data.Models.TlsExportedAuthenticator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClientFinished")
                        .HasColumnType("text");

                    b.Property<string>("ClientHandshake")
                        .HasColumnType("text");

                    b.Property<string>("ServerFinished")
                        .HasColumnType("text");

                    b.Property<string>("ServerHandshake")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TlsExportedAuthenticators");
                });

            modelBuilder.Entity("Data.Models.CfHttpHeader", b =>
                {
                    b.HasOne("Data.Models.TlsClientAuth", "TlsClientAuth")
                        .WithMany()
                        .HasForeignKey("TlsClientAuthId");

                    b.HasOne("Data.Models.TlsExportedAuthenticator", "TlsExportedAuthenticator")
                        .WithMany()
                        .HasForeignKey("TlsExportedAuthenticatorId");
                });

            modelBuilder.Entity("Data.Models.HttpHeader", b =>
                {
                    b.HasOne("Data.Models.HttpRequest", "HttpRequest")
                        .WithMany("Headers")
                        .HasForeignKey("HttpRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Models.HttpRequest", b =>
                {
                    b.HasOne("Data.Models.CfHttpHeader", "Cf")
                        .WithMany()
                        .HasForeignKey("CfId");
                });
#pragma warning restore 612, 618
        }
    }
}
