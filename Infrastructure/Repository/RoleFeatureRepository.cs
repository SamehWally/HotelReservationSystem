using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Features;
using Domain.Models.AccessControl;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class RoleFeatureRepository:IRoleFeatureRepository
    {
        private readonly Context _context;

        public RoleFeatureRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> AssignFeatureToRoleAsync(int roleId, int featureId)
        {
            var roleFeature = new RoleFeature { FeatureId = featureId, RoleId = roleId };
            await _context.RoleFeatures.AddAsync(roleFeature);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> HardRemoveFeatureFromRoleAsync(int roleId, int featureId)
        {
            var roleFeature = await _context.RoleFeatures
                .FirstOrDefaultAsync(rf=>rf.RoleId==roleId && rf.FeatureId==featureId);

            if (roleFeature != null)
            {
                _context.RoleFeatures.Remove(roleFeature);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> SoftRemoveFeatureFromRoleAsync(int roleId, int featureId)
        {
            var roleFeature = await _context.RoleFeatures
               .FirstOrDefaultAsync(rf => rf.RoleId == roleId && rf.FeatureId == featureId);

            if (roleFeature != null)
            {
                roleFeature.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IList<Feature>> GetFeatuesOfRoleAsync(int roleId)
        {
            var features= await _context.RoleFeatures
                .Where(rf=>rf.RoleId==roleId &&!rf.IsDeleted)
                .Select(rf => rf.Feature)
                .ToListAsync();
            return features;
        }

    }
}
