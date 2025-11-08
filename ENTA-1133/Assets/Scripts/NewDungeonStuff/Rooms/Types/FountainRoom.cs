using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

internal class FountainRoom : Room
{
    [SerializeField] internal override string roomDesc { get; } = "It's a room with a fountain in the center.";
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