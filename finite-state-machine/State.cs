using System;

namespace finite_state_machine
{
    public class State
    {
        public DateTime? PersonalDetailsCompletedOn { get; set; }

        public DateTime? EmailVerifiedOn { get; set; }

        public DateTime? FinancialDetailsCompletedOn { get; set; }

        public bool HasCompletedPersonalDetails => PersonalDetailsCompletedOn != null;

        public bool HasVerifiedEmail => EmailVerifiedOn != null;

        public bool HasCompletedFinancialDetails => FinancialDetailsCompletedOn != null;
    }
}