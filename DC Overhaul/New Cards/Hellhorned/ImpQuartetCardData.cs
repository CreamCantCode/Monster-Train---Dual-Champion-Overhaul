
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DCOverHaulCardPools;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using Trainworks.Managers;
using Trainworks.ManagersV2;

namespace MonsterTrainModdingTemplate.ImpQuartetData
{
    class ImpQuartetCardData
    {
        public static readonly string ImpQuartetCard = TestPlugin.GUID + "_ImpQuartet";
        public static readonly string ImpQuartetPoolID = TestPlugin.GUID + "_ImpQuartetPoolID";





        public static void BuildAndRegister()
        {


         var StarterImpPool = VanillaCardPoolIDs.ImpStarterOnlyPool;
            var ImpStarterCardPool = CustomCardPoolManager.GetVanillaCardPool(StarterImpPool);
            var FledglingImpPool = VanillaCardPoolIDs.FledglingImpOnlyPool;
            var FledglingImpCardPool = CustomCardPoolManager.GetVanillaCardPool(FledglingImpPool);
            var WelderHelperbasepool = VanillaCardPoolIDs.WelderHelperOnlyPool;
            var WelderHelperCardPool = CustomCardPoolManager.GetVanillaCardPool(WelderHelperbasepool);
           //Queen Custom Card Pools/
           

            var MoltingImpOnlyPool = new CardPoolBuilder
            {
                CardPoolID = TestPlugin.GUID + "_QueenCardPool",
                CardIDs = new List<string>
                {        
                    CustomCardManager.GetCardDataByID(VanillaCardIDs.MoltingImp).GetID(),
                },
            }.BuildAndRegister();

            

            
            


            var ImpQuartetCardBuilder = new CardDataBuilder
            {
                CardID = ImpQuartetCard,
                Name = "Imp Quartet",
                Description = "Deal [effect0.power] damage",
                Cost = 1,
                Rarity = CollectableRarity.Rare,
                TargetsRoom = true,
                Targetless = false,
                ClanID = VanillaClanIDs.Hellhorned,
                AssetPath = "assets/nothornbreak.png",
                CardPoolIDs = {},
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
                new CardEffectDataBuilder 
              {
              EffectStateType = typeof(CardEffectAddBattleCard),
              TargetMode = TargetMode.Room,
              TargetTeamType = Team.Type.Monsters,
              ParamCardPool = WelderHelperCardPool,
              ParamInt = 3,
              AdditionalParamInt = 1,
                },
                }
            }.BuildAndRegister();

            var ImpQuartetOnlyPoolBuilder = new CardPoolBuilder
            {
                CardPoolID = ImpQuartetPoolID,
                CardIDs = new List<string>
                {        
                    CustomCardManager.GetCardDataByID(ImpQuartetCard).GetID()
                },
            }.BuildAndRegister();


            

            



            




        }
    }
}