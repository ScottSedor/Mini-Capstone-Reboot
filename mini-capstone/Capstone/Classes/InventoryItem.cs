using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Capstone.Classes
{
    public class InventoryItem
    {
        public string ItemType { get; private set; }
        public string ItemId { get; private set; }
        public string ItemName { get; private set; }
        public decimal ItemIndividualPrice { get; private set; }
        public bool IsIndiviuallyWrapped { get; private set; }
        public int ItemQuantity { get; private set; } = 100;
        
        public List<ICandy> PopulateInventoryList()
        {
            List<ICandy> InventoryItemsList = new List<ICandy>();

            using (StreamReader streamReader = new StreamReader("C:/Users/Student/Desktop/Mini-Capstone-1/inventory.csv"))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] lineArray = line.Split("|");

                    ICandy newItem = AssignCandyType();
                    newItem.ItemType = lineArray[0];
                    newItem.ItemId = lineArray[1];
                    newItem.ItemName= lineArray[2];
                    newItem.ItemIndividualPrice = decimal.Parse(lineArray[3]);
                    if (lineArray[4] == "T")
                    {
                        newItem.IsIndiviuallyWrapped = true;
                    }
                    else
                    {
                        newItem.IsIndiviuallyWrapped = false;
                    }
                    InventoryItemsList.Add(newItem);
                }
                InventoryItemsList.Sort((item, item2) => string.Compare(item.ItemId, item2.ItemId));
                return InventoryItemsList;
            }
        }

        public ICandy AssignCandyType()
        {
            using (StreamReader streamReader = new StreamReader("C:/Users/Student/Desktop/Mini-Capstone-1/inventory.csv"))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] lineArray = line.Split("|");

                    if (lineArray[0] == "CH")
                    {
                        return new ChocolateCandy();
                    }
                    else if (lineArray[0] == "SR")
                    {
                        return new SourCandy();
                    }
                    else if (lineArray[0] == "HC")
                    {
                        return new HardCandy();
                    }
                    else
                    {
                        return new JellyCandy();
                    }
                }
            }
            return null;
        }
    }
}
