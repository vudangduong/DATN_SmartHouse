using Microsoft.AspNetCore.Mvc;
using SmartHouse.Server.Entity;
using SmartHouse.Server.Model_DTO.User_DTO;
namespace SmartHouse.Controllers
{
    public class UserController : Controller
    {
        HttpClient _httpClient;
        public UserController()
        {
            _httpClient = new HttpClient();
        }
        public async Task< IActionResult> Index()
        {
            try
            {
                var users = await _httpClient.GetFromJsonAsync<IEnumerable<TbUser>>("https://localhost:7027/api/User/get_list");
                return View(users);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest obj)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<CreateUserRequest>("https://localhost:7027/api/User/post", obj);

                if (response.IsSuccessStatusCode) return RedirectToAction("Index");
                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var users = await _httpClient.GetFromJsonAsync<IEnumerable<TbUser>>("https://localhost:7027/api/User/get_list");
                var user = users.SingleOrDefault(c=>c.Id == id);
                CreateUserRequest response = new CreateUserRequest()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = user.Password,
                    Position = user.Position,
                    UserCode = user.UserCode,
                    FullName = user.FullName,
                    InActive = user.InActive
                };
                if(user == null)
                {
                    return BadRequest();
                }
                return View(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, CreateUserRequest obj)
        {
            try
            {
                // https://localhost:7027/api/User/put/a0e329cb-b6b6-44de-91a0-146d1679d479
                
                obj.AdminId = Guid.NewGuid();
                obj.LoginType = true;
                obj.Limit = 1;
                obj.UserCode = "pass";
                obj.Token = "ba";
                obj.UserId = id;
                obj.UserName = "siuuuu";
                var URL = $"https://localhost:7027/api/User/put/{id}";
                var response = await _httpClient.PutAsJsonAsync<CreateUserRequest>(URL, obj);//($"https://localhost:7027/api/User/put/{id}", obj);
                if (response.IsSuccessStatusCode) return RedirectToAction("Index");
                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"https://localhost:7027/api/User/delete/{id}");
                if(response.IsSuccessStatusCode) return RedirectToAction("Index");
                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }
    }
}
