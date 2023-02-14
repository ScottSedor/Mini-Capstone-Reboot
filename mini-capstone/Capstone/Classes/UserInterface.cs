using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class is responsible for displaying data to the user and getting input from the user
    /// </summary>
    /// <remarks>
    /// All Console statements belong in this class.
    /// NO Console statements should be in any other class.
    /// </remarks>
    public sealed class UserInterface
    {

        private Store store = new Store();
        static InventoryItem inventoryItem = new InventoryItem();
        List<ICandy> inventoryItemList = inventoryItem.PopulateInventoryList();
        /// <summary>
        /// Provides all communication with human user.
        /// </summary>
        
        public void Run()
        {
            try
            {
                ShowMainMenu();
                bool isDecided = false;
                while (!isDecided)
                {
                    int mainMenuChoice = int.Parse(Console.ReadLine());
                    if (mainMenuChoice > 3 || mainMenuChoice < 1)
                    {
                        throw new CustomExecption();
                    }
                    if (mainMenuChoice == 1)
                    {
                        ShowInventoryMenu();
                        ShowMainMenu();
                    }
                    if (mainMenuChoice == 2)
                    {
                        ShowMakeSaleMenu();
                    }
                    if (mainMenuChoice == 3)
                    {
                        Console.WriteLine("\nProgram Exiting");
                        break;
                    }
                }
            }
            catch (CustomExecption incorrectNumber)
            {
                incorrectNumber.InvalidEntry();
                Run();
            }
            catch(FormatException)
            {
                Console.WriteLine("\n Oops.  Please enter a number between 1 & 3");
                Run();
            }

        }

        private void ShowMainMenu()
        {
            Console.WriteLine("\nWelcome to Hell");
            Console.WriteLine("\n(1) Show Inventory \n(2) Make Sale \n(3) Quit\n");

        }

        private void ShowInventoryMenu()
        {
            Console.WriteLine("{0, -5} {1, -20} {2, -10} {3, -5} {4, 0}", "\nId", "Name", "Wrapper", "Qty", "Price\n");
            foreach (ICandy item in inventoryItemList)
            {
                Console.WriteLine("{0, -5} {1, -20} {2, -10} {3, -5} {4, 0}", item.ItemId, item.ItemName, item.IsIndiviuallyWrapped, item.ItemQuantity, item.ItemIndividualPrice);
            }
        }

        private void ShowMakeSaleMenu()
        {
            Console.WriteLine("\n(1) Take Money \n(2) Select Products \n(3) Complete Sale\n \nCurrent Customer Balance: " + store.CustomerBalance + "\n");

            bool isDecided = false;
            while (!isDecided)
            {
                int mainMenuChoice = int.Parse(Console.ReadLine());
                if (mainMenuChoice > 3 || mainMenuChoice < 1)
                {
                    throw new CustomExecption();
                }
                if (mainMenuChoice == 1)
                {
                    Console.WriteLine("How much money would you like to add? ");
                    decimal amountToAdd = Decimal.Parse(Console.ReadLine());
                    store.AddMoney(amountToAdd);
                    ShowMakeSaleMenu();
                }
                if (mainMenuChoice == 2)
                {
                    ShowInventoryMenu();
                    Console.WriteLine("\nSelect a product by ID: ");
                    string itemId = Console.ReadLine();
                    AddItemToCartById(itemId);
                    Console.WriteLine("Your Cart Contains:  \n");
                    foreach (ICandy item in store.ShoppingCart)
                    {
                        Console.WriteLine(item.ItemQuantitySelected + " " + item.ItemName + " " + item.ItemTotalPrice + "\n");
                    }
                    ShowMakeSaleMenu();
                }
                if(mainMenuChoice == 3)
                {
                    //completeSale();
                }
            }
        }

        private void AddItemToCartById(string itemId)
        {
            foreach (ICandy item in inventoryItemList)
            {
                if (item.ItemId == itemId)
                {
                    ICandy productSelected = item;
                    store.AddProductToCart(productSelected);
                    Console.WriteLine("\n" + productSelected.ItemQuantitySelected + " " + productSelected.ItemName + "(s) Have been added to your cart.\n");
                }
            }
        }
    }
}
