using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using testApp.Context;
using testApp.Models;

namespace testApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserConnect _connect;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController( UserManager<User> userManager, SignInManager<User> signInManager, UserConnect db)
        {
           
            _userManager = userManager;
            _signInManager = signInManager;
            _connect = db;
        }


        [HttpGet]
        public IActionResult SignIn()
        {
            User user = new User();
            return View(user);
        }


        [HttpGet]
        public IActionResult Register()
        {
            User user = new User();
            return View(user);
        }

        [AllowAnonymous]
        [HttpPost]
        //[Route("register")]
        public async Task<IActionResult> Register(User model)
        {
            var userCheck = await _userManager.FindByEmailAsync(model.Email);


            if (userCheck != null)   //existing user
            {
                
                return RedirectToAction("Login");
            }

            if (model.Password != model.ConfirmPassword)
                ModelState.AddModelError("", "Passwords do not match");

            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                name = model.name,
                lastname = model.lastname,
                age = model.age,
                Gender = model.Gender

            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded && (model.age > 17))
            {
                
                return RedirectToAction("post_register","page");
            }


            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }



        [AllowAnonymous]
        [HttpPost]
        //[Route("authenticate")]

        public async Task<IActionResult> SignIn(User model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                ModelState.AddModelError("", "No Email found");

            if (await _userManager.CheckPasswordAsync(user, model.Password) == false)
                ModelState.AddModelError("", "Wrong password");

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));
                return RedirectToAction("mainpage", "page");
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("mainpage", "page");
        }

    }
}
