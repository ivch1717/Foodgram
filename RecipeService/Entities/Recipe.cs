namespace Entities;

public sealed class Recipe
{
    public Guid Id {get;}
    public Guid UserId {get;}
    public int Price {get;}
    public int Calories { get; }
    public string Name {get;}
    public string Ingredients { get; }
    public string Instructions {get;}
    public DateTime DateCreated {get;}

    public Recipe(Guid recipeId, Guid userId, int price, int calories, string name, string ingredients,
        string instructions, DateTime dateCreated)
    {
        if (recipeId ==  Guid.Empty)
        {
            throw new ArgumentException("Id не может быть пустым");
        }

        if (userId == Guid.Empty)
        {
            throw new ArgumentException("UserId не может быть пустым");
        }

        if (price < 0)
        {
            throw new ArgumentException("Цена не может быть отрицательной");
        }

        if (calories <= 0)
        {
            throw new ArgumentException("Количество каллорий должно быть положительным");
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Имя не может быть пустым");
        }

        if (string.IsNullOrEmpty(ingredients))
        {
            throw new ArgumentException("Ингридиенты не могут быть пустыми");
        }

        if (string.IsNullOrEmpty(instructions))
        {
            throw new ArgumentException("Описание не могут быть пустыми");
        }
        
        Id = recipeId;
        UserId = userId;
        Price = price;
        Calories = calories;
        Name = name;
        Ingredients = ingredients;
        Instructions =  instructions;
        DateCreated = dateCreated;
    }
}