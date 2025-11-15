using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

internal abstract class Weapon : Item
{
    [SerializeField] int damage { get; set; }
    [SerializeField] internal int handsRequired { get; private set; }
    internal void UseEvent()
    {
        //equip weapon n things
    }
    internal abstract void Attack();
    internal override string AdditionalItemInfo(string info)
    {
        return " DMG: " + damage;
    }
}
