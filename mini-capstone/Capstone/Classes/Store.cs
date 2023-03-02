using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public sealed class Store
    {
        public decimal CustomerBalance { get; private set; } = 0;
        public decimal totalCartPrice { get; private set; } = 0;
        public List<ICandy> ShoppingCart { get; private set; } = new List<ICandy>();  
        static InventoryItem inventoryItem = new InventoryItem();
        List<ICandy> inventoryItemList = inventoryItem.PopulateInventoryList();

        public Store() { }

        public decimal AddMoney()
        {
            decimal amountToAdd = decimal.Parse(Console.ReadLine());
            if (CustomerBalance >= 1000 || amountToAdd + CustomerBalance > 1000)
            {
                throw new BalanceOver1000Exception();
            }
            CustomerBalance += amountToAdd;
            return CustomerBalance;
        }
        public void CompleteSale()
        {
            if (CustomerBalance >= totalCartPrice)
            {
                CustomerBalance -= totalCartPrice;
                //add method to print receipt and clear cart.
            }
            else
            {
                throw new InsufficientFundsException();
            }
        }
        //This method adds a product from the *inventory item list* to a *shopping cart list* in the store class.
        public void AddItemToCartById()
        {
            Console.WriteLine("\nSelect a product by ID: ");
            string itemId = Console.ReadLine();
            Console.WriteLine("\nSelect a quantity to add to cart: ");
            int quantity = int.Parse(Console.ReadLine());
            foreach (ICandy item in inventoryItemList)
            {
                if (item.ItemId == itemId)
                {
                    totalCartPrice += item.ItemIndividualPrice * quantity;
                    ICandy productSelected = item;
                    AddProductToCart(productSelected, quantity);
                    Console.WriteLine("\n****************************************************************");
                    Console.WriteLine(productSelected.ItemQuantitySelected + " " + productSelected.ItemName + "(s) Have been added to your cart.");
                    Console.WriteLine("****************************************************************\n");
                }
                //else
                //{
                //    Console.WriteLine("Please select a valid item ID. ");
                //}
            }
        }
        public InventoryItem AddProductToCart(ICandy productSelected, int quantity)
        {
            if (ShoppingCart.Contains(productSelected))
            {
                productSelected.ItemQuantitySelected+=quantity;
            }
            else
            {
                productSelected.ItemQuantitySelected += quantity;
                ShoppingCart.Add(productSelected);
                
            }
            productSelected.ItemTotalPrice = productSelected.ItemIndividualPrice * productSelected.ItemQuantitySelected;
            return inventoryItem;
        }
    }
}
