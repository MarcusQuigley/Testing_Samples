﻿using System;
using System.Collections.Generic;
using System.Linq;

using TestableCodeDemos.Module3.Shared;
using TestableCodeDemos.Project3.After;

namespace TestableCodeDemos.Module3.Extras
{
    public class PrintInvoiceCommandFactory
    {
        public PrintInvoiceCommand Create()
        {
            var command = new PrintInvoiceCommand(
                new Database(),
                new InvoiceWriter(
                    new Printer(),
                    new PageLayout()));

            return command;
        }
    }
}