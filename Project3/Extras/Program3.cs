﻿using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;

using TestableCodeDemos.Module3.Shared;
using TestableCodeDemos.Project3.After;

namespace TestableCodeDemos.Module3.Extras
{
    public class Program3
    {
        static void Main(string[] args)
        {
            var container = new StandardKernel();

            container.Bind<IDatabase>()
                .To<Database>();

            container.Bind<IInvoiceWriter>()
                .To<InvoiceWriter>();

            container.Bind<IPrinter>()
                .To<Printer>();

            container.Bind<IPageLayout>()
                .To<PageLayout>();

            var invoiceId = int.Parse(args[0]);

            var command = container.Get<PrintInvoiceCommand>();

            command.Execute(invoiceId);
        }
    }
}
