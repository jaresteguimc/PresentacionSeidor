//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Presentacion.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IGes_OperativaService")]
    public interface IGes_OperativaService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGes_OperativaService/FW_Una_consulta_solicitud_clientes", ReplyAction="http://tempuri.org/IGes_OperativaService/FW_Una_consulta_solicitud_clientesRespon" +
            "se")]
        string FW_Una_consulta_solicitud_clientes(string @__a);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGes_OperativaService/FW_Una_consulta_solicitud_clientes", ReplyAction="http://tempuri.org/IGes_OperativaService/FW_Una_consulta_solicitud_clientesRespon" +
            "se")]
        System.Threading.Tasks.Task<string> FW_Una_consulta_solicitud_clientesAsync(string @__a);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGes_OperativaService/FW_Una_Add_Clientes", ReplyAction="http://tempuri.org/IGes_OperativaService/FW_Una_Add_ClientesResponse")]
        string FW_Una_Add_Clientes(string @__a);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGes_OperativaService/FW_Una_Add_Clientes", ReplyAction="http://tempuri.org/IGes_OperativaService/FW_Una_Add_ClientesResponse")]
        System.Threading.Tasks.Task<string> FW_Una_Add_ClientesAsync(string @__a);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGes_OperativaService/FW_Una_Add_Bono", ReplyAction="http://tempuri.org/IGes_OperativaService/FW_Una_Add_BonoResponse")]
        string FW_Una_Add_Bono(string @__a);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGes_OperativaService/FW_Una_Add_Bono", ReplyAction="http://tempuri.org/IGes_OperativaService/FW_Una_Add_BonoResponse")]
        System.Threading.Tasks.Task<string> FW_Una_Add_BonoAsync(string @__a);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGes_OperativaServiceChannel : Presentacion.ServiceReference.IGes_OperativaService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Ges_OperativaServiceClient : System.ServiceModel.ClientBase<Presentacion.ServiceReference.IGes_OperativaService>, Presentacion.ServiceReference.IGes_OperativaService {
        
        public Ges_OperativaServiceClient() {
        }
        
        public Ges_OperativaServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Ges_OperativaServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Ges_OperativaServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Ges_OperativaServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string FW_Una_consulta_solicitud_clientes(string @__a) {
            return base.Channel.FW_Una_consulta_solicitud_clientes(@__a);
        }
        
        public System.Threading.Tasks.Task<string> FW_Una_consulta_solicitud_clientesAsync(string @__a) {
            return base.Channel.FW_Una_consulta_solicitud_clientesAsync(@__a);
        }
        
        public string FW_Una_Add_Clientes(string @__a) {
            return base.Channel.FW_Una_Add_Clientes(@__a);
        }
        
        public System.Threading.Tasks.Task<string> FW_Una_Add_ClientesAsync(string @__a) {
            return base.Channel.FW_Una_Add_ClientesAsync(@__a);
        }
        
        public string FW_Una_Add_Bono(string @__a) {
            return base.Channel.FW_Una_Add_Bono(@__a);
        }
        
        public System.Threading.Tasks.Task<string> FW_Una_Add_BonoAsync(string @__a) {
            return base.Channel.FW_Una_Add_BonoAsync(@__a);
        }
    }
}
