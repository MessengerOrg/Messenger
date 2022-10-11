using FluentAssertions;
using Messenger.BusinessLogic.ApiCommands.Dialogs;
using Messenger.Domain.Enum;
using Messenger.IntegrationTests.Abstraction;
using Messenger.IntegrationTests.Helpers;
using Xunit;

namespace Messenger.IntegrationTests.ApiCommands.CreateDialogCommandHandlerTests;

public class CreateDialogCommandHandlerTestSuccess : IntegrationTestBase, IIntegrationTest
{
	[Fact]
	public async Task Test()
	{
		var user21th = await MessengerModule.RequestAsync(CommandHelper.Registration21thCommand(), CancellationToken.None);
		var alice = await MessengerModule.RequestAsync(CommandHelper.RegistrationAliceCommand(), CancellationToken.None);
		
		var createDialogCommand = new CreateDialogCommand(
			RequestorId: user21th.Value.Id,
			UserId: alice.Value.Id);

		var dialog = await MessengerModule.RequestAsync(createDialogCommand, CancellationToken.None);

		dialog.IsSuccess.Should().BeTrue();
		dialog.Value.MembersCount.Should().Be(2);
		dialog.Value.Members.Count.Should().Be(2);
		dialog.Value.Members.Exists(m => m.Id == user21th.Value.Id).Should().BeTrue();
		dialog.Value.Members.Exists(m => m.Id != user21th.Value.Id).Should().BeTrue();
		dialog.Value.Type.Should().Be(ChatType.Dialog);
	}
}