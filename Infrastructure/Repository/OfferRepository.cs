using Domain.Models.Offer;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class OfferRepository : IOfferRepository
    {
        private readonly Context _context;
        public OfferRepository(Context context)
        {
            _context = context;
        }

        public void AddOffer(Offer offer)
        {
            _context.Offers.Add(offer);
            _context.SaveChanges();
        }

        public Offer? GetById(int id)
        {
            var offer = _context.Offers.Where(O => !O.IsDeleted).FirstOrDefault(o => o.Id == id);
            return offer;
            //Include(o => o.OfferRooms)
        }

        public void UpdateOffer(Offer offer)
        {
            _context.Offers.Update(offer);
            _context.SaveChanges();
        }
        public void DeleteOffer(int id)
        {
            var offer = _context.Offers.Find(id);
            if (offer != null)
                offer.IsDeleted = true;

            var offerRooms = _context.OfferRooms.Where(O => O.Id == id);
            foreach (var offerroom in offerRooms)
                offerroom.IsDeleted = true;

            _context.SaveChanges();
        }

        public void UpdateStatus(int offerId)
        {
            var offer = _context.Offers.FirstOrDefault(O => O.Id == offerId);
            if (offer != null)
            {
                offer.IsActive = DateTime.UtcNow.Date <= offer.EndDate.Date;
                _context.Offers.Update(offer);
                _context.SaveChanges();
            }
        }

        public async Task<Offer?> GetOfferById(int id)
        {
            return await _context.Offers
              .AsNoTracking()
              .Include(o => o.OfferRooms)
                 .ThenInclude(or => or.Room)
              .FirstOrDefaultAsync(o => o.Id == id && !o.IsDeleted);
        }

        public async Task<List<Offer>> GetAllOfferWithRoom()
        {


            return await _context.Offers
                .Where(o => !o.IsDeleted)
                .Include(o => o.OfferRooms)
                    .ThenInclude(or => or.Room)
                  .ToListAsync();
        }

    }
}

