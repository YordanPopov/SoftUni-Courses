namespace Animals.Models;

public abstract class Animal
{
    private string _name;

    private string _favouriteFood;

    public Animal(string name, string favouriteFood)
    {
        this._name = name;
        this._favouriteFood = favouriteFood;   
    }

    public virtual string ExplainSelf()
    {
        return $"I am {this._name} and my favourite food is {this._favouriteFood}";
    }
}
