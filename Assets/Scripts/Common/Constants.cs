using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Common
{
    public class Constants
    {
        public struct  Axis
        {
            public const string horizontal = "Horizontal";
            public const string vertical = "Vertical";
        }

        public struct ParamsAnimations
        {
            public const string x = "X";
            public const string y = "Y";
            public const string death = "Death";
            public const string walkingDown = "isWalkingDown";
        }

        public struct Tags
        {
            public const string player = "Player";
            public const string enemy = "Enemy";
        }

        public enum TypeAtributte
        {
            Strenght,
            Intelligence,
            Destreza
        }

        public enum TypeAttacks
        {
            Melee,
            Embestida
        }

        public enum WeaponType
        {
            Magic,
            Melee
        }

        public enum TypesOfItem
        {
            Weapon,
            Potion,
            Materia,
            Ingredients,
            Treasures
        }



        public enum TypeOfInteraction
        {
            Click,
            Use,
            Equip,
            remove
        }

        public enum MovementDirection
        {
            Horizontal,
            Vertical
        }

        public enum TypeIntearactionExtraNPC
        {
            Quests,
            store,
            crafting
        }

      
    }
}
