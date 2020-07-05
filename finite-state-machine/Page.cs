namespace finite_state_machine
{
    public class Page
    {
        public static Page PersonalDetailsPage = new Page("/personal-details");
        public static Page EmailVerificationPage = new Page("/verify-email");
        public static Page FinancialDetailsPage = new Page("/financial-details");
        public static Page RegistrationCompletedPage = new Page("/success");
        public string Url { get; }
        private Page(string url) => Url = url;

        public override bool Equals(object obj)
        {
            return obj is Page other && other.Url.Equals(this.Url);
        }

        public override int GetHashCode()
        {
            return this.Url.GetHashCode();
        }
    }
}
