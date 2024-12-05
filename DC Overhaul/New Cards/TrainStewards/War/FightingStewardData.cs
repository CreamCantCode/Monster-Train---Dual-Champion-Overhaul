
using CustomEffects;
using HarmonyLib;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using Trainworks.Managers;
using UnityEngine.AddressableAssets;

namespace MonsterTrainModdingTemplate.MonsterCards
{
    /// <summary>
    /// Minimal example of how to create a Monster Card with an Essence.
    /// </summary>
    class FightingSteward
    {
        public static readonly string ID = TestPlugin.GUID + "_FightingStewardCard";
        public static readonly string CharID = TestPlugin.GUID + "_FightingStewardCharacter";

       




        public static void BuildAndRegister()
        {



        var ApexImpCardID = VanillaCardIDs.ApexImp;
        var ApexImpCardData = CustomCardManager.GetCardDataByID(ApexImpCardID);
        var ApexImpCharacterID = VanillaCharacterIDs.ApexImp;
        var ApexImpCharacterData = CustomCharacterManager.GetCharacterDataByID(ApexImpCharacterID);
        
        



            new CardDataBuilder
            {
                CardID = ID,
                Name = "Apex Fledgling Imp",
                Cost = 1,
                CardType = CardType.Monster,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,
                Targetless = false,
                CardArtPrefabVariantRef = (AssetReferenceGameObject)AccessTools.Field(typeof(CardData), "cardArtPrefabVariantRef").GetValue(ApexImpCardData),
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
                            Name = "Apex Fledgling Imp",
                            Size = 2,
                            Health = 5,
                            AttackDamage = 5,
                            CharacterPrefabVariantRef = (AssetReferenceGameObject)AccessTools.Field(typeof(CharacterData), "characterPrefabVariantRef").GetValue(ApexImpCharacterData),
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
                                    TriggerID = TestPlugin.GUID + "_ApexFledgingImpSpawnTrigger", 
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
                               TriggerID = TestPlugin.GUID + "_ApexFledgingImpTrigger", 
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
                                            count = 2
                                        }
                                       }
                                        
                                       }
                                    }
                            
                                }
                            },
                            UnitSynthesisBuilder = new CardUpgradeDataBuilder
                            {
                                UpgradeID = "FledglingApexImpSynth",
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
