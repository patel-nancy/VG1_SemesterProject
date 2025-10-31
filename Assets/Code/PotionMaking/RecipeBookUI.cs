using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeBookUI : MonoBehaviour
{
    [SerializeField] private TMP_Text recipeTitle;
    [SerializeField] private TMP_Text recipeText;

    [SerializeField] private TMP_Text actualText;

    public Button nextPageButton;
    public TMP_Text nextPageText;

    public Button prevPageButton;
    public TMP_Text prevPageText;

    public int currentPage = 0;
    
    void Update()
    {
        if (OrderSession.instance != null)
        {
            recipeTitle.text = OrderSession.instance.recipe_names[currentPage];
            recipeText.text = Recipe.describe(OrderSession.instance.recipe_cookbook[OrderSession.instance.recipe_names[currentPage]].actions) + "Bottle potion!";
            actualText.text = Recipe.describe(OrderSession.instance.currPlayerActions);
        }

        bool hasNext = HasNextPage();
        nextPageButton.interactable = hasNext;
        nextPageText.enabled = hasNext;

        bool hasPrev = HasPrevPage();
        prevPageButton.interactable = hasPrev;
        prevPageText.enabled = hasPrev;

        // to-do: right-hand-side of page uses a nice graphic, and the potion making minigame has hints about the current progress
    }

    bool HasNextPage()
    {
        return currentPage < (OrderSession.instance.recipe_names.Count - 1);
    }

    bool HasPrevPage()
    {
        return currentPage > 0;
    }

    public void NextPage()
    {
        if (HasNextPage())
            currentPage += 1;
    }

    public void PrevPage()
    {
        if (HasPrevPage())
            currentPage -= 1;
    }

    public void Open()
    {
        this.gameObject.SetActive(true);
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
