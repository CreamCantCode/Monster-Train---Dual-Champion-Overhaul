using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.BuildersV2;
using Trainworks.ConstantsV2;
using Trainworks.Managers;
using Trainworks.ManagersV2;
using UnityEngine;
using BepInEx.Logging;
using JetBrains.Annotations;
using MonsterTrainModdingTemplate;


namespace DCOverHaulCardPools
{
    class MyCardPools
    {
        public static CardPool QueenCardPool = ScriptableObject.CreateInstance<CardPool>(); 
     


        /*public static void MarkCardPoolForPreloading(CardPool cardPoolID, bool clan_assets = true, bool game_assets = false)
        {
            cardPoolID = RecombinantCardPool;
        }*/
        

        public static void DoCardPoolStuff()
       {

           QueenCardPool = new CardPoolBuilder
            {
                CardPoolID = TestPlugin.GUID + "_QueenCardPool",
                CardIDs = new List<string>
                {
                    CustomCardManager.GetCardDataByID(VanillaCardIDs.QueensImpling).GetID(),
                    CustomCardManager.GetCardDataByID(VanillaCardIDs.FledglingImp).GetID(),
                    CustomCardManager.GetCardDataByID(VanillaCardIDs.MoltingImp).GetID(),
                    CustomCardManager.GetCardDataByID(VanillaCardIDs.WelderHelper).GetID(),


                },

            }.BuildAndRegister();

            
        




       }

    }
}
