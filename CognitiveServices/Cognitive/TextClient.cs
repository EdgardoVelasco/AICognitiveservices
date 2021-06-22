using System;
using System.Collections.Generic;
using System.Text;
using Azure.AI.TextAnalytics;
using Azure;
using CognitiveServices.Key;

namespace CognitiveServices.Cognitive
{
    /*Esta clase se conecta al servicio cognitivo de azure.
     * Información necesaria para la conexión:
     * 1.- ENDPOINT
     * 2.- APIKEY
     */
    class TextClient
    {
        private static readonly string ENDPOINT = "https://cognitiveenvf.cognitiveservices.azure.com/";
        //private static readonly string API_KEY = "7b5338129cb948588945200a43bc8228";

        /*Atributo necesario para  obtener el servicio  cognitivo fuera de la clase*/
        public static TextAnalyticsClient Text { get; private set; }

        /*Constructor: Es utilizado para inicializar los atributos de una clase*/
        static TextClient() { InitText();  }

        /*Método que nos ayuda a conectar el servicio cognitivo con la clase*/
        private static void InitText() {
            if (Text==null) {
                var API_KEY = KeyClient.Secret.GetSecret("cognitivek1").Value.Value;
                var credencial = new AzureKeyCredential(API_KEY);
                Text = new TextAnalyticsClient(new Uri(ENDPOINT), credencial);
            }
        }

    }
}
