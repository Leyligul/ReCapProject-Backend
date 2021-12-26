using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added =  "Eklendi.";
        public static string InformationInvalid = "Bilgiler geçersiz.";
        public static string Listed = "Listelendi.";
        public static string InvalidRequest = "Kiralama işlemi gerçekleştirilemiyor.";
        public static string Deleted = "Sililndi.";
        public static string Updated = "Güncellendi.";
        public static string CarImageNumberError = "Bir arabanın en fazla 5 resmi olabilir.";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kayıt oldu.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Hatalı şifre";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut.";
        public static string AccessTokenCreated = "Token oluşturuldu.";
        public static string RequiredFieldError = "Lütfen tüm alanların dolu olduğundan emin olunuz.";
        public static string SuccessfulPayment = "Ödemeniz başarılı şekilde gerçekleştirldi.";
        public static string AlreadyRented = "Bu tarih aralığında araba zaten kiralanmıştır.";
        public static string CardAdded = "Kart bilgileri kayıt edildi.";
        public static string CardDeleted = "Kart bilgileri silindi.";
        public static string CardUpDated = "Kart bilgileri güncellendi.";
        public static string ColorAlreadyExist = "Bu renk zaten kayıtlı.";
        public static string BrandAlreadyExist = "Bu marka zaten kayıtlı.";
     
        //public static string CarImageAlreadyExist = "Bu fotoğraf zaten mevcut.";
    }
}
