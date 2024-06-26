﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Social_v2.Clothes.Api.Infrastructure;

#nullable disable

namespace Social_v2.Clothes.Api.Migrations
{
    [DbContext(typeof(ClothesDbContext))]
    [Migration("20231220023312_ChangeSkuToVarient")]
    partial class ChangeSkuToVarient
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Categories.CategoryEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int>("ForGender")
                        .HasColumnType("integer");

                    b.Property<string>("Handle")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("ParentCategoryId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Categories.CategoryProductEntity", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("text");

                    b.Property<string>("CategoryId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryProduct", (string)null);
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Collections.CollectionEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Handle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Collection", (string)null);
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.DeliveryAddresses.DeliveryAddressEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DetailAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<string>("ProvinceOrCity")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("WardOrCommune")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DeliveryAddress", (string)null);
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Inventories.InventoryEntity", b =>
                {
                    b.Property<string>("ProductSkuId")
                        .HasColumnType("text");

                    b.Property<bool>("AllowBackOrder")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Ean")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("StockLocationId")
                        .HasColumnType("text");

                    b.Property<int>("Upc")
                        .HasColumnType("integer");

                    b.HasKey("ProductSkuId");

                    b.ToTable("Inventory", (string)null);
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("CollectionId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateAt")
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

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

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

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductOptionEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductOption", (string)null);
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductOptionValueEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("OptionId")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OptionId");

                    b.ToTable("ProductOptionValue", (string)null);
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductSkuMediaEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("Height")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Mime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductVarientId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Width")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductVarientId");

                    b.ToTable("ProductVarientMedia", (string)null);
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductVarientEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductVarient", (string)null);
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Products.VarientValueEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ProductOptionId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductOptionValueId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductVarientId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductOptionId");

                    b.HasIndex("ProductOptionValueId");

                    b.HasIndex("ProductVarientId");

                    b.ToTable("VarientValue", (string)null);
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.StockLocations.StockLocationInventoryEntity", b =>
                {
                    b.Property<string>("ProductSkuId")
                        .HasColumnType("text");

                    b.Property<string>("StockLocationId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ProductSkuId", "StockLocationId");

                    b.ToTable("StockLocationInventory", (string)null);
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Stores.StockLocationEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DetailAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<string>("ProvinceOrCity")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("WardOrCommune")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("StockLocationEntity");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Users.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Wishlists.WishlistEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ProductSkuId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductSkuId")
                        .IsUnique();

                    b.ToTable("Wishlist", (string)null);
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Categories.CategoryEntity", b =>
                {
                    b.HasOne("Social_v2.Clothes.Api.Infrastructure.Entities.Categories.CategoryEntity", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Categories.CategoryProductEntity", b =>
                {
                    b.HasOne("Social_v2.Clothes.Api.Infrastructure.Entities.Categories.CategoryEntity", "Category")
                        .WithMany("CategoryProducts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductEntity", "Product")
                        .WithMany("CategoryProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.DeliveryAddresses.DeliveryAddressEntity", b =>
                {
                    b.HasOne("Social_v2.Clothes.Api.Infrastructure.Entities.Users.UserEntity", "User")
                        .WithMany("DeliveryAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Inventories.InventoryEntity", b =>
                {
                    b.HasOne("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductVarientEntity", "ProductSku")
                        .WithOne("Inventory")
                        .HasForeignKey("Social_v2.Clothes.Api.Infrastructure.Entities.Inventories.InventoryEntity", "ProductSkuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductSku");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductEntity", b =>
                {
                    b.HasOne("Social_v2.Clothes.Api.Infrastructure.Entities.Collections.CollectionEntity", "Collection")
                        .WithMany("Products")
                        .HasForeignKey("CollectionId");

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductOptionEntity", b =>
                {
                    b.HasOne("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductEntity", "Product")
                        .WithMany("Options")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductOptionValueEntity", b =>
                {
                    b.HasOne("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductOptionEntity", "Option")
                        .WithMany("OptionValues")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Option");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductSkuMediaEntity", b =>
                {
                    b.HasOne("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductVarientEntity", "ProductVarient")
                        .WithMany("ProductMedias")
                        .HasForeignKey("ProductVarientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductVarient");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductVarientEntity", b =>
                {
                    b.HasOne("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductEntity", "Product")
                        .WithMany("ProductVarients")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Products.VarientValueEntity", b =>
                {
                    b.HasOne("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductEntity", "Product")
                        .WithMany("VarientValues")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductOptionEntity", "ProductOption")
                        .WithMany("VarientValues")
                        .HasForeignKey("ProductOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductOptionValueEntity", "ProductOptionValue")
                        .WithMany("VarientValues")
                        .HasForeignKey("ProductOptionValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductVarientEntity", "ProductVarient")
                        .WithMany("VarientValues")
                        .HasForeignKey("ProductVarientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductOption");

                    b.Navigation("ProductOptionValue");

                    b.Navigation("ProductVarient");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.StockLocations.StockLocationInventoryEntity", b =>
                {
                    b.HasOne("Social_v2.Clothes.Api.Infrastructure.Entities.Stores.StockLocationEntity", "StockLocation")
                        .WithMany("StockLocationInventories")
                        .HasForeignKey("ProductSkuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Social_v2.Clothes.Api.Infrastructure.Entities.Inventories.InventoryEntity", "Inventory")
                        .WithMany("StockLocationInventories")
                        .HasForeignKey("ProductSkuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");

                    b.Navigation("StockLocation");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Wishlists.WishlistEntity", b =>
                {
                    b.HasOne("Social_v2.Clothes.Api.Infrastructure.Entities.Users.UserEntity", "Customer")
                        .WithMany("Wishlists")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductVarientEntity", "ProductSku")
                        .WithOne("Wishlist")
                        .HasForeignKey("Social_v2.Clothes.Api.Infrastructure.Entities.Wishlists.WishlistEntity", "ProductSkuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("ProductSku");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Categories.CategoryEntity", b =>
                {
                    b.Navigation("CategoryProducts");

                    b.Navigation("ChildCategories");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Collections.CollectionEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Inventories.InventoryEntity", b =>
                {
                    b.Navigation("StockLocationInventories");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductEntity", b =>
                {
                    b.Navigation("CategoryProducts");

                    b.Navigation("Options");

                    b.Navigation("ProductVarients");

                    b.Navigation("VarientValues");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductOptionEntity", b =>
                {
                    b.Navigation("OptionValues");

                    b.Navigation("VarientValues");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductOptionValueEntity", b =>
                {
                    b.Navigation("VarientValues");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Products.ProductVarientEntity", b =>
                {
                    b.Navigation("Inventory")
                        .IsRequired();

                    b.Navigation("ProductMedias");

                    b.Navigation("VarientValues");

                    b.Navigation("Wishlist")
                        .IsRequired();
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Stores.StockLocationEntity", b =>
                {
                    b.Navigation("StockLocationInventories");
                });

            modelBuilder.Entity("Social_v2.Clothes.Api.Infrastructure.Entities.Users.UserEntity", b =>
                {
                    b.Navigation("DeliveryAddresses");

                    b.Navigation("Wishlists");
                });
#pragma warning restore 612, 618
        }
    }
}
