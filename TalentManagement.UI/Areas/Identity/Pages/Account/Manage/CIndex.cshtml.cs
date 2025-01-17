﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TalentManagement.Domain.Entities;

namespace TalentManagement.UI.Areas.Identity.Pages.Account.Manage
{
    public partial class CIndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public CIndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            //[Required]
            //[Display(Name = "First Name")]
            //public string FirstName { get; set; }
            //[Required]
            //[Display(Name = "Last Name")]
            //public string LastName { get; set; }
            [Required]
            [Display(Name = "Company Name")]
            public string CompanyName { get; set; }
            
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            //var firstName = user.FirstName;
            //var lastName = user.LastName;
            var companyName = user.CompanyName;
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                //FirstName=firstName,
                //LastName=lastName,
                CompanyName=companyName
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var firstName = user.FirstName;
            var lastName = user.LastName;   
            var companyName = user.CompanyName;
            //if (Input.FirstName != firstName)
            //{
            //    user.FirstName = Input.FirstName;
            //    await _userManager.UpdateAsync(user);
            //}
            //if (Input.LastName != lastName)
            //{
            //    user.LastName = Input.LastName;
            //    await _userManager.UpdateAsync(user);
            //}
            if (Input.CompanyName != companyName)
            {
                user.CompanyName = Input.CompanyName;
                await _userManager.UpdateAsync(user);
            }
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
