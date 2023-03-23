using System.Text.RegularExpressions;
using MediatR;
using Messenger.BusinessLogic.Models;
using Messenger.BusinessLogic.Responses;
using Messenger.Services;
using Microsoft.EntityFrameworkCore;

namespace Messenger.BusinessLogic.ApiQueries.Users;

public class GetUserListBySearchQueryHandler : IRequestHandler<GetUserListBySearchQuery, Result<List<UserDto>>>
{
	private readonly DatabaseContext _context;

	public GetUserListBySearchQueryHandler(DatabaseContext context)
	{
		_context = context;
	}
	
	public async Task<Result<List<UserDto>>> Handle(GetUserListBySearchQuery request, CancellationToken cancellationToken)
	{
		if (request.Page < 1 || request.Limit < 1)
		{
			return new Result<List<UserDto>>(new BadRequestError("Page and Limit must be greater than 0"));
		}

		if (request.Limit > 40)
		{
			return new Result<List<UserDto>>(new BadRequestError("limit must not be higher than 40"));
		}
		
		var users = await _context.Users
			.AsNoTracking()
			.Where(u => u.Id != request.RequesterId)
			.Where(u => Regex.IsMatch(u.Nickname, request.SearchText))
			.Skip((request.Page - 1) * request.Limit)
			.Take(request.Limit)
			.Select(u => new UserDto(u))
			.ToListAsync(cancellationToken);
		
		return new Result<List<UserDto>>(users);
	}
}