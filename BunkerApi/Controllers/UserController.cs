using Application.Users.Commands.Registration;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BunkerApi.Models.User;

namespace BunkerApi.Controllers
{
    [ApiController]
    [Route("api/{version:apiVersion}/users")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// POST /api/1.0/users
        /// {
        ///     "Nickname": "v4dikos",
        ///     "Email": "v4dikos@yandex.ru",
        ///     "Password": "12345"
        /// }
        /// Файл берется из формы
        /// </remarks>
        /// <param name="request">Данные о пользователе</param>
        /// <returns>Возвращает пустой ответ</returns>
        /// <response code="204">Выполнено успешно</response>
        /// <response code="400">Ошибки валидации</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateUser([FromForm] UserRegistrationDto request)
        {
            var command = _mapper.Map<RegistrationCommand>(request);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
