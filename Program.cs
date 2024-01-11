// Asset Tracking Project for an organization
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using wk2_AssetTracking_EF;

MyDbContext Context = new MyDbContext();
showMainMenu();


//Show Main Menu on Console

void showMainMenu()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Welcome to the Assets Tracking application! Please select the relevant option.");
    Console.WriteLine("1-Add an Asset");
    Console.WriteLine("2-List the Assets");
    Console.WriteLine("3-Edit the Asset");
    Console.WriteLine("4-Delete the Asset");
    Console.WriteLine("0-Quit the Application");

    Console.Write("Enter your choice : ");
    Console.ResetColor();

    string userInput = Console.ReadLine();
    switch (userInput)
    {
        case "1":
            AddAsset();//Add an Asset to the list
            break;
        case "2":
            ShowAsset();//Show all the Assets in the list
            showMainMenu();
            break;
        case "3":
            EditAsset();//Edit the Asset information
            break;
        case "4":
            DeleteAsset();//Delete the Asset
            break;
        case "0":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thank you for using this application!");//Quit the application
            Console.ResetColor();
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Selection. Please try again.");//Invalid input from the user
            Console.ResetColor();
            showMainMenu();
            break;
    }
}

//Edit an Asset in the database

void EditAsset()
{
    int Flag = 0; //Variable to carry validations on data entered by the user

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Enter the Asset ID you want to edit :");
    Console.ResetColor();
    string IdValue = Console.ReadLine();

    //Validations on the input value
    if (string.IsNullOrEmpty(IdValue))
    {
        Flag = 1;
    }

    bool ValidId = Int32.TryParse(IdValue, out int outId);
    if (Flag == 0 && ValidId)
    {
        List<Asset> Record = Context.Assets.Where(x => x.Id == outId).ToList();

        if (Record.Count > 0)
        {
            foreach (Asset item in Record)
            {

                Console.WriteLine("ID".PadRight(5) + "TYPE".PadRight(15) + "BRAND".PadRight(15) + "MODEL".PadRight(15) +
                                  "OFFICE".PadRight(15) + "PURCHASE DATE".PadRight(15) + "PRICE IN USD".PadRight(15) +
                                  "CURRENCY".PadRight(10) + "LOCAL PRICE TODAY");

                Console.WriteLine(item.Id.ToString().PadRight(5) + FindAssetType(item.AssetTypeId).ToUpper().PadRight(15) +
                                          item.Brand.ToUpper().PadRight(15) + item.Model.ToUpper().PadRight(15) +
                                          FindOfficeName(item.OfficeId).ToUpper().PadRight(15) + item.PurchaseDate.ToString("MM-dd-yyyy").PadRight(15) +
                                          item.PriceInUSD.ToString().PadRight(15) + FindCurrency(item.OfficeId).ToUpper().PadRight(10) +
                                          FindLocalPrice(item.PriceInUSD, item.OfficeId));
            }

            //Enter new values to be edited in the Record
            int flag = 0;
            Console.WriteLine("Enter the new details of the Asset.");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("New Asset Type (1 for Phone | 2 for Computer) : ");
            Console.ResetColor();
            string type = Console.ReadLine();
            
            if (string.IsNullOrEmpty(type))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This is an invalid entry.");
                Console.ResetColor();
                flag = 1;
            }
            else if (!(type.ToLower().Trim() == "1" || type.ToLower().Trim() == "2"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This is an invalid entry.");
                Console.ResetColor();
                flag = 1;
            }

            //Entering Asset Brand info
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("New Brand : ");
            Console.ResetColor();
            string brand = Console.ReadLine();
            
            if (string.IsNullOrEmpty(brand))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This is an invalid entry.");
                Console.ResetColor();
                flag = 1;
            }

            //Entering Asset Model info
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("New Model : ");
            Console.ResetColor();
            string model = Console.ReadLine();
           
            if (string.IsNullOrEmpty(model))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This is an invalid entry.");
                Console.ResetColor();
                flag = 1;
            }

            //Entering Asset Office info
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("New Office (1 for Spain/2 for Sweden/3 for USA) : ");
            Console.ResetColor();
            string office = Console.ReadLine();
            
            if (string.IsNullOrEmpty(office))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This is an invalid entry.");
                Console.ResetColor();
                flag = 1;
            }
            else if (!(office.ToLower().Trim() == "1" || office.ToLower().Trim() == "2" || office.ToLower().Trim() == "3"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This is an invalid entry.");
                Console.ResetColor();
                flag = 1;
            }

            //Entering Asset Price info
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("New Price (USD) : ");
            Console.ResetColor();
            string price = Console.ReadLine();
           
            if (string.IsNullOrEmpty(price))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This is an invalid entry.");
                Console.ResetColor();
                flag = 1;
            }

            //Entering Asset Purchase Date info
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("New Purchase Date (mm/dd/yyyy): ");
            Console.ResetColor();
            string purchase_date = Console.ReadLine();
            

            if (string.IsNullOrEmpty(purchase_date))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This is an invalid entry.");
                Console.ResetColor();
                flag = 1;
            }
            else
            {
                bool isValidDate = DateTime.TryParse(purchase_date, out DateTime out_purchase_date);
                if (!isValidDate)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This is an invalid entry.");
                    Console.ResetColor();
                    flag = 1;
                }
                if (out_purchase_date > DateTime.Today)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This is an invalid entry. Purchase Date cannot be a future date.");
                    Console.ResetColor();
                    flag = 1;
                }

                if (flag == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is an invalid entry. Please try again.");
                    Console.ResetColor();
                }
                else
                {
                    var AssetNew = Context.Assets.FirstOrDefault(x => x.Id == outId);
                    AssetNew.Brand = brand;
                    AssetNew.Model = model;
                    AssetNew.PurchaseDate = out_purchase_date;
                    AssetNew.PriceInUSD = Convert.ToDouble(price);
                    AssetNew.AssetTypeId = Convert.ToInt32(type);
                    AssetNew.OfficeId = Convert.ToInt32(office);

                    Context.Assets.Update(AssetNew);
                    Context.SaveChanges();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The Asset was successfully updated to the database.");
                    Console.ResetColor();

                }
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Record with Id:" + outId + " doesnot exist.");
            Console.ResetColor();
        }

    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("This is an invalid entry. Please try again.");
        Console.ResetColor();
    }
    showMainMenu();
}

