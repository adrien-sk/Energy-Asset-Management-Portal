using EnergyPortal.Domain.Sites;
using MediatR;

namespace EnergyPortal.Application.Sites.Commands.CreateSite;

internal sealed class CreateSiteCommandHandler : IRequestHandler<CreateSiteCommand, Guid>
{
	private readonly ISitesRepository _sitesRepository;
	private readonly SiteFactory _siteFactory;

	public CreateSiteCommandHandler(ISitesRepository sitesRepository, SiteFactory siteFactory)
	{
		_sitesRepository = sitesRepository;
		_siteFactory = siteFactory;
	}

	public async Task<Guid> Handle(CreateSiteCommand request, CancellationToken cancellationToken)
	{

		var location = new Location(request.Latitude,
			request.Longitude,
			request.Address,
			request.City,
			request.Region);

		var newSite = await _siteFactory.CreateSite(request.Name, location, "Tester");
		return await _sitesRepository.CreateSite(newSite);
	}
}
