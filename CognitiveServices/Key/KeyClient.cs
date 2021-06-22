using System;
using System.Collections.Generic;
using System.Text;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;

namespace CognitiveServices.Key
{
    /*Esta clase se conecta al servicio de KeyVault a través de AAD
     * Información necesaria:
     * 1- CLIENT_ID
     * 2.-TENANT_ID
     * 3.-SECRET_CLIENT
     * 4.-VAULT_URI
     */
    class KeyClient
    {
        private static readonly string CLIENT_ID = "ab1b0dbe-ef3e-431b-98f9-428ac4104bb6";
        private static readonly string TENANT_ID = "8f801786-dcd2-4f6b-b81e-f961ea9a9e20";
        private static readonly string SECRET_CLIENT = "G-MS6ddxP6K1wheM.75z37oKI~oYY_2-i3";
        private static readonly string VAULT_URI = "https://keyenvf.vault.azure.net/";

        /*Atributo utilizado para obtener los secretos en cualquier parte del código*/
        public static SecretClient Secret{ get; private set; }

        /*Constructor*/
        static KeyClient() { InitKeyVault(); }

        private static void InitKeyVault() {
            if (Secret==null) {
                var credencial = new ClientSecretCredential(TENANT_ID, CLIENT_ID, SECRET_CLIENT);
                Secret = new SecretClient(new Uri(VAULT_URI), credencial);
            }
        }


    }
}
