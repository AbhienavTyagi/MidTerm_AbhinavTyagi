using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm_AbhinavTyagi
{
    public class InventoryItem
    {
        // Properties
        public string ItemName { get; set; }
        public int ItemId { get; set; }
        public double Price { get; set; }
        public int QuantityInStock { get; set; }

        // Constructor
        public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
        {
            ItemName = itemName;
            ItemId = itemId;
            Price = price;
            QuantityInStock = quantityInStock;
        }

        // Methods

        // Update the price of the item
        public void UpdatePrice(double newPrice)
        {
            Price = newPrice;
        }

        // Restock the item
        public void RestockItem(int additionalQuantity)
        {
            QuantityInStock += additionalQuantity;
        }

        // Sell an item
        public void SellItem(int quantitySold)
        {
            if (QuantityInStock >= quantitySold)
            {
                QuantityInStock -= quantitySold;
                Console.WriteLine("Sold " + quantitySold.ToString() + " items.");
            }
            else
            {
                Console.WriteLine("Not enough stock to sell.");
            }
        }

        // Check if an item is in stock
        public bool IsInStock()
        {
            return QuantityInStock > 0;
        }

        // Print item details
        public void PrintDetails()
        {
            Console.WriteLine("Item Name: " + ItemName.ToString() + ", Item ID: " + ItemId.ToString() + ", Price: " + Price.ToString("C") + ", Quantity in Stock: " + QuantityInStock.ToString());
        }
    }

    internal class Program
    {
      static void Main(string[] args)
            {
                InventoryItem item1 = new InventoryItem("Laptop", 101, 1200.50, 10);
                InventoryItem item2 = new InventoryItem("Smartphone", 102, 800.30, 15);

                while (true)
                {
                    Console.WriteLine("Pre-defined items:");
                    Console.WriteLine("1. " + item1.ItemName);
                    Console.WriteLine("2. " + item2.ItemName);
                    Console.WriteLine("3. Exit");

                    Console.Write("Choose an item to manage (1 or 2) or exit (3): ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    InventoryItem item;
                    if (choice == 1)
                    {
                        item = item1;
                    }
                    else if (choice == 2)
                    {
                        item = item2;
                    }
                    else if (choice == 3)
                    {
                        return; // Exit the program
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please try again.");
                        continue; // Go back to the main menu
                    }

                    // Print details of the chosen item
                    Console.WriteLine("Selected Item Details:");
                    item.PrintDetails();

                    while (true)
                    {
                        Console.WriteLine("Choose an option:");
                        Console.WriteLine("1. Sell item");
                        Console.WriteLine("2. Restock item");
                        Console.WriteLine("3. Update price");
                        Console.WriteLine("4. Check if item is in stock");
                        Console.WriteLine("5. Go back to main menu");

                        Console.Write("Enter your choice: ");
                        int actionChoice = Convert.ToInt32(Console.ReadLine());

                        switch (actionChoice)
                        {
                            case 1:
                                Console.Write("Enter quantity to sell: ");
                                int quantityToSell = Convert.ToInt32(Console.ReadLine());
                                item.SellItem(quantityToSell);
                                item.PrintDetails();
                                break;
                            case 2:
                                Console.Write("Enter quantity to restock: ");
                                int quantityToRestock = Convert.ToInt32(Console.ReadLine());
                                item.RestockItem(quantityToRestock);
                                item.PrintDetails();
                                break;
                            case 3:
                                Console.Write("Enter new price: ");
                                double newPrice = Convert.ToDouble(Console.ReadLine());
                                item.UpdatePrice(newPrice);
                                item.PrintDetails();
                                break;
                            case 4:
                                if (item.IsInStock())
                                {
                                    Console.WriteLine("Item is in stock.");
                                }
                                else
                                {
                                    Console.WriteLine("Item is out of stock.");
                                }
                                break;
                            case 5:
                                Console.WriteLine("Returning to main menu...");
                                goto MainMenu;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }
                    }
                MainMenu:
                    continue;
                }
            }
      }
    }