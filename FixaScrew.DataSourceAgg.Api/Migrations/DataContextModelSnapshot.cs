// <auto-generated />
using FixaScrew.DataSourceAgg.Api.Extensions;
using FixaScrew.DataSourceAgg.Common.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FixaScrew.DataSourceAgg.Api.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("FixaScrew.DataSourceAgg.Common.Entities.SQLDataStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Product")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StockAmount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("DataStore");
                });
#pragma warning restore 612, 618
        }
    }
}
