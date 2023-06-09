﻿using Toys.Domain.Models;

namespace TestMvvmApp.Stores
{
    public class SelectedToyStore
    {
        private readonly ToysStore _toysStore;

        public SelectedToyStore(ToysStore toysStore)
        {
            _toysStore = toysStore;
            _toysStore.ToyUpdated += ToysStore_ToyUpdated;
            _toysStore.ToyDeleted += ToysStore_ToyDeleted;
        }

        private void ToysStore_ToyDeleted(Guid id)
        {
            SelectedToy = null; //TODO: ? Select current item when items menu is populated
        }

        private void ToysStore_ToyUpdated(Toy updatedToy)
        {
            if(updatedToy.Id == SelectedToy?.Id)
            {
                SelectedToy = updatedToy;
            }
        }

        private Toy _selectedToy;

        public Toy SelectedToy
        {
            get 
            { 
                return _selectedToy; 
            } 
            set 
            { 
                _selectedToy = value;
                SelectedToyChanged?.Invoke();
            }
        }

        public event Action SelectedToyChanged;
    }
}
