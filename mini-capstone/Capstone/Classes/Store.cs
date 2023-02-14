using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public sealed class Store
    {
        public decimal CustomerBalance { get; private set; } = 0;
        public List<ICandy> ShoppingCart { get; private set; } = new List<ICandy>();  
        static InventoryItem inventoryItem = new InventoryItem();
        List<ICandy> inventoryItemList = inventoryItem.PopulateInventoryList();

        public Store() { }

        public decimal AddMoney()
        {
            if (CustomerBalance >= 1000)
            {
                throw new BalanceOver1000Exception();
            }
            decimal amountToAdd = Decimal.Parse(Console.ReadLine());
            CustomerBalance += amountToAdd;
            return CustomerBalance;
        }
        //This method adds a product from the *inventory item list* to a *shopping cart list* in the store class.
        public void AddItemToCartById()
        {
            Console.WriteLine("\nSelect a product by ID: ");
            string itemId = Console.ReadLine();
            foreach (ICandy item in inventoryItemList)
            {
                if (item.ItemId == itemId)
                {
                    ICandy productSelected = item;
                    AddProductToCart(productSelected);
                    Console.WriteLine("\n" + productSelected.ItemQuantitySelected + " " + productSelected.ItemName + "(s) Have been added to your cart.\n");
                }
            }
        }
        public InventoryItem AddProductToCart(ICandy productSelected)
        {
            if (ShoppingCart.Contains(productSelected))
            {
                productSelected.ItemQuantitySelected++;
            }
            else
            {
                productSelected.ItemQuantitySelected = 1;
                ShoppingCart.Add(productSelected);
                
            }
            productSelected.ItemTotalPrice = productSelected.ItemIndividualPrice * productSelected.ItemQuantitySelected;
            return inventoryItem;
        }

        //public  selectItem
    }
}
