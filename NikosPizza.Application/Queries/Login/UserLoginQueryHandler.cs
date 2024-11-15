
using MediatR;
using Microsoft.AspNetCore.Identity;
using NikosPizza.core.Entities.Identity;
using System.Linq.Expressions;


namespace NikosPizza.Application.Queries.Login
{
    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, UserLoginQueryResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly IPasswordValidator<ApplicationUser> _passwordValidator;

        public UserLoginQueryHandler(UserManager<ApplicationUser> userManager,
        IPasswordHasher<ApplicationUser> passwordHasher,
        IPasswordValidator<ApplicationUser> passwordValidator)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _passwordValidator = passwordValidator;

        }

        public async Task<UserLoginQueryResponse> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            UserLoginQueryResponse response = new UserLoginQueryResponse();
            // Busca el usuario por su email
            var user = await _userManager.FindByEmailAsync(request.Usuario);
            if (user == null)
            {
                response.Mensaje = "Usuario no encontrado";
                response.IsSuccess = false;
                // Usuario no encontrado
                return response;
            }

            // Valida la contraseña usando CheckPasswordAsync
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Contrasenia);

            if (isPasswordValid)
            {
                response.Mensaje = "Contraseña Correcta";
                response.IsSuccess = true;
                // Usuario no encontrado
                return response;
            }
            else
            {
                response.Mensaje = "Contraseña incorrecta";
                response.IsSuccess = false;
                // Usuario no encontrado
                return response;
            }


        }
    }
}