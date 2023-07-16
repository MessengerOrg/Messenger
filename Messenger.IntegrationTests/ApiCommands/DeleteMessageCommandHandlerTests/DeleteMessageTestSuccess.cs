using FluentAssertions;
using Messenger.BusinessLogic.ApiCommands.Chats;
using Messenger.BusinessLogic.ApiCommands.Messages;
using Messenger.Domain.Enums;
using Messenger.IntegrationTests.Abstraction;
using Messenger.IntegrationTests.Helpers;
using Xunit;

namespace Messenger.IntegrationTests.ApiCommands.DeleteMessageCommandHandlerTests;

public class DeleteMessageTestSuccess : IntegrationTestBase, IIntegrationTest
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

        var aliceJoinToConversationCommand = new JoinToChatCommand(alice.Value.Id, createConversationResult.Value.Id); 
        var bobJoinToConversationCommand = new JoinToChatCommand(bob.Value.Id, createConversationResult.Value.Id); 
        
        await RequestAsync(aliceJoinToConversationCommand, CancellationToken.None);
        await RequestAsync(bobJoinToConversationCommand, CancellationToken.None);

        var firstCreateMessageByAliceCommand = new CreateMessageCommand(
            alice.Value.Id,
            Text: "qwerty2",
            ReplyToId: null,
            createConversationResult.Value.Id,
            Files: null);
        
        var firstCreateMessageByAliceResult = 
            await RequestAsync(firstCreateMessageByAliceCommand, CancellationToken.None);

        var secondCreateMessageByAliceCommand = new CreateMessageCommand(
            alice.Value.Id,
            Text: "qwerty422",
            ReplyToId: null,
            createConversationResult.Value.Id,
            Files: null);

        var secondCreateMessageByAliceResult = 
            await RequestAsync(secondCreateMessageByAliceCommand, CancellationToken.None);

        var deleteFirstMessageByAliceCommand = new DeleteMessageCommand(
            user21Th.Value.Id,
            firstCreateMessageByAliceResult.Value.Id,
            IsDeleteForAll: true);
        
        var deleteFirstMessageByAliceResult = 
            await RequestAsync(deleteFirstMessageByAliceCommand, CancellationToken.None);

        var deleteSecondMessageByAliceCommand = new DeleteMessageCommand(
            user21Th.Value.Id,
            secondCreateMessageByAliceResult.Value.Id,
            IsDeleteForAll: true);
        
        var deleteSecondMessageByAliceResult = 
            await RequestAsync(deleteSecondMessageByAliceCommand, CancellationToken.None);

        deleteFirstMessageByAliceResult.IsSuccess.Should().BeTrue();
        deleteSecondMessageByAliceResult.IsSuccess.Should().BeTrue();
    }
}