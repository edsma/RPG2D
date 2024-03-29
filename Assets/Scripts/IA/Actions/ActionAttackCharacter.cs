﻿using UnityEngine;
using static Assets.Scripts.Common.Constants;

namespace Assets.Scripts.IA.Actions
{
    [CreateAssetMenu(menuName = "IA/Acciones/Atacar personaje")]
    public class ActionAttackCharacter : IAAction
    {
        public override void Execute(IAController controller)
        {

            Attack(controller);
        }

        private void Attack(IAController controller)
        {
            if (controller.characerReference == null)
            {
                return;
            }

            if (!controller.IsTimeForAttack())
            {
                return;
            }

            if (controller.CharacterRangeAttack(controller.rangeOfAttackInitial))
            {
                if (controller.TypeAttack.Equals(TypeAttacks.Embestida))
                {
                    controller.AttackEmbestida(controller.Damage);
                }
                else
                {
                    controller.MeleeAttack(controller.Damage);
                }
                
                controller.UpdateTimeBeetwenAttacks();
            }
        }
    }
}
