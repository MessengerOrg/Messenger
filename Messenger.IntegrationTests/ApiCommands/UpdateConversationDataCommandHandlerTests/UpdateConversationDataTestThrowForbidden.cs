using FluentAssertions;
using Messenger.BusinessLogic.ApiCommands.Chats;
using Messenger.BusinessLogic.Responses;
using Messenger.Domain.Enums;
using Messenger.IntegrationTests.Abstraction;
using Messenger.IntegrationTests.Helpers;
using Xunit;

namespace Messenger.IntegrationTests.ApiCommands.UpdateConversationDataCommandHandlerTests;

public class UpdateConversationDataTestThrowForbidden : IntegrationTestBase, IIntegrationTest
{
    [Fact]
    public async Task Test()
    {
        var user21Th = await RequestAsync(CommandHelper.Registration21ThCommand(), CancellationToken.None);
		var alice = await RequestAsync(CommandHelper.RegistrationAliceCommand(), CancellationToken.None);

		var createConversationCommand = new CreateChatCommand(
			user21Th.Value.Id,
			Name: "qwerty",
			Title: "qwerty",
			ChatType.Conversation,
			AvatarFile: null);

		var createConversationResult = await RequestAsync(createConversationCommand, CancellationToken.None);

		var aliceJoinConversationCommand = new JoinToChatCommand(alice.Value.Id, createConversationResult.Value.Id);
		
		await RequestAsync(aliceJoinConversationCommand, CancellationToken.None);
		
		var updateConversationByAliceCommand = new UpdateChatDataCommand(
			alice.Value.Id,
			createConversationResult.Value.Id,
			Name: "AliceName",
			Title: "AliceTitle");

		var updateConversationByAliceResult = 
			await RequestAsync(updateConversationByAliceCommand, CancellationToken.None);

		updateConversationByAliceResult.Error.Should().BeOfType<ForbiddenError>();
    }
}