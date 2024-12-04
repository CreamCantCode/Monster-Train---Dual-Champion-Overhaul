using HarmonyLib;
using MonsterTrainModdingTemplate.MonsterCards;
using Trainworks.Managers;

namespace MonsterTrainModdingTemplate.HarmonyPatches
{
    [HarmonyPatch(typeof(SaveManager), nameof(SaveManager.SetupRun))]
    class AddCardToStartingDeckPatch
    {
        static void Postfix(ref SaveManager __instance)
        {
            __instance.AddCardToDeck(CustomCardManager.GetCardDataByID(ApexFledglingImp.ID));
            //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID(GiveEveryoneArmor.ID));
            //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID(PlayOtherCards.ID));
            //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID(BlueEyesWhiteDragon.ID));
            //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID(DragonCostume.ID));
            //__instance.AddCardToDeck(CustomCardManager.GetCardDataByID(PyreSharpener.ID));
        }
    }
}
