using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : Singleton<CraftingManager>
{
    [Header("Config")]
    [SerializeField] private RepiceCard recipeCardPrefab;
    [SerializeField] private Transform containerRecipe;

    [Header("Recipe Info")]
    [SerializeField] private Image firstMaterialIcon;
    [SerializeField] private Image secondMaterialIcon;
    [SerializeField] private TextMeshProUGUI firstMaterialName;
    [SerializeField] private TextMeshProUGUI SecondMaterialName;
    [SerializeField] private TextMeshProUGUI firstMaterialAmount;
    [SerializeField] private TextMeshProUGUI SecondMaterialAmount;
    [SerializeField] private TextMeshProUGUI recipeMessage;
    [SerializeField] private Button buttonCrafter;

    [Header("Result item")]
    [SerializeField] Image itemResultIcon;
    [SerializeField] TextMeshProUGUI itemResultName;
    [SerializeField] TextMeshProUGUI itemResultDescription;

    [Header("Recipes")]
    [SerializeField] private RecipeList recipes;

    public recipe recipeSelected { get; set; }

    private void Start()
    {
        UploadRecipes();
    }

    private void UploadRecipes()
    {
        for (int i = 0; i < recipes.Recipes.Length; i++)
        {
            RepiceCard recipe =Instantiate(recipeCardPrefab, containerRecipe);
            recipe.ConfigureRecipeCard(recipes.Recipes[i]);
        }
    }

    public void ShowRecipe(recipe recipe)
    {
        recipeSelected = recipe;
        firstMaterialIcon.sprite = recipeSelected.Item1.Icon;
        firstMaterialName.text = recipeSelected.Item1.name;
        secondMaterialIcon.sprite = recipeSelected.Item2.Icon;
        SecondMaterialName.text = recipeSelected.Item2.name;
        firstMaterialAmount.text = $"{Inventario.Instance.GetAmountOfItems(recipe.Item1.Id)} / {recipe.Item1AmountRequired}";
        SecondMaterialAmount.text = $"{Inventario.Instance.GetAmountOfItems(recipe.Item2.Id)} / {recipe.Item2AmountRequired}";
        if (CanBeCrafted(recipe))
        {
            recipeMessage.text = $"Recipe available";
            buttonCrafter.interactable = true;
        }
        else
        {
            recipeMessage.text = $"You need more materials";
            buttonCrafter.interactable = false;
        }
        itemResultIcon.sprite = recipeSelected.itemResult.Icon;
        itemResultName.text = recipeSelected.itemResult.name;
        itemResultDescription.text = recipe.itemResult.DescriptionItemCrafting();
    }

    public bool CanBeCrafted(recipe recipe)
    {
        return Inventario.Instance.GetAmountOfItems(recipe.Item1.Id) >= recipe.Item1AmountRequired
            && Inventario.Instance.GetAmountOfItems(recipe.Item2.Id) >= recipe.Item2AmountRequired; 
    }

    public void CrafterItem()
    {
        for (int i = 0; i < recipeSelected.Item1AmountRequired; i++)
        {
            Inventario.Instance.ConsumeItem(recipeSelected.Item1.Id);

        }

        for (int i = 0; i < recipeSelected.Item2AmountRequired; i++)
        {
            Inventario.Instance.ConsumeItem(recipeSelected.Item2.Id);
        }

        Inventario.Instance.AddItem(recipeSelected.itemResult,recipeSelected.ItemResultAmount);
        ShowRecipe(recipeSelected);
    }
}
