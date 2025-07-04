using EnergyPortal.Application.Common.Commands;
using EnergyPortal.Domain.Common;
using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Sites.Commands.DeleteSite;

internal sealed class DeleteSiteCommandHandler : ICommandHandler<DeleteSiteCommand>
{
	private readonly ISitesRepository _sitesRepository;

	public DeleteSiteCommandHandler(ISitesRepository sitesRepository)
	{
		_sitesRepository = sitesRepository;
	}

	public async Task<Result> Handle(DeleteSiteCommand request, CancellationToken cancellationToken)
	{
		var id = await _sitesRepository.DeleteSite(request.id, cancellationToken);

		if (id == Guid.Empty)
		{
			return Result.Failure($"Error while deleting the site in the database : {request.id}");
		}

		return Result.Success();
	}
}
