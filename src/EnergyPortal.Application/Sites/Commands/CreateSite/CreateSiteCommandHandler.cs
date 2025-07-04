using EnergyPortal.Application.Common.Commands;
using EnergyPortal.Domain.Common;
using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Sites.Commands.CreateSite;

internal sealed class CreateSiteCommandHandler : ICommandHandler<CreateSiteCommand, Guid>
{
	private readonly ISitesRepository _sitesRepository;
	private readonly SiteFactory _siteFactory;

	public CreateSiteCommandHandler(ISitesRepository sitesRepository, SiteFactory siteFactory)
	{
		_sitesRepository = sitesRepository;
		_siteFactory = siteFactory;
	}

	public async Task<Result<Guid>> Handle(CreateSiteCommand request, CancellationToken cancellationToken)
	{
		var location = new Location(request.Latitude,
			request.Longitude,
			request.Address,
			request.City,
			request.Region);

		var newSite = await _siteFactory.CreateSite(request.Name, location, "Tester");
		var id = await _sitesRepository.CreateSite(newSite, cancellationToken);

		if (id == Guid.Empty)
		{
			return Result.Failure<Guid>("Error while creating the site in the database");
		}

		return Result.Success(id);
	}
}
