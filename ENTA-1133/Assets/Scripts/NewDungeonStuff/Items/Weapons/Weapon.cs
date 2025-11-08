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
    [SerializeField] int handsRequired { get; }
    internal abstract void UseEvent();
    internal override string AdditionalItemInfo(string info)
    {
        return " DMG: " + damage;
    }
}
