using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class damage_calculator
    {
        // A Test behaves as an ordinary method
        [Test]
        public void sets_damage_to_half_with_50_percent_mitigation()
        {
            int finalDamage = DamageCalculator.CalculateDamage(10, 0.5f);
            
            Assert.AreEqual(5,finalDamage);
        }

        [Test]
        public void sets_damage_to_20_with_80_percent_mitigation()
        {
            int finalDamage = DamageCalculator.CalculateDamage(100, 0.8f);
            
            Assert.AreEqual(20,finalDamage);
        }
    }
}
