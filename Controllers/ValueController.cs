using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockerMenuApi.Models;

namespace DockerMenuApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ValueController : ControllerBase
    {

        private readonly MenuContext _context;

        public ValueController(MenuContext context)
        {
            _context = context;
        }

        //get Api Values
        [HttpGet]
        public ActionResult<IEnumerable<Menu>> GetMenuItem()
        {

            return _context.MenusItem;
        }

    }
}
