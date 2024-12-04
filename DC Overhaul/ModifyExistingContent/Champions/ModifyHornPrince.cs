using System.Runtime.InteropServices;
using HarmonyLib;

using Spine;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using Trainworks.Managers;
using Trainworks.ManagersV2;

namespace MonsterTrainModdingTemplate.ModifyExistingContent
{
    class ModifyHornPrince
    {
        public static void Modify()
        {
            var hellhornedClan = CustomClassManager.GetClassDataByID(VanillaClanIDs.Hellhorned);
            var hornbreakerPrince = CustomCharacterManager.GetCharacterDataByID(VanillaCharacterIDs.HornbreakerPrince);
            var hornbreakerUpgradeTree = hellhornedClan.FindUpgradeTreeForChampion(hornbreakerPrince); 
            var Brawler1Data = CustomUpgradeManager.GetCardUpgradeByID(VanillaCardUpgradeDataIDs.Brawler);
            var SweepStatusEffect = new StatusEffectStackData{ statusId = VanillaStatusEffectIDs.Sweep};
            
            
            
            
             

            
        //Base Prince/

           Traverse.Create(hornbreakerPrince).Field("health").SetValue(1);
           Traverse.Create(hornbreakerPrince).Field("attackDamage").SetValue(1);

            
           
        //Brawler 1/
           
           Traverse.Create(Brawler1Data).Field("bonusHP").SetValue(2);
           Brawler1Data.GetStatusEffectUpgrades().Clear();
           var Brawler1Effect = new StatusEffectStackData {statusId = VanillaStatusEffectIDs.Multistrike, count = 2};
           Brawler1Data.GetStatusEffectUpgrades().Add(Brawler1Effect);
           
           //Strike Trigger/
           var Brawler1Strike = new CharacterTriggerDataBuilder
           {TriggerID = TestPlugin.GUID + "_Brawler1Trigger", 
           Trigger = CharacterTriggerData.Trigger.OnAttacking, 
           Description = "Gain +<nobr>[effect1.power][attack] and +[effect0.power][health]<nobr>", 
           EffectBuilders = 
           {
             new CardEffectDataBuilder 
              {
              EffectStateType = typeof(CardEffectBuffMaxHealth),
              TargetMode = TargetMode.Self,
              TargetTeamType = Team.Type.Monsters,
              ParamInt = 1
              },
             new CardEffectDataBuilder
              {
               EffectStateType = typeof(CardEffectBuffDamage),
               TargetMode = TargetMode.Self,
               TargetTeamType = Team.Type.Monsters,
               ParamInt = 1
              },
              new CardEffectDataBuilder
              {
                  EffectStateType = typeof(CardEffectHeal),
                  TargetMode = TargetMode.Self,
                  TargetTeamType = Team.Type.Monsters,
                  ParamInt = 1
              }
            }
           }.Build();
            Brawler1Data.GetTriggerUpgrades().Add(Brawler1Strike);
            
            

         //Brawler2/

        var Brawler2Data = CustomUpgradeManager.GetCardUpgradeByID(VanillaCardUpgradeDataIDs.BrawlerII);
        Traverse.Create(Brawler2Data).Field("bonusDamage").SetValue(1);
        Traverse.Create(Brawler2Data).Field("bonusHP").SetValue(2);
        Brawler2Data.GetStatusEffectUpgrades().Clear();
        var Brawler2Effect = new StatusEffectStackData {statusId = VanillaStatusEffectIDs.Multistrike, count = 3};
        Brawler2Data.GetStatusEffectUpgrades().Add(Brawler2Effect);
        var Brawler2Strike = new CharacterTriggerDataBuilder
           {TriggerID = TestPlugin.GUID + "_Brawler2Trigger", 
           Trigger = CharacterTriggerData.Trigger.OnAttacking, 
           Description = "Gain +<nobr>[effect1.power][attack] and +[effect0.power][health]<nobr>", 
           EffectBuilders = 
           {
             new CardEffectDataBuilder 
              {
              EffectStateType = typeof(CardEffectBuffMaxHealth),
              TargetMode = TargetMode.Self,
              TargetTeamType = Team.Type.Monsters,
              ParamInt = 2
              },
             new CardEffectDataBuilder
              {
               EffectStateType = typeof(CardEffectBuffDamage),
               TargetMode = TargetMode.Self,
               TargetTeamType = Team.Type.Monsters,
               ParamInt = 2
              },
              new CardEffectDataBuilder
              {
                  EffectStateType = typeof(CardEffectHeal),
                  TargetMode = TargetMode.Self,
                  TargetTeamType = Team.Type.Monsters,
                  ParamInt = 2
              }
            }
           }.Build();
            Brawler2Data.GetTriggerUpgrades().Add(Brawler2Strike);


        //brawler 3

        var Brawler3Data = CustomUpgradeManager.GetCardUpgradeByID(VanillaCardUpgradeDataIDs.BrawlerIII);
        Traverse.Create(Brawler3Data).Field("bonusDamage").SetValue(2);
        Traverse.Create(Brawler3Data).Field("bonusHP").SetValue(2);
        Brawler3Data.GetStatusEffectUpgrades().Clear();
        var Brawler3Effect = new StatusEffectStackData {statusId = VanillaStatusEffectIDs.Multistrike, count = 4};
        Brawler3Data.GetStatusEffectUpgrades().Add(Brawler3Effect);
        var Brawler3Strike = new CharacterTriggerDataBuilder
           {TriggerID = TestPlugin.GUID + "_Brawler3Trigger", 
           Trigger = CharacterTriggerData.Trigger.OnAttacking, 
           Description = "Gain +<nobr>[effect1.power][attack] and +[effect0.power][health]<nobr>", 
           EffectBuilders = 
           {
             new CardEffectDataBuilder 
              {
              EffectStateType = typeof(CardEffectBuffMaxHealth),
              TargetMode = TargetMode.Self,
              TargetTeamType = Team.Type.Monsters,
              ParamInt = 3
              },
             new CardEffectDataBuilder
              {
               EffectStateType = typeof(CardEffectBuffDamage),
               TargetMode = TargetMode.Self,
               TargetTeamType = Team.Type.Monsters,
               ParamInt = 3
              },
              new CardEffectDataBuilder
              {
                  EffectStateType = typeof(CardEffectHeal),
                  TargetMode = TargetMode.Self,
                  TargetTeamType = Team.Type.Monsters,
                  ParamInt = 3
              }
            }
           }.Build();
            Brawler3Data.GetTriggerUpgrades().Add(Brawler3Strike);





        //Reaper 1/

        var Reaper1Data = CustomUpgradeManager.GetCardUpgradeByID(VanillaCardUpgradeDataIDs.Reaper);
        Traverse.Create(Reaper1Data).Field("bonusDamage").SetValue(9);
        Traverse.Create(Reaper1Data).Field("bonusHP").SetValue(4);
        Reaper1Data.GetStatusEffectUpgrades().Clear();
        Reaper1Data.GetTriggerUpgrades().Clear();
        var Reaper1Slay = new CharacterTriggerDataBuilder
           {TriggerID = TestPlugin.GUID + "_Reaper1Trigger", 
           Trigger = CharacterTriggerData.Trigger.OnKill, 
           Description = "Gain +<nobr>[effect0.power][attack] and [Tempo][effect01.status0.power]<nobr>" ,
           EffectBuilders = 
            {
             new CardEffectDataBuilder 
              {
              EffectStateType = typeof(CardEffectBuffDamage),
              TargetMode = TargetMode.Self,
              TargetTeamType = Team.Type.Monsters,
              ParamInt = 20
              },
              new CardEffectDataBuilder
              {
                  EffectStateType = typeof(CardEffectAddStatusEffect),
                  TargetMode = TargetMode.Self,
                  TargetTeamType = Team.Type.Monsters,
                  ParamStatusEffects =
                  {
                    new StatusEffectStackData
                    {
                        statusId = VanillaStatusEffectIDs.Quick,
                        count = 1
                    }
                  }
              }
              
                }
           }.Build();
            Reaper1Data.GetTriggerUpgrades().Add(Reaper1Slay);

            //Reaper 2/

         var Reaper2Data = CustomUpgradeManager.GetCardUpgradeByID(VanillaCardUpgradeDataIDs.ReaperII);
        Traverse.Create(Reaper2Data).Field("bonusDamage").SetValue(14);
        Traverse.Create(Reaper2Data).Field("bonusHP").SetValue(7);
        Reaper2Data.GetStatusEffectUpgrades().Clear();
        Reaper2Data.GetTriggerUpgrades().Clear();
        var Reaper2Slay = new CharacterTriggerDataBuilder
           {TriggerID = TestPlugin.GUID + "_Reaper2Trigger", 
           Trigger = CharacterTriggerData.Trigger.OnKill, 
           Description = "Gain +<nobr>[effect0.power][attack] [quick]<nobr>" ,
           EffectBuilders = 
            {
             new CardEffectDataBuilder 
              {
              EffectStateType = typeof(CardEffectBuffDamage),
              TargetMode = TargetMode.Self,
              TargetTeamType = Team.Type.Monsters,
              ParamInt = 40
              },
              new CardEffectDataBuilder
              {
                  EffectStateType = typeof(CardEffectAddStatusEffect),
                  TargetMode = TargetMode.Self,
                  TargetTeamType = Team.Type.Monsters,
                  ParamStatusEffects =
                  {
                    new StatusEffectStackData
                    {
                        statusId = VanillaStatusEffectIDs.Quick,
                        count = 1
                    }
                  }
              }
              
                }
           }.Build();
            Reaper2Data.GetTriggerUpgrades().Add(Reaper2Slay);




         //Reaper 3/

          var Reaper3Data = CustomUpgradeManager.GetCardUpgradeByID(VanillaCardUpgradeDataIDs.ReaperIII);
        Traverse.Create(Reaper3Data).Field("bonusDamage").SetValue(24);
        Traverse.Create(Reaper3Data).Field("bonusHP").SetValue(13);
        Reaper3Data.GetStatusEffectUpgrades().Clear();
        Reaper3Data.GetTriggerUpgrades().Clear();
        var Reaper3Slay = new CharacterTriggerDataBuilder
           {TriggerID = TestPlugin.GUID + "_Reaper3Trigger", 
           Trigger = CharacterTriggerData.Trigger.OnKill, 
           Description = "Gain +<nobr>[effect0.power][attack] and [quick]<nobr>" ,
           EffectBuilders = 
            {
             new CardEffectDataBuilder 
              {
              EffectStateType = typeof(CardEffectBuffDamage),
              TargetMode = TargetMode.Self,
              TargetTeamType = Team.Type.Monsters,
              ParamInt = 100
              },
              new CardEffectDataBuilder
              {
                  EffectStateType = typeof(CardEffectAddStatusEffect),
                  TargetMode = TargetMode.Self,
                  TargetTeamType = Team.Type.Monsters,
                  ParamStatusEffects =
                  {
                    new StatusEffectStackData
                    {
                        statusId = VanillaStatusEffectIDs.Quick,
                        count = 1
                    }
                  }
              }
              
                }
           }.Build();
            Reaper3Data.GetTriggerUpgrades().Add(Reaper3Slay);




        // Wrathful 1/

        var Wrathful1Data = CustomUpgradeManager.GetCardUpgradeByID(VanillaCardUpgradeDataIDs.Wrathful);
        Traverse.Create(Wrathful1Data).Field("bonusDamage").SetValue(4);
        Traverse.Create(Wrathful1Data).Field("bonusHP").SetValue(14);
        Wrathful1Data.GetStatusEffectUpgrades().Clear();
        Wrathful1Data.GetTriggerUpgrades().Clear();
         var Wrathful1Revenge = new CharacterTriggerDataBuilder
           {TriggerID = TestPlugin.GUID + "_Wrathful1Trigger", 
           Trigger = CharacterTriggerData.Trigger.OnHit, 
           Description = "Gain <nobr>[rage] [effect0.status0.power] and [armor] [effect1.status0.power]<nobr>" ,
           EffectBuilders = 
            {
            
              new CardEffectDataBuilder
              {
                  EffectStateType = typeof(CardEffectAddStatusEffect),
                  TargetMode = TargetMode.Self,
                  TargetTeamType = Team.Type.Monsters,
                  ParamStatusEffects =
                  {
                    
                    new StatusEffectStackData
                    {
                        statusId = VanillaStatusEffectIDs.Rage,
                        count = 2
                    },
                  }
              },
               new CardEffectDataBuilder
              {
                  EffectStateType = typeof(CardEffectAddStatusEffect),
                  TargetMode = TargetMode.Self,
                  TargetTeamType = Team.Type.Monsters,
                  ParamStatusEffects =
                  {
                    new StatusEffectStackData
                    {
                        statusId = VanillaStatusEffectIDs.Armor,
                        count = 3
                    },
                    
                  }
              }
                }
           }.Build();
            Wrathful1Data.GetTriggerUpgrades().Add(Wrathful1Revenge);



        //Wrathful 2/

        var Wrathful2Data = CustomUpgradeManager.GetCardUpgradeByID(VanillaCardUpgradeDataIDs.WrathfulII);
        Traverse.Create(Wrathful2Data).Field("bonusDamage").SetValue(9);
        Traverse.Create(Wrathful2Data).Field("bonusHP").SetValue(19);
        Wrathful2Data.GetStatusEffectUpgrades().Clear();
        Wrathful2Data.GetTriggerUpgrades().Clear();
        
         var Wrathful2Revenge = new CharacterTriggerDataBuilder
           {TriggerID = TestPlugin.GUID + "_Wrathful2Trigger", 
           Trigger = CharacterTriggerData.Trigger.OnHit, 
           Description = "Gain <nobr>[rage] [effect0.status0.power] and [armor] [effect1.status0.power]<nobr>" ,
           EffectBuilders = 
            {
            
               new CardEffectDataBuilder
              {
                  EffectStateType = typeof(CardEffectAddStatusEffect),
                  TargetMode = TargetMode.Self,
                  TargetTeamType = Team.Type.Monsters,
                  ParamStatusEffects =
                  {
                    
                    new StatusEffectStackData
                    {
                        statusId = VanillaStatusEffectIDs.Rage,
                        count = 3
                    },
                  }
              },
               new CardEffectDataBuilder
              {
                  EffectStateType = typeof(CardEffectAddStatusEffect),
                  TargetMode = TargetMode.Self,
                  TargetTeamType = Team.Type.Monsters,
                  ParamStatusEffects =
                  {
                    new StatusEffectStackData
                    {
                        statusId = VanillaStatusEffectIDs.Armor,
                        count = 5
                    },
                    
                  }
              }
                }
           }.Build();
            Wrathful2Data.GetTriggerUpgrades().Add(Wrathful2Revenge);
            
         
         
         //Wrathful 3/


        var Wrathful3Data = CustomUpgradeManager.GetCardUpgradeByID(VanillaCardUpgradeDataIDs.WrathfulIII);
        Traverse.Create(Wrathful3Data).Field("bonusDamage").SetValue(14);
        Traverse.Create(Wrathful3Data).Field("bonusHP").SetValue(29);
        Wrathful3Data.GetStatusEffectUpgrades().Clear();
        Wrathful3Data.GetStatusEffectUpgrades().Add(SweepStatusEffect);
        Wrathful3Data.GetTriggerUpgrades().Clear();
        
         var Wrathful3Revenge = new CharacterTriggerDataBuilder
           {TriggerID = TestPlugin.GUID + "_Wrathful2Trigger", 
           Trigger = CharacterTriggerData.Trigger.OnHit, 
           Description = "Gain <nobr>[rage] [effect0.status0.power] and [armor] [effect1.status0.power]<nobr>" ,
           EffectBuilders = 
            {
            
               new CardEffectDataBuilder
              {
                  EffectStateType = typeof(CardEffectAddStatusEffect),
                  TargetMode = TargetMode.Self,
                  TargetTeamType = Team.Type.Monsters,
                  ParamStatusEffects =
                  {
                    
                    new StatusEffectStackData
                    {
                        statusId = VanillaStatusEffectIDs.Rage,
                        count = 5
                    },
                  }
              },
               new CardEffectDataBuilder
              {
                  EffectStateType = typeof(CardEffectAddStatusEffect),
                  TargetMode = TargetMode.Self,
                  TargetTeamType = Team.Type.Monsters,
                  ParamStatusEffects =
                  {
                    new StatusEffectStackData
                    {
                        statusId = VanillaStatusEffectIDs.Armor,
                        count = 8
                    },
                    
                  }
              }
                }
           }.Build();
            Wrathful3Data.GetTriggerUpgrades().Add(Wrathful3Revenge);
            


















        }
    
            
         
            
           
        }
    }

