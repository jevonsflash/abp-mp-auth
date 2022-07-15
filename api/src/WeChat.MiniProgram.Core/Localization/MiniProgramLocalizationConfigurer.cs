using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace WeChat.MiniProgram.Localization
{
    public static class MiniProgramLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MiniProgramConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MiniProgramLocalizationConfigurer).GetAssembly(),
                        "WeChat.MiniProgram.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
