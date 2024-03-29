using BlazorAppRefit.Model;

using Microsoft.AspNetCore.Components;

using System;

using static MudBlazor.CategoryTypes;

namespace BlazorAppRefit.Pages
{
    public partial class Customers
    {
        List<Customer> customers = new List<Customer>();

        [Inject]
        public ICustomerManager customerManager { get; set; }

        private bool _readOnly;
        private bool _isCellEditMode;
        private List<string> _events = new();
        private bool _editTriggerRowClick;

        protected override async Task OnInitializedAsync()
        {
            customers = await customerManager.GetCustomers();

            customers ??= new List<Customer>();
        }

        private async Task AddCustomer(Customer customer)
        {
            await customerManager.New(new Customer(customers.Count + 1, customer.Name));

            customers = await customerManager.GetCustomers();
        }

        private async Task UpdateCustomer(Customer customer )
        {
            await customerManager.Update(customer.Id, customer);

            customers = await customerManager.GetCustomers();
        }
        private async Task DeleteCustomer(Customer customer)
        {
            await customerManager.Delete(customer.Id);

            customers = await customerManager.GetCustomers();
        }

        async Task StartedEditingItem(Customer item)
        {
            _events.Insert(0, $"Event = StartedEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");

            await UpdateCustomer(item);
        }

        void CanceledEditingItem(Customer item)
        {
            _events.Insert(0, $"Event = CanceledEditingItem, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
        }

        void CommittedItemChanges(Customer item)
        {
            _events.Insert(0, $"Event = CommittedItemChanges, Data = {System.Text.Json.JsonSerializer.Serialize(item)}");
        }
    }
}
