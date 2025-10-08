using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Response;
using Domain.Enums;
using Domain.Models.AccessControl;
using Domain.Repositories;

namespace Application.Services
{
    public class FeatureService
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<ResponseDTO<Feature>> AddFeatureAsync(Feature feature)
        {
            await _featureRepository.AddAsync(feature);
            return ResponseDTO<Feature>.Success(feature, "Feature added successfully.");
        }

        public async Task<ResponseDTO<bool>> DeleteFeatureAsync(int id)
        {
            var result = await _featureRepository.DeleteAsync(id);
            return result
                ? ResponseDTO<bool>.Success(true, "Feature deleted successfully.")
                : ResponseDTO<bool>.Failure(ErrorCode.FaildResponseDto,"Feature not found or failed to delete.");
        }

        public async Task<ResponseDTO<Feature?>> GetFeatureByIdAsync(int id)
        {
            var feature = await _featureRepository.GetByIdAsync(id);
            return feature != null
                ? ResponseDTO<Feature?>.Success(feature, "Feature found.")
                : ResponseDTO<Feature?>.Failure(ErrorCode.FaildResponseDto,"Feature not found.");
        }

        public async Task<ResponseDTO<Feature?>> GetFeatureByNameAsync(string featureName)
        {
            var feature = await _featureRepository.GetByNameAsync(featureName);
            return feature != null
                ? ResponseDTO<Feature?>.Success(feature, "Feature found.")
                : ResponseDTO<Feature?>.Failure(ErrorCode.FaildResponseDto,"Feature not found.");
        }
    }

}
