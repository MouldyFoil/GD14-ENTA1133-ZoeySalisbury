using UnityEngine;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class TreasureRoom : Room
{
    [SerializeField] internal override string roomDesc { get; } = "This room seems luckier.";
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
