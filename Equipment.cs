using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordRPG
{
    public class Equipment
    {
        public int ID { get; set; } 
        public EquipmentType equipment { get; set; }

        public override string ToString()
        {
            return ($"{ID}_{equipment}");
        }

        public Equipment FromString(string input)
        {
            string[] sepInput = input.Split("_");
            if (sepInput.Length==0)
            {
                return null;
            }
            return new Equipment() {
                ID = int.Parse(sepInput[0]),
                equipment = Enum.Parse<EquipmentType>(sepInput[1])
            };
        }
    }//|userID,01_xx_xx_xx_xx,02_xx_xx_xx_xx,etc.
        public enum EquipmentType
        {
            sword, //01_50_flere tall
            shield, //02
            helmet, //03
            chestplate //04
        }
}
