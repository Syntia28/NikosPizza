
using MediatR;

namespace NikosPizza.Application.Queries.Login
{
    public class UserLoginQuery : IRequest<UserLoginQueryResponse>
    {
        public UserLoginQuery() { }

        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
    }
}