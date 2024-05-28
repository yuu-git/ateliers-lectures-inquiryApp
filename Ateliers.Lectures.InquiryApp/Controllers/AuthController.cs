using Ateliers.Lectures.InquiryApp.Models.User;
using Ateliers.Lectures.InquiryApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

/// <summary>
/// 認証コントローラー
/// </summary>
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    /// <summary>
    /// コンストラクター
    /// </summary>
    /// <param name="authService"> 認証サービス </param>
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// ユーザー登録画面を表示します。
    /// </summary>
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    /// <summary>
    /// ユーザーを登録します。
    /// </summary>
    /// <param name="model">ユーザーモデル</param>
    [HttpPost]
    public async Task<IActionResult> Register(UserModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _authService.RegisterUserAsync(model.Username, model.Password, model.Email);
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"ユーザー登録中にエラーが発生しました: {ex.Message}");
                Console.WriteLine($"Error registering user: {ex.Message}");
            }
        }
        else
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
        }

        return View(model);
    }

    /// <summary>
    /// ログイン画面を表示します。
    /// </summary>
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    /// <summary>
    /// ユーザーをログインします。
    /// </summary>
    /// <param name="model">ログインビューモデル</param>
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (_authService.ValidateUser(model.Username, model.Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "MyCookieAuth");
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                await HttpContext.SignInAsync("MyCookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "ユーザー名またはパスワードが無効です。");
        }

        return View(model);
    }

    /// <summary>
    /// ユーザーをログアウトします。
    /// </summary>
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("MyCookieAuth");
        return RedirectToAction("Login");
    }
}
