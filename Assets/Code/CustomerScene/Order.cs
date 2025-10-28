public class Order
{
    public Customer customer;
    public Recipe expected_recipe;

    public Order(Customer customer, Recipe expected_recipe)
    {
        this.customer = customer;
        this.expected_recipe = expected_recipe;
    }

    public Order(string customer_name, string customer_dialogue, int customer_prefab_idx, Recipe expected_recipe)
    {
        this.customer = new Customer(customer_name, customer_dialogue, customer_prefab_idx);
        this.expected_recipe = expected_recipe;
    }
}

