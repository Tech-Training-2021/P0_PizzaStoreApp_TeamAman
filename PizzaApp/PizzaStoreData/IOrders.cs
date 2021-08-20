namespace PizzaStoreData
{
    interface IOrders
    {
        public string PizzaNames { get; set; }
        public string PizzaSizes { get; set; }
        public string PizzaToppings { get; set; }
        //public int PizzaPrice { get; set; }
    }
    /// <summary>
    /// Pizza Type enumeration
    /// </summary>
    public enum PizzaType
    {
        CHINESE_PIZZA=1,
        THIN_CRUST,
        VEGGIE_PARADISE,
        MEXICAN_GREEWAVE,
        CHICKEN_DOMINATOR_PIZZA,
        CHICKEN_SAUSAGE_PIZZA,
        CHICKEN_GOLDEN
    }
    /// <summary>
    /// Pizza Size enumeration
    /// </summary>
    public enum PizzaSize
    {
        Small=1, Medium, Large
    }
    /// <summary>
    /// Pizza Toppings enumeration
    /// </summary>
    public enum PizzaToppings
    {
        Pepperoni=1, Sausage, Capsicum, Mushrooms
    }
}
