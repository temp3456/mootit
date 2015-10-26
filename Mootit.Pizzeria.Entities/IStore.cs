using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Mootit.Pizzeria.Entities
{
    [ServiceContract]
    public interface IStore : IDisposable
    {
        [OperationContract]
        void Sync();
        [OperationContract]
        Order GetOrder(long id);
        [OperationContract]
        Pizza GetPizza(long id);
        [OperationContract]
        Dessert GetDessert(long id);
        [OperationContract]
        Beverage GetBeverage(long id);
        [OperationContract]
        Order[] ListOrders();
        [OperationContract]
        Order[] ListCustomerOrders(long id);
        [OperationContract]
        Pizza[] ListPizzas();
        [OperationContract]
        Dessert[] ListDesserts();
        [OperationContract]
        Beverage[] ListBeverages();
        [OperationContract]
        Order InsertOrder(Order order);
    }
}
