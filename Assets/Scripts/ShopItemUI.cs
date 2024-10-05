using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    [SerializeField] ShopItem info;
    [Space]
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI buyText;
    [SerializeField] Image icon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnValidate()
    {
        if (info != null)
        {
            name = info.itemName;
            title.text = info.itemName;
            description.text = info.itemDescription;
            buyText.text = "Buy for " + info.cost + " Coins";
            icon.sprite = info.itemIcon;
        }
    }

    public void Upgrade()
    {
        UpgradeManager.Instance.Upgrade(info);
    }
}
