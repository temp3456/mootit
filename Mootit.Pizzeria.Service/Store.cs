using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Mootit.Pizzeria.Core.DAL.Entities;
using Mootit.Pizzeria.Core.Contexts;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;

namespace Mootit.Pizzeria.Service
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single)]
    public class Store : Entities.IStore, IServiceBehavior, IErrorHandler, IChannelInitializer
    {
        #region Members
        private PizzeriaContext context;
        #endregion

        #region Constructors
        public Store()
        {
            this.context = new PizzeriaContext();
        }
        #endregion

        #region IStore
        public void Sync()
        {
            this.Dispose();

            this.context = new PizzeriaContext();
        }

        public Entities.Order GetOrder(long id)
        {
            Entities.Order found = null;
            List<Entities.Pizza> pizzas = null;
            List<Entities.Beverage> beverages = null;
            List<Entities.Dessert> desserts = null;
            double pizzaCost, beverageCost, dessertCost;

            try
            {
                var item = context.Orders.FirstOrDefault(order => order.Id == id);

                if (item != null)
                {
                    pizzaCost = this.SliptSlicesToMeasureCost(item.Order_Pizzas.OrderBy(i => i.Slice).ToList());
                    pizzas = new List<Entities.Pizza>();
                    foreach (Order_Pizzas order_Pizzas in item.Order_Pizzas.OrderBy(i => i.Slice))
                        pizzas.Add(new Entities.Pizza()
                        {
                             Id = order_Pizzas.Id_Pizza,
                             Flavor = order_Pizzas.Pizza.Flavor,
                             Description = order_Pizzas.Pizza.Description,
                             Price = order_Pizzas.Pizza.Price,
                             Slice = order_Pizzas.Slice
                        });

                    beverageCost = 0;
                    beverages = new List<Entities.Beverage>();
                    foreach (Order_Beverages order_Beverages in item.Order_Beverages)
                    {
                        beverages.Add(new Entities.Beverage()
                        {
                            Id = order_Beverages.Beverage.Id,
                            Name = order_Beverages.Beverage.Name,
                            Price = order_Beverages.Beverage.Price
                        });
                        beverageCost += order_Beverages.Beverage.Price;
                    }

                    dessertCost = 0;
                    desserts = new List<Entities.Dessert>();
                    foreach (Order_Desserts order_Desserts in item.Order_Desserts)
                    {
                        desserts.Add(new Entities.Dessert()
                        {
                            Id = order_Desserts.Desserts.Id,
                            Name = order_Desserts.Desserts.Name,
                            Price = order_Desserts.Desserts.Price
                        });
                        dessertCost += order_Desserts.Desserts.Price;
                    }

                    found = new Entities.Order()
                    {
                        Id = item.Id,
                        Customer = item.Id,
                        Created = item.Created,
                        Delivered = item.Delivered,
                        Pizzas = pizzas.ToArray(),
                        Beverages = beverages.ToArray(),
                        Desserts = desserts.ToArray(),
                        PizzaCost = pizzaCost,
                        BeverageCost = beverageCost,
                        DessertCost = dessertCost
                    };
                }

                return found;
            }
            finally
            {
                found = null;
                pizzas = null;
                beverages = null;
                desserts = null;
            }
        }

        public Entities.Pizza GetPizza(long id)
        {
            Entities.Pizza found = null;

            try
            {
                var item = context.Pizzas.FirstOrDefault(order => order.Id == id);

                if (item != null)
                {
                    found = new Entities.Pizza()
                    {
                        Id = item.Id,
                        Description = item.Description,
                        Flavor = item.Flavor,
                        Price = item.Price,
                        Slice = 0
                    };
                }

                return found;
            }
            finally
            {
                found = null;
            }
        }

        public Entities.Dessert GetDessert(long id)
        {
            Entities.Dessert found = null;

            try
            {
                var item = context.Desserts.FirstOrDefault(order => order.Id == id);

                if (item != null)
                {
                    found = new Entities.Dessert()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price
                    };
                }

                return found;
            }
            finally
            {
                found = null;
            }
        }

        public Entities.Beverage GetBeverage(long id)
        {
            Entities.Beverage found = null;

            try
            {
                var item = context.Beverages.FirstOrDefault(order => order.Id == id);

                if (item != null)
                {
                    found = new Entities.Beverage()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price
                    };
                }

                return found;
            }
            finally
            {
                found = null;
            }
        }

        public Entities.Order[] ListOrders()
        {
            List<Entities.Order> found = null;
            List<Entities.Pizza> pizzas = null;
            List<Entities.Beverage> beverages = null;
            List<Entities.Dessert> desserts = null;

            try
            {
                found = new List<Entities.Order>();
                foreach (Order item in context.Orders.ToList())
                    if (item != null)
                    {
                        double pizzaCost, beverageCost, dessertCost;

                        pizzaCost = this.SliptSlicesToMeasureCost(item.Order_Pizzas.OrderBy(i => i.Slice).ToList());
                        pizzas = new List<Entities.Pizza>();
                        foreach (Order_Pizzas order_Pizzas in item.Order_Pizzas)
                            pizzas.Add(new Entities.Pizza()
                            {
                                Id = order_Pizzas.Pizza.Id,
                                Description = order_Pizzas.Pizza.Description,
                                Flavor = order_Pizzas.Pizza.Flavor,
                                Price = order_Pizzas.Pizza.Price,
                                Slice = order_Pizzas.Slice
                            });

                        beverageCost = 0;
                        beverages = new List<Entities.Beverage>();
                        foreach (Order_Beverages order_Beverages in item.Order_Beverages)
                        {
                            beverages.Add(new Entities.Beverage()
                            {
                                Id = order_Beverages.Beverage.Id,
                                Name = order_Beverages.Beverage.Name,
                                Price = order_Beverages.Beverage.Price
                            });
                            beverageCost += order_Beverages.Beverage.Price;
                        }

                        dessertCost = 0;
                        desserts = new List<Entities.Dessert>();
                        foreach (Order_Desserts order_Desserts in item.Order_Desserts)
                        {
                            desserts.Add(new Entities.Dessert()
                            {
                                Id = order_Desserts.Desserts.Id,
                                Name = order_Desserts.Desserts.Name,
                                Price = order_Desserts.Desserts.Price
                            });
                            dessertCost += order_Desserts.Desserts.Price;
                        }

                        found.Add(new Entities.Order()
                        {
                            Id = item.Id,
                            Customer = item.Id,
                            Created = item.Created,
                            Delivered = item.Delivered,
                            Pizzas = pizzas.ToArray(),
                            Beverages = beverages.ToArray(),
                            Desserts = desserts.ToArray(),
                            PizzaCost = pizzaCost,
                            BeverageCost = beverageCost,
                            DessertCost = dessertCost
                        });
                    }

                return found.ToArray();
            }
            finally
            {
                found = null;
                pizzas = null;
                beverages = null;
                desserts = null;
            }
        }

        public Entities.Order[] ListCustomerOrders(long id)
        {
            List<Entities.Order> found = null;
            List<Entities.Pizza> pizzas = null;
            List<Entities.Beverage> beverages = null;
            List<Entities.Dessert> desserts = null;

            try
            {
                found = new List<Entities.Order>();
                foreach (Order item in context.Orders.ToList().Where(i => i.Customer == id))
                    if (item != null)
                    {
                        double pizzaCost, beverageCost, dessertCost;

                        pizzaCost = this.SliptSlicesToMeasureCost(item.Order_Pizzas.OrderBy(i => i.Slice).ToList());
                        pizzas = new List<Entities.Pizza>();
                        foreach (Order_Pizzas order_Pizzas in item.Order_Pizzas)
                            pizzas.Add(new Entities.Pizza()
                            {
                                Id = order_Pizzas.Pizza.Id,
                                Description = order_Pizzas.Pizza.Description,
                                Flavor = order_Pizzas.Pizza.Flavor,
                                Price = order_Pizzas.Pizza.Price,
                                Slice = order_Pizzas.Slice
                            });

                        beverageCost = 0;
                        beverages = new List<Entities.Beverage>();
                        foreach (Order_Beverages order_Beverages in item.Order_Beverages)
                        {
                            beverages.Add(new Entities.Beverage()
                            {
                                Id = order_Beverages.Beverage.Id,
                                Name = order_Beverages.Beverage.Name,
                                Price = order_Beverages.Beverage.Price
                            });
                            beverageCost += order_Beverages.Beverage.Price;
                        }

                        dessertCost = 0;
                        desserts = new List<Entities.Dessert>();
                        foreach (Order_Desserts order_Desserts in item.Order_Desserts)
                        {
                            desserts.Add(new Entities.Dessert()
                            {
                                Id = order_Desserts.Desserts.Id,
                                Name = order_Desserts.Desserts.Name,
                                Price = order_Desserts.Desserts.Price
                            });
                            dessertCost += order_Desserts.Desserts.Price;
                        }

                        found.Add(new Entities.Order()
                        {
                            Id = item.Id,
                            Customer = item.Id,
                            Created = item.Created,
                            Delivered = item.Delivered,
                            Pizzas = pizzas.ToArray(),
                            Beverages = beverages.ToArray(),
                            Desserts = desserts.ToArray(),
                            PizzaCost = pizzaCost,
                            BeverageCost = beverageCost,
                            DessertCost = dessertCost
                        });
                    }

                return found.ToArray();
            }
            finally
            {
                found = null;
                pizzas = null;
                beverages = null;
                desserts = null;
            }
        }

        public Entities.Pizza[] ListPizzas()
        {
            List<Entities.Pizza> found = null;

            try
            {
                found = new List<Entities.Pizza>();
                foreach (Pizza item in context.Pizzas.ToList())
                    if (item != null)
                    {
                        found.Add(new Entities.Pizza()
                        {
                            Id = item.Id,
                            Description = item.Description,
                            Flavor = item.Flavor,
                            Price = item.Price
                        });
                    }

                return found.ToArray();
            }
            finally
            {
                found = null;
            }
        }

        public Entities.Dessert[] ListDesserts()
        {
            List<Entities.Dessert> found = null;

            try
            {
                found = new List<Entities.Dessert>();
                foreach (Dessert item in context.Desserts.ToList())
                    if (item != null)
                    {
                        found.Add(new Entities.Dessert()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Price = item.Price
                        });
                    }

                return found.ToArray();
            }
            finally
            {
                found = null;
            }
        }

        public Entities.Beverage[] ListBeverages()
        {
            List<Entities.Beverage> found = null;

            try
            {
                found = new List<Entities.Beverage>();
                foreach (Beverage item in context.Beverages.ToList())
                    if (item != null)
                    {
                        found.Add(new Entities.Beverage()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Price = item.Price
                        });
                    }

                return found.ToArray();
            }
            finally
            {
                found = null;
            }
        }

        public Entities.Order InsertOrder(Entities.Order order)
        {
            Order added = null;

            try
            {
                added = new Order()
                {
                    Customer = order.Customer
                };

                if (order.Pizzas != null)
                    foreach (Entities.Pizza pizza in order.Pizzas)
                        added.Order_Pizzas.Add(new Order_Pizzas()
                        {
                            Id_Pizza = pizza.Id,
                            Slice = pizza.Slice
                        });

                if (order.Beverages != null)
                    foreach (Entities.Beverage beverage in order.Beverages)
                        added.Order_Beverages.Add(new Order_Beverages()
                        {
                            Id_Beverage = beverage.Id
                        });

                if (order.Desserts != null)
                    foreach (Entities.Dessert dessert in order.Desserts)
                        added.Order_Desserts.Add(new Order_Desserts()
                        {
                            Id_Dessert = dessert.Id
                        });


                added = context.Orders.Add(added);

                context.SaveChanges();

                return GetOrder(added.Id);
            }
            finally
            {
                added = null;
            }
        }

        public void Dispose()
        {
            if (this.context != null)
                this.context.Dispose();
        }
        #endregion

        #region Service Interfaces
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher channelDispatchers in serviceHostBase.ChannelDispatchers)
            {
                channelDispatchers.ChannelInitializers.Add(this);
                channelDispatchers.ErrorHandlers.Add(this);
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            ((ServiceBehaviorAttribute)serviceDescription.Behaviors[typeof(ServiceBehaviorAttribute)]).ConcurrencyMode = ConcurrencyMode.Multiple;
            ((ServiceBehaviorAttribute)serviceDescription.Behaviors[typeof(ServiceBehaviorAttribute)]).InstanceContextMode = InstanceContextMode.Single;
            ((ServiceBehaviorAttribute)serviceDescription.Behaviors[typeof(ServiceBehaviorAttribute)]).IgnoreExtensionDataObject = true;
            ((ServiceBehaviorAttribute)serviceDescription.Behaviors[typeof(ServiceBehaviorAttribute)]).IncludeExceptionDetailInFaults = false;
        }

        public bool HandleError(Exception error)
        {
            return true;
        }

        public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
            FaultException exception = error as FaultException;

            if (exception == null)
                exception = new FaultException(error.Message);

            fault = Message.CreateMessage(version, exception.CreateMessageFault(), exception.Action);
        }

        public void Initialize(IClientChannel channel)
        {
        }
        #endregion

        private double SliptSlicesToMeasureCost(List<Order_Pizzas> pizzasOrdered)
        {
            double pizzaCost = 0;

            foreach (Order_Pizzas order_Pizzas in pizzasOrdered.Where(i => i.Slice == 1))
                pizzaCost += order_Pizzas.Pizza.Price;

            pizzaCost += this.GetCostFromPizzaCollection(pizzasOrdered, 2);
            pizzaCost += this.GetCostFromPizzaCollection(pizzasOrdered, 3);
            pizzaCost += this.GetCostFromPizzaCollection(pizzasOrdered, 4);

            return pizzaCost;
        }

        private double GetCostFromPizzaCollection(List<Order_Pizzas> pizzasNormal, int slices)
        {
            double pizzaCost = 0;
            double temp= 0;

            List<Order_Pizzas> pizzas  = pizzasNormal.Where(i => i.Slice == slices).ToList();
            for (int i = 0; i < pizzas.Count; i++)
            {
                if (temp < pizzas[i].Pizza.Price)
                    temp = pizzas[i].Pizza.Price;

                if ((i + 1) % slices == 0)
                {
                    pizzaCost += temp;
                    temp = 0;
                }
            }

            return pizzaCost;
        }
    }
}
