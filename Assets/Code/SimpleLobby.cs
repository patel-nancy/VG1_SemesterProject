using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class SimpleLobby : MonoBehaviour
{
    [System.Serializable]
    public class OrderData
    {
        public string customerName;
        public Sprite customerPortrait;
        public string potionName;
        public Sprite potionIcon;
        public List<Sprite> ingredientIcons; // Stores ingredient images

    }

    [Header("UI References")]

    public Transform ordersParent;
    public GameObject orderCardPrefab;

    [Header("Orders (filled with the inspector tab for now)")]
    public List<OrderData> orders = new List<OrderData>();

    public void Start()
    {
        RenderOrders();

    }

    private void RenderOrders()
    {
        if (!ordersParent || !orderCardPrefab)
        {
            Debug.LogWarning("SimpleLobby: Assign ordersParent and orderCardPrefab.");
            return;
        }

        // clear old
        for (int i = ordersParent.childCount - 1; i >= 0; i--)
        {
            Destroy(ordersParent.GetChild(i).gameObject);
        }

        // spawn new
        foreach (var order in orders)
        {
            var card = Instantiate(orderCardPrefab, ordersParent).transform;

            // Find children by these exact names from the prefab

            var portrait = card.Find("Portrait")?.GetComponent<Image>();
            var customerTxt = card.Find("CustomerName")?.GetComponent<TMP_Text>();
            var potionTxt = card.Find("PotionName")?.GetComponent<TMP_Text>();
            var row = card.Find("IngredientRow");
            var templateGO = row?.Find("Ingredient Icon Template")?.gameObject;

            if (portrait) portrait.sprite = order.customerPortrait;
            if (customerTxt) customerTxt.text = order.customerName;
            if (potionTxt) potionTxt.text = order.potionName;

            if (row && templateGO)
            {
                // clear previous icons (keep the template)

                for (int i = row.childCount - 1; i >= 0; i--)
                {
                    var c = row.GetChild(i);
                    if (c.name != "IngredientIconTemplate") Destroy(c.gameObject);
                }

                if (order.ingredientIcons != null)
                {
                    foreach (var icon in order.ingredientIcons)
                    {
                        var iconGO = Object.Instantiate(templateGO, row);
                        iconGO.name = "IngredientIcon";
                        iconGO.SetActive(true);
                        var img = iconGO.GetComponent<Image>();
                        if (img) img.sprite = icon;
                    }
                }

                // ensure template stays disabled
                templateGO.SetActive(false);
            }



        }
    }
}
