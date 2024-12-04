using HarmonyLib;
using Trainworks.BuildersV2;
using Trainworks.Constants;
using Trainworks.Managers;

namespace MonsterTrainModdingTemplate.ModifyExistingContent
{
    class ModifyFrozenLance
    {
        public static void Modify()
        {
            string frozenLanceID = VanillaCardIDs.FrozenLance;
            var frozenLanceData = CustomCardManager.GetCardDataByID(frozenLanceID);


            var piercingTrait = new CardTraitDataBuilder
            {
                TraitStateType = VanillaCardTraitTypes.CardTraitIgnoreArmor,
            }.Build();
            frozenLanceData.GetTraits().Add(piercingTrait);


            // Set Frozen Lance's damage to 12
            var frozenLanceDamageEffect = frozenLanceData.GetEffects()[0];
            Traverse.Create(frozenLanceDamageEffect).Field("paramInt").SetValue(12);

           
            var frostbiteEffect = new CardEffectDataBuilder
            {
                EffectStateType = typeof(CardEffectAddStatusEffect),
                TargetMode = TargetMode.LastTargetedCharacters,
                ParamStatusEffects =
                {
                    new StatusEffectStackData {statusId = VanillaStatusEffectIDs.Frostbite, count = 327}
                },
            }.Build();
            frozenLanceData.GetEffects().Add(frostbiteEffect);
        }
    }
}
