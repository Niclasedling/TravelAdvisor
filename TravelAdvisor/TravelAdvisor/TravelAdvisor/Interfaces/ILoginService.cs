using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TravelAdvisor.Interfaces
{
    public interface ILoginService
    {
        Task Login(string Email, string Password);
        //Task Register (string Email, string Password, string Firstname, string Lastname);
    }
}
