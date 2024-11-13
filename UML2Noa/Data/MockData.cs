using PizzaLibrary.Models;

public static class MockData
{
    #region Instance fields
    private static Dictionary<string, Customer> _customerData =
        new Dictionary<string, Customer>()
        {
            { "12121212", new Customer("Mikkel", "12121212", "Street 123") },
            { "13131313", new Customer("Charlotte", "13131313", "Avenue 321") },
            { "14141414", new Customer("Carina", "14141414", "High Street 234") },
            { "15151515", new Customer("Muhammed", "15151515", "North Street 345") }
        };

    private static List<MenuItem> _menuItemData =
        new List<MenuItem>()
        {
            new MenuItem("Margherita", 85, "Tomat, ost", MenuType.PIZZECLASSSICHE),
            new MenuItem("Vesuvio", 95, "Tomat, ost & skinke", MenuType.PIZZECLASSSICHE),
            new MenuItem("Capricciosa", 98, "Tomat, ost, skinke & champignon", MenuType.PIZZECLASSSICHE),
            new MenuItem("Calzone", 98, "Indbagt pizza med tomat, ost, skinke & champignon", MenuType.PIZZECLASSSICHE),
            new MenuItem("Quattro Stagioni", 99, "Tomat, ost, skinke, champignon, rejer & paprika", MenuType.PIZZECLASSSICHE),
            new MenuItem("Marinara", 97, "Tomat, ost, rejer, muslinger & hvidløg", MenuType.PIZZECLASSSICHE),
            new MenuItem("Vegetariana", 98, "Tomat, ost & grønsager", MenuType.PIZZECLASSSICHE),
            new MenuItem("Italiana", 97, "Tomat, ost, løg & kødsauce", MenuType.PIZZECLASSSICHE)
        };
    #endregion

    #region Properties
    public static Dictionary<string, Customer> CustomerData
    {
        get { return _customerData; }
    }


    public static List<MenuItem> MenuItemData
    {
        get { return _menuItemData; }
    }
    #endregion

    public static void Reset()
    {
        _customerData = new Dictionary<string, Customer>()
            {
            { "12121212", new Customer("Mikkel", "12121212", "Street 123") },
            { "13131313", new Customer("Charlotte", "13131313", "Avenue 321") },
            { "14141414", new Customer("Carina", "14141414", "High Street 234") },
            { "15151515", new Customer("Muhammed", "15151515", "North Street 345") }
            };

        _menuItemData =
        new List<MenuItem>()
        {
            new MenuItem("margherita", 85, "tomat, ost", MenuType.PIZZECLASSSICHE),
            new MenuItem("vesuvio", 95, "tomat, ost & skinke", MenuType.PIZZECLASSSICHE),
            new MenuItem("capricciosa", 98, "tomat, ost, skinke & champignon", MenuType.PIZZECLASSSICHE),
            new MenuItem("calzone", 98, "indbagt pizza med tomat, ost, skinke & champignon", MenuType.PIZZECLASSSICHE),
            new MenuItem("quattro stagioni", 99, "tomat, ost, skinke, champignon, rejer & paprika", MenuType.PIZZECLASSSICHE),
            new MenuItem("marinara", 97, "tomat, ost, rejer, muslinger & hvidløg", MenuType.PIZZECLASSSICHE),
            new MenuItem("vegetariana", 98, "tomat, ost & grønsager", MenuType.PIZZECLASSSICHE),
            new MenuItem("italiana", 97, "tomat, ost, løg & kødsauce", MenuType.PIZZECLASSSICHE)

        };


    }
}
