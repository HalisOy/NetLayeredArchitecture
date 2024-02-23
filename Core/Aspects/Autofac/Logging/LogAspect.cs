using Castle.Core.Logging;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Logging;

public class LogAspect:MethodInterception
{

    protected override void OnBefore(IInvocation invocation)
    {
        Debug.WriteLine("test");
    }
}
