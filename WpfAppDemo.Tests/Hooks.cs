using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace WpfAppDemo.Tests
{
    [Binding]
    public class Hooks
    {
        private static TracerProvider tracerProvider;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource("SpecFlowTest")
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("specflow-tests"))
                //.Add() // You can switch to OTLP exporter
                .AddOtlpExporter(opt =>
                {
                    opt.Endpoint = new Uri("http://localhost:4317");
                })
                .Build();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            tracerProvider?.Dispose();
        }
    }
}
