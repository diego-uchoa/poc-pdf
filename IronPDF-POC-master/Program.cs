using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace resultado_pdf {
    public class Program {
        public static void Main(string[] args) {
            IronPdf.License.LicenseKey = "IRONPDF.FERNADOFONTESSANTOS.15684-B1AE1CD7EC-JTNSK74BYF4JP-6Y53Z7EMKH7K-6GCJYXTSL7AX-QCFNRSGY2DD5-JFGCXTLC6CMS-RZPX27-TU7UDUWC53OIUA-DEPLOYMENT.TRIAL-IAJJAX.TRIAL.EXPIRES.16.FEB.2023";
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
