namespace Beyond.Utils
{
    public static class ProgressBar
    {
        public static string GenerateProgressBarAsString(decimal progress, int width = 50)
        {
            if (progress > 100 || progress < 0)
            {
                return "Invalid progress.";
            }

            var filledValue = (int)(progress * width) / 100;
            var emtpyValue = (int)(width - filledValue);

            var filled = new string('█', filledValue);
            var empty = new string(' ', emtpyValue);

            return $"|{filled}{empty}|";
        }
    }
}
