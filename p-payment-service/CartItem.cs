﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace p_payment_service
{

    public class CartItem
    {
        private List<Item> _item;

        public event EventHandler<ItemChangedEventArgs> ItemChanged;
        public event EventHandler<ItemAddedEventArgs> ItemAdded;
        public event EventHandler ItemsCleared; // Custom event for clearing items

        public decimal total { get; set; }
        public string paymentMethod { get; set; }
        public string serviceMethod { get; set; }
        public int orderNo { get; set; }
       

        public List<Item> Item
        {
            get { return _item; }
            set
            {
                _item = value;
                OnItemChanged(new ItemChangedEventArgs(value));
            }
        }

        public CartItem()
        {
            _item = new List<Item>(); // Initialize the _item list in the constructor
            total = 0;
            orderNo = Properties.Settings.Default.OrderNo;
        }

        public void AddItem(Item newItem)
        {
            _item.Add(newItem);
            OnItemAdded(new ItemAddedEventArgs(newItem));
        }

        public decimal CalculateTotal()
        {
            total = 0;
            foreach (Item item in _item)
            {
                total += item.Price * item.Quantity;
                if (item.AdditionalItem != null)
                {
                    foreach (var option in item.AdditionalItem)
                    {
                        foreach(var additionalOption in option.additionalCartOptions)
                        total += additionalOption.Price;
                    }
                }
            }
            return total;
        }

        protected virtual void OnItemChanged(ItemChangedEventArgs e)
        {
            ItemChanged?.Invoke(this, e);
        }

        protected virtual void OnItemAdded(ItemAddedEventArgs e)
        {
            ItemAdded?.Invoke(this, e);
        }

        public void ClearItems()
        {
            _item.Clear();
            OnItemsCleared(); // Raise the ItemsCleared event
        }
        protected virtual void OnItemsCleared()
        {
            ItemsCleared?.Invoke(this, EventArgs.Empty);
        }
    }

    public class ItemChangedEventArgs : EventArgs
    {
        public List<Item> ChangedItems { get; }

        public ItemChangedEventArgs(List<Item> changedItems)
        {
            ChangedItems = changedItems;
        }
    }

    public class ItemAddedEventArgs : EventArgs
    {
        public Item AddedItem { get; }

        public ItemAddedEventArgs(Item addedItem)
        {
            AddedItem = addedItem;
        }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Image Picture { get; set; }
        public List<AdditionalCartItem> AdditionalItem { get; set; }
        public Item()
        {
            AdditionalItem = new List<AdditionalCartItem>(); // Initialize the AdditionalItem list in the constructor
        }
    }

    public class AdditionalCartItem
    {
        public string Name { get; set; }
        public List<AdditionalCartOption> additionalCartOptions;

        public AdditionalCartItem()
        {
            additionalCartOptions = new List<AdditionalCartOption>();

        }
    }

    public class AdditionalCartOption
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

}
