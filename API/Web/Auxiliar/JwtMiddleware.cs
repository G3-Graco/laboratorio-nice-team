﻿using Core.Entidades;
using Core.Interfaces.Servicios;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Web.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        // private IUserService _service;
        private readonly IConfiguration _configuration;

        public JwtMiddleware(RequestDelegate next, IConfiguration configuracion)
        {
            // _service = userService;
            _next = next;
            _configuration = configuracion;
        }

        public async Task Invoke(HttpContext context, IUsuarioServicio usuarioServicio)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                await attachUserToContext(context, usuarioServicio, token);

            await _next(context);
        }

        private async Task attachUserToContext(HttpContext context, IUsuarioServicio usuarioServicio, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var skey = _configuration["Jwt:Key"];
                var key = Encoding.ASCII.GetBytes(skey);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var usuarioId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                

                var usuario = await usuarioServicio.ObternerPorIdAsincrono(usuarioId);

                if (usuario != null) context.Items["ok"] = true;
            }
            catch
            {
                //
            }
        }

    }
}