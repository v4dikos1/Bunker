using MediatR;

namespace Application.Pictures.Commands.Delete
{
    public class DeletePictureCommand : IRequest
    {
        /// <summary>
        /// Code удаляемого файла
        /// </summary>
        public Guid Id { get; set; }
    }
}
