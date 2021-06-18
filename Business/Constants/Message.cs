using Entity.ConCreate;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Message
    {
        public static string LengthError = "Veri istenilen uzunlukta değil";
        public static string LoginSuccess = "Giriş Başarılı";
        public static string LoginError = "Giriş Başarsız";
        public static string AuthorizationDenied = "yetkiniz yok";
        public static string UserRegistered = "Kayıt Başarılı";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string AccessTokenCreated = "Token Oluşturuldu";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string PasswordError = "Parola Hatalı";
        public static string CarCountLenghtError = "Bu Kriterlerde Araç Mevcut Değil";
        public static string CarNotFound = "Araç Mevcut Değil";
    }
}
