﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhasmoRESTApi.Data;

namespace PhasmoRESTApi.Migrations
{
    [DbContext(typeof(PhasmoContext))]
    partial class PhasmoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhasmoRESTApi.Models.Evidence", b =>
                {
                    b.Property<long>("EvidenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EvidenceId");

                    b.ToTable("Evidences");
                });

            modelBuilder.Entity("PhasmoRESTApi.Models.Ghost", b =>
                {
                    b.Property<long>("GhostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Strengths")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weaknesses")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GhostId");

                    b.ToTable("Ghosts");
                });

            modelBuilder.Entity("PhasmoRESTApi.Models.Ghost_Evidence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("EvidenceId")
                        .HasColumnType("bigint");

                    b.Property<long>("GhostId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EvidenceId");

                    b.HasIndex("GhostId");

                    b.ToTable("Ghost_Evidences");
                });

            modelBuilder.Entity("PhasmoRESTApi.Models.Ghost_Evidence", b =>
                {
                    b.HasOne("PhasmoRESTApi.Models.Evidence", "Evidence")
                        .WithMany("Ghost_Evidences")
                        .HasForeignKey("EvidenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PhasmoRESTApi.Models.Ghost", "Ghost")
                        .WithMany("Ghost_Evidences")
                        .HasForeignKey("GhostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evidence");

                    b.Navigation("Ghost");
                });

            modelBuilder.Entity("PhasmoRESTApi.Models.Evidence", b =>
                {
                    b.Navigation("Ghost_Evidences");
                });

            modelBuilder.Entity("PhasmoRESTApi.Models.Ghost", b =>
                {
                    b.Navigation("Ghost_Evidences");
                });
#pragma warning restore 612, 618
        }
    }
}
