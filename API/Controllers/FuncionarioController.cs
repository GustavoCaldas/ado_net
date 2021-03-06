using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepository rep;
        public FuncionarioController(IFuncionarioRepository rep)
        {
            this.rep = rep;

        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllFuncionario()
        {
            return Ok(await this.rep.GetAllFuncionarios());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetFuncionarioById(int id)
        {
            return Ok(await this.rep.GetFuncionarioById(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateFuncionario([FromBody] Funcionario funcionario)
        {
            await this.rep.AddFuncionario(funcionario);
            return Ok("Funcionario has been created");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteFuncionario(int id)
        {
            await this.rep.RemoveFuncionario(id);
            return Ok("Funcionario has been deleted");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateFuncionario(int id, [FromBody] Funcionario funcionario)
        {
            funcionario.Id = id;
            await this.rep.UpdateFuncionario(funcionario);
            return Ok("Funcionario has been updated");
        }
    }
}