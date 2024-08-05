using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Domain.Settings
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }    // JWT oluşturmak ve doğrulamak için kullanılan anahtar
        public string Issuer { get; set; }       // Token'ı oluşturan kuruluş
        public string Audience { get; set; }     // Token'ın geçerli olduğu kullanıcılar
        public int ExpirationMinutes { get; set; } // Token'ın geçerlilik süresi (dakika cinsinden)
    }
}
