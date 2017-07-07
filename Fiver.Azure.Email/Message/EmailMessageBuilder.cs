using System;
using System.Collections.Generic;
using System.Text;

namespace Fiver.Azure.Email.Message
{
    public sealed class EmailMessageBuilder :
        IEmailMessageAddSubject,
        IEmailMessageAddFrom,
        IEmailMessageAddBody,
        IEmailMessageAddTo,
        IEmailMessageBuilder
    {
        private string subject = "";
        private string from = "";
        private string body = "";
        private List<string> to = new List<string>();
        private List<string> cc = new List<string>();
        private List<string> bcc = new List<string>();
        private List<string> attachments = new List<string>();

        private EmailMessageBuilder() { }

        public static IEmailMessageAddSubject Init()
        {
            return new EmailMessageBuilder();
        }

        public IEmailMessageAddFrom AddSubject(string subject)
        {
            this.subject = subject;
            return this;
        }

        public IEmailMessageAddBody AddFrom(string from)
        {
            this.from = from;
            return this;
        }

        public IEmailMessageAddTo AddBody(string body)
        {
            this.body = body;
            return this;
        }

        public IEmailMessageBuilder AddTo(string to)
        {
            this.to.Add(to);
            return this;
        }

        public IEmailMessageBuilder AddCC(string cc)
        {
            this.cc.Add(cc);
            return this;
        }

        public IEmailMessageBuilder AddBCC(string bcc)
        {
            this.bcc.Add(bcc);
            return this;
        }

        public IEmailMessageBuilder AddAttachment(string attachment)
        {
            this.attachments.Add(attachment);
            return this;
        }

        public EmailMessage Build()
        {
            return new EmailMessage(
                subject: this.subject,
                from: this.from,
                body: this.body,
                to: this.to,
                cc: this.cc,
                bcc: this.bcc,
                attachments: this.attachments);
        }
    }

    #region " Abstractions "

    public interface IEmailMessageAddSubject
    {
        IEmailMessageAddFrom AddSubject(string subject);
    }

    public interface IEmailMessageAddFrom
    {
        IEmailMessageAddBody AddFrom(string from);
    }

    public interface IEmailMessageAddBody
    {
        IEmailMessageAddTo AddBody(string body);
    }

    public interface IEmailMessageAddTo
    {
        IEmailMessageBuilder AddTo(string to);
    }

    public interface IEmailMessageBuilder
    {
        IEmailMessageBuilder AddTo(string to);
        IEmailMessageBuilder AddCC(string cc);
        IEmailMessageBuilder AddBCC(string bcc);
        IEmailMessageBuilder AddAttachment(string attachment);
        EmailMessage Build();
    }

    #endregion 
}
