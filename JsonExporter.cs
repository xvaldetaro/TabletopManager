using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
//using System.Net.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows;
namespace WpfApplication1
{
    class JsonExporter
    {
        public static string jsonFileFromCombatTable(CombatTable combatants)
        {
            return JsonConvert.SerializeObject(combatants, Formatting.Indented);
        }
        public static string jsonFileFromCombatant(Combatant combatant)
        {
            return JsonConvert.SerializeObject(combatant, Formatting.Indented);
        }
        public static void combatTableFromJsonFile(CombatTable paramAdventure, string jsonFile)
        {
             JArray adventureJson = JArray.Parse(jsonFile);
            
            //Every Combatant
             foreach (JObject combatantJson in adventureJson.Children())
             {
                 CommAddCombatant commAdd = new CommAddCombatant(paramAdventure, combatantFromJsonObject(combatantJson));
                 commAdd.Execute();
             }
        }
        private static Combatant combatantFromJsonObject(JObject combatantJson)
        {
            Combatant combatant = new Combatant((string)combatantJson["CName"], true);
            combatant.AB = (float)combatantJson["AB"];
            combatant.AbilityCHA = (int)combatantJson["AbilityCHA"];
            combatant.AbilityCON = (int)combatantJson["AbilityCON"];
            combatant.AbilityDEX = (int)combatantJson["AbilityDEX"];
            combatant.AbilityINT = (int)combatantJson["AbilityINT"];
            combatant.AbilitySTR = (int)combatantJson["AbilitySTR"];
            combatant.AbilityWIS = (int)combatantJson["AbilityWIS"];
            combatant.AC = (float)combatantJson["AC"];
            combatant.Fort = (float)combatantJson["Fort"];
            combatant.Gold = (float)combatantJson["Gold"];
            combatant.HP = (float)combatantJson["HP"];
            combatant.Initiative = (float)combatantJson["Initiative"];
            combatant.InitMod = (float)combatantJson["InitMod"];
            combatant.IsNPC = (bool)combatantJson["IsNPC"];
            combatant.MaxHP = (float)combatantJson["MaxHP"];
            combatant.Notes = (string)combatantJson["Notes"];
            combatant.PName = (string)combatantJson["PName"];
            combatant.Refl = (float)combatantJson["Refl"];
            combatant.Will = (float)combatantJson["Will"];
            combatant.XP = (float)combatantJson["XP"];

            combatant.Feats = JsonConvert.DeserializeObject<ObservableCollection<string>>(combatantJson["Feats"].ToString());
            combatant.Items = JsonConvert.DeserializeObject<ObservableCollection<Item>>(combatantJson["Items"].ToString());
            

            JArray skillsJson = (JArray)combatantJson["Skills"];
            for (int i = 0; i < (int)eSkills.Use_Rope + 1; i++)
            {
                Skill skill = JsonConvert.DeserializeObject<Skill>(skillsJson[i].ToString());
                combatant.setSkillRank((eSkills)i, skill.SkillRank); 
            }
            return combatant;
                
        }
        
    }
}
