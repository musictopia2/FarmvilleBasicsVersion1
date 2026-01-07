namespace Phase14MultipleWorksites.Services;
public static class Extensions
{
    extension (double progress)
    {
        public string GetTimeString
        {
            get
            {
                TimeSpan time = TimeSpan.FromSeconds(progress);
                return time.GetTimeString;
            }
        }
    }
    extension (TimeSpan time)
    {
        public string GetTimeString
        {
            get
            {
                if (time.TotalSeconds < 1)
                {
                    return "0s";
                }

                var parts = new BasicList<string>();

                if (time.Days > 0)
                {
                    parts.Add($"{time.Days}d");
                }

                if (time.Hours > 0)
                {
                    parts.Add($"{time.Hours}h");
                }

                if (time.Minutes > 0)
                {
                    parts.Add($"{time.Minutes}m");
                }

                // Only show seconds if:
                // - there are no larger units, OR
                // - seconds > 0
                if (time.Seconds > 0 || parts.Count == 0)
                {
                    parts.Add($"{time.Seconds}s");
                }

                return string.Join(" ", parts);
            }
        }
    }
}