//Add an Asset in the Database

void AddAsset()
{
    while (true)
    {
        Asset Asset = new Asset();
        int flag = 0; // Flag to record any invalid entries
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("To enter a new Asset - follow the steps | To Quit Enter : 'Q'");
        Console.ResetColor();

        //Entering Asset Type info
        Console.Write("Enter the type of Asset (1 for Phone | 2 for Computer) : ");
        string type = Console.ReadLine();
        if (string.IsNullOrEmpty(type))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This is an invalid entry.");
            Console.ResetColor();
            flag = 1;
        }
        else if (type.ToLower().Trim() == "q")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Exiting the Add Assets application.");
            Console.ResetColor();
            break;
        }
        else if (!(type.ToLower().Trim() == "1" || type.ToLower().Trim() == "2"))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This is an invalid entry.");
            Console.ResetColor();
            flag = 1;
        }

        //Entering Asset Brand info
        Console.Write("Enter the Brand of Asset : ");
        string brand = Console.ReadLine();
        if (string.IsNullOrEmpty(brand))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This is an invalid entry.");
            Console.ResetColor();
            flag = 1;
        }
        else if (brand.ToLower().Trim() == "q")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Exiting the Add Assets application.");
            Console.ResetColor();
            break;
        }

        //Entering Asset Model info
        Console.Write("Enter the Model of Asset : ");
        string model = Console.ReadLine();
        if (string.IsNullOrEmpty(model))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This is an invalid entry.");
            Console.ResetColor();
            flag = 1;
        }
        else if (model.ToLower().Trim() == "q")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Exiting the Add Assets application.");
            Console.ResetColor();
            break;
        }

        //Entering Asset Office info
        Console.Write("Enter the Office of Asset (1 for Spain/2 for Sweden/3 for USA) : ");
        string office = Console.ReadLine();
        if (string.IsNullOrEmpty(office))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This is an invalid entry.");
            Console.ResetColor();
            flag = 1;
        }
        else if (office.ToLower().Trim() == "q")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Exiting the Add Assets application.");
            Console.ResetColor();
            break;
        }
        else if (!(office.ToLower().Trim() == "1" || office.ToLower().Trim() == "2" || office.ToLower().Trim() == "3"))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This is an invalid entry.");
            Console.ResetColor();
            flag = 1;
        }

        //Entering Asset Price info
        Console.Write("Enter the Price of Asset (USD) : ");
        string price = Console.ReadLine();
        if (string.IsNullOrEmpty(price))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This is an invalid entry.");
            Console.ResetColor();
            flag = 1;
        }
        else if (price.ToLower().Trim() == "q")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Exiting the Add Assets application.");
            Console.ResetColor();
            break;
        }

        //Entering Asset Purchase Date info
        Console.Write("Enter the Purchase Date of Asset (mm/dd/yyyy): ");
        string purchase_date = Console.ReadLine();

        if (string.IsNullOrEmpty(purchase_date))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This is an invalid entry.");
            Console.ResetColor();
            flag = 1;
        }
        else if (purchase_date.ToLower().Trim() == "q")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Exiting the Add Assets application.");
            Console.ResetColor();
            break;
        }
        else
        {
            bool isValidDate = DateTime.TryParse(purchase_date, out DateTime out_purchase_date);
            if (!isValidDate)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This is an invalid entry.");
                Console.ResetColor();
                flag = 1;
            }
            if (out_purchase_date > DateTime.Today)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This is an invalid entry. Purchase Date cannot be a future date.");
                Console.ResetColor();
                flag = 1;
            }

            if (flag == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is an invalid entry. Please try again.");
                Console.ResetColor();
            }
            else
            {
                Asset.Brand = brand;
                Asset.Model = model;
                Asset.PurchaseDate = out_purchase_date;
                Asset.PriceInUSD = Convert.ToDouble(price);
                Asset.AssetTypeId = Convert.ToInt32(type);
                Asset.OfficeId = Convert.ToInt32(office);

                Context.Assets.Add(Asset);
                Context.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The Asset was successfully added to the database.");
                Console.ResetColor();
            }
        }
    }
    showMainMenu();
}

