using System;
using UnityEngine;


namespace Composite
{
    public sealed class CompositeTest : MonoBehaviour
    {
        private void Start()
        {
            IAttack attack = new Unit();
            Detachment attacks = new Detachment();
            attacks.AddUnit(attack);
            
            
            attack.Attack();
            attacks.Attack();

            var j = new JsonData<UnitsData>();
            var un = new UnitData[2];
            var d1 = new UnitData
            {
                type = "warrior",
                health = 150
            };
            var d2 = new UnitData
            {
                type = "mag",
                health = 30
            };
            un[0] = d1;
            un[1] = d2;
            var unitsData = new UnitsData
            {
                units = un
            };
            j.Save(unitsData, "./Assets/Src/StructuralPatterns/Composite/UnitsNew.json");
            var units = j.Load("./Assets/Src/StructuralPatterns/Composite/Units.json");
            Debug.Log(units);
        }
    }
}
