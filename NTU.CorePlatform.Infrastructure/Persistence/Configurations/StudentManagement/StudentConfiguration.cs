using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTU.CorePlatform.Domain.Entities.Identity;
using NTU.CorePlatform.Domain.Entities.StudentManagement;

namespace NTU.CorePlatform.Infrastructure.Persistence.Configurations.StudentManagement;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        builder.HasKey(x => x.Id);

        // Thông tin sinh viên
        builder.Property(x => x.StudentCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(x => x.StudentCode)
            .IsUnique();

        builder.Property(x => x.FullName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.DateOfBirth)
            .IsRequired();

        builder.Property(x => x.Gender)
            .HasMaxLength(20);

        // Giấy tờ & Liên hệ
        builder.Property(x => x.IdentityNumber)
            .HasMaxLength(20);

        builder.Property(x => x.Email)
            .HasMaxLength(150);

        builder.Property(x => x.MobilePhoneNumber)
            .HasMaxLength(20);

        builder.Property(x => x.HomePhoneNumber)
            .HasMaxLength(20);

        // Thông tin cá nhân
        builder.Property(x => x.PlaceOfBirth).HasMaxLength(100);
        builder.Property(x => x.Hometown).HasMaxLength(100);
        builder.Property(x => x.Nationality).HasMaxLength(50);
        builder.Property(x => x.Ethnicity).HasMaxLength(50);
        builder.Property(x => x.Religion).HasMaxLength(50);
        builder.Property(x => x.PlaceOfOrigin).HasMaxLength(150);

        // Địa chỉ
        builder.Property(x => x.PermanentAddress).HasMaxLength(255);
        builder.Property(x => x.Ward).HasMaxLength(100);
        builder.Property(x => x.District).HasMaxLength(100);
        builder.Property(x => x.Province).HasMaxLength(100);
        builder.Property(x => x.CurrentAddress).HasMaxLength(255);
        builder.Property(x => x.MailingAddress).HasMaxLength(255);

        // Chính sách
        builder.Property(x => x.PolicyBeneficiary).HasMaxLength(100);
        builder.Property(x => x.AllowanceBeneficiary).HasMaxLength(100);
        builder.Property(x => x.TargetGroup).HasMaxLength(100);

        // Quan hệ 1-1 với User
        builder.HasOne(x => x.User)
            .WithOne(x => x.Student)
            .HasForeignKey<Student>(x => x.UserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
