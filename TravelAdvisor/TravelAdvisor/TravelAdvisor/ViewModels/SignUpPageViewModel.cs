using System;
using System.Collections.Generic;
using System.Text;
using TravelAdvisor.Models;
using TravelAdvisor.Services;
using Xamarin.Forms;

namespace TravelAdvisor.ViewModels
{
    public class SignUpPageViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        public Command<object> RegisterCommand
        {
            get
            {
                return new Command<object>(Register);
            }
        }
        public SignUpPageViewModel(INavService naviService) : base(naviService)
        {
            _userService = DependencyService.Get<IUserService>();
            //Code for creating the ViewModel


        }

        public override void Init()
        {   
            
            //Code for initialize the ViewModel
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string firstname;
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        private string lastname;
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        async void Register(object sender)
        {
            
            UserCreateDto userCreateDto = new UserCreateDto
            {
                Email = Email,
                Password = Cryptography.EncryptData(Password),
                FirstName = Firstname,
                LastName = Lastname,
            };
           var guid = await _userService.CreateUser(userCreateDto);

        }
        
    }
}
