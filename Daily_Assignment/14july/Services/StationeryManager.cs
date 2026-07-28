using System;
using System.Collections.Generic;
using System.Linq;

namespace StationeryStoreManagement
{
    public class StationeryManager
    {
        private List<StationeryItem> items;
        private BillingService billingService;

        public StationeryManager()
        {
            items = new List<StationeryItem>();
            billingService = new BillingService();
        }

        public void AddItem()
        {
            Console.Clear();
            Console.WriteLine("----- Add Stationery Item -----");

            Console.WriteLine("Select Item Type");
            Console.WriteLine("1. Notebook");
            Console.WriteLine("2. Pen");
            Console.WriteLine("3. Marker");
            Console.Write("Enter Choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            StationeryItem item;

            switch (choice)
            {
                case 1:
                    Notebook notebook = new Notebook();

                    Console.Write("Enter Pages: ");
                    notebook.Pages = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Paper Type: ");
                    notebook.PaperType = Console.ReadLine();

                    item = notebook;
                    break;

                case 2:
                    Pen pen = new Pen();

                    Console.Write("Enter Ink Color: ");
                    pen.InkColor = Console.ReadLine();

                    Console.Write("Enter Pen Type: ");
                    pen.PenType = Console.ReadLine();

                    item = pen;
                    break;

                case 3:
                    Marker marker = new Marker();

                    Console.Write("Permanent (true/false): ");
                    marker.Permanent = Convert.ToBoolean(Console.ReadLine());

                    item = marker;
                    break;

                default:
                    Console.WriteLine("Invalid Item Type.");
                    return;
            }

            Console.Write("Enter Item Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (items.Any(i => i.ItemId == id))
                throw new DuplicateItemException();

            item.ItemId = id;

            Console.Write("Enter Item Name: ");
            item.ItemName = Console.ReadLine();

            Console.Write("Enter Category: ");
            item.Category = Console.ReadLine();

            Console.Write("Enter Brand: ");
            item.Brand = Console.ReadLine();

            Console.Write("Enter Price: ");
            item.Price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Quantity: ");
            item.Quantity = Convert.ToInt32(Console.ReadLine());

            items.Add(item);

            Console.WriteLine();
            Console.WriteLine("Item Added Successfully.");
        }

        public void DisplayAllItems()
        {
            Console.Clear();

            if (items.Count == 0)
            {
                Console.WriteLine("No Items Available.");
                return;
            }

            Console.WriteLine("----------- Item List -----------");

            foreach (StationeryItem item in items)
            {
                item.DisplayDetails();
            }
        }
        public void SearchItem()
{
    Console.Clear();
    Console.WriteLine("1. Search by Item Id");
    Console.WriteLine("2. Search by Item Name");
    Console.Write("Enter Choice: ");

    int choice = Convert.ToInt32(Console.ReadLine());

    StationeryItem item = null;

    switch (choice)
    {
        case 1:
            Console.Write("Enter Item Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            item = items.FirstOrDefault(i => i.ItemId == id);
            break;

        case 2:
            Console.Write("Enter Item Name: ");
            string name = Console.ReadLine();

            item = items.FirstOrDefault(i =>
                i.ItemName.Equals(name, StringComparison.OrdinalIgnoreCase));
            break;

        default:
            Console.WriteLine("Invalid Choice.");
            return;
    }

    if (item == null)
        throw new ItemNotFoundException();

    Console.WriteLine();
    item.DisplayDetails();
}

public void UpdateItem()
{
    Console.Clear();

    Console.Write("Enter Item Id: ");
    int id = Convert.ToInt32(Console.ReadLine());

    StationeryItem item = items.FirstOrDefault(i => i.ItemId == id);

    if (item == null)
        throw new ItemNotFoundException();

    Console.Write("Enter New Brand: ");
    item.Brand = Console.ReadLine();

    Console.Write("Enter New Price: ");
    item.Price = Convert.ToDouble(Console.ReadLine());

    Console.Write("Enter New Quantity: ");
    item.Quantity = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine();
    Console.WriteLine("Item Updated Successfully.");
}
        public void DeleteItem()
        {
            Console.Clear();

            Console.Write("Enter Item Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            StationeryItem item = items.FirstOrDefault(i => i.ItemId == id);

            if (item == null)
                throw new ItemNotFoundException();

            Console.Write("Delete this item? (Y/N): ");
            string choice = Console.ReadLine();

            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                items.Remove(item);
                Console.WriteLine("Item Deleted Successfully.");
            }
            else
            {
                Console.WriteLine("Delete Operation Cancelled.");
            }
        }

        public void PurchaseItem()
        {
            Console.Clear();

            Console.Write("Enter Item Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            StationeryItem item = items.FirstOrDefault(i => i.ItemId == id);

            if (item == null)
                throw new ItemNotFoundException();

            Console.Write("Enter Quantity: ");
            int purchaseQuantity = Convert.ToInt32(Console.ReadLine());

            if (purchaseQuantity > item.Quantity)
                throw new InsufficientStockException();

            item.Quantity -= purchaseQuantity;

            Console.WriteLine();
            billingService.GenerateBill(item, purchaseQuantity);

            Console.WriteLine();
            Console.WriteLine("Purchase Successful.");
            Console.WriteLine("Remaining Stock : " + item.Quantity);
        }
        public void ViewLowStockItems()
        {
            Console.Clear();

            var lowStockItems = items.Where(i => i.Quantity < 5).ToList();

            if (lowStockItems.Count == 0)
            {
                Console.WriteLine("No Low Stock Items.");
                return;
            }

            Console.WriteLine("--------- Low Stock Items ---------");

            foreach (StationeryItem item in lowStockItems)
            {
                item.DisplayDetails();
            }
        }

        public void SortItems()
        {
            Console.Clear();

            Console.WriteLine("Sort By");
            Console.WriteLine("1. Price (Ascending)");
            Console.WriteLine("2. Name (Ascending)");
            Console.WriteLine("3. Quantity (Descending)");
            Console.Write("Enter Choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    items = items.OrderBy(i => i.Price).ToList();
                    break;

                case 2:
                    items = items.OrderBy(i => i.ItemName).ToList();
                    break;

                case 3:
                    items = items.OrderByDescending(i => i.Quantity).ToList();
                    break;

                default:
                    Console.WriteLine("Invalid Choice.");
                    return;
            }

            Console.WriteLine();
            Console.WriteLine("Items Sorted Successfully.");
            Console.WriteLine();

            foreach (StationeryItem item in items)
            {
                item.DisplayDetails();
            }
        }
    }
}