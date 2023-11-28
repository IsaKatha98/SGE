namespace Ejercicio03.Models
{
    public class ErrorViewModel
    {
        public string?  RequestId { get; set; }

        public  bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public static string mensajeError()
        {
            string error = "ayuda";

            return error;
        }
    }
}