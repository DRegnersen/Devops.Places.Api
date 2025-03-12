﻿using Devops.Places.DataAccess.Models.Dto;

namespace Devops.Places.DataAccess.Services.Abstractions;

public interface IPlaceRepository
{
    Task<PlaceDto> CreatePlaceAsync(CreatePlaceDto place, CancellationToken cancellationToken = default);

    Task<PlaceDto[]> GetPlacesAsync(int? maxPlaces = null, CancellationToken cancellationToken = default);
}