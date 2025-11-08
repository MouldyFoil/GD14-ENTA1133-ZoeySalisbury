using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
internal class EncounterRoom : Room
{
    [SerializeField] internal override string roomDesc { get; } = "There are signs of battle.";
    internal override void OnRoomSearched()
    {

    }
    internal override void ExtraEnterBehavior()
    {

    }

    internal override void OnRoomCreated()
    {

    }

    internal override bool PopulateItemsSpecal()
    {
        return false;
    }
}
