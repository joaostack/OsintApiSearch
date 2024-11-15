using System.Text.Json.Serialization;

namespace OsintApiSearch
{
    public class Picsart
    {
        public class Root
        {
            public string status { get; set; }
            public List<string> response { get; set; }
        }
    }

    public class NetShoes
    {
        public class Root
        {
            public bool exists { get; set; }
        }
    }

    public class Chess
    {
        public class Root
        {
            public bool isEmailAvailable { get; set; }
            public string reason { get; set; }
        }
    }

    public class Duolingo
    {
        public class Root
        {
            public List<User> users { get; set; }
        }

        public class User
        {
            public int streak { get; set; }
            public string picture { get; set; }
            public bool hasGoogleId { get; set; }
            public int id { get; set; }
            public bool hasPlus { get; set; }
            public string fromLanguage { get; set; }
            public List<object> roles { get; set; }
            public bool hasFacebookId { get; set; }
            public bool hasRecentActivity15 { get; set; }
            public string name { get; set; }
            public string username { get; set; }
            public List<object> courses { get; set; }
        }
    }

    public class Xwitter
    {
        public class Root
        {
            public bool valid { get; set; }
            public string msg { get; set; }
            public bool taken { get; set; }
        }
    }

    public class Spotify
    {
        public class AllowedCallingCode
        {
            public string country_code { get; set; }
            public string calling_code { get; set; }
        }

        public class Errors
        {
            public string email { get; set; }
        }

        public class Root
        {
            public int status { get; set; }
            public Errors errors { get; set; }
            public string country { get; set; }
            public bool can_accept_licenses_in_one_step { get; set; }
            public bool requires_marketing_opt_in { get; set; }
            public bool requires_marketing_opt_in_text { get; set; }
            public bool requires_tailored_ads_opt_in { get; set; }
            public int minimum_age { get; set; }
            public string country_group { get; set; }
            public bool specific_licenses { get; set; }
            public string terms_conditions_acceptance { get; set; }
            public string privacy_policy_acceptance { get; set; }
            public string spotify_marketing_messages_option { get; set; }
            public bool pretick_eula { get; set; }
            public bool show_collect_personal_info { get; set; }
            public bool use_all_genders { get; set; }
            public bool use_other_gender { get; set; }
            public bool use_prefer_not_to_say_gender { get; set; }
            public bool show_non_required_fields_as_optional { get; set; }
            public int date_endianness { get; set; }
            public bool is_country_launched { get; set; }
            public List<AllowedCallingCode> allowed_calling_codes { get; set; }

            [JsonPropertyName("push-notifications")]
            public bool pushnotifications { get; set; }
        }
    }
}
