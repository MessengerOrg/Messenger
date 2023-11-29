﻿// <auto-generated />
using System;
using Messenger.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Messenger.Services.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230531050137_DateOfLastAccess")]
    partial class DateOfLastAccess
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Messenger.Domain.Entities.AttachmentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uuid");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("Messenger.Domain.Entities.BanUserByChatEntity", b =>
                {
                    b.Property<Guid>("ChatId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BanDateOfExpire")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ChatId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("BanUserByChats");
                });

            modelBuilder.Entity("Messenger.Domain.Entities.ChatEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AvatarFileName")
                        .HasColumnType("text");

                    b.Property<Guid?>("LastMessageId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LastMessageId")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.ToTable("Chats");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2975dbfe-bc05-4962-ba85-e4d1b4e8f7a8"),
                            AvatarFileName = "dotnetchat.jpg",
                            Name = "DotNetRuChat",
                            OwnerId = new Guid("5aef3c7f-8040-4a99-9a3d-388695e55763"),
                            Title = "DotNetRuChat",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("2b56ee19-fe9c-4fab-884b-ff7d85a9f337"),
                            AvatarFileName = "dotnettalkschat.jpg",
                            Name = "dotnettalks",
                            OwnerId = new Guid("ee677bde-c6e6-40b3-8294-5fb5e913202a"),
                            Title = ".NET Talks",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("f69acb05-018c-4626-9e70-46fbb5dfde6f"),
                            Type = 0
                        });
                });

            modelBuilder.Entity("Messenger.Domain.Entities.ChatUserEntity", b =>
                {
                    b.Property<Guid>("ChatId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("CanSendMedia")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("MuteDateOfExpire")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ChatId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ChatUsers");

                    b.HasData(
                        new
                        {
                            ChatId = new Guid("2975dbfe-bc05-4962-ba85-e4d1b4e8f7a8"),
                            UserId = new Guid("5aef3c7f-8040-4a99-9a3d-388695e55763"),
                            CanSendMedia = true
                        },
                        new
                        {
                            ChatId = new Guid("2975dbfe-bc05-4962-ba85-e4d1b4e8f7a8"),
                            UserId = new Guid("ee677bde-c6e6-40b3-8294-5fb5e913202a"),
                            CanSendMedia = true
                        },
                        new
                        {
                            ChatId = new Guid("2975dbfe-bc05-4962-ba85-e4d1b4e8f7a8"),
                            UserId = new Guid("a85825ba-f99b-4177-a858-96384303ea14"),
                            CanSendMedia = true
                        },
                        new
                        {
                            ChatId = new Guid("2975dbfe-bc05-4962-ba85-e4d1b4e8f7a8"),
                            UserId = new Guid("9f40e295-8b43-4329-b37e-d267deee6c4a"),
                            CanSendMedia = true
                        },
                        new
                        {
                            ChatId = new Guid("2b56ee19-fe9c-4fab-884b-ff7d85a9f337"),
                            UserId = new Guid("9f40e295-8b43-4329-b37e-d267deee6c4a"),
                            CanSendMedia = true
                        },
                        new
                        {
                            ChatId = new Guid("2b56ee19-fe9c-4fab-884b-ff7d85a9f337"),
                            UserId = new Guid("ee677bde-c6e6-40b3-8294-5fb5e913202a"),
                            CanSendMedia = true
                        },
                        new
                        {
                            ChatId = new Guid("2b56ee19-fe9c-4fab-884b-ff7d85a9f337"),
                            UserId = new Guid("a85825ba-f99b-4177-a858-96384303ea14"),
                            CanSendMedia = true
                        },
                        new
                        {
                            ChatId = new Guid("f69acb05-018c-4626-9e70-46fbb5dfde6f"),
                            UserId = new Guid("ee677bde-c6e6-40b3-8294-5fb5e913202a"),
                            CanSendMedia = true
                        },
                        new
                        {
                            ChatId = new Guid("f69acb05-018c-4626-9e70-46fbb5dfde6f"),
                            UserId = new Guid("5aef3c7f-8040-4a99-9a3d-388695e55763"),
                            CanSendMedia = true
                        });
                });

            modelBuilder.Entity("Messenger.Domain.Entities.DeletedDialogByUserEntity", b =>
                {
                    b.Property<Guid>("ChatId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("ChatId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("DeletedDialogByUsers");
                });

            modelBuilder.Entity("Messenger.Domain.Entities.DeletedMessageByUserEntity", b =>
                {
                    b.Property<Guid>("MessageId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("MessageId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("DeletedMessageByUsers");
                });

            modelBuilder.Entity("Messenger.Domain.Entities.MessageEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateOfCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsEdit")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ReplyToMessageId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ReplyToMessageId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8f2e54bc-4eec-47d6-a2cb-44fb435a77c7"),
                            ChatId = new Guid("2975dbfe-bc05-4962-ba85-e4d1b4e8f7a8"),
                            DateOfCreate = new DateTime(2023, 5, 31, 5, 1, 36, 401, DateTimeKind.Utc).AddTicks(9800),
                            IsEdit = false,
                            OwnerId = new Guid("a85825ba-f99b-4177-a858-96384303ea14"),
                            Text = "привет, какие книжки почитать?"
                        },
                        new
                        {
                            Id = new Guid("ef65d839-fbe4-4775-b3d2-229ce23c3324"),
                            ChatId = new Guid("2975dbfe-bc05-4962-ba85-e4d1b4e8f7a8"),
                            DateOfCreate = new DateTime(2023, 5, 31, 5, 1, 36, 402, DateTimeKind.Utc).AddTicks(368),
                            IsEdit = false,
                            OwnerId = new Guid("5aef3c7f-8040-4a99-9a3d-388695e55763"),
                            ReplyToMessageId = new Guid("8f2e54bc-4eec-47d6-a2cb-44fb435a77c7"),
                            Text = "Книги в айтишке это как предметы в школе, созданы что б отбить у тебя желание учиться..."
                        },
                        new
                        {
                            Id = new Guid("dd5bfabd-9982-4995-ba70-20c55643a5ab"),
                            ChatId = new Guid("2975dbfe-bc05-4962-ba85-e4d1b4e8f7a8"),
                            DateOfCreate = new DateTime(2023, 5, 31, 5, 1, 36, 402, DateTimeKind.Utc).AddTicks(765),
                            IsEdit = false,
                            OwnerId = new Guid("ee677bde-c6e6-40b3-8294-5fb5e913202a"),
                            ReplyToMessageId = new Guid("ef65d839-fbe4-4775-b3d2-229ce23c3324"),
                            Text = "ладно"
                        },
                        new
                        {
                            Id = new Guid("fe3c2f65-41fc-42a4-903b-52fa3ea1076b"),
                            ChatId = new Guid("2975dbfe-bc05-4962-ba85-e4d1b4e8f7a8"),
                            DateOfCreate = new DateTime(2023, 5, 31, 5, 1, 36, 402, DateTimeKind.Utc).AddTicks(1153),
                            IsEdit = false,
                            OwnerId = new Guid("5aef3c7f-8040-4a99-9a3d-388695e55763"),
                            Text = "ага"
                        },
                        new
                        {
                            Id = new Guid("ef0be2a3-74c0-4e82-b56c-562b15440701"),
                            ChatId = new Guid("f69acb05-018c-4626-9e70-46fbb5dfde6f"),
                            DateOfCreate = new DateTime(2023, 5, 31, 5, 1, 36, 402, DateTimeKind.Utc).AddTicks(1586),
                            IsEdit = false,
                            OwnerId = new Guid("5aef3c7f-8040-4a99-9a3d-388695e55763"),
                            Text = "привет"
                        },
                        new
                        {
                            Id = new Guid("1bbb3da1-da30-499e-a866-190d22ab4590"),
                            ChatId = new Guid("f69acb05-018c-4626-9e70-46fbb5dfde6f"),
                            DateOfCreate = new DateTime(2023, 5, 31, 5, 1, 36, 402, DateTimeKind.Utc).AddTicks(1967),
                            IsEdit = false,
                            OwnerId = new Guid("5aef3c7f-8040-4a99-9a3d-388695e55763"),
                            Text = "привет, как дела?"
                        });
                });

            modelBuilder.Entity("Messenger.Domain.Entities.RoleUserByChatEntity", b =>
                {
                    b.Property<Guid>("ChatId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("CanAddAndRemoveUserToConversation")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanBanUser")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanChangeChatData")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanGivePermissionToUser")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("boolean");

                    b.Property<int>("RoleColor")
                        .HasColumnType("integer");

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ChatId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("RoleUserByChats");
                });

            modelBuilder.Entity("Messenger.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AvatarFileName")
                        .HasColumnType("text");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5aef3c7f-8040-4a99-9a3d-388695e55763"),
                            AvatarFileName = "kaminome.jpg",
                            Bio = "the best account",
                            DisplayName = "kami no me",
                            Nickname = "kaminome",
                            PasswordHash = "gzF/n+F8YPd/IvNrALE/XtGhhoJhtRs+PP3eco6JYzB36pVy2TGyj/4+68GXGws4EiIjSAkPKutdJuj6tb0d7A==",
                            PasswordSalt = "fh1cbqngj2gJnAoolbwi6e6tPVGwUnrLVsCX1l7UbD+Nxz72Y8F4ucWNaBa0kLopPAyFWHesvCfZX7OSlqG3ZVAjYTUIa+YCV3TXwgNnQARH0KptctnRHczMzlk5D0bmHra29Zc3rGkWpsxtVGhuayb/FIUGPG92Md0G8d6v2GI="
                        },
                        new
                        {
                            Id = new Guid("ee677bde-c6e6-40b3-8294-5fb5e913202a"),
                            AvatarFileName = "alice.jpg",
                            Bio = "cool status",
                            DisplayName = "alice1",
                            Nickname = "alice1234",
                            PasswordHash = "gzF/n+F8YPd/IvNrALE/XtGhhoJhtRs+PP3eco6JYzB36pVy2TGyj/4+68GXGws4EiIjSAkPKutdJuj6tb0d7A==",
                            PasswordSalt = "fh1cbqngj2gJnAoolbwi6e6tPVGwUnrLVsCX1l7UbD+Nxz72Y8F4ucWNaBa0kLopPAyFWHesvCfZX7OSlqG3ZVAjYTUIa+YCV3TXwgNnQARH0KptctnRHczMzlk5D0bmHra29Zc3rGkWpsxtVGhuayb/FIUGPG92Md0G8d6v2GI="
                        },
                        new
                        {
                            Id = new Guid("a85825ba-f99b-4177-a858-96384303ea14"),
                            Bio = "I'm Bob",
                            DisplayName = "bob1",
                            Nickname = "bob1234",
                            PasswordHash = "gzF/n+F8YPd/IvNrALE/XtGhhoJhtRs+PP3eco6JYzB36pVy2TGyj/4+68GXGws4EiIjSAkPKutdJuj6tb0d7A==",
                            PasswordSalt = "fh1cbqngj2gJnAoolbwi6e6tPVGwUnrLVsCX1l7UbD+Nxz72Y8F4ucWNaBa0kLopPAyFWHesvCfZX7OSlqG3ZVAjYTUIa+YCV3TXwgNnQARH0KptctnRHczMzlk5D0bmHra29Zc3rGkWpsxtVGhuayb/FIUGPG92Md0G8d6v2GI="
                        },
                        new
                        {
                            Id = new Guid("9f40e295-8b43-4329-b37e-d267deee6c4a"),
                            Bio = "why alex?",
                            DisplayName = "alex1",
                            Nickname = "alex1234",
                            PasswordHash = "gzF/n+F8YPd/IvNrALE/XtGhhoJhtRs+PP3eco6JYzB36pVy2TGyj/4+68GXGws4EiIjSAkPKutdJuj6tb0d7A==",
                            PasswordSalt = "fh1cbqngj2gJnAoolbwi6e6tPVGwUnrLVsCX1l7UbD+Nxz72Y8F4ucWNaBa0kLopPAyFWHesvCfZX7OSlqG3ZVAjYTUIa+YCV3TXwgNnQARH0KptctnRHczMzlk5D0bmHra29Zc3rGkWpsxtVGhuayb/FIUGPG92Md0G8d6v2GI="
                        });
                });

            modelBuilder.Entity("Messenger.Domain.Entities.UserSessionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DateOfLastAccess")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("ExpiresAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Value")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserSessions");
                });

            modelBuilder.Entity("Messenger.Domain.Entities.AttachmentEntity", b =>
                {
                    b.HasOne("Messenger.Domain.Entities.MessageEntity", "Message")
                        .WithMany("Attachments")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("Messenger.Domain.Entities.BanUserByChatEntity", b =>
                {
                    b.HasOne("Messenger.Domain.Entities.ChatEntity", "Chat")
                        .WithMany("BanUserByChats")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Domain.Entities.UserEntity", "User")
                        .WithMany("BanUserByChats")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Messenger.Domain.Entities.ChatEntity", b =>
                {
                    b.HasOne("Messenger.Domain.Entities.MessageEntity", "LastMessage")
                        .WithOne("LastMessageByChat")
                        .HasForeignKey("Messenger.Domain.Entities.ChatEntity", "LastMessageId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Messenger.Domain.Entities.UserEntity", "Owner")
                        .WithMany("Chats")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("LastMessage");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Messenger.Domain.Entities.ChatUserEntity", b =>
                {
                    b.HasOne("Messenger.Domain.Entities.ChatEntity", "Chat")
                        .WithMany("ChatUsers")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Domain.Entities.UserEntity", "User")
                        .WithMany("ChatUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Messenger.Domain.Entities.DeletedDialogByUserEntity", b =>
                {
                    b.HasOne("Messenger.Domain.Entities.ChatEntity", "Chat")
                        .WithMany("DeletedDialogByUsers")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Domain.Entities.UserEntity", "User")
                        .WithMany("DeletedDialogByUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Messenger.Domain.Entities.DeletedMessageByUserEntity", b =>
                {
                    b.HasOne("Messenger.Domain.Entities.MessageEntity", "Message")
                        .WithMany("DeletedMessageByUsers")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Domain.Entities.UserEntity", "User")
                        .WithMany("DeletedMessageByUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Messenger.Domain.Entities.MessageEntity", b =>
                {
                    b.HasOne("Messenger.Domain.Entities.ChatEntity", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Domain.Entities.UserEntity", "Owner")
                        .WithMany("Messages")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Messenger.Domain.Entities.MessageEntity", "ReplyToMessage")
                        .WithMany()
                        .HasForeignKey("ReplyToMessageId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Chat");

                    b.Navigation("Owner");

                    b.Navigation("ReplyToMessage");
                });

            modelBuilder.Entity("Messenger.Domain.Entities.RoleUserByChatEntity", b =>
                {
                    b.HasOne("Messenger.Domain.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Domain.Entities.ChatUserEntity", "ChatUser")
                        .WithOne("Role")
                        .HasForeignKey("Messenger.Domain.Entities.RoleUserByChatEntity", "ChatId", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Messenger.Domain.Entities.UserSessionEntity", b =>
                {
                    b.HasOne("Messenger.Domain.Entities.UserEntity", "User")
                        .WithMany("UserSessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Messenger.Domain.Entities.ChatEntity", b =>
                {
                    b.Navigation("BanUserByChats");

                    b.Navigation("ChatUsers");

                    b.Navigation("DeletedDialogByUsers");

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Messenger.Domain.Entities.ChatUserEntity", b =>
                {
                    b.Navigation("Role");
                });

            modelBuilder.Entity("Messenger.Domain.Entities.MessageEntity", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("DeletedMessageByUsers");

                    b.Navigation("LastMessageByChat");
                });

            modelBuilder.Entity("Messenger.Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("BanUserByChats");

                    b.Navigation("ChatUsers");

                    b.Navigation("Chats");

                    b.Navigation("DeletedDialogByUsers");

                    b.Navigation("DeletedMessageByUsers");

                    b.Navigation("Messages");

                    b.Navigation("UserSessions");
                });
#pragma warning restore 612, 618
        }
    }
}
