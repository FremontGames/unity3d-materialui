using System;
using MDUI.Component;

namespace MDUI.Style
{
	public class StaticFilesLoader
	{
		public string prefix= "i18n/locale-";
		public string suffix= ".json";
	}

	public class MDGlobal
	{
		public string lang;
		public string locale;

		// i18n
		public string preferredLanguage = "en";
		public string fallbackLanguage = "en";
		// l10n
		public string preferredLocale = "us";

		public StaticFilesLoader staticFilesLoader;


	}
}

