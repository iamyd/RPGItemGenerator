using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBattle
{
    public class Image
    {
        CharacterImage image;
        public Image(CharacterImage i)
        {
            image = i;
        }
        public void Attack()
        {
            image.State = CharacterImage.CharacterState.Attacking;
        }
        public void TakeDamage()
        {
            image.State = CharacterImage.CharacterState.TakeDamage;
        }
        public void Idle()
        {
            image.State = CharacterImage.CharacterState.Idle;
        }
        public void Dead()
        {
            image.State = CharacterImage.CharacterState.Dead;
        }
    }
}
