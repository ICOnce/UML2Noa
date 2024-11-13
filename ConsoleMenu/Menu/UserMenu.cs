using PizzaLibrary.Services;
using ConsoleMenu.Controllers;
using ConsoleMenu.Controllers.MenuItems;
using PizzaLibrary.Models;

public class UserMenu
{
    private static string mainMenuChoices = "\t1.Vis Pizzamenu\n\t2.Vis Kunder\n\t3.Add Customer\n\t4. Add menu item\n\tQ.Afslut\n\n\tIndtast valg:";

    private CustomerRepository _customerRepository = new CustomerRepository(MockData.CustomerData);
    private MenuRepository _menuItemRepository = new MenuRepository(MockData.MenuItemData);
    private static string ReadChoice(string choices)
    {
        Console.Clear();
        Console.Write(choices);
        string choice = Console.ReadLine();
        Console.Clear();
        return choice.ToLower();
    }
    public void ShowMenu()
    {
        string theChoice = ReadChoice(mainMenuChoices);
        while (theChoice != "q")
        {
            switch (theChoice)
            {
                case "1":
                    Console.WriteLine("Valg 1");
                    ShowMenuItemController showMenuItemController = new ShowMenuItemController(_menuItemRepository);
                    showMenuItemController.ShowAllMenuItems();
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Valg 2");
                    _customerRepository.PrintAllCustomers();
                    Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Valg 3");
                    Console.WriteLine("Indlæs navn:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Indlæs mobil nr:");
                    string mobile = Console.ReadLine();
                    Console.WriteLine("Indlæs adresse:");
                    string address = Console.ReadLine();
                    Console.WriteLine("Vil du være clubmember y/n");
                    string clubMemberString = Console.ReadLine().ToLower();
                    bool isClubMember = (clubMemberString[0] == 'y') ? true : false;
                    _customerRepository.AddCustomer(new Customer(name, mobile, address));
                    _customerRepository.GetCustomerByMobile(mobile).ClubMember = isClubMember;
                    //AddCustomerController addMenuItemController = new AddCustomerController(name, mobile, address, isClubMember, _customerRepository);
                    //addMenuItemController.AddCustomer();
                    break;
                case "4":
                    Console.WriteLine("Valg 4");
                    Console.WriteLine("Indlæs et navn");
                    string itemName = Console.ReadLine();
                    Console.WriteLine("Indlæs en pris");
                    double price = double.Parse(Console.ReadLine());
                    Console.WriteLine("Indlæs beskrivelse");
                    string desc = Console.ReadLine();
                    MenuType mt = MenuType.SALATER;
                    Console.WriteLine("Indlæs menu type" +
                        " \n1: SANDWICHES \n2: BRUCHETTA_CROSTINO \n3: SALATER \n4: PIZZECLASSSICHE \n5: PIZZESPECIALI \n6: PASTAALFORNO \n7: TILBEHØR");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            mt = MenuType.SANDWICHES;
                            break;
                        case "2":
                            mt = MenuType.BRUCHETTA_CROSTINO;
                            break;
                        case "3":
                            mt = MenuType.SALATER;
                            break;
                        case "4":
                            mt = MenuType.PIZZECLASSSICHE;
                            break;
                        case "5":
                            mt = MenuType.PIZZESPECIALI;
                            break;
                        case "6":
                            mt = MenuType.PASTAALFORNO;
                            break;
                        case "7":
                            mt = MenuType.TILBEHØR;
                            break;
                    }
                    MenuItem nw = new MenuItem(itemName, price, desc, mt);
                    break;
                default:
                    Console.WriteLine(mainMenuChoices);
                    break;
            }
            theChoice = ReadChoice(mainMenuChoices);
        }
    }

}
