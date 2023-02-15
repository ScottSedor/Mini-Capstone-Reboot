using Capstone.Classes;
using System;
using System.IO;
using System.Numerics;

namespace Capstone
{
    /// <summary>
    /// This class is the main entry point for the application.
    /// 
    /// 
    /// </summary>
    /// 
    /// Shows Main Menu on Start
    /// 
    /// ------------------
    /// (1) Show Inventory
    /// (2) Make Sale
    /// (3) Quit
    /// ------------------
    /// 
    /// ***InventoryItem*** should contain  Chocolates, Sours, Licorice, Hard Candy
    /// ***InventoryItem*** has *ItemId* *ItemName*, *ItemPrice*, *IsIndividuallyWrapped*, *ItemQuantity* (max qty 100)), *ItemList*
    /// ***InventoryItem*** will read from text file and restock ItemQuantity on Start
    /// 
    /// MainMenuOption (1) will show items as such:
    /// 
    /// -------------------------------------------------
    /// Id  Name             Wrapper    Qty         Price
    /// C1  Chocolate Bites  Y          100         $1.10
    /// C2  Coco Bar         N          42          $2.75
    /// H1  Pickle Suckers   Y          SOLD OUT    $1.45
    /// H2  DotNet Blocky    Y          100         $1.35
    /// H3  Java Greener     N          100         $2.56
    /// H4  Java Bluemataz   N          100         $3.10
    /// L1  Anise Bite       Y          100         $0.35
    /// L2  Strawberry Straw Y          27          $1.25
    /// S1  Sweet Sours      N          SOLD OUT    $0.25
    /// S2  Bitter Chews     Y          78          $0.90
    /// S3  Sour Gummy       Y          1           $0.15
    /// -------------------------------------------------
    /// 
    /// Main menu should display after Inventory
    /// Store Items Alphebetically by *ItemId* 
    ///
    /// MainMenuOption (2) displays MakeSaleSubMenu:
    /// 
    /// --------------------------------
    /// (1) Take Money
    /// (2) Select Products
    /// (3) Complete Sale
    /// Current Customer Balance: $0.00    (should be displayed after each deposit)
    /// --------------------------------
    /// 
    /// MakeSaleSubMenu (1) TakeMoney will allow users to deposit money into machine's **CurrentAccountBalance** (up to $100 at a time [$1000 max limit]) invalid amounts result in error message
    /// 
    /// MakeSaleSubMenu (2) Displays *ItemList* from *InventoryItem* for selection by *ItemId*  Dictionary<string, InventoryItem> ItemList
    /// error displays for invaild *ItemId*  ->  back to MakeSaleSubMenu  
    /// error displays for SOLD OUT *ItemQuantity*
    /// error displays for *ItemQuantity* below (amountSelected)   ->  back to MakeSaleSubMenu
    /// error displays for **CurrentAccountBalance** lower than **TotalPrice**  "insufficiant funds"  -> back to MakeSaleSubMenu
    /// 
    /// If purchase succeeds, generate line in *AuditLog* file
    /// Logging will AppendTo AuditLog* NOT overwrite
    /// *AuditLog* includes *DateTime*, *ActionTaken*, *CurrentAccountBalance* before && after purchase
    /// 
    /// If purchase succeeds, **CurrentAccountBalance** is updated ->  back to MakeSaleSubMenu
    /// 
    /// MakeSaleSubMenu (3) shows a receipt for products purchased and shows changed returned to customer
    /// Show change in dollar and coin amount
    /// customer balance resets to 0
    /// shopping cart resets
    /// receipt shows *ItemName*, *ProductType* (product type is a derived property), *QuantitySelected* (QuantitySelected is a derived property?),  *ItemPrice*, *ItemCartTotalPrice*, *SalesTotalPrice*, *ChangeExpected*  
    /// ITEM QUANTITIES UPDATE AND PERSIST
    /// 
    /// The Product Types should be displayed using the following descriptions:
    /// 
    /// -----------------------------------
    /// Chocolates: Chocolate Confectionery
    /// Sours: Sour Flavored Candies
    /// Licorce: Licorce and Jellies
    /// Hard Candy: Hard Tack Confectionery
    /// -----------------------------------
    /// 
    /// Example Receipt:
    /// 
    /// ---------------------------------------------------------------------
    /// 10 Chocolate Bites Chocolate Confectionery $1.10 $11.00
    /// 22 Strawberry Straw Licorce and Jellies $1.25 $27.50
    /// 2 Pickle Suckers Hard Tack Confectionery $1.45 $2.90
    /// 50 Sweet Sours Sour Flavored Candies $0.25 $12.50
    /// 12 Anise Bite Licorce and Jellies $0.35 $4.20
    /// Total: $58.10
    /// Change: $91.90
    /// (4) Twenties, (1) Tens, (1) Ones, (3) Quarters, (1) Dimes, (1) nickels
    /// ---------------------------------------------------------------------
    /// 
    /// Return to MainMenu
    /// MainMenu (1) ShowInventory Shows updated *ItemQuantity*
    /// 
    /// 
    /// 
    ///Purchases will be audited as such:
    ///
    /// ----------------------------------------------------------------------
    /// 09/28/2021  12:00:00 PM       MONEY RECIEVED:         $50.00   $50.00
    /// 09/28/2021  12:00:15 PM       MONEY RECIEVED:         $100.00  $150.00
    /// 09/28/2021  12:00:20 PM   10  Chocolate Bites   C1    $11.00   $139.00
    /// 09/28/2021  12:01:25 PM   22  Strawberry Straw  L2    $27.50   $111.50
    /// 09/28/2021  12:03:12 PM   2   Pickle Suckers    H1    $2.90    $108.60
    /// 09/28/2021  12:03:57 PM   50  Sweet Sours       S1    $12.50   $96.10
    /// 09/28/2021  12:05:02 PM   12  Anise Bite        L1    $4.20    $91.90
    /// 09/28/2021  12:05:58 PM       CHANGE GIVEN:           $91.90   $0.00
    /// ----------------------------------------------------------------------
    ///
    /// Write Unit Tests
    /// 
    /// BONUS REQ AFTER


    public sealed class Program
    {
        public static void Main(string[] args)
        {
            UserInterface consoleInterface = new UserInterface();
            consoleInterface.Run();
        }
    }
}
