using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System.Threading.Tasks;

public class MyIoc : SimpleIoc, IServiceLocator
{

    public static MyIoc Instance { get; private set; } = new MyIoc();
}
