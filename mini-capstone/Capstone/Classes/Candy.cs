using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public interface ICandy
    {
        public string ItemType { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemIndividualPrice { get; set; }
        public decimal ItemTotalPrice { get; set; }
        public bool IsIndiviuallyWrapped { get; set; }
        public int ItemQuantity { get;}
        public int ItemQuantitySelected { get; set; }
    }

    public class ChocolateCandy : ICandy
    {
        public string ItemType { get;  set; }
        public string ItemId { get;  set; }
        public string ItemName { get;  set; }
        public decimal ItemIndividualPrice { get;  set; }
        public decimal ItemTotalPrice { get; set; }

        public bool IsIndiviuallyWrapped { get; set; }
        public int ItemQuantity { get; } = 100;
        public int ItemQuantitySelected { get; set; } = 0;

    }

    public class SourCandy : ICandy
    {
        public string ItemType { get;  set; }
        public string ItemId { get;  set; }
        public string ItemName { get;  set; }
        public decimal ItemIndividualPrice { get;  set; }
        public decimal ItemTotalPrice { get; set; }

        public bool IsIndiviuallyWrapped { get;  set; }
        public int ItemQuantity { get; } = 100;
        public int ItemQuantitySelected { get; set; } = 0;

    }

    public class HardCandy : ICandy
    {
        public string ItemType { get;  set; }
        public string ItemId { get;  set; }
        public string ItemName { get;  set; }
        public decimal ItemIndividualPrice { get;  set; }
        public decimal ItemTotalPrice { get; set; }

        public bool IsIndiviuallyWrapped { get;  set; }
        public int ItemQuantity { get; } = 100;
        public int ItemQuantitySelected { get; set; } = 0;

    }

    public class JellyCandy : ICandy
    {
        public string ItemType { get;  set; }
        public string ItemId { get;  set; }
        public string ItemName { get;  set; }
        public decimal ItemIndividualPrice { get;  set; }
        public decimal ItemTotalPrice { get; set; }

        public bool IsIndiviuallyWrapped { get;  set; }
        public int ItemQuantity { get; } = 100;
        public int ItemQuantitySelected { get; set; } = 0;

    }
}
