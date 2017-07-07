using System;
using System.Collections.Generic;
using System.Text;

namespace Fiver.Azure.Email.Message
{
    public sealed class EmailMessage
    {
        private readonly List<string> to;
        private readonly List<string> cc;
        private readonly List<string> bcc;
        private readonly List<string> attachments;

        public EmailMessage(string subject, string from, string body, List<string> to, 
            List<string> cc, List<string> bcc, List<string> attachments)
        {
            if (string.IsNullOrEmpty(subject))
                throw new ArgumentException("Subject must be set");

            if (string.IsNullOrEmpty(from))
                throw new ArgumentException("From must be set");

            if (string.IsNullOrEmpty(body))
                throw new ArgumentException("Body must be set");

            if (to.Count == 0)
                throw new ArgumentException("At least one To must be set");

            this.Subject = subject;
            this.From = from;
            this.Body = body;
            this.to = to;
            this.cc = cc;
            this.bcc = bcc;
            this.attachments = attachments;
        }

        public string Subject { get; }
        public string From { get; }
        public string Body { get; }
        public IReadOnlyList<string> To => to;
        public IReadOnlyList<string> CC => cc;
        public IReadOnlyList<string> BCC => bcc;
        public IReadOnlyList<string> Attachments => attachments;
    }
}
