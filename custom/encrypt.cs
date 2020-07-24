using Microsoft.AspNetCore.DataProtection;

namespace univo.custom
{   
  
    public class encrypt
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;
       private const string Key = "autogenerado12342434-0_"; //clave de encriptacion

       public encrypt(IDataProtectionProvider dataProtectionProvider)
       {
           _dataProtectionProvider = dataProtectionProvider;
       }

       public string Encrypt(string input)
       {
           var protector = _dataProtectionProvider.CreateProtector(Key);
           return protector.Protect(input);
       } //retornar el string encriptado

       public string Decrypt(string cipherText)
       {
           var protector = _dataProtectionProvider.CreateProtector(Key);
           return protector.Unprotect(cipherText);
       }//retorna el string desencriptado
    }


}