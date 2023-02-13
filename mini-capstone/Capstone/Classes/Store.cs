using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// Most of the "work" (the data and the methods) of dealing with inventory and money 
    /// should be created or controlled from this class
    /// </summary>
    /// <remarks>
    /// As a reminder, no Console statements belong in this class or any other class besides UserInterface
    /// </remarks>
    public sealed class Store
    {
        public decimal CustomerBalance { get; private set; } = 0;
        public List<ICandy> ShoppingCart { get; private set; } = new List<ICandy>();  
        InventoryItem inventoryItem = new InventoryItem();
        public Store() { }

        public decimal AddMoney(decimal amountToAdd)
        {
            if(CustomerBalance >= 1000)
            {
                throw new CustomExecption();
            }
            CustomerBalance += amountToAdd;
            return CustomerBalance;
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
