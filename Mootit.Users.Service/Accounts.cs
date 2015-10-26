using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using Mootit.Users.Core.DAL.Contexts;
using Mootit.Users.Core.DAL.Entities;

namespace Mootit.Users.Service
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single)]
    public class Accounts : Entities.IAccounts, IServiceBehavior, IErrorHandler, IChannelInitializer
    {
        #region Members
        private UsersContext context;
        #endregion

        #region Constructors
        public Accounts()
        {
            this.context = new UsersContext();
        }
        #endregion

        #region IAccounts
        public void Sync()
        {
            this.Dispose();
            this.context = new UsersContext();
        }

        public Entities.Customer GetCustomer(long id)
        {
            Entities.Customer found = null;


            try
            {
                var item = context.Customers.FirstOrDefault(i => i.Id_User == id);

                if (item != null)
                {
                    found = new Entities.Customer()
                    {
                        User = new Entities.User()
                        {
                            Id = item.Id_User,
                            Username = item.Users.Username
                        },
                        Address = item.Address,
                        Fullname = item.Fullname,
                        PhoneNumer = item.PhoneNumer
                    };
                }

                return found;
            }
            finally
            {
                found = null;
            }
        }

        public Entities.Customer GetCustomerByPhone(int phoneNumer)
        {
            Entities.Customer found = null;


            try
            {
                var item = context.Customers.FirstOrDefault(i => i.PhoneNumer == phoneNumer);

                if (item != null)
                {
                    found = new Entities.Customer()
                    {
                        User = new Entities.User()
                        {
                            Id = item.Id_User,
                            Username = item.Users.Username
                        },
                        Address = item.Address,
                        Fullname = item.Fullname,
                        PhoneNumer = item.PhoneNumer
                    };
                }

                return found;
            }
            finally
            {
                found = null;
            }
        }

        public Entities.Customer InsertCustomer(Entities.Customer customer)
        {
            Customer added = null;

            try
            {
                added = new Customer()
                {
                    Users = new User()
                    {
                        Username = customer.User.Username
                    },
                    Address = customer.Address,
                    Fullname = customer.Fullname,
                    PhoneNumer = customer.PhoneNumer
                };

                added = context.Customers.Add(added);

                context.SaveChanges();

                return GetCustomer(added.Id_User);
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
    }
}
