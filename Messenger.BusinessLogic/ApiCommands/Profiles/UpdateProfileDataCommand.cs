using MediatR;
using Messenger.BusinessLogic.Models;
using Messenger.BusinessLogic.Responses;

namespace Messenger.BusinessLogic.ApiCommands.Profiles;

public record UpdateProfileDataCommand(
	Guid RequestorId,
	string DisplayName,
	string NickName,
	string? Bio
) : IRequest<Result<UserDto>>;