﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SEOMacroscope {
	
	
	[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("ICSharpCode.SettingsEditor.SettingsCodeGeneratorTool", "5.1.0.5216")]
	internal sealed partial class MacroscopePreferences : global::System.Configuration.ApplicationSettingsBase {
		
		private static MacroscopePreferences defaultInstance = ((MacroscopePreferences)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new MacroscopePreferences())));
		
		public static MacroscopePreferences Default {
			get {
				return defaultInstance;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("False")]
		public bool AnalyzeKeywordsInText {
			get {
				return ((bool)(this["AnalyzeKeywordsInText"]));
			}
			set {
				this["AnalyzeKeywordsInText"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("v0.0.0.0")]
		public string AppVersion {
			get {
				return ((string)(this["AppVersion"]));
			}
			set {
				this["AppVersion"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("False")]
		public bool CheckExternalLinks {
			get {
				return ((bool)(this["CheckExternalLinks"]));
			}
			set {
				this["CheckExternalLinks"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("False")]
		public bool CheckHreflangs {
			get {
				return ((bool)(this["CheckHreflangs"]));
			}
			set {
				this["CheckHreflangs"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool CrawlChildDirectories {
			get {
				return ((bool)(this["CrawlChildDirectories"]));
			}
			set {
				this["CrawlChildDirectories"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("0")]
		public int CrawlDelay {
			get {
				return ((int)(this["CrawlDelay"]));
			}
			set {
				this["CrawlDelay"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool CrawlParentDirectories {
			get {
				return ((bool)(this["CrawlParentDirectories"]));
			}
			set {
				this["CrawlParentDirectories"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("-1")]
		public int Depth {
			get {
				return ((int)(this["Depth"]));
			}
			set {
				this["Depth"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("150")]
		public int DescriptionMaxLen {
			get {
				return ((int)(this["DescriptionMaxLen"]));
			}
			set {
				this["DescriptionMaxLen"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("20")]
		public int DescriptionMaxWords {
			get {
				return ((int)(this["DescriptionMaxWords"]));
			}
			set {
				this["DescriptionMaxWords"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("10")]
		public int DescriptionMinLen {
			get {
				return ((int)(this["DescriptionMinLen"]));
			}
			set {
				this["DescriptionMinLen"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("3")]
		public int DescriptionMinWords {
			get {
				return ((int)(this["DescriptionMinWords"]));
			}
			set {
				this["DescriptionMinWords"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool DetectLanguage {
			get {
				return ((bool)(this["DetectLanguage"]));
			}
			set {
				this["DetectLanguage"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("False")]
		public bool EnableLevenshteinDeduplication {
			get {
				return ((bool)(this["EnableLevenshteinDeduplication"]));
			}
			set {
				this["EnableLevenshteinDeduplication"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool FetchAudio {
			get {
				return ((bool)(this["FetchAudio"]));
			}
			set {
				this["FetchAudio"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool FetchBinaries {
			get {
				return ((bool)(this["FetchBinaries"]));
			}
			set {
				this["FetchBinaries"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool FetchImages {
			get {
				return ((bool)(this["FetchImages"]));
			}
			set {
				this["FetchImages"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool FetchJavascripts {
			get {
				return ((bool)(this["FetchJavascripts"]));
			}
			set {
				this["FetchJavascripts"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool FetchStylesheets {
			get {
				return ((bool)(this["FetchStylesheets"]));
			}
			set {
				this["FetchStylesheets"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool FetchVideo {
			get {
				return ((bool)(this["FetchVideo"]));
			}
			set {
				this["FetchVideo"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool FetchXml {
			get {
				return ((bool)(this["FetchXml"]));
			}
			set {
				this["FetchXml"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool FirstRun {
			get {
				return ((bool)(this["FirstRun"]));
			}
			set {
				this["FirstRun"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool FollowCanonicalLinks {
			get {
				return ((bool)(this["FollowCanonicalLinks"]));
			}
			set {
				this["FollowCanonicalLinks"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("False")]
		public bool FollowHrefLangLinks {
			get {
				return ((bool)(this["FollowHrefLangLinks"]));
			}
			set {
				this["FollowHrefLangLinks"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("False")]
		public bool FollowListLinks {
			get {
				return ((bool)(this["FollowListLinks"]));
			}
			set {
				this["FollowListLinks"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("False")]
		public bool FollowNoFollow {
			get {
				return ((bool)(this["FollowNoFollow"]));
			}
			set {
				this["FollowNoFollow"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("False")]
		public bool FollowRedirects {
			get {
				return ((bool)(this["FollowRedirects"]));
			}
			set {
				this["FollowRedirects"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool FollowRobotsProtocol {
			get {
				return ((bool)(this["FollowRobotsProtocol"]));
			}
			set {
				this["FollowRobotsProtocol"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool FollowSitemapLinks {
			get {
				return ((bool)(this["FollowSitemapLinks"]));
			}
			set {
				this["FollowSitemapLinks"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("")]
		public string HttpProxyHost {
			get {
				return ((string)(this["HttpProxyHost"]));
			}
			set {
				this["HttpProxyHost"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("0")]
		public int HttpProxyPort {
			get {
				return ((int)(this["HttpProxyPort"]));
			}
			set {
				this["HttpProxyPort"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("False")]
		public bool IgnoreQueries {
			get {
				return ((bool)(this["IgnoreQueries"]));
			}
			set {
				this["IgnoreQueries"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("32")]
		public int MaxFetchesPerWorker {
			get {
				return ((int)(this["MaxFetchesPerWorker"]));
			}
			set {
				this["MaxFetchesPerWorker"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("2")]
		public ushort MaxHeadingDepth {
			get {
				return ((ushort)(this["MaxHeadingDepth"]));
			}
			set {
				this["MaxHeadingDepth"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("16")]
		public int MaxLevenshteinDistance {
			get {
				return ((int)(this["MaxLevenshteinDistance"]));
			}
			set {
				this["MaxLevenshteinDistance"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("64")]
		public int MaxLevenshteinSizeDifference {
			get {
				return ((int)(this["MaxLevenshteinSizeDifference"]));
			}
			set {
				this["MaxLevenshteinSizeDifference"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("0")]
		public int MaxRetries {
			get {
				return ((int)(this["MaxRetries"]));
			}
			set {
				this["MaxRetries"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("1")]
		public int MaxThreads {
			get {
				return ((int)(this["MaxThreads"]));
			}
			set {
				this["MaxThreads"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("-1")]
		public int PageLimit {
			get {
				return ((int)(this["PageLimit"]));
			}
			set {
				this["PageLimit"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("False")]
		public bool PauseDisplayDuringScan {
			get {
				return ((bool)(this["PauseDisplayDuringScan"]));
			}
			set {
				this["PauseDisplayDuringScan"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool ProcessAudio {
			get {
				return ((bool)(this["ProcessAudio"]));
			}
			set {
				this["ProcessAudio"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool ProcessBinaries {
			get {
				return ((bool)(this["ProcessBinaries"]));
			}
			set {
				this["ProcessBinaries"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool ProcessImages {
			get {
				return ((bool)(this["ProcessImages"]));
			}
			set {
				this["ProcessImages"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool ProcessJavascripts {
			get {
				return ((bool)(this["ProcessJavascripts"]));
			}
			set {
				this["ProcessJavascripts"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("False")]
		public bool ProcessPdfs {
			get {
				return ((bool)(this["ProcessPdfs"]));
			}
			set {
				this["ProcessPdfs"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool ProcessStylesheets {
			get {
				return ((bool)(this["ProcessStylesheets"]));
			}
			set {
				this["ProcessStylesheets"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool ProcessVideo {
			get {
				return ((bool)(this["ProcessVideo"]));
			}
			set {
				this["ProcessVideo"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool ProcessXml {
			get {
				return ((bool)(this["ProcessXml"]));
			}
			set {
				this["ProcessXml"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("30")]
		public int RequestTimeout {
			get {
				return ((int)(this["RequestTimeout"]));
			}
			set {
				this["RequestTimeout"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("False")]
		public bool ResolveAddresses {
			get {
				return ((bool)(this["ResolveAddresses"]));
			}
			set {
				this["ResolveAddresses"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("2")]
		public int SameDomainTolerance {
			get {
				return ((int)(this["SameDomainTolerance"]));
			}
			set {
				this["SameDomainTolerance"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("False")]
		public bool ScanSitesInList {
			get {
				return ((bool)(this["ScanSitesInList"]));
			}
			set {
				this["ScanSitesInList"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool ShowProgressDialogues {
			get {
				return ((bool)(this["ShowProgressDialogues"]));
			}
			set {
				this["ShowProgressDialogues"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("False")]
		public bool SitemapIncludeLinkedPdfs {
			get {
				return ((bool)(this["SitemapIncludeLinkedPdfs"]));
			}
			set {
				this["SitemapIncludeLinkedPdfs"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("")]
		public string StartUrl {
			get {
				return ((string)(this["StartUrl"]));
			}
			set {
				this["StartUrl"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("70")]
		public int TitleMaxLen {
			get {
				return ((int)(this["TitleMaxLen"]));
			}
			set {
				this["TitleMaxLen"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("512")]
		public int TitleMaxPixelWidth {
			get {
				return ((int)(this["TitleMaxPixelWidth"]));
			}
			set {
				this["TitleMaxPixelWidth"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("10")]
		public int TitleMaxWords {
			get {
				return ((int)(this["TitleMaxWords"]));
			}
			set {
				this["TitleMaxWords"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("10")]
		public int TitleMinLen {
			get {
				return ((int)(this["TitleMinLen"]));
			}
			set {
				this["TitleMinLen"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("3")]
		public int TitleMinWords {
			get {
				return ((int)(this["TitleMinWords"]));
			}
			set {
				this["TitleMinWords"] = value;
			}
		}
		
		[global::System.Configuration.UserScopedSettingAttribute()]
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[global::System.Configuration.DefaultSettingValueAttribute("True")]
		public bool WarnAboutInsecureLinks {
			get {
				return ((bool)(this["WarnAboutInsecureLinks"]));
			}
			set {
				this["WarnAboutInsecureLinks"] = value;
			}
		}
	}
}
