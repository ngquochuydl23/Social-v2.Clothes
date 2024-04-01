﻿// <auto-generated />
using System;
using Clothes.ProductManagement.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Clothes.ProductManagement.Api.Migrations
{
    [DbContext(typeof(ClothesProductContext))]
    partial class ClothesProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Clothes.ProductManagement.Api.Infrastructure.Entities.Categories.CategoryEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Handle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ParentCategoryId")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Clothes.ProductManagement.Api.Infrastructure.Entities.Collections.CollectionEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Handle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Collection", (string)null);
                });

            modelBuilder.Entity("Clothes.ProductManagement.Api.Infrastructure.Entities.ProductTags.TagEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tag", (string)null);
                });

            modelBuilder.Entity("Clothes.ProductManagement.Api.Infrastructure.Entities.ProductTypes.ProductTypeEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductType", (string)null);
                });

            modelBuilder.Entity("Clothes.ProductManagement.Api.Infrastructure.Entities.Products.ProductCategoryEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategory", (string)null);
                });

            modelBuilder.Entity("Clothes.ProductManagement.Api.Infrastructure.Entities.Products.ProductEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("CollectionId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Discountable")
                        .HasColumnType("boolean");

                    b.Property<string>("Handle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsGiftCard")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ProductTypeId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Subtitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Clothes.ProductManagement.Api.Infrastructure.Entities.Products.ProductTagEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("TagId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("TagId");

                    b.ToTable("ProductTag", (string)null);
                });

            modelBuilder.Entity("Clothes.ProductManagement.Api.Infrastructure.Entities.Categories.CategoryEntity", b =>
                {
                    b.HasOne("Clothes.ProductManagement.Api.Infrastructure.Entities.Categories.CategoryEntity", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Clothes.ProductManagement.Api.Infrastructure.Entities.Products.ProductCategoryEntity", b =>
                {
                    b.HasOne("Clothes.ProductManagement.Api.Infrastructure.Entities.Categories.CategoryEntity", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clothes.ProductManagement.Api.Infrastructure.Entities.Products.ProductEntity", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Clothes.ProductManagement.Api.Infrastructure.Entities.Products.ProductEntity", b =>
                {
                    b.HasOne("Clothes.ProductManagement.Api.Infrastructure.Entities.Collections.CollectionEntity", "Collection")
                        .WithMany("Products")
                        .HasForeignKey("CollectionId");

                    b.HasOne("Clothes.ProductManagement.Api.Infrastructure.Entities.ProductTypes.ProductTypeEntity", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("Clothes.ProductManagement.Api.Infrastructure.Entities.Products.ProductTagEntity", b =>
                {
                    b.HasOne("Clothes.ProductManagement.Api.Infrastructure.Entities.Products.ProductEntity", "Product")
                        .WithMany("ProductTags")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clothes.ProductManagement.Api.Infrastructure.Entities.ProductTags.TagEntity", "Tag")
                        .WithMany("ProductTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Clothes.ProductManagement.Api.Infrastructure.Entities.Categories.CategoryEntity", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("Clothes.ProductManagement.Api.Infrastructure.Entities.Collections.CollectionEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Clothes.ProductManagement.Api.Infrastructure.Entities.ProductTags.TagEntity", b =>
                {
                    b.Navigation("ProductTags");
                });

            modelBuilder.Entity("Clothes.ProductManagement.Api.Infrastructure.Entities.ProductTypes.ProductTypeEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Clothes.ProductManagement.Api.Infrastructure.Entities.Products.ProductEntity", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("ProductTags");
                });
#pragma warning restore 612, 618
        }
    }
}
