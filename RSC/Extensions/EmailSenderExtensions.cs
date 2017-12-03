using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using RSC.Services;

namespace RSC.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Подтверждение email",
                $"Пожалуйста подтвердите ваш  email: <a href='{HtmlEncoder.Default.Encode(link)}'>Подтвердить</a>");
        }
    }
}
