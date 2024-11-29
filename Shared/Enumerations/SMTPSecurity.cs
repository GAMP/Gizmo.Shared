using System.ComponentModel.DataAnnotations;

namespace Gizmo
{
    public enum SMTPSecurity
    {
        [Name("None", "SMTP_SECURITY_NONE")]
        None = 0,
        [Name("SSL", "SMTP_SECURITY_SSL")]
        SSL = 1,
        [Name("None", "SMTP_SECURITY_STARTTLS")]
        STARTTLS = 2
    }
}
