namespace ZeroStack.IdentityServer.API.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; } = null!;

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public Duende.IdentityServer.Models.ErrorMessage? Error { get; set; }
    }
}
