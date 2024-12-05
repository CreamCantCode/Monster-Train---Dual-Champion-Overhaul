
using CustomEffects;
using HarmonyLib;
using MonsterTrainModdingTemplate.ModifyExistingContent;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using Trainworks.Managers;
using UnityEngine.AddressableAssets;

namespace MonsterTrainModdingTemplate.MonsterCards
{
    /// <summary>
    /// Minimal example of how to create a Monster Card with an Essence.
    /// </summary>
    class FledglingImpLord
    {
        public static readonly string ID = TestPlugin.CLANID + "_FledglingImpLordCard";
        public static readonly string CharID = TestPlugin.CLANID + "_FledglingImpLordCharacter";

       




        public static void BuildAndRegister()
        {



        
        



            new CardDataBuilder
            {
                CardID = ID,
                Name = "Fledgling Imp Lord",
                Cost = 2,
                CardType = CardType.Monster,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,
                Targetless = false,
                CardArtPrefabVariantRef = (AssetReferenceGameObject)AccessTools.Field(typeof(CardData), "cardArtPrefabVariantRef").GetValue(CustomCardManager.GetCardDataByID(HornedWarrior.ID)),
                ClanID = VanillaClanIDs.Hellhorned,
                CardPoolIDs = { VanillaCardPoolIDs.HellhornedBanner, VanillaCardPoolIDs.UnitsAllBanner },
                EffectBuilders =
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectSpawnMonster),
                        TargetMode = TargetMode.DropTargetCharacter,
                        ParamCharacterDataBuilder = new CharacterDataBuilder
                        {
                            CharacterID = CharID,
                            Name = "Fledgling Imp Lord",
                            Size = 2,
                            Health = 10,
                            AttackDamage = 10,
                            CharacterPrefabVariantRef = (AssetReferenceGameObject)AccessTools.Field(typeof(CharacterData), "characterPrefabVariantRef").GetValue(CustomCharacterManager.GetCharacterDataByID(HornedWarrior.CharID)),
                            SubtypeKeys = { VanillaSubtypeIDs.Demon,VanillaSubtypeIDs.Imp,VanillaSubtypeIDs.Chosen },
                            StartingStatusEffects = 
                            {
                                new StatusEffectStackData
                                {
                                    statusId = StatusEffectMoltState.StatusId,
                                    count = 5
                                }
                            },
                            
                            TriggerBuilders =
                            {
                                new CharacterTriggerDataBuilder
                                {
                                    TriggerID = TestPlugin.GUID + "_FledgingImpLordSpawnTrigger", 
                                    Trigger = CharacterTriggerData.Trigger.OnSpawn,
                                    Description = "Apply <nobr>[rage] [effect0.status0.power] to friendly units.</nobr>",
                                    EffectBuilders =
                                    {
                                       
                                       new CardEffectDataBuilder
                                       {
                                       EffectStateType = typeof(CardEffectAddStatusEffect),
                                       TargetMode = TargetMode.Room,
                                       TargetTeamType = Team.Type.Monsters,
                                       ParamStatusEffects = 
                                       {
                                        new StatusEffectStackData
                                        {
                                            statusId = VanillaStatusEffectIDs.Rage,
                                            count = 5
                                        }
                                       }
                                        
                                       }
                                    }
                                },
                         new CharacterTriggerDataBuilder
                                {
                               TriggerID = TestPlugin.GUID + "_FledgingImpLordResolveTrigger", 
                               Trigger = CharacterTriggerData.Trigger.PostCombat,
                               Description = "Apply <nobr>[rage] [effect0.status0.power] to friendly units.</nobr>",
                               EffectBuilders =
                                {
                                       
                                       new CardEffectDataBuilder
                                       {
                                       EffectStateType = typeof(CardEffectAddStatusEffect),
                                       TargetMode = TargetMode.Room,
                                       TargetTeamType = Team.Type.Monsters,
                                       ParamStatusEffects = 
                                       {
                                        new StatusEffectStackData
                                        {
                                            statusId = VanillaStatusEffectIDs.Rage,
                                            count = 5
                                        }
                                       }
                                        
                                       }
                                    }
                            
                                }
                            },
                            UnitSynthesisBuilder = new CardUpgradeDataBuilder
                            {
                                UpgradeID = "FledglingImpLordSynth",
                                UpgradeDescription = "+10[attack] +10[health]",
                                HideUpgradeIconOnCard = true,
                                UseUpgradeHighlightTextTags = true,
                                BonusDamage = 10,
                                BonusHP = 10,
                            }
                        }
                    }
                },
            }.BuildAndRegister();
        }
    }
}
