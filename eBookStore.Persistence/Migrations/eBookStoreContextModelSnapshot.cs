﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eBookStore.Persistence.Data;

#nullable disable

namespace eBookStore.Persistence.Migrations
{
    [DbContext(typeof(eBookStoreContext))]
    partial class eBookStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CITY");

                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("COUNTRY_ID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED_AT");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int")
                        .HasColumnName("ENTITY_STATUS");

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasColumnName("FULL_ADDRESS");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("POSTAL_CODE");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("REGION");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int")
                        .HasColumnName("STREET_NUMBER");

                    b.Property<int>("UnitNumber")
                        .HasColumnType("int")
                        .HasColumnName("UNIT_NUMBER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED_AT");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Addresses", "Adresses");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("COUNTRY_NAME");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED_AT");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int")
                        .HasColumnName("ENTITY_STATUS");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED_AT");

                    b.HasKey("Id");

                    b.ToTable("Countries", "Countries");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED_AT");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int")
                        .HasColumnName("ENTITY_STATUS");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("STATUS");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED_AT");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus", "OrderStatus");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED_AT");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int")
                        .HasColumnName("ENTITY_STATUS");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED_AT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("VALUE");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes", "PaymentTypes");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("EntityStatus")
                        .HasColumnType("tinyint")
                        .HasColumnName("ENTITY_STATUS");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("OrderIndex")
                        .HasColumnType("int")
                        .HasColumnName("ORDER_INDEX");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", "Roles");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.ShippingMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED_AT");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int")
                        .HasColumnName("ENTITY_STATUS");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(120)")
                        .HasColumnName("NAME");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("PRICE");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED_AT");

                    b.HasKey("Id");

                    b.ToTable("ShippingMethods", "ShippingMethods");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.ShopOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("ADDRESS_ID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED_AT");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int")
                        .HasColumnName("ENTITY_STATUS");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ORDER_DATE");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int")
                        .HasColumnName("ORDER_STATUS_ID");

                    b.Property<int>("OrderTotal")
                        .HasColumnType("int")
                        .HasColumnName("ORDER_TOTAL");

                    b.Property<int>("ShippingMethodId")
                        .HasColumnType("int")
                        .HasColumnName("SHIPPING_METHOD_ID");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED_AT");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.Property<int>("UserPaymentMethodId")
                        .HasColumnType("int")
                        .HasColumnName("USER_PAYMENT_METHOD_ID");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("ShippingMethodId");

                    b.HasIndex("UserPaymentMethodId");

                    b.ToTable("ShopOrders", "ShopOrders");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED_AT");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int")
                        .HasColumnName("ENTITY_STATUS");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED_AT");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ShoppingCarts", "ShoppingCarts");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.ShoppingCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookItemId")
                        .HasColumnType("int")
                        .HasColumnName("BOOK_ITEM_ID");

                    b.Property<int>("CartId")
                        .HasColumnType("int")
                        .HasColumnName("CART_ID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED_AT");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int")
                        .HasColumnName("ENTITY_STATUS");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("QUANTITY");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED_AT");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("ShoppingCartItems", "ShoppingCartItems");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte>("EntityStatus")
                        .HasColumnType("tinyint")
                        .HasColumnName("ENTITY_STATUS");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("FIRST_NAME");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("LAST_NAME");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", "Users");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.UserAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("ADDRESS_ID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED_AT");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int")
                        .HasColumnName("ENTITY_STATUS");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit")
                        .HasColumnName("IS_DEFAULT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED_AT");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersAddresses", "UserAdresses");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.UserPaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountNumber")
                        .HasColumnType("int")
                        .HasColumnName("ACCOUNT_NUMBER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED_AT");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int")
                        .HasColumnName("ENTITY_STATUS");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("EXPIRY_DATE");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit")
                        .HasColumnName("IS_DEFAULT");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("int")
                        .HasColumnName("PAYMENT_TYPE_ID");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasColumnName("PROVIDER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED_AT");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.HasIndex("PaymentTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPaymentMethods", "UserPaymentMethods");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.UserReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("COMMENT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED_AT");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int")
                        .HasColumnName("ENTITY_STATUS");

                    b.Property<int>("OrderLineId")
                        .HasColumnType("int")
                        .HasColumnName("ORDER_LINE_ID");

                    b.Property<int>("RatingValue")
                        .HasColumnType("int")
                        .HasColumnName("RATING_VALUE");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED_AT");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserReviews", "UserReviews");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("eBookStore.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("eBookStore.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("eBookStore.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("eBookStore.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eBookStore.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("eBookStore.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.Address", b =>
                {
                    b.HasOne("eBookStore.Domain.Entities.Country", "Country")
                        .WithMany("Addresses")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.ShopOrder", b =>
                {
                    b.HasOne("eBookStore.Domain.Entities.Address", "Address")
                        .WithMany("ShopOrders")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eBookStore.Domain.Entities.OrderStatus", "OrderStatus")
                        .WithMany("ShopOrders")
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eBookStore.Domain.Entities.ShippingMethod", "ShippingMethod")
                        .WithMany("ShopOrders")
                        .HasForeignKey("ShippingMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eBookStore.Domain.Entities.UserPaymentMethod", "UserPaymentMethod")
                        .WithMany("ShopOrders")
                        .HasForeignKey("UserPaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("OrderStatus");

                    b.Navigation("ShippingMethod");

                    b.Navigation("UserPaymentMethod");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.ShoppingCart", b =>
                {
                    b.HasOne("eBookStore.Domain.Entities.User", "User")
                        .WithMany("ShoppingCart")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.ShoppingCartItem", b =>
                {
                    b.HasOne("eBookStore.Domain.Entities.ShoppingCart", "ShoppingCart")
                        .WithMany("ShoppingCartItem")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.UserAddress", b =>
                {
                    b.HasOne("eBookStore.Domain.Entities.Address", "Address")
                        .WithMany("UserAddress")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eBookStore.Domain.Entities.User", "User")
                        .WithMany("UserAddress")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.UserPaymentMethod", b =>
                {
                    b.HasOne("eBookStore.Domain.Entities.PaymentType", "PaymentType")
                        .WithMany("UserPaymentMethod")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eBookStore.Domain.Entities.User", "User")
                        .WithMany("UserPaymentMethod")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.UserReview", b =>
                {
                    b.HasOne("eBookStore.Domain.Entities.User", "User")
                        .WithMany("UserReview")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.Address", b =>
                {
                    b.Navigation("ShopOrders");

                    b.Navigation("UserAddress");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.Country", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.OrderStatus", b =>
                {
                    b.Navigation("ShopOrders");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.PaymentType", b =>
                {
                    b.Navigation("UserPaymentMethod");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.ShippingMethod", b =>
                {
                    b.Navigation("ShopOrders");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.ShoppingCart", b =>
                {
                    b.Navigation("ShoppingCartItem");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.User", b =>
                {
                    b.Navigation("ShoppingCart");

                    b.Navigation("UserAddress");

                    b.Navigation("UserPaymentMethod");

                    b.Navigation("UserReview");
                });

            modelBuilder.Entity("eBookStore.Domain.Entities.UserPaymentMethod", b =>
                {
                    b.Navigation("ShopOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
