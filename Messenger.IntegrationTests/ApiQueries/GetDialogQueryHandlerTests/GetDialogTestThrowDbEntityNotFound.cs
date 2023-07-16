using FluentAssertions;
using Messenger.BusinessLogic.ApiCommands.Dialogs;
using Messenger.BusinessLogic.ApiQueries.Chats;
using Messenger.BusinessLogic.Responses;
using Messenger.IntegrationTests.Abstraction;
using Messenger.IntegrationTests.Helpers;
using Xunit;

namespace Messenger.IntegrationTests.ApiQueries.GetDialogQueryHandlerTests;

public class GetDialogTestThrowDbEntityNotFound : IntegrationTestBase, IIntegrationTest
{
    [Fact]
    public async Task Test()
    {
        var user21Th = await RequestAsync(CommandHelper.Registration21ThCommand(), CancellationToken.None);
        var alice = await RequestAsync(CommandHelper.RegistrationAliceCommand(), CancellationToken.None);
        var bob = await RequestAsync(CommandHelper.RegistrationBobCommand(), CancellationToken.None);

        var createDialogCommand = new CreateDialogCommand(user21Th.Value.Id, alice.Value.Id);
        
        var createDialogResult = await RequestAsync(createDialogCommand, CancellationToken.None);

        var getDialogQuery = new GetChatQuery(bob.Value.Id, createDialogResult.Value.Id);
        
        var getDialogResult = await RequestAsync(getDialogQuery, CancellationToken.None);

        getDialogResult.Error.Should().BeOfType<DbEntityNotFoundError>();
    }
}