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
    public class RoleFeatureService
    {
        private readonly IRoleFeatureRepository _roleFeatureRepository;
        //private readonly IFeatureRepository _featureRepository;

        public RoleFeatureService(IRoleFeatureRepository roleFeatureRepository /*IFeatureRepository featureRepository*/)
        {
            _roleFeatureRepository = roleFeatureRepository;
            //_featureRepository = featureRepository;
        }

        public async Task<ResponseDTO<bool>> AssignFeatureToRoleAsync(int roleId, int featureId)
        {
            var isAssigned = await _roleFeatureRepository.AssignFeatureToRoleAsync(roleId, featureId);
            return isAssigned
                ? ResponseDTO<bool>.Success(true, "Feature assigned to role successfully.")
                : ResponseDTO<bool>.Failure(ErrorCode.FaildResponseDto,"Failed to assign feature to role.");
        }

        public async Task<ResponseDTO<bool>> RemoveFeatureFromRoleAsync(int roleId, int featureId)
        {
            var isRemoved = await _roleFeatureRepository.SoftRemoveFeatureFromRoleAsync(roleId, featureId);
            return isRemoved
                ? ResponseDTO<bool>.Success(true, "Feature removed from role successfully.")
                : ResponseDTO<bool>.Failure(ErrorCode.FaildResponseDto,"Failed to remove feature from role.");
        }
        public async Task<bool> CheckFeatureAccess(int roleId, string featureName)
        {
           
            var features=await _roleFeatureRepository.GetFeatuesOfRoleAsync(roleId);
            foreach (var feature in features)
            {
                if (feature.Name == featureName)
                    return true;
            }
            return false;

            
        }

        public async Task<ResponseDTO<IEnumerable<Feature>>> GetFeaturesByRoleAsync(int roleId)
        {
            var features = await _roleFeatureRepository.GetFeatuesOfRoleAsync(roleId);
            return ResponseDTO<IEnumerable<Feature>>.Success(features, "Features retrieved successfully.");
        }
    }
}
