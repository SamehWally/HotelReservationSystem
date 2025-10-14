using Domain.Models.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IOfferRepository
    {
        void AddOffer(Offer offer);
        Offer? GetById(int id);
        Task<Offer?> GetOfferById(int id);
        Task<List<Offer>> GetAllOfferWithRoom();
        void UpdateStatus(int id);
        void UpdateOffer(Offer offer);
        void DeleteOffer(int id);
    }
}
