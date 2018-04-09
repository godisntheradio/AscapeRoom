using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string Name { get; set; }
    
    public Texture Thumbnail { get; set; }

    public Item() { }
    public Item(string name) { Name = name; }
    public Item(string name, Texture texture)
    {
        this.Name = name;
        this.Thumbnail = texture;
    }
}
