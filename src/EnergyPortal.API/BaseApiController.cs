﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EnergyPortal.API;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseApiController : ControllerBase
{
	protected readonly ISender Sender;

	protected BaseApiController(ISender sender)
	{
		Sender = sender;
	}
}
