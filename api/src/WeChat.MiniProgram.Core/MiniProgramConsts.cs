using WeChat.MiniProgram.Debugging;

namespace WeChat.MiniProgram
{
    public class MiniProgramConsts
    {
        public const string LocalizationSourceName = "MiniProgram";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "005f15a40c99447d86966905fb8c6466";
    }
}
