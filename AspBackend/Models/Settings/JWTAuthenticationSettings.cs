using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Aspbackend.Models.Settings ;

    /// <summary>
    /// Настройка JWT
    /// </summary>
    public class JWTAuthenticationSettings
    {
        /// <summary>
        /// Издатель
        /// </summary>
        public required string Issuer { get; set; }

        /// <summary>
        /// Слушатель
        /// </summary>
        public required string Audience { get; set; }

        /// <summary>
        /// Секрет
        /// </summary>
        public required string Secret { get; set; }

        /// <summary>
        /// Срок жизни токена
        /// </summary>
        public int TokenLifetime { get; set; }

        /// <summary>
        /// Получить ключ безопасности
        /// </summary>
        /// <returns></returns>
        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }