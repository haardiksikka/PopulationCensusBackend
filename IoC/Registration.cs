using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Unity;

namespace IoC
{
    public static class Registration
    {
        public static IUnityContainer Register()
        {

            UnityContainer container = new UnityContainer();
            container.RegisterType<IUserBLl, UserBLl>();
            container.Resolve()
            //var resolver = new UnityResolver()

            return container;
        }
    }
}
