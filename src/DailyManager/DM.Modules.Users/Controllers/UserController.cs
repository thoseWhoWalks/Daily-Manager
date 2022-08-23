using DM.Module.Users.Models;
using DM.Module.Users.Services;
using Microsoft.AspNetCore.Mvc;

namespace DM.Module.Users.Controllers
{
    [Route("api/users")]
    internal class UserController : Controller
    {
        #region Dependencies

        private readonly IUserService _service;

        #endregion

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task CreateAsync([FromBody] UserToCreateModel model)
        {
            await _service.CreateAsync(model);
        }

        [HttpPut]
        public async Task UpdateAsync([FromBody] UserToUpdateModel model)
        {
            await _service.UpdateAsync(model);
        }

        [HttpPatch, Route("{id}/edit/password")]
        public async Task ChangePasswordAsync([FromBody] UserToChangePasswordModel model)
        {
            await _service.ChangePasswordAsync(model);
        }

        [HttpDelete, Route("{id}")]
        public void Delete([FromRoute] Guid id)
        {
            _service.Delete(id);
        }
    }
}
