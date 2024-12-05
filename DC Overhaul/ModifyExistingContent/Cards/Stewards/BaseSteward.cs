
using CustomEffects;
using HarmonyLib;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using Trainworks.Managers;
using UnityEngine.AddressableAssets;

namespace MonsterTrainModdingTemplate.ModifyExistingContent
{
    /// <summary>
    /// Minimal example of how to create a Monster Card with an Essence.
    /// </summary>
    class BaseSteward
    {
        public static readonly string ID = VanillaCardIDs.TrainSteward;
        public static readonly string CharID = VanillaCharacterIDs.TrainSteward;

        

         
         public void modify()
         {
          var data = CustomCardManager.GetCardDataByID(CharID);
         }
        
    }
}
