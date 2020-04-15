using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory")]
    public int[] inventory;
    public int currPoc = 0;
    public int maxPoc = 8;

    [Header("Visuals")]
    public Image[] slots;
    private Color ab;
    public GameObject Inventory;
    private void Start()
    {
        ab = slots[0].color;
        for (int i = 0; i < 9; i++)
        {
            inventory[i] = -1;
        }
    }

    public void updateIn(int type)
    {
        for (int i = 0; i < 9; i++)
        {
            if(slots[i].color == ab)
            {
                currPoc = i;
                break;
            }
        }

        inventory[currPoc] = type;

        switch (type)
        {
            case 0:
                slots[currPoc].color = new Color(255f, 0f, 0f);
                break;
            case 1:
                slots[currPoc].color = new Color(0f, 255f, 0f);
                break;
            case 2:
               
                slots[currPoc].sprite = Resources.Load<Sprite>("Sprites/bluekeyimage");
                slots[currPoc].color = new Color(37, 255, 255);

                break;
            default:
                break;
        }

        currPoc++;
    }

    public bool Request(int type)
    {
        bool found = false;

        for (int i = 0; i < 9; i++)
        {
            if (inventory[i] == type)
            {
                inventory[i] = -1;
                slots[i].color = ab;
                found = true;
            }
        }

        return found;
    }

}
