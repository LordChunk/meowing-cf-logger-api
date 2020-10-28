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
    [DbContext(typeof(MeowingCfLoggerContext))]
    [Migration("20201028221800_HttpHeaderCompositeKey")]
    partial class HttpHeaderCompositeKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Models.CfHttpHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Asn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientAcceptEncoding")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientTcpRtt")
                        .HasColumnType("int");

                    b.Property<string>("Colo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EdgeRequestKeepAliveStatus")
                        .HasColumnType("int");

                    b.Property<string>("HttpProtocol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestPriority")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TlsCipher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TlsClientAuthId")
                        .HasColumnType("int");

                    b.Property<int?>("TlsExportedAuthenticatorId")
                        .HasColumnType("int");

                    b.Property<string>("TlsVersion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TlsClientAuthId");

                    b.HasIndex("TlsExportedAuthenticatorId");

                    b.ToTable("CfHttpHeaders");
                });

            modelBuilder.Entity("Data.Models.HttpHeader", b =>
                {
                    b.Property<string>("Header")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("HttpRequestId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Header", "HttpRequestId");

                    b.HasIndex("HttpRequestId");

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

                    b.Property<int?>("CfId")
                        .HasColumnType("int");

                    b.Property<int>("ContentLength")
                        .HasColumnType("int");

                    b.Property<string>("Fetchers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Redirect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CfId");

                    b.ToTable("HttpRequests");
                });

            modelBuilder.Entity("Data.Models.TlsClientAuth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CertFingerprintSha1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertIssuerDn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertIssuerDnLegacy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertIssuerDnrfc2253")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertNotAfter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertNotBefore")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertPresented")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertSerial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertSubjectDn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertSubjectDnLegacy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertSubjectDnrfc2253")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CertVerified")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TlsClientAuths");
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
