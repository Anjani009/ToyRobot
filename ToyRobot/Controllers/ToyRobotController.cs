using Microsoft.AspNetCore.Mvc;
using ToyRobot.Models;

namespace ToyRobot.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ToyRobotController : ControllerBase
    {
        private readonly Robot _robot;
        public ToyRobotController(Robot robot)
        {
            _robot = robot;
        }

        [HttpPost]
        [Route("place")]
        public IActionResult Place(PlaceRequest request)
        {
            _robot.Place(request.X, request.Y, request.direction);
            return Ok("Robot placed.");
        }

        [HttpPost]
        [Route("move")]
        public IActionResult Move()
        {
            _robot.Move();
            return Ok("Robot moved.");
        }

        [HttpPost]
        [Route("left")]
        public IActionResult Left()
        {
            _robot.Left();
            return Ok("Robot turned left.");
        }

        [HttpPost]
        [Route("right")]
        public IActionResult Right()
        {
            _robot.Right();
            return Ok("Robot turned right.");
        }

        [HttpGet]
        [Route("report")]
        public IActionResult Report()
        {
            return Ok(_robot.Report());
        }
    }
}
