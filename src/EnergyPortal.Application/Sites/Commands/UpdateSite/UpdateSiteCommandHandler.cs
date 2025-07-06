using EnergyPortal.Application.Common.Commands;
using EnergyPortal.Domain.Common;
using EnergyPortal.Domain.Sites;

namespace EnergyPortal.Application.Sites.Commands.UpdateSite;

internal sealed class UpdateSiteCommandHandler : ICommandHandler<UpdateSiteCommand>
{
	private readonly ISitesRepository _sitesRepository;

	public UpdateSiteCommandHandler(ISitesRepository sitesRepository)
	{
		_sitesRepository = sitesRepository;
	}

	public async Task<Result> Handle(UpdateSiteCommand request, CancellationToken cancellationToken)
	{
		var site = await _sitesRepository.GetSiteById(request.Id, cancellationToken);

		if (site == null)
		{
			return Result.Failure<Site>($"Cannot retrieve Site from database for id : {request.Id}");
		}

		var location = new Location(request.Latitude,
			request.Longitude,
			request.Address,
			request.City,
			request.Region);


		site.Update(request.Name, location, "Tester");

		var id = await _sitesRepository.UpdateSite(site, cancellationToken);

		if (id == Guid.Empty)
		{
			return Result.Failure<Guid>($"Error while updating the site in the database : {request.Id}");
		}

		return Result.Success(id);
	}
}
