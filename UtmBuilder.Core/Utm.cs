using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.Extensions;

namespace UtmBuilder.Core
{
    public class Utm
    {
        public Utm(
            Url url
            ,Campaign campaign)
        {
            Url = url;
            Campaign = campaign;
        }

        /// <summary>
        /// URL (Website Link)
        /// </summary>
        public Url Url { get; } 

        /// <summary>
        /// Campaign Details
        /// </summary>
        public Campaign Campaign { get; } 

        public static implicit operator string(Utm utm)
            => utm.ToString();

        public override string ToString()
        {
                var segments = new List<string>();

                segments.AddStringIfNotNull("utm_source", Campaign.Source);
                segments.AddStringIfNotNull("utm_medium", Campaign.Medium);
                segments.AddStringIfNotNull("utm_campaign", Campaign.Name);
                segments.AddStringIfNotNull("utm_id", Campaign.Id);
                segments.AddStringIfNotNull("utm_term", Campaign.Term);
                segments.AddStringIfNotNull("utm_content", Campaign.Content);

                return $"{Url.Address}?{string.Join("&", segments)}";
        }
    }
}
