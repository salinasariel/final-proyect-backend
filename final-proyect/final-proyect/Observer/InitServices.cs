using final_proyect.Interfaces;

namespace final_proyect.Observer
{
    public class InitServices
    {
        private readonly OfferSubject _offerSubject;
        private readonly IUserService _userService;

        public InitServices(OfferSubject offerSubject, IUserService userService)
        {
            _offerSubject = offerSubject;
            _userService = userService;
        }

        public void Initialize()
        {
            var enterprises = _userService.GetAllEnterprises();
            foreach (var enterprise in enterprises)
            {
                var observer = new EnterpriseObserver(_userService, enterprise);
                _offerSubject.Attach(observer);
            }
        }
    }
}
