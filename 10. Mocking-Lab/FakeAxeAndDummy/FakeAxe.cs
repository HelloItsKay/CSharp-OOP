using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy
{
   public class FakeAxe:IWeapon
   {
       public void Attack(ITarget target)
       {

       }

       public int AttackPoints => 100;
       public int DurabilityPoints => 100;
   }
}
