using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

internal abstract class Item : MonoBehaviour
{
    [SerializeField] string description { get; }
    [SerializeField] float size { get; }
    [SerializeField] int uses { get; set; }
    internal abstract string AdditionalItemInfo(string info);
    [SerializeField] RarityEnum rarity { get; set; }
    internal string ReturnItemNameWithInfo()
    {
        string allInfo = name;
        allInfo += ". Size: " + size + " Uses: " + uses;
        allInfo += AdditionalItemInfo(allInfo);
        return allInfo;
    }
}
internal enum RarityEnum
{
    common = 50,
    uncommon = 45,
    rare = 20,
    epic = 10,
    legendary = 5,
}