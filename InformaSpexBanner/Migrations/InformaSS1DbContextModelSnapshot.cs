using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using InformaSpexBanner.Data;

namespace InformaSpexBanner.Migrations
{
    [DbContext(typeof(InformaSS1DbContext))]
    partial class InformaSS1DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InformaSpexBanner.Entities.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExhibitionId");

                    b.Property<byte[]>("Image");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ExhibitionId");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("InformaSpexBanner.Entities.CustomText", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BannerId");

                    b.Property<string>("FixedText");

                    b.Property<string>("FontColorHex");

                    b.Property<int>("FontSize");

                    b.Property<string>("FontTypeFace");

                    b.Property<int>("PositionX");

                    b.Property<int>("PositionY");

                    b.HasKey("Id");

                    b.HasIndex("BannerId")
                        .IsUnique();

                    b.ToTable("CustomTexts");
                });

            modelBuilder.Entity("InformaSpexBanner.Entities.Exhibition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("WebUrl");

                    b.HasKey("Id");

                    b.ToTable("Exhibitions");
                });

            modelBuilder.Entity("InformaSpexBanner.Entities.Banner", b =>
                {
                    b.HasOne("InformaSpexBanner.Entities.Exhibition", "Exhibition")
                        .WithMany("Banners")
                        .HasForeignKey("ExhibitionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InformaSpexBanner.Entities.CustomText", b =>
                {
                    b.HasOne("InformaSpexBanner.Entities.Banner", "Banner")
                        .WithOne("Text")
                        .HasForeignKey("InformaSpexBanner.Entities.CustomText", "BannerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
