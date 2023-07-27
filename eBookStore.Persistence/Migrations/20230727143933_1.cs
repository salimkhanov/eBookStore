using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBookStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Adresses");

            migrationBuilder.EnsureSchema(
                name: "Countries");

            migrationBuilder.EnsureSchema(
                name: "OrderStatus");

            migrationBuilder.EnsureSchema(
                name: "PaymentTypes");

            migrationBuilder.EnsureSchema(
                name: "Roles");

            migrationBuilder.EnsureSchema(
                name: "ShippingMethods");

            migrationBuilder.EnsureSchema(
                name: "ShopOrders");

            migrationBuilder.EnsureSchema(
                name: "ShoppingCartItems");

            migrationBuilder.EnsureSchema(
                name: "ShoppingCarts");

            migrationBuilder.EnsureSchema(
                name: "UserPaymentMethods");

            migrationBuilder.EnsureSchema(
                name: "UserReviews");

            migrationBuilder.EnsureSchema(
                name: "Users");

            migrationBuilder.EnsureSchema(
                name: "UserAdresses");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Countries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COUNTRY_NAME = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENTITY_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                schema: "OrderStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STATUS = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENTITY_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                schema: "PaymentTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VALUE = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENTITY_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORDER_INDEX = table.Column<int>(type: "int", nullable: false),
                    ENTITY_STATUS = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethods",
                schema: "ShippingMethods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    PRICE = table.Column<double>(type: "float", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENTITY_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethods", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    LAST_NAME = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    ENTITY_STATUS = table.Column<byte>(type: "tinyint", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "Adresses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UNIT_NUMBER = table.Column<int>(type: "int", nullable: false),
                    STREET_NUMBER = table.Column<int>(type: "int", nullable: false),
                    FULL_ADDRESS = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    CITY = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    REGION = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    POSTAL_CODE = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    COUNTRY_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENTITY_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_COUNTRY_ID",
                        column: x => x.COUNTRY_ID,
                        principalSchema: "Countries",
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Roles",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Roles",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                schema: "ShoppingCarts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENTITY_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Users_USER_ID",
                        column: x => x.USER_ID,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPaymentMethods",
                schema: "UserPaymentMethods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    PAYMENT_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    PROVIDER = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    ACCOUNT_NUMBER = table.Column<int>(type: "int", nullable: false),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IS_DEFAULT = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENTITY_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPaymentMethods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserPaymentMethods_PaymentTypes_PAYMENT_TYPE_ID",
                        column: x => x.PAYMENT_TYPE_ID,
                        principalSchema: "PaymentTypes",
                        principalTable: "PaymentTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPaymentMethods_Users_USER_ID",
                        column: x => x.USER_ID,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserReviews",
                schema: "UserReviews",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    ORDER_LINE_ID = table.Column<int>(type: "int", nullable: false),
                    RATING_VALUE = table.Column<int>(type: "int", nullable: false),
                    COMMENT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENTITY_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReviews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserReviews_Users_USER_ID",
                        column: x => x.USER_ID,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersAddresses",
                schema: "UserAdresses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    ADDRESS_ID = table.Column<int>(type: "int", nullable: false),
                    IS_DEFAULT = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENTITY_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAddresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsersAddresses_Addresses_ADDRESS_ID",
                        column: x => x.ADDRESS_ID,
                        principalSchema: "Adresses",
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersAddresses_Users_USER_ID",
                        column: x => x.USER_ID,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                schema: "ShoppingCartItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CART_ID = table.Column<int>(type: "int", nullable: false),
                    BOOK_ITEM_ID = table.Column<int>(type: "int", nullable: false),
                    QUANTITY = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENTITY_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_ShoppingCarts_CART_ID",
                        column: x => x.CART_ID,
                        principalSchema: "ShoppingCarts",
                        principalTable: "ShoppingCarts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopOrders",
                schema: "ShopOrders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    ORDER_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USER_PAYMENT_METHOD_ID = table.Column<int>(type: "int", nullable: false),
                    ADDRESS_ID = table.Column<int>(type: "int", nullable: false),
                    SHIPPING_METHOD_ID = table.Column<int>(type: "int", nullable: false),
                    ORDER_TOTAL = table.Column<int>(type: "int", nullable: false),
                    ORDER_STATUS_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENTITY_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShopOrders_Addresses_ADDRESS_ID",
                        column: x => x.ADDRESS_ID,
                        principalSchema: "Adresses",
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopOrders_OrderStatus_ORDER_STATUS_ID",
                        column: x => x.ORDER_STATUS_ID,
                        principalSchema: "OrderStatus",
                        principalTable: "OrderStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopOrders_ShippingMethods_SHIPPING_METHOD_ID",
                        column: x => x.SHIPPING_METHOD_ID,
                        principalSchema: "ShippingMethods",
                        principalTable: "ShippingMethods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopOrders_UserPaymentMethods_USER_PAYMENT_METHOD_ID",
                        column: x => x.USER_PAYMENT_METHOD_ID,
                        principalSchema: "UserPaymentMethods",
                        principalTable: "UserPaymentMethods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopOrders_Users_USER_ID",
                        column: x => x.USER_ID,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_COUNTRY_ID",
                schema: "Adresses",
                table: "Addresses",
                column: "COUNTRY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Roles",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrders_ADDRESS_ID",
                schema: "ShopOrders",
                table: "ShopOrders",
                column: "ADDRESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrders_ORDER_STATUS_ID",
                schema: "ShopOrders",
                table: "ShopOrders",
                column: "ORDER_STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrders_SHIPPING_METHOD_ID",
                schema: "ShopOrders",
                table: "ShopOrders",
                column: "SHIPPING_METHOD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrders_USER_ID",
                schema: "ShopOrders",
                table: "ShopOrders",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrders_USER_PAYMENT_METHOD_ID",
                schema: "ShopOrders",
                table: "ShopOrders",
                column: "USER_PAYMENT_METHOD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_CART_ID",
                schema: "ShoppingCartItems",
                table: "ShoppingCartItems",
                column: "CART_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_USER_ID",
                schema: "ShoppingCarts",
                table: "ShoppingCarts",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPaymentMethods_PAYMENT_TYPE_ID",
                schema: "UserPaymentMethods",
                table: "UserPaymentMethods",
                column: "PAYMENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPaymentMethods_USER_ID",
                schema: "UserPaymentMethods",
                table: "UserPaymentMethods",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_USER_ID",
                schema: "UserReviews",
                table: "UserReviews",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Users",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Users",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsersAddresses_ADDRESS_ID",
                schema: "UserAdresses",
                table: "UsersAddresses",
                column: "ADDRESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersAddresses_USER_ID",
                schema: "UserAdresses",
                table: "UsersAddresses",
                column: "USER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ShopOrders",
                schema: "ShopOrders");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems",
                schema: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "UserReviews",
                schema: "UserReviews");

            migrationBuilder.DropTable(
                name: "UsersAddresses",
                schema: "UserAdresses");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Roles");

            migrationBuilder.DropTable(
                name: "OrderStatus",
                schema: "OrderStatus");

            migrationBuilder.DropTable(
                name: "ShippingMethods",
                schema: "ShippingMethods");

            migrationBuilder.DropTable(
                name: "UserPaymentMethods",
                schema: "UserPaymentMethods");

            migrationBuilder.DropTable(
                name: "ShoppingCarts",
                schema: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "Adresses");

            migrationBuilder.DropTable(
                name: "PaymentTypes",
                schema: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Countries");
        }
    }
}
