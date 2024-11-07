using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using DrunkCompany;
using static BepInEx.BepInDependency;
using DrunkCompany.Scripts;

namespace DrunkCompany
{
	[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
	[BepInDependency(StaticNetcodeLib.StaticNetcodeLib.Guid, DependencyFlags.HardDependency)]
	[BepInDependency("x753.More_Suits", DependencyFlags.HardDependency)]

	public class DrunkCompany : BaseUnityPlugin
	{
		public static DrunkCompany Instance { get; private set; } = null!;
		internal new static ManualLogSource Logger { get; private set; } = null!;
		internal static Harmony? Harmony { get; set; }

		private void Awake()
		{
			Logger = base.Logger;
			Instance = this;

			Patch();
			
			Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} v{MyPluginInfo.PLUGIN_VERSION} has loaded!");

		}

		internal static void Patch()
		{
			Harmony ??= new Harmony(MyPluginInfo.PLUGIN_GUID);

			Logger.LogDebug("Patching...");

			Harmony.PatchAll();

			Logger.LogDebug("Finished patching!");
		}

		internal static void Unpatch()
		{
			Logger.LogDebug("Unpatching...");

			Harmony?.UnpatchSelf();

			Logger.LogDebug("Finished unpatching!");
		}
	}
}
