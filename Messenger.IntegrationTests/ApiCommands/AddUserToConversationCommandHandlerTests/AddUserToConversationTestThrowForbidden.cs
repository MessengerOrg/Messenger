using FluentAssertions;
using Messenger.BusinessLogic.ApiCommands.Chats;
using Messenger.BusinessLogic.ApiCommands.Conversations;
using Messenger.BusinessLogic.Responses;
using Messenger.Domain.Enums;
using Messenger.IntegrationTests.Abstraction;
using Messenger.IntegrationTests.Helpers;
using Xunit;

namespace Messenger.IntegrationTests.ApiCommands.AddUserToConversationCommandHandlerTests;

public class AddUserToConversationTestThrowForbidden : IntegrationTestBase, IIntegrationTest
{
    [Fact]
    public async Task Test()
    {
        var user21Th = await RequestAsync(CommandHelper.Registration21ThCommand(), CancellationToken.None);
        var alice = await RequestAsync(CommandHelper.RegistrationAliceCommand(), CancellationToken.None);
        var bob = await RequestAsync(CommandHelper.RegistrationBobCommand(), CancellationToken.None);

        var createConversationCommand = new CreateChatCommand(
            user21Th.Value.Id,
            Name: "qwerty",
            Title: "qwerty",
            ChatType.Conversation,
            AvatarFile: null);
		
        var createConversationResult = await RequestAsync(createConversationCommand, CancellationToken.None);

        var addUserAliceToConversationByBobCommand = new AddUserToConversationCommand(
            bob.Value.Id,
            createConversationResult.Value.Id,
            alice.Value.Id);

        var addUserAliceToConversationByBobResult =
            await RequestAsync(addUserAliceToConversationByBobCommand, CancellationToken.None);

        var userAliceJoinToConversationCommand = new JoinToChatCommand(alice.Value.Id, createConversationResult.Value.Id);
        
        await RequestAsync(userAliceJoinToConversationCommand, CancellationToken.None);
        
        var addUserBobToConversationByAliceCommand = new AddUserToConversationCommand(
            bob.Value.Id,
            createConversationResult.Value.Id,
            alice.Value.Id);

        var addUserBobToConversationByAliceResult =
            await RequestAsync(addUserBobToConversationByAliceCommand, CancellationToken.None);

        addUserAliceToConversationByBobResult.Error.Should().BeOfType<ForbiddenError>();
        addUserBobToConversationByAliceResult.Error.Should().BeOfType<ForbiddenError>();
    }
}