using Azure.Core;
using EscolaDeIdiomasApp.Domain.DTOs.Request;
using EscolaDeIdiomasApp.Domain.DTOs.Response;
using EscolaDeIdiomasApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EscolaDeIdiomasApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController(ITurmasDomainService turmasDomainService) : ControllerBase
    {
        [HttpPost("cadastrar-turma")]
        [ProducesResponseType(typeof(TurmaResponseDto), StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] TurmaRequestDto request)
        {
            try
            {
                var result = turmasDomainService.CriarTurma(request);

                return StatusCode(StatusCodes.Status201Created, result);
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

        [HttpPut("atualizar-turma/{id}")]
        [ProducesResponseType(typeof(TurmaResponseDto), StatusCodes.Status200OK)]
        public IActionResult Update(Guid id, [FromBody] TurmaRequestDto request)
        {
            try
            {
                var result = turmasDomainService.AtualizarTurma(id, request);

                return StatusCode(StatusCodes.Status200OK, result);
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

        [HttpDelete("remover-turma/{id}")]
        [ProducesResponseType(typeof(TurmaResponseDto), StatusCodes.Status200OK)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var result = turmasDomainService.ExcluirTurma(id);

                return StatusCode(StatusCodes.Status200OK, result);
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

        [HttpGet("obter-turma/{id}")]
        [ProducesResponseType(typeof(TurmaResponseDto), StatusCodes.Status200OK)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var result = turmasDomainService.ObterTurmaPorId(id);

                return StatusCode(StatusCodes.Status200OK, result);
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

        [HttpGet("listar-niveis-turmas")]
        [ProducesResponseType(typeof(NivelTurmaDto), StatusCodes.Status200OK)]
        public IActionResult GetClassesLevels()
        {
            var result = turmasDomainService.ListarNiveisDasTurmas();

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("listar-turmas")]
        [ProducesResponseType(typeof(TurmaResponseDto), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            try
            {
                var result = turmasDomainService.ListarTurmas();

                return StatusCode(StatusCodes.Status200OK, result);
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
