using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class Container
    {
        private readonly Dictionary<Type, Type> types = new Dictionary<Type, Type>();

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            types[typeof(TInterface)] = typeof(TImplementation);

        }

        private object Create(Type type, object[] parameters)
        {
            var cType = types[type];
            var constructor = cType.GetConstructors()[0];
       
            return constructor.Invoke(parameters);
        }

        public TInterface Create<TInterface>(object[] parameters)
        {
            return (TInterface)Create(typeof(TInterface), parameters);
        }

    }
}
