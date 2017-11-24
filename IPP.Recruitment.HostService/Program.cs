using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace IPP.Recruitment.HostService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Create a URI to serve as the base address
                Uri httpUrl = new Uri("http://localhost:8090/PaymentService");
                //Create ServiceHost
                ServiceHost host = new ServiceHost(typeof(IPP.Recruitment.Domain.PaymentService), httpUrl);
                //Add a service endpoint
                host.AddServiceEndpoint(typeof(IPP.Recruitment.Domain.IPaymentService)
                , new WSHttpBinding(), "");
                //Enable metadata exchange
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                host.Description.Behaviors.Add(smb);
                //Start the Service
                host.Open();

                Console.WriteLine("Payment Service is host at " + DateTime.Now.ToString());
                Console.WriteLine("Host is running... Press <Enter> key to stop");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed in hosting Payment Service");
                Console.WriteLine(ex.Message);
                Console.WriteLine("") ;
                Console.WriteLine("Run the following command as Administrator to grant permission for Payment Service URL:") ;
                Console.WriteLine("----------------------------------") ;             
                Console.WriteLine("netsh http add urlacl url=http://+:8090/PaymentService user={current user}") ;
                Console.WriteLine("----------------------------------") ;             
                Console.WriteLine("Press <Enter> key to exit");
                Console.ReadLine();

            }
        }
    }
}
