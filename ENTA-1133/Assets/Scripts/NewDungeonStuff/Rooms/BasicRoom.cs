using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame.Scripts.DungeonThing.Rooms
{
    internal class BasicRoom : Room
    {
        internal override string roomDesc { get; } = "It's a basic room.";
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
}
