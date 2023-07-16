using FluentAssertions;
using Messenger.BusinessLogic.ApiCommands.Chats;
using Messenger.BusinessLogic.ApiCommands.Conversations;
using Messenger.Domain.Enums;
using Messenger.IntegrationTests.Abstraction;
using Messenger.IntegrationTests.Helpers;
using Xunit;

namespace Messenger.IntegrationTests.ApiCommands.RemoveUserFromConversationCommandHandlerTests;

public class RemoveUserFromConversationTestSuccess : IntegrationTestBase, IIntegrationTest
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
		
		var addAliceInConversationCommand = new AddUserToConversationCommand(
			user21Th.Value.Id,
			createConversationResult.Value.Id,
			alice.Value.Id);
		
		var addBobInConversationCommand = new AddUserToConversationCommand(
			user21Th.Value.Id,
			createConversationResult.Value.Id,
			bob.Value.Id);
		
		var addAlexInConversationCommand = new AddUserToConversationCommand(
			user21Th.Value.Id,
			createConversationResult.Value.Id,
			alex.Value.Id);

		await RequestAsync(addAliceInConversationCommand, CancellationToken.None);
		await RequestAsync(addBobInConversationCommand, CancellationToken.None);
		await RequestAsync(addAlexInConversationCommand, CancellationToken.None);

		var createBobRoleBy21ThCommand = new CreateOrUpdateRoleUserInConversationCommand(
			user21Th.Value.Id,
			createConversationResult.Value.Id,
			bob.Value.Id,
			RoleTitle: "moderator",
			RoleColor.Blue,
			CanBanUser: false,
			CanChangeChatData: false,
			CanAddAndRemoveUserToConversation: true,
			CanGivePermissionToUser: false);

		await RequestAsync(createBobRoleBy21ThCommand, CancellationToken.None);

		var removeAliceFromConversationBy21ThCommand= new RemoveUserFromConversationCommand(
			user21Th.Value.Id,
			createConversationResult.Value.Id,
			alice.Value.Id);
		
		var removeAlexFromConversationByBobCommand = new RemoveUserFromConversationCommand(
			bob.Value.Id,
			createConversationResult.Value.Id,
			alex.Value.Id);

		var removeAliceFromConversationBy21ThResult =
			await RequestAsync(removeAliceFromConversationBy21ThCommand, CancellationToken.None);
		var removeAlexFromConversationByBobResult =
			await RequestAsync(removeAlexFromConversationByBobCommand, CancellationToken.None);

		removeAliceFromConversationBy21ThResult.IsSuccess.Should().BeTrue();
		removeAlexFromConversationByBobResult.IsSuccess.Should().BeTrue();
	}
}