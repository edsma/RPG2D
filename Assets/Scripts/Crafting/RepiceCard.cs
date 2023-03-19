using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RepiceCard : MonoBehaviour
{
    [SerializeField] private Image recipeIcon;
    [SerializeField] private TextMeshProUGUI recipeName;

    public recipe uploadRecipe { get; set; }

    public void ConfigureRecipeCard(recipe recipe)
    {
        uploadRecipe = recipe;
       
        recipeName.text = uploadRecipe.itemResult.Name;
        recipeIcon.sprite = uploadRecipe.itemResult.Icon;
    }

    public void SelectRecipe()
    {
        CraftingManager.Instance.ShowRecipe(uploadRecipe);
    }
}
