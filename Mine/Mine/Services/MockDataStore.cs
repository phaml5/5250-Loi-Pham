﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Aries Fire", Description="Passionate, Creative, Impulsive, Energetic", Value=9 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Libra Air", Description="Intelligent, Social, Indecisive, Communicative", Value=5 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Capricorn Earth", Description="Practical, Methodical, Stubborn, Realistic", Value=4 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Scorpio Water", Description="Emotional, Perceptive, Hypersensitive, Compassionate", Value=2 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Virgo Earth", Description="Adaptable, Flexible, Communicative, Versatile", Value=6 }
            };
        }

        public async Task<bool> CreateAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemModel> ReadAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}