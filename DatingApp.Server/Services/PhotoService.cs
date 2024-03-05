﻿using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DatingApp.Server.Helpers;
using DatingApp.Server.Interfaces;
using Microsoft.Extensions.Options;

namespace DatingApp.Server.Services
{
	public class PhotoService : IPhotoService
	{
		private readonly Cloudinary _cloudinary;
		public PhotoService(IOptions<CloudinarySettings> config) 
		{
			var acc = new Account(
				config.Value.CloudName,
				config.Value.APIKey,
				config.Value.ApiSecret
				);

			_cloudinary = new Cloudinary( acc );
		}
		public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
		{
			var uploadResult = new ImageUploadResult();

			if(file.Length > 0)
			{
				using var stream = file.OpenReadStream();
				var uploadParams = new ImageUploadParams
				{
					File = new FileDescription(file.FileName, stream),
					Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
					Folder = "da-net7"
				};
				uploadResult = await _cloudinary.UploadAsync(uploadParams);
			}

			return uploadResult;
		}

		public async Task<DeletionResult> DeletePhotoAsync(string publicId)
		{
			var deletParams = new DeletionParams(publicId);

			return await _cloudinary.DestroyAsync(deletParams);
		}
	}
}
