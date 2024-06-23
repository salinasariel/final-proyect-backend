using final_proyect.Interfaces;
using final_proyect.Services;
using final_proyect_backend.Models;
using System;

namespace final_proyect.Observer
{
    public class OfferSubject
    {
        private readonly List<IObserver> _observers;
        private readonly EmailService _emailService;
        private readonly IUserService _userService;

        public OfferSubject(EmailService emailService, IUserService userService)
        {
            _emailService = emailService;
            _userService = userService;
            _observers = new List<IObserver>();
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            if (observer != null)
            {
                _observers.Remove(observer);
            }
        }

        public async Task Notify(Offers offer, Students student)
        {
            foreach (var observer in _observers)
            {
                observer.Update(offer, student);
            }

            var enterprise = _userService.GetEnterpriseById(offer.UserId);
            if (enterprise != null)
            {
                await _emailService.SendEnterpriseApplicationNotification(enterprise.Email, student.Name, offer.Tittle);
            }
        }
    }

}
