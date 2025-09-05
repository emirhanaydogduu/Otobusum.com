using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otobusum.com.Migrations
{
    /// <inheritdoc />
    public partial class AddOdemeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Durak",
                columns: table => new
                {
                    durak_id = table.Column<int>(type: "int", nullable: false),
                    ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sehir = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Durak__DFDE714158CECB0B", x => x.durak_id);
                });

            migrationBuilder.CreateTable(
                name: "Firma",
                columns: table => new
                {
                    firma_id = table.Column<int>(type: "int", nullable: false),
                    ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Firma__5F84B8AD91DA020A", x => x.firma_id);
                });

            migrationBuilder.CreateTable(
                name: "Personel",
                columns: table => new
                {
                    personel_id = table.Column<int>(type: "int", nullable: false),
                    ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    gorev = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Personel__48A5539F69FE9315", x => x.personel_id);
                });

            migrationBuilder.CreateTable(
                name: "Rota",
                columns: table => new
                {
                    rota_id = table.Column<int>(type: "int", nullable: false),
                    kalkis = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    varis = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    mesafe_km = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rota__0A3744CCBC8FDAFD", x => x.rota_id);
                });

            migrationBuilder.CreateTable(
                name: "Sofor",
                columns: table => new
                {
                    sofor_id = table.Column<int>(type: "int", nullable: false),
                    ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ehliyet_no = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sofor__8B25EFF8222A5BB1", x => x.sofor_id);
                });

            migrationBuilder.CreateTable(
                name: "Yolcu",
                columns: table => new
                {
                    yolcu_id = table.Column<int>(type: "int", nullable: false),
                    ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tc_no = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: false),
                    telefon = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Yolcu__A54471A5F81F16AA", x => x.yolcu_id);
                });

            migrationBuilder.CreateTable(
                name: "Otobus",
                columns: table => new
                {
                    otobus_id = table.Column<int>(type: "int", nullable: false),
                    firma_id = table.Column<int>(type: "int", nullable: false),
                    plaka = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    marka = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    kapasite = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Otobus__4CF290F25157024F", x => x.otobus_id);
                    table.ForeignKey(
                        name: "FK__Otobus__firma_id__4CA06362",
                        column: x => x.firma_id,
                        principalTable: "Firma",
                        principalColumn: "firma_id");
                });

            migrationBuilder.CreateTable(
                name: "Rota_Durak",
                columns: table => new
                {
                    rota_id = table.Column<int>(type: "int", nullable: false),
                    durak_id = table.Column<int>(type: "int", nullable: false),
                    durak_sirasi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rota_Dur__07CAA3D8AF38FE19", x => new { x.rota_id, x.durak_id });
                    table.ForeignKey(
                        name: "FK__Rota_Dura__durak__59063A47",
                        column: x => x.durak_id,
                        principalTable: "Durak",
                        principalColumn: "durak_id");
                    table.ForeignKey(
                        name: "FK__Rota_Dura__rota___5812160E",
                        column: x => x.rota_id,
                        principalTable: "Rota",
                        principalColumn: "rota_id");
                });

            migrationBuilder.CreateTable(
                name: "Yorum",
                columns: table => new
                {
                    yorum_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yolcu_id = table.Column<int>(type: "int", nullable: false),
                    puan = table.Column<int>(type: "int", nullable: false),
                    yorum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tarih = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Yorum__B0FA5C855DA639AD", x => x.yorum_id);
                    table.ForeignKey(
                        name: "FK__Yorum__yolcu_id__3E1D39E1",
                        column: x => x.yolcu_id,
                        principalTable: "Yolcu",
                        principalColumn: "yolcu_id");
                });

            migrationBuilder.CreateTable(
                name: "Bakim",
                columns: table => new
                {
                    bakim_id = table.Column<int>(type: "int", nullable: false),
                    otobus_id = table.Column<int>(type: "int", nullable: false),
                    personel_id = table.Column<int>(type: "int", nullable: false),
                    tarih = table.Column<DateOnly>(type: "date", nullable: false),
                    aciklama = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bakim__0F7162E5ED4A309F", x => x.bakim_id);
                    table.ForeignKey(
                        name: "FK__Bakim__otobus_id__619B8048",
                        column: x => x.otobus_id,
                        principalTable: "Otobus",
                        principalColumn: "otobus_id");
                    table.ForeignKey(
                        name: "FK__Bakim__personel___628FA481",
                        column: x => x.personel_id,
                        principalTable: "Personel",
                        principalColumn: "personel_id");
                });

            migrationBuilder.CreateTable(
                name: "Sefer",
                columns: table => new
                {
                    sefer_id = table.Column<int>(type: "int", nullable: false),
                    kalkis = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    varis = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tarih = table.Column<DateOnly>(type: "date", nullable: false),
                    saat = table.Column<TimeOnly>(type: "time", nullable: false),
                    fiyat = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    otobus_id = table.Column<int>(type: "int", nullable: false),
                    sofor_id = table.Column<int>(type: "int", nullable: false),
                    personel_id = table.Column<int>(type: "int", nullable: false),
                    rota_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sefer__AE50B52EFA215C81", x => x.sefer_id);
                    table.ForeignKey(
                        name: "FK__Sefer__otobus_id__5BE2A6F2",
                        column: x => x.otobus_id,
                        principalTable: "Otobus",
                        principalColumn: "otobus_id");
                    table.ForeignKey(
                        name: "FK__Sefer__personel___5DCAEF64",
                        column: x => x.personel_id,
                        principalTable: "Personel",
                        principalColumn: "personel_id");
                    table.ForeignKey(
                        name: "FK__Sefer__rota_id__5EBF139D",
                        column: x => x.rota_id,
                        principalTable: "Rota",
                        principalColumn: "rota_id");
                    table.ForeignKey(
                        name: "FK__Sefer__sofor_id__5CD6CB2B",
                        column: x => x.sofor_id,
                        principalTable: "Sofor",
                        principalColumn: "sofor_id");
                });

            migrationBuilder.CreateTable(
                name: "FirmaYorum",
                columns: table => new
                {
                    yorum_id = table.Column<int>(type: "int", nullable: false),
                    firma_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FirmaYor__B0FA5C85B2B40CE0", x => x.yorum_id);
                    table.ForeignKey(
                        name: "FK__FirmaYoru__firma__45BE5BA9",
                        column: x => x.firma_id,
                        principalTable: "Firma",
                        principalColumn: "firma_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__FirmaYoru__yorum__44CA3770",
                        column: x => x.yorum_id,
                        principalTable: "Yorum",
                        principalColumn: "yorum_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtobusYorum",
                columns: table => new
                {
                    yorum_id = table.Column<int>(type: "int", nullable: false),
                    otobus_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OtobusYo__B0FA5C85235E7CF3", x => x.yorum_id);
                    table.ForeignKey(
                        name: "FK__OtobusYor__otobu__498EEC8D",
                        column: x => x.otobus_id,
                        principalTable: "Otobus",
                        principalColumn: "otobus_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__OtobusYor__yorum__489AC854",
                        column: x => x.yorum_id,
                        principalTable: "Yorum",
                        principalColumn: "yorum_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoforYorum",
                columns: table => new
                {
                    yorum_id = table.Column<int>(type: "int", nullable: false),
                    sofor_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SoforYor__B0FA5C85D79B0A5B", x => x.yorum_id);
                    table.ForeignKey(
                        name: "FK__SoforYoru__sofor__4D5F7D71",
                        column: x => x.sofor_id,
                        principalTable: "Sofor",
                        principalColumn: "sofor_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__SoforYoru__yorum__4C6B5938",
                        column: x => x.yorum_id,
                        principalTable: "Yorum",
                        principalColumn: "yorum_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bilet",
                columns: table => new
                {
                    bilet_id = table.Column<int>(type: "int", nullable: false),
                    yolcu_id = table.Column<int>(type: "int", nullable: false),
                    sefer_id = table.Column<int>(type: "int", nullable: false),
                    koltuk_no = table.Column<int>(type: "int", nullable: false),
                    satis_tarihi = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bilet__033C9972EC0362BB", x => x.bilet_id);
                    table.ForeignKey(
                        name: "FK__Bilet__sefer_id__693CA210",
                        column: x => x.sefer_id,
                        principalTable: "Sefer",
                        principalColumn: "sefer_id");
                    table.ForeignKey(
                        name: "FK__Bilet__yolcu_id__68487DD7",
                        column: x => x.yolcu_id,
                        principalTable: "Yolcu",
                        principalColumn: "yolcu_id");
                });

            migrationBuilder.CreateTable(
                name: "Rezervasyon",
                columns: table => new
                {
                    rezervasyon_id = table.Column<int>(type: "int", nullable: false),
                    yolcu_id = table.Column<int>(type: "int", nullable: false),
                    sefer_id = table.Column<int>(type: "int", nullable: false),
                    koltuk_no = table.Column<int>(type: "int", nullable: false),
                    rezervasyon_tarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    durum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rezervas__770E0154E399A685", x => x.rezervasyon_id);
                    table.ForeignKey(
                        name: "FK__Rezervasy__sefer__6FE99F9F",
                        column: x => x.sefer_id,
                        principalTable: "Sefer",
                        principalColumn: "sefer_id");
                    table.ForeignKey(
                        name: "FK__Rezervasy__yolcu__6EF57B66",
                        column: x => x.yolcu_id,
                        principalTable: "Yolcu",
                        principalColumn: "yolcu_id");
                });

            migrationBuilder.CreateTable(
                name: "SeferYorum",
                columns: table => new
                {
                    yorum_id = table.Column<int>(type: "int", nullable: false),
                    sefer_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SeferYor__B0FA5C8586A56446", x => x.yorum_id);
                    table.ForeignKey(
                        name: "FK__SeferYoru__sefer__41EDCAC5",
                        column: x => x.sefer_id,
                        principalTable: "Sefer",
                        principalColumn: "sefer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__SeferYoru__yorum__40F9A68C",
                        column: x => x.yorum_id,
                        principalTable: "Yorum",
                        principalColumn: "yorum_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Odeme",
                columns: table => new
                {
                    odeme_id = table.Column<int>(type: "int", nullable: false),
                    bilet_id = table.Column<int>(type: "int", nullable: false),
                    odeme_tutari = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    odeme_tarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    odeme_tipi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Odeme__30746959D0F33946", x => x.odeme_id);
                    table.ForeignKey(
                        name: "FK__Odeme__bilet_id__6C190EBB",
                        column: x => x.bilet_id,
                        principalTable: "Bilet",
                        principalColumn: "bilet_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bakim_otobus_id",
                table: "Bakim",
                column: "otobus_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bakim_personel_id",
                table: "Bakim",
                column: "personel_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bilet_sefer_id",
                table: "Bilet",
                column: "sefer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bilet_yolcu_id",
                table: "Bilet",
                column: "yolcu_id");

            migrationBuilder.CreateIndex(
                name: "IX_FirmaYorum_firma_id",
                table: "FirmaYorum",
                column: "firma_id");

            migrationBuilder.CreateIndex(
                name: "IX_Odeme_bilet_id",
                table: "Odeme",
                column: "bilet_id");

            migrationBuilder.CreateIndex(
                name: "IX_Otobus_firma_id",
                table: "Otobus",
                column: "firma_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Otobus__0C052B2F76855E86",
                table: "Otobus",
                column: "plaka",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OtobusYorum_otobus_id",
                table: "OtobusYorum",
                column: "otobus_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyon_sefer_id",
                table: "Rezervasyon",
                column: "sefer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyon_yolcu_id",
                table: "Rezervasyon",
                column: "yolcu_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rota_Durak_durak_id",
                table: "Rota_Durak",
                column: "durak_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sefer_otobus_id",
                table: "Sefer",
                column: "otobus_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sefer_personel_id",
                table: "Sefer",
                column: "personel_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sefer_rota_id",
                table: "Sefer",
                column: "rota_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sefer_sofor_id",
                table: "Sefer",
                column: "sofor_id");

            migrationBuilder.CreateIndex(
                name: "IX_SeferYorum_sefer_id",
                table: "SeferYorum",
                column: "sefer_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Sofor__CE5DBA39EBEABFF8",
                table: "Sofor",
                column: "ehliyet_no",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoforYorum_sofor_id",
                table: "SoforYorum",
                column: "sofor_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Yolcu__E61FE7CA6EF1521D",
                table: "Yolcu",
                column: "tc_no",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_yolcu_id",
                table: "Yorum",
                column: "yolcu_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bakim");

            migrationBuilder.DropTable(
                name: "FirmaYorum");

            migrationBuilder.DropTable(
                name: "Odeme");

            migrationBuilder.DropTable(
                name: "OtobusYorum");

            migrationBuilder.DropTable(
                name: "Rezervasyon");

            migrationBuilder.DropTable(
                name: "Rota_Durak");

            migrationBuilder.DropTable(
                name: "SeferYorum");

            migrationBuilder.DropTable(
                name: "SoforYorum");

            migrationBuilder.DropTable(
                name: "Bilet");

            migrationBuilder.DropTable(
                name: "Durak");

            migrationBuilder.DropTable(
                name: "Yorum");

            migrationBuilder.DropTable(
                name: "Sefer");

            migrationBuilder.DropTable(
                name: "Yolcu");

            migrationBuilder.DropTable(
                name: "Otobus");

            migrationBuilder.DropTable(
                name: "Personel");

            migrationBuilder.DropTable(
                name: "Rota");

            migrationBuilder.DropTable(
                name: "Sofor");

            migrationBuilder.DropTable(
                name: "Firma");
        }
    }
}
