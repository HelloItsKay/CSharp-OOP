using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy
{
public    class FakeDummy:ITarget
    {
        public void TakeAttack(int attackPoints)
        {
            
        }

        public int Health => 2000;
        public int GiveExperience() => 20;

        public bool IsDead() => true;
    }
}
