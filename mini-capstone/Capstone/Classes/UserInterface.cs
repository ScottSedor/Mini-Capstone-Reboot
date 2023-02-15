using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Capstone.Classes
{
    public sealed class UserInterface
    {
        private Store store = new Store();
        static InventoryItem inventoryItem = new InventoryItem();
        List<ICandy> inventoryItemList = inventoryItem.PopulateInventoryList();   
        public void Run()
        {
            try
            {
                ShowMainMenu();
            }
            catch (CustomException incorrectNumber)
            {
                incorrectNumber.InvalidEntryMainMenu();
                Run();
            }
            catch (MakeSaleMenuException incorrectNumber)
            {
                incorrectNumber.InvalidEntryMakeSaleMenu();
                ShowMakeSaleMenu();
            }
            catch (FormatException)
            {
                Console.WriteLine("\n Oops.  Please enter a number between 1 & 3");
                Run();
            }
        }
        //This method will show the main menu options
        private void ShowMainMenu()
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("\nWelcome to Command Line Candy Store");
            Console.WriteLine("\n(1) Show Inventory \n(2) Make Sale \n(3) Quit\n");
            Console.WriteLine("--------------------------------------------------------------");
            bool isDecided = false;
            while (!isDecided)
            {
               int mainMenuChoice = int.Parse(Console.ReadLine());
               if (mainMenuChoice > 3 || mainMenuChoice < 1)
               {
                    throw new CustomException();
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
        private void ShowMakeSaleMenu()
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("\nWelcome to Command Line Candy Store");
            Console.WriteLine("\n(1) Take Money \n(2) Select Products \n(3) Complete Sale\n \nCurrent Customer Balance: " + store.CustomerBalance + "\n");
            Console.WriteLine("--------------------------------------------------------------");
            bool isDecided = false;
            while (!isDecided)
            {
                int mainMenuChoice = int.Parse(Console.ReadLine());
                if (mainMenuChoice > 3 || mainMenuChoice < 1)
                {
                    throw new MakeSaleMenuException();
                }
                if (mainMenuChoice == 1)
                {
                    DepositMoney();
                }
                if (mainMenuChoice == 2)
                {
                    SelectItem();
                }
                if (mainMenuChoice == 3)
                {
                    try
                    {
                        store.CompleteSale();
                    }
                    catch (InsufficientFundsException ex)
                    {
                        ex.NotEnoughFunds();
                    }
                }
                //Console.WriteLine("\n***ERROR***\n Invalid Entry\n");
                ShowMakeSaleMenu();
            }
        }

        private void SelectItem()
        {
            ShowInventoryMenu();
            store.AddItemToCartById();
            DisplayCartContents();
            ShowMakeSaleMenu();
        }

        private void DepositMoney()
        {
            try
            {
                Console.WriteLine("\nHow much money would you like to add? ");
                store.AddMoney();
                ShowMakeSaleMenu();
            }
            catch (BalanceOver1000Exception invalidEntry)
            {
                invalidEntry.InvalidEntry();
                ShowMakeSaleMenu();
            }
        }

        //This method displays the current contents of the shopping cart for the current session
        public void DisplayCartContents()
        {
            Console.WriteLine("Your Cart Contains:  \n");
            foreach (ICandy item in store.ShoppingCart)
            {
                Console.WriteLine(item.ItemQuantitySelected + " " + item.ItemName + " " + item.ItemTotalPrice);
            }
            Console.WriteLine("\nTotal price is currently:  " + store.totalCartPrice + "\n");
        }

        //This method prints a list of vending items from a list populated by a .csv text file.
        private void ShowInventoryMenu()
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("{0, -5} {1, -20} {2, -10} {3, -5} {4, 0}", "\nId", "Name", "Wrapper", "Qty", "Price\n");
            foreach (ICandy item in inventoryItemList)
            {
                Console.WriteLine("{0, -5} {1, -20} {2, -10} {3, -5} {4, 0}", item.ItemId, item.ItemName, item.IsIndiviuallyWrapped, item.ItemQuantity, item.ItemIndividualPrice);
            }
            Console.WriteLine("--------------------------------------------------------------");
        }
    }
}
