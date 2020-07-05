using System;

namespace finite_state_machine.workflow
{
    public interface IUrlProvider
    {
        string Url {get;}
    }

    public class PersonalDetailsStep: Finite.State<State>, IUrlProvider
    {
        public PersonalDetailsStep()
        {
            LinkTo<EmailVerificationStep>(s => s.HasCompletedPersonalDetails);
        }

        public string Url => "/personal-details";
    }

    public class EmailVerificationStep: Finite.State<State>, IUrlProvider
    {
        public EmailVerificationStep()
        {
            LinkTo<FinancialDetailsStep>(s => s.HasVerifiedEmail);
        }

        public string Url => "/verify-email";
    }

    public class FinancialDetailsStep: Finite.State<State>, IUrlProvider
    {
        public FinancialDetailsStep()
        {
            LinkTo<RegistrationCompleted>(s => s.HasCompletedFinancialDetails);
        }

        public string Url => "/financial-details";
    }

    public class RegistrationCompleted: Finite.State<State>, IUrlProvider
    {
        public string Url => "/success";
    }
}