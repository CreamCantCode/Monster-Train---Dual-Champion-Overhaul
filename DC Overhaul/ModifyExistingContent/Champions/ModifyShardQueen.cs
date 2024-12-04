using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using HarmonyLib;
using DCOverHaulCardPools;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using Trainworks.Managers;
using Trainworks.ManagersV2;
using MonsterTrainModdingTemplate.ImpQuartetData;




namespace MonsterTrainModdingTemplate.ModifyExistingContent
{
    class ModifyShardQueen
    {
        public static void Modify()
        {
            string ShardQueenID = VanillaCharacterIDs.ShardtailQueen;
            var shardQueen = CustomCharacterManager.GetCharacterDataByID(ShardQueenID);
            var queensImp = VanillaCardIDs.QueensImpling;
            var StarterImpPool = VanillaCardPoolIDs.ImpStarterOnlyPool;
            var ImpStarterCardPool = CustomCardPoolManager.GetVanillaCardPool(StarterImpPool);
            var FledglingImpPool = VanillaCardPoolIDs.FledglingImpOnlyPool;
            var FledglingImpCardPool = CustomCardPoolManager.GetVanillaCardPool(FledglingImpPool);
           //Queen Custom Card Pools/

            var MoltingImpOnlyPool = new CardPoolBuilder
            {
                CardPoolID = TestPlugin.GUID + "_QueenCardPool",
                CardIDs = new List<string>
                {        
                    CustomCardManager.GetCardDataByID(VanillaCardIDs.MoltingImp).GetID(),
                },
            }.BuildAndRegister();

           
        


        
        
        //Base Queen/
        Traverse.Create(shardQueen).Field("health").SetValue(1);
        Traverse.Create(shardQueen).Field("attackDamage").SetValue(1);

    //Imp Parade 1/

     var ImpParade1Data = CustomUpgradeManager.GetCardUpgradeByID(VanillaCardUpgradeDataIDs.ImpParade);
     Traverse.Create(ImpParade1Data).Field("bonusHP").SetValue(9);
     Traverse.Create(ImpParade1Data).Field("bonusDamage").SetValue(7);
     ImpParade1Data.GetTriggerUpgrades().Clear();
     ImpParade1Data.GetRoomModifierUpgrades().Clear();

     //Give Cards/
     var ImpParade1Draw = new CharacterTriggerDataBuilder
           {TriggerID = TestPlugin.GUID + "_ImpParade1Trigger", 
           Trigger = CharacterTriggerData.Trigger.PostCombat, 
           Description = "Add a <b>Queens Impling</b> and a <b>Molting Imp</b> to your hand." ,
           EffectBuilders = 
          {
             new CardEffectDataBuilder 
              {
              EffectStateType = typeof(CardEffectAddBattleCard),
              TargetMode = TargetMode.Room,
              TargetTeamType = Team.Type.Monsters,
              ParamCardPool = ImpStarterCardPool,
              ParamInt = 3,
              AdditionalParamInt = 1,
              },
              new CardEffectDataBuilder 
              {
              EffectStateType = typeof(CardEffectAddBattleCard),
              TargetMode = TargetMode.Room,
              TargetTeamType = Team.Type.Monsters,
              ParamCardPool = MoltingImpOnlyPool,
              ParamInt = 3,
              AdditionalParamInt = 1,
              
              },
                }
           }.Build();
            ImpParade1Data.GetTriggerUpgrades().Add(ImpParade1Draw);

            //Imp Parade 1 Room Modifier/

        var ImpParade1RoomEnergy = new RoomModifierDataBuilder
        {
            RoomModifierID = TestPlugin.GUID + "_ImpParade1RoomEnergyModifier",
            RoomModifierClassType = typeof(RoomStateUnitCostModifier),
            Description = "Imp units cost [paramint][ember] on this floor.",
            DescriptionInPlay = "Imp units cost [paramint][ember] on this floor.",
            ParamInt = -1,
            ParamSubtype = VanillaSubtypeIDs.Imp

        }.Build();
        ImpParade1Data.GetRoomModifierUpgrades().Add(ImpParade1RoomEnergy);

    // Imp Parade 2/

        var ImpParade2Data = CustomUpgradeManager.GetCardUpgradeByID(VanillaCardUpgradeDataIDs.ImpParadeII);
     Traverse.Create(ImpParade2Data).Field("bonusHP").SetValue(14);
     Traverse.Create(ImpParade2Data).Field("bonusDamage").SetValue(7);
     ImpParade2Data.GetTriggerUpgrades().Clear();
     ImpParade2Data.GetRoomModifierUpgrades().Clear();

     //Give Cards/
     var ImpParade2Draw = new CharacterTriggerDataBuilder
           {TriggerID = TestPlugin.GUID + "_ImpParade2Trigger", 
           Trigger = CharacterTriggerData.Trigger.PostCombat, 
           Description = "Add a <b>Queens Impling</b>, a <b>Molting Imp</b> and a <b>Fledgling Imp</b> to your hand." ,
           EffectBuilders = 
          {
             new CardEffectDataBuilder 
              {
              EffectStateType = typeof(CardEffectAddBattleCard),
              TargetMode = TargetMode.Room,
              TargetTeamType = Team.Type.Monsters,
              ParamCardPool = ImpStarterCardPool,
              ParamInt = 3,
              AdditionalParamInt = 1,
              },
              new CardEffectDataBuilder 
              {
              EffectStateType = typeof(CardEffectAddBattleCard),
              TargetMode = TargetMode.Room,
              TargetTeamType = Team.Type.Monsters,
              ParamCardPool = MoltingImpOnlyPool,
              ParamInt = 3,
              AdditionalParamInt = 1,
              
              },
              new CardEffectDataBuilder 
              {
              EffectStateType = typeof(CardEffectAddBattleCard),
              TargetMode = TargetMode.Room,
              TargetTeamType = Team.Type.Monsters,
              ParamCardPool = FledglingImpCardPool,
              ParamInt = 3,
              AdditionalParamInt = 1,
              
              },
                }
           }.Build();
            ImpParade2Data.GetTriggerUpgrades().Add(ImpParade2Draw);
            //Imp Parade 2 Room Modifier/
        var ImpParade2RoomEnergy = new RoomModifierDataBuilder
        {
            RoomModifierID = TestPlugin.GUID + "_ImpParade1RoomEnergyModifier",
            RoomModifierClassType = typeof(RoomStateUnitCostModifier),
            Description = "Imp units cost [paramint][ember] on this floor.",
            DescriptionInPlay = "Imp units cost [paramint][ember] on this floor.",
            ParamInt = -1,
            ParamSubtype = VanillaSubtypeIDs.Imp

        }.Build();
        ImpParade2Data.GetRoomModifierUpgrades().Add(ImpParade2RoomEnergy);


    // Imp Parade 3/

    var ImpParade3Data = CustomUpgradeManager.GetCardUpgradeByID(VanillaCardUpgradeDataIDs.ImpParadeIII);
     Traverse.Create(ImpParade3Data).Field("bonusHP").SetValue(14);
     Traverse.Create(ImpParade3Data).Field("bonusDamage").SetValue(7);
     ImpParade3Data.GetTriggerUpgrades().Clear();
     ImpParade3Data.GetRoomModifierUpgrades().Clear();

     //Give Cards/
     var ImpParade3Draw = new CharacterTriggerDataBuilder
           {TriggerID = TestPlugin.GUID + "_ImpParade3Trigger", 
           Trigger = CharacterTriggerData.Trigger.PostCombat, 
           Description = "Add an <b>Imp Quartet</b> to your hand." ,
           EffectBuilders = 
          {
             new CardEffectDataBuilder 
              {
              EffectStateType = typeof(CardEffectAddBattleCard),
              TargetMode = TargetMode.Room,
              TargetTeamType = Team.Type.Monsters,
              ParamCardPool = CustomCardPoolManager.GetCustomCardPoolByID(ImpQuartetCardData.ImpQuartetPoolID),
              ParamInt = 3,
              AdditionalParamInt = 1,
              },
              
                }
           }.Build();
            ImpParade3Data.GetTriggerUpgrades().Add(ImpParade3Draw);

            //Imp Parade 3 Room Modifier/

        var ImpParade3RoomEnergy = new RoomModifierDataBuilder
        {
            RoomModifierID = TestPlugin.GUID + "_ImpParade1RoomEnergyModifier",
            RoomModifierClassType = typeof(RoomStateUnitCostModifier),
            Description = "Imp units cost [paramint][ember] on this floor.",
            DescriptionInPlay = "Imp units cost [paramint][ember] on this floor.",
            ParamInt = -1,
            ParamSubtype = VanillaSubtypeIDs.Imp

        }.Build();
        ImpParade3Data.GetRoomModifierUpgrades().Add(ImpParade3RoomEnergy);






















           
        }
    }
}
