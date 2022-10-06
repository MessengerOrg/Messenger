using FluentAssertions;
using Messenger.BusinessLogic.Conversations.Commands;
using Messenger.Domain.Entities;
using Messenger.IntegrationTests.Abstraction;
using Messenger.IntegrationTests.Helpers;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Messenger.IntegrationTests.Conversations.CommandsTests;

public class JoinToConversationCommandHandlerTestSuccess : IntegrationTestBase, IIntegrationTest
{
	[Fact]
	public async Task Test()
	{
		var user21th = EntityHelper.CreateUser21th();
		var alice = EntityHelper.CreateUserAlice();
		
		DatabaseContextFixture.Users.AddRange(user21th, alice);
		await DatabaseContextFixture.SaveChangesAsync();

		var conversation = EntityHelper.CreateConversation(user21th.Id, "qwerty", "qwerty");
		
		DatabaseContextFixture.Chats.Add(conversation);
		await DatabaseContextFixture.SaveChangesAsync();
		
		DatabaseContextFixture.ChatUsers.Add(new ChatUser {UserId = user21th.Id, ChatId = conversation.Id});
		await DatabaseContextFixture.SaveChangesAsync();

		var joinToConversationCommand = new JoinToConversationCommand
		{
			RequesterId = alice.Id,
			ChatId = conversation.Id
		};

		await MessengerModule.RequestAsync(joinToConversationCommand, CancellationToken.None);

		var chatUser = await DatabaseContextFixture.ChatUsers
			.FirstOrDefaultAsync(c => c.UserId == alice.Id && c.ChatId == conversation.Id);

		chatUser.Should().NotBeNull();
	}
}