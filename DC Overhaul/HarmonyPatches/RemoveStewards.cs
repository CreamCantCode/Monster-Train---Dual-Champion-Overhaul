using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using JetBrains.Annotations;
using MonsterTrainModdingTemplate.ModifyExistingContent;
using MonsterTrainModdingTemplate.MonsterCards;
using Trainworks.ConstantsV2;
using Trainworks.Managers;

namespace DCOverhaul.HarmonyPatches
{
[HarmonyPatch(typeof(RelicManager), nameof(RelicManager.ApplyStartOfRunRelicEffects))]
    class RemoveTrainStewardsPatch
    {
        public static void Postfix(SaveManager ___saveManager, RelicEffectParams ___relicEffectParams)
        {
            var deck = new List<CardState>(___saveManager.GetDeckState());
            foreach (var cardState in deck)
            {
                if (cardState.GetID() == VanillaCardIDs.TrainSteward)
                {
                    ___saveManager.RemoveCardFromDeck(cardState);
                }
            }
        }
    }
}
