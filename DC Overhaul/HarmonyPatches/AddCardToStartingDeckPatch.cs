using HarmonyLib;
using MonsterTrainModdingTemplate.MonsterCards;
using Trainworks.ConstantsV2;
using Trainworks.Managers;
using MonsterTrainModdingTemplate.ModifyExistingContent;
using System.Collections.Generic;

namespace MonsterTrainModdingTemplate.HarmonyPatches
{
    [HarmonyPatch(typeof(SaveManager), nameof(SaveManager.SetupRun))]

    class AddCardToStartingDeckPatch
    {

        
        

        
        static void Postfix(ref SaveManager __instance)
        {
            __instance.AddCardToDeck(CustomCardManager.GetCardDataByID(ApexFledglingImp.ID));
            
            __instance.AddCardToDeck(CustomCardManager.GetCardDataByID(FledglingImpLord.ID));
            //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID(PlayOtherCards.ID));
            //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID(BlueEyesWhiteDragon.ID));
            //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID(DragonCostume.ID));
            //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID(PyreSharpener.ID));
        }
    }
}
