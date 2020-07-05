using System;
using Stateless;

namespace finite_state_machine
{
    public enum Events
    {
        PersonalDetailsSubmitted = 1,
        EmailVerified = 2,
        FinancialDetailsSubmitted = 3
    }

    class Program
    {
        static void Main(string[] args)
        {
            var state = new State();

            var machine = CreateStateMachine(state);

            Console.WriteLine(state);
            Console.WriteLine(machine.State.Url);

            MakeTransition(machine, Events.PersonalDetailsSubmitted, state);
            MakeTransition(machine, Events.EmailVerified, state);
            MakeTransition(machine, Events.FinancialDetailsSubmitted, state);
        }

        private static void MakeTransition(StateMachine<Page, Events> machine, Events trigger, State state)
        {
            machine.Fire(trigger);
            Console.WriteLine(state);
            Console.WriteLine(machine.State.Url);
        }

        private static StateMachine<Page, Events> CreateStateMachine(State state)
        {
            var machine = new StateMachine<Page, Events>(Page.PersonalDetailsPage);
            machine.Configure(Page.PersonalDetailsPage)
                .Permit(Events.PersonalDetailsSubmitted, Page.EmailVerificationPage)
                .OnExit(() => state.PersonalDetailsCompletedOn = DateTime.UtcNow);
            
            machine.Configure(Page.EmailVerificationPage)
                .Permit(Events.EmailVerified, Page.FinancialDetailsPage)
                .OnExit(() => state.EmailVerifiedOn = DateTime.UtcNow);
            
            machine.Configure(Page.FinancialDetailsPage)
                .Permit(Events.FinancialDetailsSubmitted, Page.RegistrationCompletedPage)
                .OnExit(() => state.FinancialDetailsCompletedOn = DateTime.UtcNow);
            
            return machine;
        }

        private static string GetPage(State state)
        {
            return "";
        }
    }
}
