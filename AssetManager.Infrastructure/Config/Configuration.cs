using AssetManager.Domain.Entities;
using AssetManager.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssetManager.Infrastructure.Config;

internal sealed class Configuration : IEntityTypeConfiguration<Area>,
    IEntityTypeConfiguration<Asset>,
    IEntityTypeConfiguration<Camera>,
    IEntityTypeConfiguration<Recorder>,
    IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        builder.HasKey(i => i.Id);

        builder
            .Property(i => i.Id)
            .HasConversion(i => i.Value, i => new AreaId(i));

        builder
            .Property(i => i.Name)
            .HasConversion(i => i.Name, i => new AreaName(i));


        builder.HasMany(i => i.Assets);

        builder.HasMany(i => i.Owners);
        
        builder.ToTable("Areas");
    }

    public void Configure(EntityTypeBuilder<Asset> builder)
    {            
        
        builder.HasKey(i => i.Id);

        builder
            .Property(i => i.Id)
            .HasConversion(i => i.Value, i => new AssetId(i));

        builder
            .Property(i => i.Name)
            .HasConversion(i => i.Name, i => new AssetName(i))
            .HasColumnName("Name");

        builder.Property( i => i.IpId)
            .HasConversion(i => i.IpAddress, i => new AssetIpId(i))
            .HasColumnName("IpId");
        
        builder.Property(i => i.Port)
            .HasConversion(i => i.Port, i => new ClientPort(i))
            .HasColumnName("Client Port");
        
        builder.Property(i => i.UserName)
            .HasConversion(i => i.Value, i => new UserName(i))
            .HasColumnName("UserName");
        
        builder.Property(i => i.Password)
            .HasConversion(i => i.Value, i => new Password(i))
            .HasColumnName("Password");

        builder.HasMany(i => i.Owners);
  
        builder.ToTable("Assets");
    }

    public void Configure(EntityTypeBuilder<Camera> builder)
    {
        builder.HasBaseType<Asset>();
        builder.ToTable("Cameras");
    }

    public void Configure(EntityTypeBuilder<Recorder> builder)
    {
        builder.HasBaseType<Asset>();
        builder.HasMany<Camera>();
        builder.ToTable("Recorders");
    }

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(i => i.Id);

        builder
            .Property(i => i.Id)
            .HasConversion(i => i.Value, i => new UserId(i));

        builder.Property(i => i.FirstName)
            .HasColumnName("FirstName");

        builder.Property(i => i.LastName)
            .HasColumnName("LastName");

        builder.Property(i => i.Username)
            .HasColumnName("Username");

        builder.Property(i => i.Password)
            .HasColumnName("Password");

        builder.Property(i => i.Role)
            .HasColumnName("Role");

        builder.ToTable("Users");
    }
}