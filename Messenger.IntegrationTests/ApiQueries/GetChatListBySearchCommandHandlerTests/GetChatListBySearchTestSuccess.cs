using FluentAssertions;
using Messenger.BusinessLogic.ApiCommands.Chats;
using Messenger.BusinessLogic.ApiQueries.Chats;
using Messenger.Domain.Enums;
using Messenger.IntegrationTests.Abstraction;
using Messenger.IntegrationTests.Helpers;
using Xunit;

namespace Messenger.IntegrationTests.ApiQueries.GetChatListBySearchCommandHandlerTests;

public class GetChatListBySearchTestSuccess : IntegrationTestBase, IIntegrationTest
{
    [Fact]
    public async Task Test()
    {
        var user21Th = await MessengerModule.RequestAsync(CommandHelper.Registration21ThCommand(), CancellationToken.None);
        var alice = await MessengerModule.RequestAsync(CommandHelper.RegistrationAliceCommand(), CancellationToken.None);

        var firstCreateConversationCommand = new CreateChatCommand(
            user21Th.Value.Id,
            Name: "qwerty",
            Title: "qwerty",
            ChatType.Conversation,
            AvatarFile: null);
        
        var secondCreateConversationCommand = new CreateChatCommand(
            user21Th.Value.Id,
            Name: "qwerty2",
            Title: "qwerty2",
            ChatType.Conversation,
            AvatarFile: null);

        var firstCreateConversationResult =
            await MessengerModule.RequestAsync(firstCreateConversationCommand, CancellationToken.None);
        var secondCreateConversationResult = 
            await MessengerModule.RequestAsync(secondCreateConversationCommand, CancellationToken.None);

        var firstGetUserListBySearchByAliceQuery =
            new GetChatListBySearchQuery(alice.Value.Id, firstCreateConversationCommand.Name); 
        var secondGetUserListBySearchByAliceQuery = 
            new GetChatListBySearchQuery(alice.Value.Id, secondCreateConversationCommand.Name);
        
        var firstGetUserListBySearchByAliceResult = 
            await MessengerModule.RequestAsync(firstGetUserListBySearchByAliceQuery, CancellationToken.None);
        var secondGetUserListBySearchByAliceResult = 
            await MessengerModule.RequestAsync(secondGetUserListBySearchByAliceQuery, CancellationToken.None);

        firstGetUserListBySearchByAliceResult.Value.Count.Should().Be(2);
        
        firstGetUserListBySearchByAliceResult.Value
            .FirstOrDefault(u => u.Id == firstCreateConversationResult.Value.Id).Should().NotBeNull();
        
        firstGetUserListBySearchByAliceResult.Value
            .FirstOrDefault(u => u.Id == secondCreateConversationResult.Value.Id).Should().NotBeNull();
        
        secondGetUserListBySearchByAliceResult.Value.Count.Should().Be(1);
        
        secondGetUserListBySearchByAliceResult.Value
            .FirstOrDefault(u => u.Id == firstCreateConversationResult.Value.Id).Should().BeNull();
        
        secondGetUserListBySearchByAliceResult.Value
            .FirstOrDefault(u => u.Id == secondCreateConversationResult.Value.Id).Should().NotBeNull();
    }
}