using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserLoginSystem.ViewModels;

namespace UserLoginSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleInManager = roleInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            IdentityUser user = new IdentityUser
            {
                Email = model.EmailAdress,
                UserName = model.UserName,
            };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return View(model);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            ModelState.AddModelError("Error", "Username or Password is not correct");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            IdentityRole role = new IdentityRole
            {
                Name = model.RoleName
            };
            var result = await _roleInManager.CreateAsync(role);
            if (result.Succeeded)
            {
                ViewBag.Success = "Role is Created";
                return View();
            }
            foreach (var err in result.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }
            return View();
        }
        [HttpGet]
        public IActionResult DeleteRole()
        {
            List<RoleViewModel> rolelist = new List<RoleViewModel>();
            foreach (var role in _roleInManager.Roles)
            {
                RoleViewModel viewModel = new RoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                rolelist.Add(viewModel);
            }
            return View(rolelist);
        }
        public async Task<IActionResult>DeletedRole(string id)
        {
           var role =  await _roleInManager.FindByIdAsync(id);
            if (role!=null)
            {
                await _roleInManager.DeleteAsync(role);
            }
            return RedirectToAction("DeleteRole","Account");
        }
        [HttpGet]
        public IActionResult AddRoleToUser()
        {
            SetRoleToUser model = new SetRoleToUser
            {
                UserList = _userManager.Users.ToList(),
                RolerList = _roleInManager.Roles.ToList()
            };
            return View(model);
        }
        [HttpPost]
        public async Task< IActionResult> AddRoleToUser(SetRoleToUser model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            await _userManager.AddToRoleAsync(user, model.RoleId);
            return RedirectToAction("AddRoleToUser", "Account");
        }
        public IActionResult Denied()
        {
            return View();
        }
    }
}
