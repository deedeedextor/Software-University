namespace Skeleton.Tests.FakeObjects
{
    using Skeleton.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FakeTarget : ITarget
    {
        public int Health => 0;

        public int GiveExperience() => 20;

        public bool IsDead() => true;

        public void TakeAttack(int attackPoints)
        {
        }
    }
}
