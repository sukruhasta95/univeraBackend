using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //account messages:
        public static string AccountAdded = "Hesap Eklendi";
        public static string AccountDeleted = "Hesap Silindi";
        public static string AccountUpdated = "Hesap Güncellendi";
        public static string AccountNotFound = "Hesap Bulunamadı";
        public static string InsufficientBalance = "Yetersiz Bakiye";
        public static string QuantityIsNotLessThenZero = "Sıfırdan büyük değer giriniz.";

        //user messages:

        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserNotFound = "Kullanıcı Bulunamadı";

    }
}
