using BepInEx;
using HarmonyLib;
using MonsterTrainModdingTemplate.ModifyExistingContent;
using MonsterTrainModdingTemplate.MonsterCards;
using System.Collections.Generic;
using Trainworks.BuildersV2;
using Trainworks.Interfaces;
using MonsterTrainModdingTemplate.ImpQuartetData;
using CustomEffects;

namespace MonsterTrainModdingTemplate
{
    // Credit to Rawsome, Stable Infery for the base of this method.
    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInProcess("MonsterTrain.exe")]
    [BepInProcess("MtLinkHandler.exe")]
    [BepInDependency("tools.modding.trainworks")]
    public class TestPlugin : BaseUnityPlugin, IInitializable
    {
        public const string GUID = "Cream.Dual.Champion.Mod";
        public const string NAME = "Dual Champions Overhaul";
        public const string VERSION = "0.0.1";
        // This needs to be an unique identifier. Used to ensure IDs are unique.
        public const string CLANID = "TestClan";

        private void Awake()
        {
            var harmony = new Harmony(GUID);
            harmony.PatchAll();
        }

        public void Initialize()
        {
            // Automatically find types in this assembly with a BuildAndRegister static method and call it.
            /*var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                var method = type.GetMethod("BuildAndRegister", BindingFlags.Static | BindingFlags.Public);
                if (method != null)
                {
                    _ = method.Invoke(null, null);
                }
            }*/

            // Or if you prefer to call them all manually.
             MoltData.BuildAndRegister();
            // Start with the clan.
         
      
            // Then Starter cards if using custom made cards.

           ImpQuartetCardData.BuildAndRegister();
           ApexFledglingImp.BuildAndRegister();
           FledglingImpLord.BuildAndRegister();
           
            // Then Champions
            // Subtypes
            
            // Cards
            ModifyFrozenLance.Modify();
            ModifyHornPrince.Modify();
            ModifyShardQueen.Modify();
            
           
           
           
            // Relics
            
            // Enhancers
           
            // StatusEffects
            // Banner
            

            // Custom Trait Tooltips.
            
            // Custom RoomModifier TooltipTitle.
            
        }
    }
}
