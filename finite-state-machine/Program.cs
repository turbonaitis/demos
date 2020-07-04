using System;

namespace finite_state_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            var state = new State();
            Console.WriteLine(state);
            Console.WriteLine(GetPage(state));

            state.PersonalDetailsCompletedOn = DateTime.Now;
            Console.WriteLine(state);
            Console.WriteLine(GetPage(state));

            state.EmailVerifiedOn = DateTime.Now;
            Console.WriteLine(state);
            Console.WriteLine(GetPage(state));

            state.FinancialDetailsCompletedOn = DateTime.Now;
            Console.WriteLine(state);
            Console.WriteLine(GetPage(state));
        }

        private static string GetPage(State state)
        {
            if (!state.HasCompletedPersonalDetails)
            {
                return "/personal-details";
            }

            if (!state.HasVerifiedEmail)
            {
                return "/verify-email";
            }

            if (!state.HasCompletedFinancialDetails)
            {
                return "/financial-details";
            }

            return "/success";
        }
    }
}
