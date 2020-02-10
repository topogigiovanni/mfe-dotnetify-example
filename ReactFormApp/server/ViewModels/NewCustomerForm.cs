﻿using DotNetify;
using DotNetify.Elements;
using DotNetify.Security;
using System.Linq;
using System.Reactive.Linq;

namespace ReactFormApp
{
   [Authorize]
   public class NewCustomerForm : BaseVM
   {
      private readonly ICustomerRepository _customerRepository;

      public ReactiveProperty<Customer> NewCustomer { get; } = new ReactiveProperty<Customer>();

      public NewCustomerForm(ICustomerRepository customerRepository)
      {
         _customerRepository = customerRepository;

         AddInternalProperty<CustomerFormData>("Submit")
            .SubscribedBy(NewCustomer, formData => Save(formData));
      }

      public override void Dispose()
      {
         base.Dispose();
      }

      public Customer Save(CustomerFormData formData)
      {
         return _customerRepository.Add(formData);
      }
   }
}