//Delete an Asset from the Database

void DeleteAsset()
{
    List<Asset> AllAsset = Context.Assets.ToList();
    if (AllAsset.Count > 0)
    {
        List<Asset> SortedAsset = AllAsset.OrderBy(x => x.OfficeId).ThenBy(x => x.PurchaseDate).ToList();
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("ID".PadRight(5) + "TYPE".PadRight(15) + "BRAND".PadRight(15) + "MODEL".PadRight(15) +
                          "OFFICE".PadRight(15) + "PURCHASE DATE".PadRight(15) + "PRICE IN USD".PadRight(15) +
                          "CURRENCY".PadRight(10) + "LOCAL PRICE TODAY");
        foreach (Asset item in SortedAsset)
        {
            Console.WriteLine(item.Id.ToString().PadRight(5) + FindAssetType(item.AssetTypeId).ToUpper().PadRight(15) +
                                      item.Brand.ToUpper().PadRight(15) + item.Model.ToUpper().PadRight(15) +
                                      FindOfficeName(item.OfficeId).ToUpper().PadRight(15) + item.PurchaseDate.ToString("MM-dd-yyyy").PadRight(15) +
                                      item.PriceInUSD.ToString().PadRight(15) + FindCurrency(item.OfficeId).ToUpper().PadRight(10) +
                                      FindLocalPrice(item.PriceInUSD, item.OfficeId));
        }
        int Count = SortedAsset.Count();
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("Total Number of Rows -".ToUpper().PadLeft(120) + Count);
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");



        int Flag = 0; //Variable to carry validations on data entered by the user

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter the Asset ID you want to delete :");
        Console.ResetColor();
        string IdValue = Console.ReadLine();

        //Validations on the input value
        if (string.IsNullOrEmpty(IdValue))
        {
            Flag = 1;
        }

        bool ValidId = Int32.TryParse(IdValue, out int outId);
        if (Flag == 0 && ValidId)
        {
            List<Asset> SelectedCar = Context.Assets.Where(x => x.Id == outId).ToList();
            if (SelectedCar.Count > 0)
            {
                var asset = Context.Assets.FirstOrDefault(x => x.Id == outId);
                Context.Assets.Remove(asset);
                Context.SaveChanges();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Record successfully deleted from the database.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Record with Id:" + outId + " doesnot exist.");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This is an invalid entry. Please try again.");
            Console.ResetColor();
        }
      }
      else
      {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("There is no Assets data in the table.");
          Console.ResetColor();
      }

    showMainMenu();
}

//List Assets from the Database

