using Azure.Core;
using EscolaDeIdiomasApp.Domain.DTOs.Request;
using EscolaDeIdiomasApp.Domain.DTOs.Response;
using EscolaDeIdiomasApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EscolaDeIdiomasApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController(IAlunosDomainService alunosDomainService, IAlunoTurmasDomainService alunoTurmasDomainService) : ControllerBase
    {
        [HttpPost("cadastrar-aluno")]
        [ProducesResponseType(typeof(AlunoResponseDto), StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] CadastrarAlunoRequestDto request)
        {
            try
            {
                AlunoResponseDto response = alunosDomainService.CriarAluno(request);

                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (ValidationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    message = $"Erros de validação: {ex.Message}"
                });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message
                });
            }
        }

        [HttpPost("matricular-aluno-turma/{id}")]
        [ProducesResponseType(typeof(AlunoResponseDto), StatusCodes.Status200OK)]
        public IActionResult SubscribeToClass(Guid id, [FromBody] AlunoTurmasRequestDto request)
        {
            try
            {
                AlunoResponseDto response = alunoTurmasDomainService.MatricularAlunoEmTurma(id, request);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (ValidationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    message = $"Erros de validação: {ex.Message}"
                });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message
                });
            }
        }

        [HttpPut("atualizar-aluno/{id}")]
        [ProducesResponseType(typeof(AlunoResponseDto), StatusCodes.Status200OK)]
        public IActionResult Update(Guid id, AtualizarAlunoRequestDto request)
        {
            try
            {
                AlunoResponseDto response = alunosDomainService.AtualizarAluno(id, request);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (ValidationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    message = $"Erros de validação: {ex.Message}"
                });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message
                });
            }
        }

        [HttpDelete("remover-aluno/{id}")]
        [ProducesResponseType(typeof(AlunoResponseDto), StatusCodes.Status200OK)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                AlunoResponseDto response = alunosDomainService.ExcluirAluno(id);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message
                });
            }
        }

        [HttpDelete("remover-aluno-turma/{id}")]
        [ProducesResponseType(typeof(AlunoResponseDto), StatusCodes.Status200OK)]
        public IActionResult RemoveFromClass(Guid id, [FromBody] AlunoTurmasRequestDto request)
        {
            try
            {
                AlunoResponseDto response = alunoTurmasDomainService.RemoverAlunoDaTurma(id, request);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (ValidationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    message = $"Erros de validação: {ex.Message}"
                });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message
                });
            }
        }

        [HttpGet("obter-aluno/{id}")]
        [ProducesResponseType(typeof(AlunoResponseDto), StatusCodes.Status200OK)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                AlunoResponseDto response = alunosDomainService.ObterAlunoPorId(id);

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message
                });
            }
        }

        [HttpGet("listar-alunos")]
        [ProducesResponseType(typeof(AlunoResponseDto), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            try
            {
                List<AlunoResponseDto>? response = alunosDomainService.ListarAlunos();

                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message
                });
            }
        }
    }
}
