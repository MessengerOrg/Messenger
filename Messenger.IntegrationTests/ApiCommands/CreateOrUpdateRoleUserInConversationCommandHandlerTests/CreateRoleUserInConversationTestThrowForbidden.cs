using FluentAssertions;
using Messenger.BusinessLogic.ApiCommands.Chats;
using Messenger.BusinessLogic.ApiCommands.Conversations;
using Messenger.BusinessLogic.Responses;
using Messenger.Domain.Enums;
using Messenger.IntegrationTests.Abstraction;
using Messenger.IntegrationTests.Helpers;
using Xunit;

namespace Messenger.IntegrationTests.ApiCommands.CreateOrUpdateRoleUserInConversationCommandHandlerTests;

public class CreateRoleUserInConversationTestThrowForbidden : IntegrationTestBase, IIntegrationTest
{
    [Fact]
    public async Task Test()
    {
        var user21Th = await RequestAsync(CommandHelper.Registration21ThCommand(), CancellationToken.None);
        var alice = await RequestAsync(CommandHelper.RegistrationAliceCommand(), CancellationToken.None);
        var bob = await RequestAsync(CommandHelper.RegistrationBobCommand(), CancellationToken.None);
        var alex = await RequestAsync(CommandHelper.RegistrationAlexCommand(), CancellationToken.None);

        var createConversationCommand = new CreateChatCommand(
            user21Th.Value.Id,
            Name: "qwerty",
            Title: "qwerty",
            ChatType.Conversation,
            AvatarFile: null);
		
        var createConversationResult = await RequestAsync(createConversationCommand, CancellationToken.None);

        var userAliceJoinToConversationCommand = new JoinToChatCommand(alice.Value.Id, createConversationResult.Value.Id);
        var userAlexJoinToConversationCommand = new JoinToChatCommand(alex.Value.Id, createConversationResult.Value.Id);
        
        await RequestAsync(userAliceJoinToConversationCommand, CancellationToken.None);
        await RequestAsync(userAlexJoinToConversationCommand, CancellationToken.None);

        var createAlexRoleInConversationByAliceCommand = new CreateOrUpdateRoleUserInConversationCommand(
            alice.Value.Id,
            createConversationResult.Value.Id,
            alex.Value.Id,
            RoleTitle: "moderator",
            RoleColor.Cyan,
            CanBanUser: true,
            CanChangeChatData: false,
            CanAddAndRemoveUserToConversation: true,
            CanGivePermissionToUser: false);

        var createRoleUserAlexInConversationByAliceResult =
            await RequestAsync(createAlexRoleInConversationByAliceCommand, CancellationToken.None);
        
        var createAliceRoleInConversationByBobCommand = new CreateOrUpdateRoleUserInConversationCommand(
            bob.Value.Id,
            createConversationResult.Value.Id,
            alice.Value.Id,
            RoleTitle: "moderator",
            RoleColor.Cyan,
            CanBanUser: true,
            CanChangeChatData: false,
            CanAddAndRemoveUserToConversation: true,
            CanGivePermissionToUser: false);

        var createRoleUserAliceInConversationByBobResult =
            await RequestAsync(createAliceRoleInConversationByBobCommand, CancellationToken.None);

        createRoleUserAlexInConversationByAliceResult.Error.Should().BeOfType<ForbiddenError>();
        createRoleUserAliceInConversationByBobResult.Error.Should().BeOfType<ForbiddenError>();
    }
}