void ShowAsset()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Enter the Asset Type to View : 1 for Phone | 2 for Computer | 3 for All : ");
    string InputAsset = Console.ReadLine();
    Console.ResetColor();

    List<Asset> Result = Context.Assets.ToList(); 

    if (InputAsset == "1")
    {
        Result = Context.Assets.Where(x => x.AssetTypeId == 1).ToList();
    }

    else if (InputAsset == "2")
    {
        Result = Context.Assets.Where(x => x.AssetTypeId == 2).ToList();
    }

    if (Result.Count > 0)
    {
        List<Asset> SortedAsset = Result.OrderBy(x => x.OfficeId).ThenBy(x => x.PurchaseDate).ToList();
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("ID".PadRight(5) + "TYPE".PadRight(15) + "BRAND".PadRight(15) + "MODEL".PadRight(15) +
                          "OFFICE".PadRight(15) + "PURCHASE DATE".PadRight(15) + "PRICE IN USD".PadRight(15) +
                          "CURRENCY".PadRight(10) + "LOCAL PRICE TODAY");

        foreach (Asset item in SortedAsset)
        {
            DateTime EndOfLife_Date = item.PurchaseDate.AddYears(3);

            if (DateTime.Today > EndOfLife_Date)
            {
                if (DateTime.Today <= EndOfLife_Date.AddDays(90))
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(item.Id.ToString().PadRight(5) + FindAssetType(item.AssetTypeId).ToUpper().PadRight(15) +
                                      item.Brand.ToUpper().PadRight(15) + item.Model.ToUpper().PadRight(15) +
                                      FindOfficeName(item.OfficeId).ToUpper().PadRight(15) + item.PurchaseDate.ToString("MM-dd-yyyy").PadRight(15) +
                                      item.PriceInUSD.ToString().PadRight(15) + FindCurrency(item.OfficeId).ToUpper().PadRight(10) +
                                      FindLocalPrice(item.PriceInUSD, item.OfficeId));
                    Console.ResetColor();
                }
                else if (DateTime.Today > EndOfLife_Date.AddDays(90) && DateTime.Today <= EndOfLife_Date.AddDays(180))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(item.Id.ToString().PadRight(5) + FindAssetType(item.AssetTypeId).ToUpper().PadRight(15) +
                                      item.Brand.ToUpper().PadRight(15) + item.Model.ToUpper().PadRight(15) +
                                      FindOfficeName(item.OfficeId).ToUpper().PadRight(15) + item.PurchaseDate.ToString("MM-dd-yyyy").PadRight(15) +
                                      item.PriceInUSD.ToString().PadRight(15) + FindCurrency(item.OfficeId).ToUpper().PadRight(10) +
                                      FindLocalPrice(item.PriceInUSD, item.OfficeId));
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(item.Id.ToString().PadRight(5) + FindAssetType(item.AssetTypeId).ToUpper().PadRight(15) +
                                      item.Brand.ToUpper().PadRight(15) + item.Model.ToUpper().PadRight(15) +
                                      FindOfficeName(item.OfficeId).ToUpper().PadRight(15) + item.PurchaseDate.ToString("MM-dd-yyyy").PadRight(15) +
                                      item.PriceInUSD.ToString().PadRight(15) + FindCurrency(item.OfficeId).ToUpper().PadRight(10) +
                                      FindLocalPrice(item.PriceInUSD, item.OfficeId));
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine(item.Id.ToString().PadRight(5) + FindAssetType(item.AssetTypeId).ToUpper().PadRight(15) +
                                      item.Brand.ToUpper().PadRight(15) + item.Model.ToUpper().PadRight(15) +
                                      FindOfficeName(item.OfficeId).ToUpper().PadRight(15) + item.PurchaseDate.ToString("MM-dd-yyyy").PadRight(15) +
                                      item.PriceInUSD.ToString().PadRight(15) + FindCurrency(item.OfficeId).ToUpper().PadRight(10) +
                                      FindLocalPrice(item.PriceInUSD, item.OfficeId));
            }
        }
        int Count = SortedAsset.Count();
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("Total Number of Rows -".ToUpper().PadLeft(120) + Count);
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("There is no Assets data to display.");
        Console.ResetColor();
    }
}

//Function to find Local Price Today

double FindLocalPrice(double price, int office)
{
    switch (office)
    {
        case 1:
            return price * 0.91;
        case 2:
            return price * 10.23;
        case 3:
            return price;
        default:
            return price;
    }
}

//Find currency on the basis of office
string FindCurrency(int office)
{
    switch (office)
    {
        case 1:
            return "EUR";
        case 2:
            return "SEK";
        case 3:
            return "USD";
        default:
            return "USD";
    }
}

string FindOfficeName(int Office)
{
    switch (Office)
    {
        case 1:
            return "Spain";
        case 2:
            return "Sweden";
        case 3:
            return "USA";
        default:
            return "USA";
    }
}

string FindAssetType(int Type)
{
    switch (Type)
    {
        case 1:
            return "Phone";
        case 2:
            return "Computer";
        default:
            return "Phone";
    }
}
