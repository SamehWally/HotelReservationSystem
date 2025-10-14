using Application.DTOs.Offer;
using Application.Services;
using AutoMapper;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Offer;
using Presentation.ViewModels.Response;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly OfferService _offerServices;

        public OfferController(IMapper mapper, OfferService offerServices)
        {
            _mapper = mapper;
            _offerServices = offerServices;
        }

        [HttpPost]
        public ResponseViewModel<string> AddOffer([FromForm] AddOfferVM viewModel)
        {
            //    var addoffer = new AddOfferDto {
            //        Title = viewModel.Title,
            //        Description = viewModel.Description,
            //        StartDate = viewModel.StartDate,
            //        EndDate = viewModel.EndDate,
            //        DisCountPercent = viewModel.DisCountPercent,
            //        RoomIds = viewModel.RoomIds,
            //    };

            var addoffer = _mapper.Map<AddOfferDto>(viewModel);
            var offer = _offerServices.AddOffer(addoffer);
            return new SuccessResponseViewModel<string>(offer);
        }
        [HttpGet("id")]
        public ResponseViewModel<GetOfferViewModel> GetOfferById(int id)
        {
            var offer = _offerServices.GetOfferById(id);
            if (offer == null)
                return new ErrorResponseViewModel<GetOfferViewModel>(ErrorCode.OfferNotFound);


            //var offerVM = new GetOfferViewModel {
            //    Id = offer.Id,
            //    Title = offer.Title,
            //    Description = offer.Description,
            //    DiscountPercent = offer.DiscountPercent,
            //    StartDate = offer.StartDate,
            //    EndDate = offer.EndDate,
            //    IsActive = offer.IsActive,
            //    RoomIds = offer.RoomIds,
            //};

            var offerVM = _mapper.Map<GetOfferViewModel>(offer);
            return new SuccessResponseViewModel<GetOfferViewModel>(offerVM);

        }
        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<ResponseViewModel<string>> UpdateOffer([FromForm] UpdateOfferVM viewModel)
        {


            //var offerDto = new UpdateOfferDto
            //{
            //    Id = viewModel.Id,
            //    Title = viewModel.Title,
            //    Description = viewModel.Description,
            //    StartDate = viewModel.StartDate,
            //    EndDate = viewModel.EndDate,
            //    DisCountPercent = viewModel.DisCountPercent,
            //    RoomIds = viewModel.RoomIds,

            //};
            var offerVM = _mapper.Map<UpdateOfferDto>(viewModel);

            var offer = _offerServices.UpdateOffer(offerVM);

            return new SuccessResponseViewModel<string>(offer);
        }
        [HttpDelete("id")]
        public bool DeleteOffer(int id)
        {
            var offer = _offerServices.SoftDeleteOffer(id);
            if (!offer)
            {
                return false;
            }
            return true;
        }
        [HttpGet("GetOfferByIdWithRoom")]
        public async Task<ResponseViewModel<GetOfferByIdVM>> GetOfferByIdWithRoom(int id)
        {
            var offer = await _offerServices.GetOfferByIdAsync(id);
            if (offer == null)
                return new ErrorResponseViewModel<GetOfferByIdVM>(ErrorCode.OfferNotFound);


            //var offerVM = new GetOfferViewModel {
            //    Id = offer.Id,
            //    Title = offer.Title,
            //    Description = offer.Description,
            //    DiscountPercent = offer.DiscountPercent,
            //    StartDate = offer.StartDate,
            //    EndDate = offer.EndDate,
            //    IsActive = offer.IsActive,
            //    RoomIds = offer.RoomIds,
            //};

            var offerVM = _mapper.Map<GetOfferByIdVM>(offer);
            return new SuccessResponseViewModel<GetOfferByIdVM>(offerVM);

        }
        [HttpGet("GetAllOfferWithRoom")]
        public async Task<ResponseViewModel<List<GetAllOfferVM>>> GetAllOfferWithRoom()
        {
            var offers = await _offerServices.GetAllOffersAsync();
            if (offers == null)
                return new ErrorResponseViewModel<List<GetAllOfferVM>>(ErrorCode.OfferNotFound);


            //var offerVM = new GetOfferViewModel {
            //    Id = offer.Id,
            //    Title = offer.Title,
            //    Description = offer.Description,
            //    DiscountPercent = offer.DiscountPercent,
            //    StartDate = offer.StartDate,
            //    EndDate = offer.EndDate,
            //    IsActive = offer.IsActive,
            //    RoomIds = offer.RoomIds,
            //};

            var offerVM = _mapper.Map<List<GetAllOfferVM>>(offers);
            return new SuccessResponseViewModel<List<GetAllOfferVM>>(offerVM);

        }
    }
}
