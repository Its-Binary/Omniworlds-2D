using UnityEngine;

public class Equipment : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;

    public virtual void Use()
    {
        
    }
}
