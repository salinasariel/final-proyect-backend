using final_proyect.Interfaces;
using final_proyect_backend.Models;
using System;

namespace final_proyect.Observer
{
    public class EnterpriseObserver : IObserver
    {
        private readonly IUserService _userService;
        private readonly Enterprises _enterprise;

        public EnterpriseObserver(IUserService userService, Enterprises enterprise)
        {
            _userService = userService;
            _enterprise = enterprise;
        }

        public void Update(Offers offer, Students student)
        {
            _userService.NotifyEnterprise(_enterprise, offer, student);
        }
    }
}
