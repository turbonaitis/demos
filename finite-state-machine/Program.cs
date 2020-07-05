using System;
using Finite;
using finite_state_machine.workflow;
using Shouldly;

namespace finite_state_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            var state = new State();
            var machine = CreateStateMachine(state);
            Console.WriteLine(state);
            Console.WriteLine(GetPage(machine));
            
            TestTransition<EmailVerificationStep>(s => s.PersonalDetailsCompletedOn = DateTime.Now, state, machine);

            TestTransition<FinancialDetailsStep>(s => s.EmailVerifiedOn = DateTime.Now, state, machine);

            TestTransition<RegistrationCompleted>(s => s.FinancialDetailsCompletedOn = DateTime.Now, state, machine);
        }

        private static void TestTransition<TStep>(Action<State> mutator, State state, Finite.StateMachine<State> machine)
            where TStep:Finite.State<State>
        {
            Action emailVerificationTransition = () => machine.TransitionTo<TStep>();
            emailVerificationTransition.ShouldThrow<Finite.InvalidTransitionException>();
            mutator(state);
            emailVerificationTransition.ShouldNotThrow();
            Console.WriteLine(state);
            Console.WriteLine(GetPage(machine));
        }

        private static Finite.StateMachine<State> CreateStateMachine(State state)
        {
            var allStates = new Finite.State<State>[]{
                new PersonalDetailsStep(),
                new EmailVerificationStep(),
                new FinancialDetailsStep(),
                new RegistrationCompleted()
            };

            var machine = new Finite.StateMachine<State>(
                new Finite.StateProviders.ManualStateProvider<State>(allStates),
                state);

            machine.ResetTo<PersonalDetailsStep>();

            return machine;
        }

        private static string GetPage(StateMachine<State> machine)
        {
            if(machine.CurrentState is IUrlProvider urlProvider){
                return urlProvider.Url;
            }

            throw new ArgumentException();
        }
    }
}
